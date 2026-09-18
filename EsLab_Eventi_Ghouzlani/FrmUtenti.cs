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
    public partial class FrmUtenti : Form
    {
        private List<ClsUtente> _utenti = new List<ClsUtente>();
        private List<ClsClasse> _classi = new List<ClsClasse>();
        private ClsUtente _utenteSelezionato = null;
        private bool _modalitaModifica = false;
        private bool _modalitaVisualizza = false;

        public FrmUtenti()
        {
            InitializeComponent();
        }

        private void FrmUtenti_Load(object sender, EventArgs e)
        {
            CaricaClassi();
            CaricaUtenti();
            ResetCampi();

        }
        
        private void CaricaClassi()
        {
            string errore;
            _classi = ClsClasseBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento classi: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CaricaComboBox();
        }

        private void CaricaComboBox()
        {
            cbClasse.DataSource = null;
            cbClasse.DisplayMember = "Sigla";
            cbClasse.ValueMember = "Sigla";
            cbClasse.DataSource = _classi;
            cbClasse.SelectedIndex = -1;
        }

        private void CaricaUtenti()
        {
            string errore;
            _utenti = ClsUtenteBL.GetAll(ref Program.conn, out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                PopolaListView(_utenti);
        }

        private void PopolaListView(List<ClsUtente> utenti)
        {
            lvUtenti.Items.Clear();
            for (int i = 0; i < utenti.Count; i++)
            {
                ClsUtente u = utenti[i];
                ListViewItem lvi = new ListViewItem(u.Nome + " " + u.Cognome);
                lvi.SubItems.Add(u.ClasseID);
                lvi.SubItems.Add(u.Ruolo == 'A' ? "Admin" : "Studente");
                lvi.Tag = u;
                lvUtenti.Items.Add(lvi);
            }
            lblNumRecordTrovati.Text = "Risultati trovati: " + utenti.Count;
        }

        private void ResetCampi()
        {
            tbNome.Clear();     
            tbCognome.Clear();     
            tbUsername.Clear();      
            tbPassword.Clear();      
            chbStudente.Checked = true;
            chAdmin.Checked = false;
            chbRappreClasse.Checked = false;
            chbRappreIstituto.Checked = false;
            cbClasse.SelectedIndex = -1;

            _utenteSelezionato = null;
            _modalitaModifica = false;
            lblTitolo.Text = "Crea Utente";
            btnAggiungi.Text = "➕Aggiungi";
        }

        private ClsUtente LeggiCampi()
        {
            ClsUtente u = new ClsUtente();
            u.Nome = tbNome.Text.Trim();
            u.Cognome = tbCognome.Text.Trim();
            u.Username = tbUsername.Text.Trim();
            u.Password = tbPassword.Text;
            u.Matricola = _utenteSelezionato != null ? _utenteSelezionato.Matricola : null;
            u.Ruolo = chAdmin.Checked ? 'A' : 'S';
            u.RappresentanteClasse = chbRappreClasse.Checked;
            u.RappresentanteIstituto = chbRappreIstituto.Checked;
            if (chAdmin.Checked)
                u.ClasseID = "";
            else if (cbClasse.SelectedValue != null)
                u.ClasseID = cbClasse.SelectedValue.ToString();
            else
                u.ClasseID = "";
            return u;
        }

        private bool ValidaCampi()
        {
            bool campiValidati = true;
            if (string.IsNullOrWhiteSpace(tbNome.Text) ||
                string.IsNullOrWhiteSpace(tbCognome.Text) ||
                string.IsNullOrWhiteSpace(tbUsername.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Compila tutti i campi obbligatori.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidati = false;
            }

            if (!chAdmin.Checked && cbClasse.SelectedValue == null)
            {
                MessageBox.Show("Seleziona la classe dello studente.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                campiValidati = false;
            }

            return campiValidati;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ValidaCampi())
            {
                ClsUtente utente = LeggiCampi();
                string errore;

                if (!_modalitaModifica)
                {
                    ClsUtente esistente = ClsUtenteBL.GetByUsername(ref Program.conn, utente.Username, out errore);
                    if (esistente != null)
                        MessageBox.Show("Username già in uso.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        long id = 0;
                        do
                        {
                            utente.Matricola = GeneraMatricola();
                            id = ClsUtenteBL.Create(ref Program.conn, utente, out errore);
                        }
                        while (id <= 0 && errore.ToLower().IndexOf("duplicate") >= 0);

                        if (!string.IsNullOrEmpty(errore) && id <= 0)
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (id > 0)
                        {
                            MessageBox.Show("Utente aggiunto con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCampi();
                            CaricaUtenti();
                        }
                    }
                }
                else
                {
                    if (_utenteSelezionato == null)
                        MessageBox.Show("Seleziona un utente da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        int esito = ClsUtenteBL.Update(ref Program.conn, _utenteSelezionato.ID, utente, out errore);
                        if (!string.IsNullOrEmpty(errore))
                            MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (!string.IsNullOrEmpty(tbPassword.Text) && tbPassword.Text != _utenteSelezionato.Password)
                                ClsUtenteBL.UpdatePassword(ref Program.conn, _utenteSelezionato.ID, tbPassword.Text, out errore);

                            MessageBox.Show("Utente modificato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCampi();
                            CaricaUtenti();
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

        private void VisualizzaUtenteSelezionato()
        {
            if (lvUtenti.SelectedItems.Count > 0)
            {
                _utenteSelezionato = (ClsUtente)lvUtenti.SelectedItems[0].Tag;
                tbNome.Text = _utenteSelezionato.Nome;
                tbCognome.Text = _utenteSelezionato.Cognome;
                tbUsername.Text = _utenteSelezionato.Username;
                tbPassword.Text = _utenteSelezionato.Password;
                chAdmin.Checked = _utenteSelezionato.Ruolo == 'A';
                chbStudente.Checked = !chAdmin.Checked;
                chbRappreClasse.Checked = _utenteSelezionato.RappresentanteClasse;
                chbRappreIstituto.Checked = _utenteSelezionato.RappresentanteIstituto;
                if (!string.IsNullOrEmpty(_utenteSelezionato.ClasseID))
                    cbClasse.SelectedValue = _utenteSelezionato.ClasseID;
            }
        }

        private void CampiReadOnly(bool soloLettura)
        {
            tbNome.Enabled = !soloLettura;
            tbCognome.Enabled = !soloLettura;
            tbUsername.Enabled = !soloLettura;
            tbPassword.Enabled = !soloLettura;
            chbStudente.Enabled = !soloLettura;
            chAdmin.Enabled = !soloLettura;
            chbRappreClasse.Enabled = !soloLettura;
            chbRappreIstituto.Enabled = !soloLettura;
            cbClasse.Enabled = !soloLettura;
            btnAggiungi.Enabled = !soloLettura;
            btnModifica.Enabled = !soloLettura;
            btnElimina.Enabled = !soloLettura;
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un utente da visualizzare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = !_modalitaVisualizza;
                if (_modalitaVisualizza)
                {
                    VisualizzaUtenteSelezionato();
                    CampiReadOnly(true);
                    lvUtenti.Enabled = true;
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
            if (lvUtenti.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona un utente da modificare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _modalitaVisualizza = false;
                CampiReadOnly(false);
                VisualizzaUtenteSelezionato();
                _modalitaModifica = true;
                lblTitolo.Text = "Modifica Utente";
                btnAggiungi.Text = "☑️ Salva";
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lvUtenti.SelectedItems.Count == 0)
                MessageBox.Show("Seleziona almeno un utente da eliminare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dr = MessageBox.Show("Vuoi eliminare gli utenti selezionati?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ListViewItem[] selezionati = new ListViewItem[lvUtenti.SelectedItems.Count];
                    lvUtenti.SelectedItems.CopyTo(selezionati, 0);

                    int eliminati = 0;
                    string errore = "";
                    for (int i = 0; i < selezionati.Length; i++)
                    {
                        ClsUtente u = (ClsUtente)selezionati[i].Tag;
                        int esito = ClsUtenteBL.Delete(ref Program.conn, u.ID, out errore);
                        if (string.IsNullOrEmpty(errore) && esito > 0)
                            eliminati++;
                    }

                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show(eliminati + " utente/i eliminato/i.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetCampi();
                    CaricaUtenti();
                }
            }
        }

        private void tbFiltroNome_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbFiltroNome.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
                PopolaListView(_utenti);
            else
            {
                List<ClsUtente> risultato = _utenti.FindAll(u => (u.Nome != null && u.Nome.ToLower().IndexOf(filtro.ToLower()) >= 0) ||
                                                                (u.Cognome != null && u.Cognome.ToLower().IndexOf(filtro.ToLower()) >= 0));
                PopolaListView(risultato);
            }

           
        }

        private void lvUtenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modalitaVisualizza && lvUtenti.SelectedItems.Count > 0)
                VisualizzaUtenteSelezionato();
        }

        private static readonly Random _rnd = new Random();

        private string GeneraMatricola()
        {
            string matricola = "st";
            for (int i = 0; i < 5; i++)
            {
                int numero = _rnd.Next(0, 10);
                matricola += numero.ToString();
            }
            return matricola;
        }
    }
}