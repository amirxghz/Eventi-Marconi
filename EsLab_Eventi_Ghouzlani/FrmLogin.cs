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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        private void llblAccedi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlAccesso.BringToFront();
            pnlRegistrati.Visible = false;
            pnlAccesso.Visible = true;
        }

        private void llblRegistrati_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlRegistrati.BringToFront();
            pnlAccesso.Visible = false;
            pnlRegistrati.Visible = true;
        }
        
        
        private void btnVisualizzaPasswordCreata_MouseDown(object sender, MouseEventArgs e)
        {
            btnVisualizzaPasswordCreata.ForeColor = Color.DodgerBlue;
            tbCreaPassword.UseSystemPasswordChar = false;
        }

        private void btnVisualizzaPasswordCreata_MouseUp(object sender, MouseEventArgs e)
        {
            btnVisualizzaPasswordCreata.ForeColor = Color.Black;
            tbCreaPassword.UseSystemPasswordChar = true;
        }

        private void btnVisualizzaPassword_MouseDown(object sender, MouseEventArgs e)
        {
            btnVisualizzaPassword.ForeColor = Color.DodgerBlue;
            tbPasswordLog.UseSystemPasswordChar = false;
        }

        private void btnVisualizzaPassword_MouseUp(object sender, MouseEventArgs e)
        {
            btnVisualizzaPassword.ForeColor = Color.Black;
            tbPasswordLog.UseSystemPasswordChar = true;
        }

        private void btnRegistrati_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNome.Text) ||
                string.IsNullOrWhiteSpace(tbCognome.Text) ||
                string.IsNullOrWhiteSpace(tbUsernae.Text) ||
                string.IsNullOrWhiteSpace(tbCreaPassword.Text))
                MessageBox.Show("Compila tutti i campi obbligatori (Nome, Cognome, Username, Password).","Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ClsUtente nuovoUtente = new ClsUtente();
                nuovoUtente.Nome = tbNome.Text.Trim();
                nuovoUtente.Cognome = tbCognome.Text.Trim();
                nuovoUtente.Username = tbUsernae.Text.Trim();
                nuovoUtente.Password = tbCreaPassword.Text;
                nuovoUtente.RappresentanteClasse = false;
                nuovoUtente.RappresentanteIstituto = false;
                nuovoUtente.Ruolo = 'S';
                nuovoUtente.ClasseID = "";

                string errore;

                ClsUtente esistente = ClsUtenteBL.GetByUsername(ref Program.conn, nuovoUtente.Username, out errore);
                if (esistente != null)
                    MessageBox.Show("Username già in uso, scegline un altro.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    nuovoUtente.Matricola = GeneraMatricola();
                    long id = ClsUtenteBL.Create(ref Program.conn, nuovoUtente, out errore);
                    this.Cursor = Cursors.Default;

                    if (!string.IsNullOrEmpty(errore) || id <= 0)
                        MessageBox.Show("Errore durante la registrazione: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        nuovoUtente.ID = (int)id;
                        Program.UtenteLoggato = nuovoUtente;

                        MessageBox.Show("Registrazione avvenuta con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmMainUtente frmMainUtente = new FrmMainUtente();
                        frmMainUtente.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private static readonly Random _rnd = new Random();

        private string GeneraMatricola()
        {
            string matricola;
            string errore;
            bool giaEsistente;
            do
            {
                matricola = GeneraMatricolaCasuale();
                ClsUtente esistente = ClsUtenteBL.GetByMatricola(ref Program.conn, matricola, out errore);
                if (esistente != null)
                    giaEsistente = true;
                else
                    giaEsistente = false;
            }
            while (giaEsistente);

            return matricola;
        }
        private string GeneraMatricolaCasuale()
        {
            string matricola = "st";

            for (int i = 0; i < 5; i++)
            {
                int numero = _rnd.Next(0, 10);
                matricola += numero.ToString();
            }

            return matricola;
        }

        private void btnAccedi_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPasswordLog.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                MessageBox.Show("Inserisci username e password.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.Cursor = Cursors.WaitCursor;
                string errore;
                ClsUtente utente = ClsUtenteBL.Login(ref Program.conn, username, password, out errore);
                this.Cursor = Cursors.Default;

                if (!string.IsNullOrEmpty(errore))
                    MessageBox.Show(errore, "Accesso negato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (utente == null)
                        MessageBox.Show("Username o password errati.", "Accesso negato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Program.UtenteLoggato = utente;

                        if (utente.Ruolo == 'A' || utente.Ruolo == 'a')
                        {
                            FrmMainAdmin frmMainAdmin = new FrmMainAdmin();
                            frmMainAdmin.ShowDialog();
                        }
                        else
                        {
                            FrmMainUtente frmMainUtente = new FrmMainUtente();
                            frmMainUtente.ShowDialog();
                        }

                        this.Close();
                    }
                }
            }      
        }
    }
}