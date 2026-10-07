namespace EsLab_Eventi_Ghouzlani
{
    partial class usEvento
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbLocandina = new System.Windows.Forms.PictureBox();
            this.lblGiorno = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocandina)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLocandina
            // 
            this.pbLocandina.Image = global::EsLab_Eventi_Ghouzlani.Properties.Resources.locandinaCarica;
            this.pbLocandina.Location = new System.Drawing.Point(6, 81);
            this.pbLocandina.Name = "pbLocandina";
            this.pbLocandina.Size = new System.Drawing.Size(242, 150);
            this.pbLocandina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLocandina.TabIndex = 0;
            this.pbLocandina.TabStop = false;
            // 
            // lblGiorno
            // 
            this.lblGiorno.AutoSize = true;
            this.lblGiorno.Font = new System.Drawing.Font("Coolvetica", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiorno.Location = new System.Drawing.Point(3, 1);
            this.lblGiorno.Name = "lblGiorno";
            this.lblGiorno.Size = new System.Drawing.Size(87, 77);
            this.lblGiorno.TabIndex = 1;
            this.lblGiorno.Text = "16";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 288);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(239, 67);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "L";
            // 
            // usEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblGiorno);
            this.Controls.Add(this.pbLocandina);
            this.Name = "usEvento";
            this.Size = new System.Drawing.Size(251, 361);
            ((System.ComponentModel.ISupportInitialize)(this.pbLocandina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLocandina;
        private System.Windows.Forms.Label lblGiorno;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
