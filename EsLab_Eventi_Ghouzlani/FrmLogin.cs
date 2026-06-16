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

        private void pbFotoProfilo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "File Immagine|*.jpg;*.jpeg;*.png";
                ofd.Title = "Seleziona una foto profilo(solo jpg, jpeg e png)";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Program._fotoProfilo = Image.FromFile(ofd.FileName);
                        //pbFotoProfilo.Image = Program._fotoProfilo;
                        pbFotoProfilo.Tag = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore nel caricamento dell'immagine: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pbFotoProfilo_MouseHover(object sender, EventArgs e)
        {
            pbFotoProfilo.BorderStyle = BorderStyle.Fixed3D;
            pbFotoProfilo.Image = Properties.Resources.caricaPfp;
        }

        private void pbFotoProfilo_MouseLeave(object sender, EventArgs e)
        {
            pbFotoProfilo.BorderStyle = BorderStyle.None;
            //pbFotoProfilo.Image = Program._fotoProfilo;
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
            FrmMainUtente frmMainUtente = new FrmMainUtente();
            frmMainUtente.ShowDialog();
            this.Close();
        }

        private void btnAccedi_Click(object sender, EventArgs e)
        {
            FrmMainAdmin frmMainAdmin = new FrmMainAdmin();
            frmMainAdmin.ShowDialog();
            this.Close();
        }
    }
}
