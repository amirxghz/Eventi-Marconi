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
    public partial class FrmPartecipa : Form
    {
        private List<ClsEvento> _eventi = new List<ClsEvento>();
        private List<ClsAttivita> _attivitaEvento = new List<ClsAttivita>();
        private int _eventoPreselezionato = 0;

        private static readonly Random _rnd = new Random();

        public FrmPartecipa(int eventoID)
        {
            InitializeComponent();

            _eventoPreselezionato = eventoID;
        }

        private void FrmPartecipa_Load(object sender, EventArgs e)
        {
            CaricaEventi();

            if (_eventoPreselezionato > 0)
            {
                cbEvento.SelectedValue = _eventoPreselezionato;
                cbEvento.Enabled = false; 
            }
            else
                cbEvento.Enabled = true;

          
            if (cbEvento.SelectedValue != null)
            {
                int eventoID = Convert.ToInt32(cbEvento.SelectedValue);
                CaricaAttivita(eventoID);
                AggiornaPrezzo(eventoID);
            }
        }

        private void CaricaEventi()
        {
            string errore;
            _eventi = ClsEventoBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento eventi: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CaricaComboBox();
        }

        private void CaricaComboBox()
        {
            cbEvento.DataSource = null;
            cbEvento.DisplayMember = "Nome";
            cbEvento.ValueMember = "ID1";
            cbEvento.DataSource = _eventi;
            cbEvento.SelectedIndex = -1;
        }

        private void CbEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEvento.SelectedValue == null)
            {
                lvAttività.Items.Clear();
                _attivitaEvento.Clear();
                lblPrezzo.Text = "Gratis";
            }
            else
            {
                int eventoID = Convert.ToInt32(cbEvento.SelectedValue);
                CaricaAttivita(eventoID);
                AggiornaPrezzo(eventoID);
            }
        }

        private void AggiornaPrezzo(int eventoID)
        {
            ClsEvento evento = _eventi.Find(ev => ev.ID1 == eventoID);
            if (evento == null)
                lblPrezzo.Text = "Gratis";
            else
            {
                if (evento.Prezzo > 0)
                    lblPrezzo.Text = evento.Prezzo.ToString("0.00") + " €";
                else
                    lblPrezzo.Text = "Gratis";
            }
        }

        private void CaricaAttivita(int eventoID)
        {
            string errore;
            _attivitaEvento = ClsAttivitaBL.GetByEventoID(ref Program.conn, eventoID, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento attività: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _attivitaEvento = _attivitaEvento.OrderBy(a => a.Dalle).ToList();

                lvAttività.Items.Clear();
                for (int i = 0; i < _attivitaEvento.Count; i++)
                {
                    ClsAttivita a = _attivitaEvento[i];
                    ListViewItem lvi = new ListViewItem(a.Titolo);
                    lvi.SubItems.Add(a.Dalle.ToString(@"hh\:mm"));
                    lvi.SubItems.Add(a.Alle.ToString(@"hh\:mm"));
                    lvi.Tag = a;
                    lvAttività.Items.Add(lvi);
                }
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string GeneraCodicePartecipazione()
        {
            string codice;
            string errore;
            bool giaUsato;

            do
            {
                codice = GeneraCodiceCasuale();
                List<ClsAderire> esistenti = ClsAderireBL.GetByCodicePartecipazione(ref Program.conn, codice, out errore);
                giaUsato = esistenti != null && esistenti.Count > 0;
            }
            while (giaUsato);

            return codice;
        }

        private string GeneraCodiceCasuale()
        {
            string codiceNum = String.Empty;
            string codiceChar = String.Empty;

            for (int i = 0; i < 3; i++)
                codiceNum += _rnd.Next(0, 10);

            for (int i = 3; i < 5; i++)
                codiceChar += Convert.ToChar(_rnd.Next(65, 91));

            return codiceNum + codiceChar;
        }

        private void btnPartecipa_Click(object sender, EventArgs e)
        {
            string errore;

            string codice = null;

            for (int i = 0; i < _attivitaEvento.Count && codice == null; i++)
            {
                ClsAderire esistente = ClsAderireBL.GetByAttivitaIDeStudenteID(ref Program.conn,_attivitaEvento[i].ID1,Program.UtenteLoggato.ID,out errore);

                if (esistente != null && !string.IsNullOrEmpty(esistente.CodicePartecipazione))
                    codice = esistente.CodicePartecipazione;
            }

            if (codice == null)
            {
                codice = GeneraCodicePartecipazione();
            }

            int giaIscrittoA = 0;
            int nuoveIscrizioni = 0;

            for (int i = 0; i < _attivitaEvento.Count; i++)
            {
                ClsAttivita att = _attivitaEvento[i];

                ClsAderire esistente = ClsAderireBL.GetByAttivitaIDeStudenteID(ref Program.conn,att.ID1,Program.UtenteLoggato.ID,out errore);

                if (esistente != null)
                    giaIscrittoA++;
                else
                {
                    ClsAderire nuovaAdesione = new ClsAderire();

                    nuovaAdesione.CodicePartecipazione = codice;
                    nuovaAdesione.Iscritto = true;
                    nuovaAdesione.Pagato = false;
                    nuovaAdesione.Partecipato = false;
                    nuovaAdesione.AttivitaID = att.ID1;

                    if (string.IsNullOrEmpty(Program.UtenteLoggato.ClasseID))
                        nuovaAdesione.ClasseID = null;
                    else
                        nuovaAdesione.ClasseID = Program.UtenteLoggato.ClasseID;

                    nuovaAdesione.StudenteID = Program.UtenteLoggato.ID;

                    long id = ClsAderireBL.Create(ref Program.conn,nuovaAdesione,out errore);

                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore durante l'iscrizione a \"" + att.Titolo + "\": " + errore,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else
                    {
                        if (id > 0)
                            nuoveIscrizioni++;
                    }
                }
            }

            if (giaIscrittoA == _attivitaEvento.Count)
                MessageBox.Show("Sei già iscritto a questo evento.\nCodice di partecipazione: " + codice,"Già iscritto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else if (nuoveIscrizioni > 0)
                MessageBox.Show("Iscrizione all'evento completata!\n\nCodice di partecipazione: " + codice,"Iscrizione effettuata",MessageBoxButtons.OK,MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}