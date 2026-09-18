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
    public partial class FrmAttivita : Form
    {
        private List<ClsAttivita> _attivita = new List<ClsAttivita>();
        private List<ClsEvento> _eventi = new List<ClsEvento>();
        private ClsAttivita _attivitaSelezionata = null;
        private bool _modalitaModifica = false;
        private bool _modalitaVisualizza = false;

        public FrmAttivita()
        {
            InitializeComponent();
        }

        private void FrmAttivita_Load(object sender, EventArgs e)
        {
            CaricaEventi();
        }

        private void CaricaEventi()
        {
            string errore;
            _eventi = ClsEventoBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento eventi: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CaricaComboBox();
            cbEvento.SelectedIndex = -1;
        }

        private void CaricaComboBox()
        {
            cbEvento.DataSource = null;
            cbEvento.DisplayMember = "Nome";
            cbEvento.ValueMember = "ID1";
            cbEvento.DataSource = _eventi;
            cbEvento.SelectedIndex = -1;
        }

        private int EventoSelezionatoID()
        {
            int id = 0;
            if (cbEvento.SelectedIndex != -1)
                id = _eventi[cbEvento.SelectedIndex].ID1;

            return id;
        }


        private void CbEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetCampi();
            CaricaAttivita();
        }

        private void CaricaAttivita()
        {
            int eventoID = EventoSelezionatoID();
            string errore;

            if (eventoID > 0)
                _attivita = ClsAttivitaBL.GetByEventoID(ref Program.conn, eventoID, out errore);
            else
                _attivita = ClsAttivitaBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                PopolaListView(_attivita);
        }

        private void PopolaListView(List<ClsAttivita> attivita)
        {
            List<ClsAttivita> attivitaOrdinate = attivita.OrderBy(a => a.Dalle).ToList();

            lvAttività.Items.Clear();
            for (int i = 0; i < attivitaOrdinate.Count; i++)
            {
                ClsAttivita a = attivitaOrdinate[i];
                ListViewItem lvi = new ListViewItem(a.Ordine.ToString());
                lvi.SubItems.Add(a.Titolo);
                lvi.SubItems.Add(a.Dalle.ToString(@"hh\:mm"));
                lvi.SubItems.Add(a.Alle.ToString(@"hh\:mm"));
                lvi.Tag = a;
                lvAttività.Items.Add(lvi);
            }
            lblNumRecordTrovati.Text = "Risultati trovati: " + attivitaOrdinate.Count;
        }

        private void ResetCampi()
        {
            tbTitolo.Clear();
            rtbDescrizione.Clear();
            dtpDalle.Value = DateTime.Today;
            dtpAlle.Value = DateTime.Today;

            _attivitaSelezionata = null;
            _modalitaModifica = false;
            lblTitolo.Text = "Crea Attività";
            btnAggiungi.Text = "➕Aggiungi";
        }

        private ClsAttivita LeggiCampi()
        {
            ClsAttivita a = new ClsAttivita();
            a.Titolo = tbTitolo.Text.Trim();
            a.Testo = rtbDescrizione.Text.Trim();
            a.Dalle = dtpDalle.Value.TimeOfDay;
            a.Alle = dtpAlle.Value.TimeOfDay;
            a.EventoID = EventoSelezionatoID();
            if (_attivitaSelezionata != null)
                a.Ordine = _attivitaSelezionata.Ordine;
            else
                a.Ordine = _attivita.Count + 1;
            return a;
        }

        private bool ValidaCampi()
        {
            bool campiValidi = true;
            if (string.IsNullOrWhiteSpace(tbTitolo.Text))
            {
                MessageBox.Show("Inserisci il titolo dell'attività.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidi = false;
            }

            if (EventoSelezionatoID() <= 0)
            {
                MessageBox.Show("Seleziona l'evento a cui appartiene l'attività.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidi = false;
            }

            if (dtpAlle.Value.TimeOfDay <= dtpDalle.Value.TimeOfDay)
            {
                MessageBox.Show("L'orario \"Alle\" deve essere successivo all'orario \"Dalle\".", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidi = false;
            }

            return campiValidi;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ValidaCampi())
            {
                ClsAttivita attivita = LeggiCampi();
                string errore;

                if (!_modalitaModifica)
                {
                    long id = ClsAttivitaBL.Create(ref Program.conn, attivita, out errore);
                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (id > 0)
                    {
                        MessageBox.Show("Attività aggiunta con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DateTime alle = dtpAlle.Value;
                        ResetCampi();
                        dtpDalle.Value = alle;
                        dtpAlle.Value = alle.AddHours(1);
                        CaricaAttivita();
                    }
                }
                else
                {
                    if (_attivitaSelezionata == null)
                        MessageBox.Show("Seleziona un'attività da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        int esito = ClsAttivitaBL.Update(ref Program.conn, _attivitaSelezionata.ID1, attivita, out errore);
                        if (!string.IsNullOrEmpty(errore))
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Attività modificata con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCampi();
                            CaricaAttivita();
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

        private void VisualizzaAttivitaSelezionata()
        {
            if (lvAttività.SelectedItems.Count > 0)
            {
                _attivitaSelezionata = (ClsAttivita)lvAttività.SelectedItems[0].Tag;
                tbTitolo.Text = _attivitaSelezionata.Titolo;
                rtbDescrizione.Text = _attivitaSelezionata.Testo;
                dtpDalle.Value = DateTime.Today.Add(_attivitaSelezionata.Dalle);
                dtpAlle.Value = DateTime.Today.Add(_attivitaSelezionata.Alle);
                cbEvento.SelectedValue = _attivitaSelezionata.EventoID;
            }
        }

        private void CampiReadOnly(bool soloLettura)
        {
            tbTitolo.Enabled = !soloLettura;
            rtbDescrizione.Enabled = !soloLettura;
            dtpDalle.Enabled = !soloLettura;
            dtpAlle.Enabled = !soloLettura;
            cbEvento.Enabled = !soloLettura;
            btnAggiungi.Enabled = !soloLettura;
            btnModifica.Enabled = !soloLettura;
            btnElimina.Enabled = !soloLettura;
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            if (lvAttività.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleziona un'attività da visualizzare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _modalitaVisualizza = !_modalitaVisualizza;
                if (_modalitaVisualizza)
                {
                    VisualizzaAttivitaSelezionata();
                    CampiReadOnly(true);
                    lvAttività.Enabled = true;
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
            if (lvAttività.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un'attività da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = false;
                CampiReadOnly(false);
                VisualizzaAttivitaSelezionata();
                _modalitaModifica = true;
                lblTitolo.Text = "Modifica Attività";
                btnAggiungi.Text = "☑️ Salva";
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lvAttività.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona almeno un'attività da eliminare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dr = MessageBox.Show("Vuoi eliminare le attività selezionate?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    ListViewItem[] selezionati = new ListViewItem[lvAttività.SelectedItems.Count];
                    lvAttività.SelectedItems.CopyTo(selezionati, 0);

                    int eliminati = 0;
                    string errore = "";
                    for (int i = 0; i < selezionati.Length; i++)
                    {
                        ClsAttivita a = (ClsAttivita)selezionati[i].Tag;
                        int esito = ClsAttivitaBL.Delete(ref Program.conn, a.ID1, out errore);
                        if (string.IsNullOrEmpty(errore) && esito > 0)
                            eliminati++;
                    }

                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show(eliminati + " attività eliminata/e.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetCampi();
                    CaricaAttivita();
                }
            }
        }

        private void tbFiltroNome_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbFiltro.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
                PopolaListView(_attivita);
            else
            {
                List<ClsAttivita> risultato = _attivita.FindAll(a => a.Titolo != null && a.Titolo.ToLower().Contains(filtro.ToLower()));
                PopolaListView(risultato);
            }
        }
    }
}