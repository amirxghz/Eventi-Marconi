using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsLab_Eventi_Ghouzlani
{
    public partial class FrmIndirizzi : Form
    {
        private List<ClsIndirizzo> _indirizzi = new List<ClsIndirizzo>();
        private List<ClsClasse> _tutteLeClassi = new List<ClsClasse>();
        private List<ClsUtente> _tuttiGliStudenti = new List<ClsUtente>();
        private ClsIndirizzo _indirizzoSelezionato = null;
        private bool _modalitaModifica = false;
        private bool _modalitaVisualizza = false;

        public FrmIndirizzi()
        {
            InitializeComponent();
        }

        private void FrmIndirizzi_Load(object sender, EventArgs e)
        {
            CaricaIndirizzi();
        }

        private void CaricaIndirizzi()
        {
            string errore;
            _indirizzi = ClsIndirizzoBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento indirizzi: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _tutteLeClassi = ClsClasseBL.GetAll(ref Program.conn, out errore);
                _tuttiGliStudenti = ClsUtenteBL.GetByRuolo(ref Program.conn, 'S', out errore);

                PopolaListView(_indirizzi);
            }
        }

        private int ContaIscritti(int indirizzoID)
        {
            List<string> sigleClassiIndirizzo = new List<string>();

            for (int i = 0; i < _tutteLeClassi.Count; i++)
            {
                if (_tutteLeClassi[i].IndirizzoID == indirizzoID)
                    sigleClassiIndirizzo.Add(_tutteLeClassi[i].Sigla);
            }

            int numeroIscritti = _tuttiGliStudenti.Count(u =>u.ClasseID != null && sigleClassiIndirizzo.Contains(u.ClasseID));

            return numeroIscritti;
        }

        private void PopolaListView(List<ClsIndirizzo> indirizzi)
        {
            lvIndirizzi.Items.Clear();
            for (int i = 0; i < indirizzi.Count; i++)
            {
                ClsIndirizzo ind = indirizzi[i];
                ListViewItem lvi = new ListViewItem(ind.ID.ToString());
                lvi.SubItems.Add(ind.Nome);
                lvi.SubItems.Add(ContaIscritti(ind.ID).ToString());
                lvi.Tag = ind;
                lvIndirizzi.Items.Add(lvi);
            }
            lblNumRecordTrovati.Text = "Risultati trovati: " + indirizzi.Count;
        }

        private void ResetCampi()
        {
            tbNome.Clear();

            _indirizzoSelezionato = null;
            _modalitaModifica = false;
            lblTitolo.Text = "Crea Indirizzo";
            btnAggiungi.Text = "➕Aggiungi";
        }

        private bool ValidaCampi()
        {
            bool campiValidati = true;
            if (string.IsNullOrWhiteSpace(tbNome.Text))
            {
                MessageBox.Show("Inserisci il nome dell'indirizzo.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidati = false;
            }
            return campiValidati;  
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ValidaCampi())
            {
                ClsIndirizzo indirizzo = new ClsIndirizzo();
                indirizzo.Nome = tbNome.Text.Trim();

                string errore;

                if (!_modalitaModifica)
                {
                    long id = ClsIndirizzoBL.Create(ref Program.conn, indirizzo, out errore);
                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (id > 0)
                    {
                        MessageBox.Show("Indirizzo aggiunto con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCampi();
                        CaricaIndirizzi();
                    }
                }
                else
                {
                    if (_indirizzoSelezionato == null)
                        MessageBox.Show("Seleziona un indirizzo da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        int esito = ClsIndirizzoBL.Update(ref Program.conn, _indirizzoSelezionato.ID, indirizzo, out errore);
                        if (!string.IsNullOrEmpty(errore))
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Indirizzo modificato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCampi();
                            CaricaIndirizzi();
                        }
                    }
                }
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            ResetCampi();
            CampiReadOnly(false);
            _modalitaVisualizza = false;
            btnVisualizza.Text = "👁️Visualizza";
        }

        private void VisualizzaIndirizzoSelezionato()
        {
            if (lvIndirizzi.SelectedItems.Count > 0)
            {
                _indirizzoSelezionato = (ClsIndirizzo)lvIndirizzi.SelectedItems[0].Tag;
                tbNome.Text = _indirizzoSelezionato.Nome;
            }         
        }

        private void CampiReadOnly(bool soloLettura)
        {
            tbNome.Enabled = !soloLettura;
            btnAggiungi.Enabled = !soloLettura;
            lvIndirizzi.Enabled = !soloLettura;
            btnModifica.Enabled = !soloLettura;
            btnElimina.Enabled = !soloLettura;
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            if (lvIndirizzi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un indirizzo da visualizzare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = !_modalitaVisualizza;
                if (_modalitaVisualizza)
                {
                    VisualizzaIndirizzoSelezionato();
                    CampiReadOnly(true);
                    lvIndirizzi.Enabled = true; 
                    btnVisualizza.Text = "👁️Smetti";
                }
                else
                {
                    ResetCampi();
                    CampiReadOnly(false);
                    btnVisualizza.Text = "👁️Visualizza";
                }
            }          
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (lvIndirizzi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un indirizzo da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = false;
                CampiReadOnly(false);
                VisualizzaIndirizzoSelezionato();
                _modalitaModifica = true;
                lblTitolo.Text = "Modifica Indirizzo";
                btnAggiungi.Text = "☑️ Salva";
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lvIndirizzi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona almeno un indirizzo da eliminare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ListViewItem[] selezionati = new ListViewItem[lvIndirizzi.SelectedItems.Count];
                lvIndirizzi.SelectedItems.CopyTo(selezionati, 0);
                
                List<string> bloccati = new List<string>();
                for (int i = 0; i < selezionati.Length; i++)
                {
                    ClsIndirizzo ind = (ClsIndirizzo)selezionati[i].Tag;
                    int numClassiCollegate = _tutteLeClassi.Count(c => c.IndirizzoID == ind.ID);
                    if (numClassiCollegate > 0)
                        bloccati.Add(ind.Nome + " (" + numClassiCollegate + " classe/i collegata/e)");
                }

                if (bloccati.Count > 0)
                    MessageBox.Show("Impossibile eliminare i seguenti indirizzi perché hanno classi collegate:\n\n" + string.Join("\n", bloccati) +
                                    "\n\nElimina o riassegna prima quelle classi.", "Eliminazione bloccata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult dr = MessageBox.Show("Vuoi eliminare gli indirizzi selezionati?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int eliminati = 0;
                        string errore = "";
                        for (int i = 0; i < selezionati.Length; i++)
                        {
                            ClsIndirizzo ind = (ClsIndirizzo)selezionati[i].Tag;
                            int esito = ClsIndirizzoBL.Delete(ref Program.conn, ind.ID, out errore);
                            if (string.IsNullOrEmpty(errore) && esito > 0)
                                eliminati++;
                        }

                        if (!string.IsNullOrEmpty(errore))
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        MessageBox.Show(eliminati + " indirizzo/i eliminato/i.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCampi();
                        CaricaIndirizzi();
                    }
                }
            }          
        }

        private void tbFiltroNome_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbFiltroNome.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
                PopolaListView(_indirizzi);
            else
            {
                List<ClsIndirizzo> risultato = _indirizzi.FindAll(ind => ind.Nome != null && ind.Nome.ToLower().Contains(filtro.ToLower()));
                PopolaListView(risultato);
            }
           
        }

        private void lvIndirizzi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modalitaVisualizza && lvIndirizzi.SelectedItems.Count > 0)
                VisualizzaIndirizzoSelezionato();
        }
    }
}