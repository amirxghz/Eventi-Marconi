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
        public FrmEventi()
        {
            InitializeComponent();
        }

        private void pbLocandina_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "File Immagine|*.jpg;*.jpeg;*.png";
                ofd.Title = "Seleziona una locandina per il tuo evento(solo jpg, jpeg e png)";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Program._evento = Image.FromFile(ofd.FileName);
                        //pbLocandina.Image = Program._evento;
                        pbLocandina.Tag = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore nel caricamento dell'immagine: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pbLocandina_MouseHover(object sender, EventArgs e)
        {
            pbLocandina.BorderStyle = BorderStyle.Fixed3D;
            pbLocandina.Image = Properties.Resources.caricaPfp;
        }

        private void pbLocandina_MouseLeave(object sender, EventArgs e)
        {
            pbLocandina.BorderStyle = BorderStyle.None;
            //pbLocandina.Image = Program._fotoProfilo;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {

        }

        private void btnModifica_Click(object sender, EventArgs e)
        {

        }

        private void btnElimina_Click(object sender, EventArgs e)
        {

        }

        private void tbFiltroNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmEventi_Load(object sender, EventArgs e)
        {

        }
        
    }
}
