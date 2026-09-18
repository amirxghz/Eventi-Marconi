namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmValidaAccessoEvento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbIDaderire = new System.Windows.Forms.TextBox();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.btnValida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIDaderire
            // 
            this.tbIDaderire.Font = new System.Drawing.Font("Helvetica", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDaderire.Location = new System.Drawing.Point(89, 101);
            this.tbIDaderire.Name = "tbIDaderire";
            this.tbIDaderire.Size = new System.Drawing.Size(215, 49);
            this.tbIDaderire.TabIndex = 0;
            this.tbIDaderire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIDaderire_KeyDown);
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(41, 60);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(311, 38);
            this.lblTitolo.TabIndex = 193;
            this.lblTitolo.Text = "Codice Partecipazione";
            // 
            // btnValida
            // 
            this.btnValida.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnValida.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValida.Location = new System.Drawing.Point(89, 165);
            this.btnValida.Name = "btnValida";
            this.btnValida.Size = new System.Drawing.Size(215, 66);
            this.btnValida.TabIndex = 236;
            this.btnValida.Text = "Valida";
            this.btnValida.UseVisualStyleBackColor = false;
            this.btnValida.Click += new System.EventHandler(this.btnValida_Click);
            // 
            // FrmValidaAccessoEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 313);
            this.Controls.Add(this.btnValida);
            this.Controls.Add(this.lblTitolo);
            this.Controls.Add(this.tbIDaderire);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmValidaAccessoEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmValidaAccessoEvento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmValidaAccessoEvento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIDaderire;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Button btnValida;
    }
}
