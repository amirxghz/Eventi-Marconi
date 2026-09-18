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
    public partial class FrmMainUtente : Form
    {
        private List<ClsEvento> _eventi = new List<ClsEvento>();
        private List<ClsAttivita> _attivitaEvento = new List<ClsAttivita>();
        private ClsEvento _eventoSelezionato = null;

        private string _codiceCorrente = null;

        public FrmMainUtente()
        {
            InitializeComponent();
        }

        private void FrmMainUtente_Load(object sender, EventArgs e)
        {
            NascondiInfoIscrizione();
            CaricaEventi();
        }

        private void CaricaEventi()
        {
            string errore;

            _eventi = ClsEventoBL.GetAll(ref Program.conn,out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento eventi: " + errore,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                PopolaListViewEventi(_eventi);
        }

        private string FormattaPrezzo(decimal prezzo)
        {
            string prezzoFormattato = "Gratis";

            if (prezzo > 0)
                prezzoFormattato = prezzo.ToString("0.00") + "€";

            return prezzoFormattato;
        }

        private void PopolaListViewEventi(List<ClsEvento> eventi)
        {
            List<ClsEvento> eventiOrdinati =eventi.OrderBy(ev => ev.Dal).ToList();

            lvEventi.Items.Clear();

            for (int i = 0; i < eventiOrdinati.Count; i++)
            {
                ClsEvento ev = eventiOrdinati[i];

                ListViewItem lvi =
                    new ListViewItem(ev.Nome);

                lvi.SubItems.Add(ev.Descrizione);
                lvi.SubItems.Add(ev.Dal.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ev.Al.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(FormattaPrezzo(ev.Prezzo));
                lvi.Tag = ev;

                lvEventi.Items.Add(lvi);
            }
        }

        private void lvEventi_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (lvEventi.SelectedItems.Count == 0)
            {
                lvAttività.Items.Clear();
                _attivitaEvento.Clear();
                _eventoSelezionato = null;

                NascondiInfoIscrizione();
            }
            else
            {
                _eventoSelezionato =(ClsEvento)lvEventi.SelectedItems[0].Tag;

                CaricaAttivita(_eventoSelezionato.ID1);

                AggiornaStatoIscrizioneEvento();
            }
        }

        private void CaricaAttivita(int eventoID)
        {
            string errore;

            _attivitaEvento =ClsAttivitaBL.GetByEventoID(ref Program.conn,eventoID,out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento attività: " + errore,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                PopolaListViewAttivita(_attivitaEvento);
        }

        private void PopolaListViewAttivita(
            List<ClsAttivita> attivita)
        {
            List<ClsAttivita> attivitaOrdinate =attivita.OrderBy(a => a.Dalle).ToList();

            lvAttività.Items.Clear();

            for (int i = 0; i < attivitaOrdinate.Count; i++)
            {
                ClsAttivita a = attivitaOrdinate[i];

                ListViewItem lvi =new ListViewItem(a.Ordine.ToString());

                lvi.SubItems.Add(a.Titolo);
                lvi.SubItems.Add(a.Dalle.ToString(@"hh\:mm"));
                lvi.SubItems.Add(a.Alle.ToString(@"hh\:mm"));
                lvi.SubItems.Add(a.Testo);
                lvi.Tag = a;

                lvAttività.Items.Add(lvi);
            }
        }

        private void AggiornaStatoIscrizioneEvento()
        {
            List<ClsAderire> adesioniIscritte =new List<ClsAderire>();

            if (_eventoSelezionato == null ||Program.UtenteLoggato == null ||_attivitaEvento.Count == 0)
                NascondiInfoIscrizione();
            else
            {
                string errore;

                for (int i = 0; i < _attivitaEvento.Count; i++)
                {
                    ClsAderire ad =
                        ClsAderireBL.GetByAttivitaIDeStudenteID(ref Program.conn,_attivitaEvento[i].ID1,Program.UtenteLoggato.ID,out errore);
                    if (ad != null && ad.Iscritto)
                        adesioniIscritte.Add(ad);
                }

                if (adesioniIscritte.Count >= _attivitaEvento.Count)
                {
                    _codiceCorrente =adesioniIscritte[0].CodicePartecipazione;

                    btnPartecipa.Visible = true;
                    btnPartecipa.Enabled = false;

                    lblIscritto.Visible = true;

                    lblCodicePartecipazione.Visible = true;
                    lblCodicePartecipazione.Text ="Codice di Partecipazione: " +_codiceCorrente;

                    btnCopia.Visible = true;
                }
                else
                {
                    _codiceCorrente = null;

                    btnPartecipa.Visible = true;
                    btnPartecipa.Enabled = true;

                    lblIscritto.Visible = false;
                    lblCodicePartecipazione.Visible = false;

                    btnCopia.Visible = false;
                }
            }
        }


        private void btnCopia_Click(object sender,EventArgs e)
        {
            if (!string.IsNullOrEmpty(_codiceCorrente))
                Clipboard.SetText(_codiceCorrente);
        }

        private void NascondiInfoIscrizione()
        {
            _codiceCorrente = null;

            btnPartecipa.Visible = false;
            lblIscritto.Visible = false;
            lblCodicePartecipazione.Visible = false;
            btnCopia.Visible = false;
        }

        private void btnPartecipa_Click(object sender,EventArgs e)
        {
            if (_eventoSelezionato != null)
            {
                FrmPartecipa frmPartecipa =new FrmPartecipa(_eventoSelezionato.ID1);
                frmPartecipa.ShowDialog();

                AggiornaStatoIscrizioneEvento();
            }
        }

        private void TbFiltroEventi_TextChanged(object sender,EventArgs e)
        {
            string filtro =tbFiltroEventi.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
                PopolaListViewEventi(_eventi);
            else
            {
                List<ClsEvento> risultato =_eventi.FindAll(ev =>ev.Nome != null &&ev.Nome.ToLower().Contains(filtro.ToLower()));
                PopolaListViewEventi(risultato);
            }
        }

        private void TbFiltroAttivita_TextChanged(object sender,EventArgs e)
        {
            string filtro =tbFiltroAttivita.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
                PopolaListViewAttivita(_attivitaEvento);
            else
            {
                List<ClsAttivita> risultato =_attivitaEvento.FindAll(a =>a.Titolo != null &&a.Titolo.ToLower().Contains(filtro.ToLower()));
                PopolaListViewAttivita(risultato);
            }
        }
    }
}