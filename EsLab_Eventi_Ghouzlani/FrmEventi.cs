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
    public partial class FrmEventi : Form
    {
        private List<ClsEvento> _eventi = new List<ClsEvento>();
        private ClsEvento _eventoSelezionato = null;
        private bool _modalitaModifica = false;
        private bool _modalitaVisualizza = false;

        public FrmEventi()
        {
            InitializeComponent();
        }

        private void FrmEventi_Load(object sender, EventArgs e)
        {
            CaricaEventi();
            ResetCampi();
        }

        private void LvEventi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modalitaVisualizza && lvEventi.SelectedItems.Count > 0)
                VisualizzaEventoSelezionato();
        }


        private void CaricaEventi()
        {
            string errore;
            _eventi = ClsEventoBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                PopolaListView(_eventi);
        }

        private string FormattaPrezzo(decimal prezzo)
        {
            string prezzoFormattato = "Gratis";
            if (prezzo > 0)
                prezzoFormattato = prezzo.ToString("0.00")+"€";
            return prezzoFormattato;
        }

        private void PopolaListView(List<ClsEvento> eventi)
        {
            List<ClsEvento> eventiOrdinati = eventi.OrderBy(ev => ev.Dal).ToList();

            lvEventi.Items.Clear();
            for (int i = 0; i < eventiOrdinati.Count; i++)
            {
                ClsEvento ev = eventiOrdinati[i];
                ListViewItem lvi = new ListViewItem(ev.Nome);
                lvi.SubItems.Add(ev.Dal.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ev.Al.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(FormattaPrezzo(ev.Prezzo));
                lvi.Tag = ev;
                lvEventi.Items.Add(lvi);
            }
            lblNumRecordTrovati.Text = "Risultati trovati: " + eventiOrdinati.Count;
        }

        private void ResetCampi()
        {
            tbTitolo.Clear();
            rtbDescrizione.Clear();
            dtpDal.Value = DateTime.Now;
            dtpAl.Value = DateTime.Now;
            nudPrezzo.Value = 0;

            _eventoSelezionato = null;
            _modalitaModifica = false;
            lblTitolo.Text = "Crea Evento";
            btnAggiungi.Text = "➕Aggiungi";
        }

        private ClsEvento LeggiCampi()
        {
            ClsEvento ev = new ClsEvento();
            ev.Nome = tbTitolo.Text.Trim();
            ev.Descrizione = rtbDescrizione.Text.Trim();
            ev.Dal = dtpDal.Value.Date;
            ev.Al = dtpAl.Value.Date;
            ev.Prezzo = nudPrezzo.Value;
            ev.AdminID = Program.UtenteLoggato != null ? Program.UtenteLoggato.ID : 0;
            return ev;
        }

        private bool ValidaCampi()
        {
            bool campiValidati = true;
            if (string.IsNullOrWhiteSpace(tbTitolo.Text))
            {
                MessageBox.Show("Inserisci il titolo dell'evento.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidati = false;
            }

            if (dtpAl.Value.Date < dtpDal.Value.Date)
            {
                MessageBox.Show("La data \"Al\" non può essere precedente alla data \"Dal\".", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidati = false;
            }

            return campiValidati;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ValidaCampi())
            {
                ClsEvento evento = LeggiCampi();
                string errore;

                if (!_modalitaModifica)
                {
                    long id = ClsEventoBL.Create(ref Program.conn, evento, out errore);
                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (id > 0)
                    {
                        MessageBox.Show("Evento aggiunto con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCampi();
                        CaricaEventi();
                    }
                }
                else
                {
                    if (_eventoSelezionato == null)
                        MessageBox.Show("Seleziona un evento da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        int esito = ClsEventoBL.Update(ref Program.conn, _eventoSelezionato.ID1, evento, out errore);
                        if (!string.IsNullOrEmpty(errore))
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Evento modificato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCampi();
                            CaricaEventi();
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

        private void VisualizzaEventoSelezionato()
        {
            if (lvEventi.SelectedItems.Count > 0)
            {
                _eventoSelezionato = (ClsEvento)lvEventi.SelectedItems[0].Tag;
                tbTitolo.Text = _eventoSelezionato.Nome;
                rtbDescrizione.Text = _eventoSelezionato.Descrizione;
                dtpDal.Value = _eventoSelezionato.Dal;
                dtpAl.Value = _eventoSelezionato.Al;
                nudPrezzo.Value = _eventoSelezionato.Prezzo;
            }
        }

        private void CampiReadOnly(bool soloLettura)
        {
            tbTitolo.Enabled = !soloLettura;
            rtbDescrizione.Enabled = !soloLettura;
            dtpDal.Enabled = !soloLettura;
            dtpAl.Enabled = !soloLettura;
            nudPrezzo.Enabled = !soloLettura;
            btnAggiungi.Enabled = !soloLettura;
            btnModifica.Enabled = !soloLettura;
            btnElimina.Enabled = !soloLettura;
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            if (lvEventi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un evento da visualizzare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = !_modalitaVisualizza;
                if (_modalitaVisualizza)
                {
                    VisualizzaEventoSelezionato();
                    CampiReadOnly(true);
                    lvEventi.Enabled = true;
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
            if (lvEventi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un evento da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = false;
                CampiReadOnly(false);
                VisualizzaEventoSelezionato();
                _modalitaModifica = true;
                lblTitolo.Text = "Modifica Evento";
                btnAggiungi.Text = "☑️ Salva";
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lvEventi.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona almeno un evento da eliminare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dr = MessageBox.Show("Vuoi eliminare gli eventi selezionati?\n(vengono eliminate anche le eventuali attività collegate)", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ListViewItem[] selezionati = new ListViewItem[lvEventi.SelectedItems.Count];
                    lvEventi.SelectedItems.CopyTo(selezionati, 0);

                    int eliminati = 0;
                    string errore = "";
                    for (int i = 0; i < selezionati.Length; i++)
                    {
                        ClsEvento ev = (ClsEvento)selezionati[i].Tag;
                        int esito = ClsEventoBL.Delete(ref Program.conn, ev.ID1, out errore);
                        if (string.IsNullOrEmpty(errore) && esito > 0)
                            eliminati++;
                    }

                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show(eliminati + " evento/i eliminato/i.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetCampi();
                    CaricaEventi();
                }
            }
        }

        private void tbFiltroNome_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbFiltroNome.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
                PopolaListView(_eventi);
            else
            {
                List<ClsEvento> risultato = _eventi.FindAll(ev => ev.Nome != null && ev.Nome.ToLower().Contains(filtro.ToLower()));
                PopolaListView(risultato);
            }
        }

        private void btnAttività_Click(object sender, EventArgs e)
        {
            FrmAttivita frmAttivita = new FrmAttivita();
            frmAttivita.ShowDialog();
        }
    }
}