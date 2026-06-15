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
        public FrmPartecipa()
        {
            InitializeComponent();
        }
        private void btnPartecipa_Click(object sender, EventArgs e)
        {
            CreaCodice();
            tlpQRcode.Controls.Clear();
            tlpQRcode.SuspendLayout();

            int righe = 20;       // 21
            int colonne = 20;  // 21
            int modSize = 15;

            tlpQRcode.RowCount = righe;
            tlpQRcode.ColumnCount = colonne;
            tlpQRcode.RowStyles.Clear();
            tlpQRcode.ColumnStyles.Clear();
            tlpQRcode.Padding = new Padding(0);
            tlpQRcode.Margin = new Padding(0);

            for (int r = 0; r < righe; r++)
                tlpQRcode.RowStyles.Add(new RowStyle(SizeType.Absolute, modSize));

            for (int c = 0; c < colonne; c++)
                tlpQRcode.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, modSize));

            for (int y = 0; y < righe; y++)
            {
                for (int x = 0; x < colonne; x++)
                {
                    Panel cella = new Panel();
                    cella.Dock = DockStyle.Fill;
                    cella.Margin = new Padding(0);
                    cella.BackColor = QRcode[y,x] ? Color.Black : Color.White;

                    tlpQRcode.Controls.Add(cella, x, y); 
                }
            }

            tlpQRcode.ResumeLayout();

        }
        bool[,] QRcode = new bool[20, 20];

        private void CreaCodice()
        {
            Random rnd = new Random();
            for (int y = 0; y < QRcode.GetLength(0); y++)
            {
                for (int x = 0; x < QRcode.GetLength(1); x++)
                {
                    bool elemento;
                    if (rnd.Next(0, 2) == 1)
                        elemento = true;
                    else
                        elemento = false;
                    QRcode[y, x] = elemento;
                }
            }
        }
    }
}
