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
    public partial class FrmClassi : Form
    {
        private List<ClsClasse> _classi = new List<ClsClasse>();
        private List<ClsIndirizzo> _indirizzi = new List<ClsIndirizzo>();
        private List<ClsUtente> _tuttiGliStudenti = new List<ClsUtente>();
        private ClsClasse _classeSelezionata = null;
        private bool _modalitaModifica = false;
        private bool _modalitaVisualizza = false;

        public FrmClassi()
        {
            InitializeComponent();
        }

        private void FrmClassi_Load(object sender, EventArgs e)
        {
            CaricaIndirizzi();
            CaricaClassi();
            CaricaComboBox();
        }


        private void CaricaIndirizzi()
        {
            string errore;
            _indirizzi = ClsIndirizzoBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento indirizzi: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CaricaComboBox();
        }

        private void CaricaClassi()
        {
            string errore;
            _classi = ClsClasseBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _tuttiGliStudenti = ClsUtenteBL.GetByRuolo(ref Program.conn, 'S', out errore);
                if (!string.IsNullOrEmpty(errore))
                    MessageBox.Show("Errore nel caricamento studenti: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                PopolaListView(_classi);
            }
        }

        private void CaricaComboBox()
        {
            cbIndirizzo.DataSource = null;
            cbIndirizzo.DisplayMember = "Nome";
            cbIndirizzo.ValueMember = "ID";
            cbIndirizzo.DataSource = _indirizzi;
            cbIndirizzo.SelectedIndex = -1;
        }

        private int ContaStudenti(string classeSigla)
        {
            int numStudenti = 0;
            numStudenti = _tuttiGliStudenti.Count(u => u.ClasseID == classeSigla);
            return numStudenti;
        }

        private string NomeIndirizzo(int indirizzoID)
        {
            string nomeIndirizzo = "";
            ClsIndirizzo indirizzo = _indirizzi.Find(x => x.ID == indirizzoID);

            if (indirizzo != null)
                nomeIndirizzo = indirizzo.Nome;

            return nomeIndirizzo;
        }

        private void PopolaListView(List<ClsClasse> classi)
        {
            lvClassi.Items.Clear();
            for (int i = 0; i < classi.Count; i++)
            {
                ClsClasse c = classi[i];
                ListViewItem lvi = new ListViewItem(c.Sigla);
                lvi.SubItems.Add(c.Aula);
                lvi.SubItems.Add(NomeIndirizzo(c.IndirizzoID));
                lvi.SubItems.Add(ContaStudenti(c.Sigla).ToString());
                lvi.Tag = c;
                lvClassi.Items.Add(lvi);
            }
            lblNumRecordTrovati.Text = "Risultati trovati: " + classi.Count;
        }

        private void ResetCampi()
        {
            tbTitolo.Clear();
            tbSezione.Clear();
            nudAnno.Value = 1;
            if (cbIndirizzo.Items.Count > 0)
                cbIndirizzo.SelectedIndex = 0;

            _classeSelezionata = null;
            _modalitaModifica = false;
            lblTitolo.Text = "Crea Classi";
            btnAggiungi.Text = "➕Aggiungi";
        }

        private ClsClasse LeggiCampi()
        {
            ClsClasse c = new ClsClasse();
            c.Aula = tbTitolo.Text.Trim();
            c.Sezione = tbSezione.Text.Trim().ToUpper();
            c.Anno = (byte)nudAnno.Value;
            if (cbIndirizzo.SelectedIndex == -1)
                c.IndirizzoID = 0;
            else
                c.IndirizzoID = _indirizzi[cbIndirizzo.SelectedIndex].ID;
            c.Sigla = c.Anno + c.Sezione;
            return c;
        }

        private bool ValidaCampi()
        {
            bool campiValidati = true;
            if (string.IsNullOrWhiteSpace(tbTitolo.Text) ||
                string.IsNullOrWhiteSpace(tbSezione.Text) ||
                nudAnno.Value <= 0 ||
                cbIndirizzo.SelectedValue == null)
            {
                MessageBox.Show("Compila tutti i campi obbligatori.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidati = false;
            }
            return campiValidati;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ValidaCampi())
            {
                ClsClasse classe = LeggiCampi();
                string errore;

                if (!_modalitaModifica)
                {
                    int esito = ClsClasseBL.Create(ref Program.conn, classe, out errore);
                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (esito > 0)
                    {
                        MessageBox.Show("Classe aggiunta con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCampi();
                        CaricaClassi();
                    }
                }
                else
                {
                    if (_classeSelezionata == null)
                        MessageBox.Show("Seleziona una classe da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        int esito = ClsClasseBL.Update(ref Program.conn, _classeSelezionata.Sigla, classe, out errore);
                        if (!string.IsNullOrEmpty(errore))
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Classe modificata con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCampi();
                            CaricaClassi();
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

        private void VisualizzaClasseSelezionata()
        {
            if (lvClassi.SelectedItems.Count > 0)
            {
                _classeSelezionata = (ClsClasse)lvClassi.SelectedItems[0].Tag;
                tbTitolo.Text = _classeSelezionata.Aula;
                tbSezione.Text = _classeSelezionata.Sezione;
                if (_classeSelezionata.Anno > 0)
                    nudAnno.Value = _classeSelezionata.Anno;
                else
                    nudAnno.Value = 1;
                cbIndirizzo.SelectedValue = _classeSelezionata.IndirizzoID;
            }
        }

        private void CampiReadOnly(bool soloLettura)
        {
            tbTitolo.Enabled = !soloLettura;
            tbSezione.Enabled = !soloLettura;
            nudAnno.Enabled = !soloLettura;
            cbIndirizzo.Enabled = !soloLettura;
            btnAggiungi.Enabled = !soloLettura;
            lvClassi.Enabled = !soloLettura;
            btnModifica.Enabled = !soloLettura;
            btnElimina.Enabled = !soloLettura;
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            if (lvClassi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona una classe da visualizzare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = !_modalitaVisualizza;
                if (_modalitaVisualizza)
                {
                    VisualizzaClasseSelezionata();
                    CampiReadOnly(true);
                    lvClassi.Enabled = true;
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
            if (lvClassi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona una classe da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = false;
                CampiReadOnly(false);
                VisualizzaClasseSelezionata();
                _modalitaModifica = true;
                lblTitolo.Text = "Modifica Classe";
                btnAggiungi.Text = "☑️ Salva";
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lvClassi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona almeno una classe da eliminare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dr = MessageBox.Show("Vuoi eliminare le classi selezionate?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ListViewItem[] selezionati = new ListViewItem[lvClassi.SelectedItems.Count];
                    lvClassi.SelectedItems.CopyTo(selezionati, 0);

                    int eliminati = 0;
                    string errore = "";
                    for (int i = 0; i < selezionati.Length; i++)
                    {
                        ClsClasse c = (ClsClasse)selezionati[i].Tag;
                        int esito = ClsClasseBL.Delete(ref Program.conn, c.Sigla, out errore);
                        if (string.IsNullOrEmpty(errore) && esito > 0)
                            eliminati++;
                    }

                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show(eliminati + " classe/i eliminata/e.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetCampi();
                    CaricaClassi();
                }
            }         
        }

        private void tbFiltroNome_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbFiltroNome.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
                PopolaListView(_classi);
            else
            {
                List<ClsClasse> risultato = _classi.FindAll(c => (c.Sigla != null && c.Sigla.ToLower().Contains(filtro.ToLower())) ||
                                                                  (c.Aula != null && c.Aula.ToLower().Contains(filtro.ToLower())));
                PopolaListView(risultato);
            }
        }

        private void lvClassi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modalitaVisualizza && lvClassi.SelectedItems.Count > 0)
                VisualizzaClasseSelezionata();
        }

        private void btnIndirizzo_Click(object sender, EventArgs e)
        {
            FrmIndirizzi frmIndirizzi = new FrmIndirizzi();
            frmIndirizzi.Show();
        }
    }
}