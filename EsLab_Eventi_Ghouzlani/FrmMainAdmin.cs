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
    public partial class FrmMainAdmin : Form
    {
        public FrmMainAdmin()
        {
            InitializeComponent();
        }

        private Form frmCorrente = null;
        private Button btnPrecedente = null;
        private void SelezionaBottone(Button btn)
        {
            if (btnPrecedente != null && btnPrecedente != btn)
                btnPrecedente.BackColor = Color.FromArgb(255, 255, 255);

            btn.BackColor = Color.FromArgb(34, 66, 137);
            btnPrecedente = btn;
        }
        private void AprireFormMDI(Form nuovaForm, Button btn)
        {
            if (frmCorrente != null)
            {
                frmCorrente.Close();
                frmCorrente.Dispose();
            }

            nuovaForm.MdiParent = this;
            nuovaForm.WindowState = FormWindowState.Maximized;

            nuovaForm.Show();

            frmCorrente = nuovaForm;

            SelezionaBottone(btn);
        }

        private void btnEventi_Click(object sender, EventArgs e)
        {
            FrmEventi frmEventi = new FrmEventi();
            AprireFormMDI(frmEventi, btnEventi);
        }

        private void btnAttività_Click(object sender, EventArgs e)
        {
            FrmAttivita frmAttivita = new FrmAttivita();
            AprireFormMDI(frmAttivita, btnAttività);
        }

        private void btnIscrizioni_Click(object sender, EventArgs e)
        {
            FrmIscrizioni frmIscrizioni = new FrmIscrizioni();
            AprireFormMDI(frmIscrizioni, btnIscrizioni);
        }

        private void btnValida_Click(object sender, EventArgs e)
        {
            FrmValidaAccessoEvento frmValidaAccessoEvento = new FrmValidaAccessoEvento();
            AprireFormMDI(frmValidaAccessoEvento, btnValida);
        }

        private void btnUtenti_Click(object sender, EventArgs e)
        {
            FrmUtenti frmUtenti = new FrmUtenti();
            AprireFormMDI(frmUtenti, btnUtenti);
        }

        private void btnClassi_Click(object sender, EventArgs e)
        {
            FrmClassi frmClassi = new FrmClassi();
            AprireFormMDI(frmClassi, btnClassi);
        }

        private void btnIndirizzi_Click(object sender, EventArgs e)
        {
            FrmIndirizzi frmIndirizzi = new FrmIndirizzi();
            AprireFormMDI(frmIndirizzi, btnIndirizzi);
        }
    }
}
