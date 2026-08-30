namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmClassi
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
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tbTitolo = new System.Windows.Forms.TextBox();
            this.lblIconDataProduzione2 = new System.Windows.Forms.Label();
            this.lblTitolo2 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumRecordTrovati = new System.Windows.Forms.Label();
            this.lvClassi = new System.Windows.Forms.ListView();
            this.lblIconEdizione = new System.Windows.Forms.Label();
            this.tbFiltroNome = new System.Windows.Forms.TextBox();
            this.lblCercaPerTitolo = new System.Windows.Forms.Label();
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.nudAnno = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.textBox1);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.label4);
            this.pnlDetails.Controls.Add(this.nudAnno);
            this.pnlDetails.Controls.Add(this.tbTitolo);
            this.pnlDetails.Controls.Add(this.lblIconDataProduzione2);
            this.pnlDetails.Controls.Add(this.lblTitolo2);
            this.pnlDetails.Controls.Add(this.btnAnnulla);
            this.pnlDetails.Controls.Add(this.btnAggiungi);
            this.pnlDetails.Controls.Add(this.lblTitolo);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(789, 0);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(510, 570);
            this.pnlDetails.TabIndex = 99;
            // 
            // tbTitolo
            // 
            this.tbTitolo.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitolo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbTitolo.Location = new System.Drawing.Point(54, 129);
            this.tbTitolo.Name = "tbTitolo";
            this.tbTitolo.Size = new System.Drawing.Size(171, 33);
            this.tbTitolo.TabIndex = 227;
            // 
            // lblIconDataProduzione2
            // 
            this.lblIconDataProduzione2.AutoSize = true;
            this.lblIconDataProduzione2.BackColor = System.Drawing.Color.Transparent;
            this.lblIconDataProduzione2.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconDataProduzione2.ForeColor = System.Drawing.Color.Black;
            this.lblIconDataProduzione2.Location = new System.Drawing.Point(22, 132);
            this.lblIconDataProduzione2.Name = "lblIconDataProduzione2";
            this.lblIconDataProduzione2.Size = new System.Drawing.Size(34, 25);
            this.lblIconDataProduzione2.TabIndex = 228;
            this.lblIconDataProduzione2.Text = "🚪";
            // 
            // lblTitolo2
            // 
            this.lblTitolo2.AutoSize = true;
            this.lblTitolo2.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo2.ForeColor = System.Drawing.Color.Gray;
            this.lblTitolo2.Location = new System.Drawing.Point(23, 103);
            this.lblTitolo2.Name = "lblTitolo2";
            this.lblTitolo2.Size = new System.Drawing.Size(54, 23);
            this.lblTitolo2.TabIndex = 226;
            this.lblTitolo2.Text = "Aula*";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulla.Location = new System.Drawing.Point(314, 509);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(117, 31);
            this.btnAnnulla.TabIndex = 225;
            this.btnAnnulla.Text = "↩️ Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAggiungi.Location = new System.Drawing.Point(17, 506);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(273, 36);
            this.btnAggiungi.TabIndex = 224;
            this.btnAggiungi.Text = "➕Aggiungi";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(20, 57);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(164, 38);
            this.lblTitolo.TabIndex = 192;
            this.lblTitolo.Text = "Crea Classi";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNumRecordTrovati);
            this.panel2.Controls.Add(this.lvClassi);
            this.panel2.Controls.Add(this.lblIconEdizione);
            this.panel2.Controls.Add(this.tbFiltroNome);
            this.panel2.Controls.Add(this.lblCercaPerTitolo);
            this.panel2.Controls.Add(this.btnVisualizza);
            this.panel2.Controls.Add(this.btnElimina);
            this.panel2.Controls.Add(this.btnModifica);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 570);
            this.panel2.TabIndex = 98;
            // 
            // lblNumRecordTrovati
            // 
            this.lblNumRecordTrovati.Font = new System.Drawing.Font("Coolvetica", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordTrovati.Location = new System.Drawing.Point(374, 74);
            this.lblNumRecordTrovati.Name = "lblNumRecordTrovati";
            this.lblNumRecordTrovati.Size = new System.Drawing.Size(249, 26);
            this.lblNumRecordTrovati.TabIndex = 230;
            this.lblNumRecordTrovati.Text = "Risultati trovati: 0";
            this.lblNumRecordTrovati.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lvClassi
            // 
            this.lvClassi.AllowDrop = true;
            this.lvClassi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1});
            this.lvClassi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClassi.FullRowSelect = true;
            this.lvClassi.HideSelection = false;
            this.lvClassi.Location = new System.Drawing.Point(39, 103);
            this.lvClassi.Name = "lvClassi";
            this.lvClassi.Size = new System.Drawing.Size(584, 442);
            this.lvClassi.TabIndex = 229;
            this.lvClassi.UseCompatibleStateImageBehavior = false;
            this.lvClassi.View = System.Windows.Forms.View.Details;
            this.lvClassi.SelectedIndexChanged += new System.EventHandler(this.lvClassi_SelectedIndexChanged);
            // 
            // lblIconEdizione
            // 
            this.lblIconEdizione.AutoSize = true;
            this.lblIconEdizione.BackColor = System.Drawing.Color.Transparent;
            this.lblIconEdizione.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconEdizione.ForeColor = System.Drawing.Color.Black;
            this.lblIconEdizione.Location = new System.Drawing.Point(43, 69);
            this.lblIconEdizione.Name = "lblIconEdizione";
            this.lblIconEdizione.Size = new System.Drawing.Size(32, 23);
            this.lblIconEdizione.TabIndex = 228;
            this.lblIconEdizione.Text = "🔍";
            // 
            // tbFiltroNome
            // 
            this.tbFiltroNome.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltroNome.Location = new System.Drawing.Point(81, 65);
            this.tbFiltroNome.Name = "tbFiltroNome";
            this.tbFiltroNome.Size = new System.Drawing.Size(302, 30);
            this.tbFiltroNome.TabIndex = 227;
            this.tbFiltroNome.TextChanged += new System.EventHandler(this.tbFiltroNome_TextChanged);
            // 
            // lblCercaPerTitolo
            // 
            this.lblCercaPerTitolo.AutoSize = true;
            this.lblCercaPerTitolo.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCercaPerTitolo.ForeColor = System.Drawing.Color.Gray;
            this.lblCercaPerTitolo.Location = new System.Drawing.Point(35, 39);
            this.lblCercaPerTitolo.Name = "lblCercaPerTitolo";
            this.lblCercaPerTitolo.Size = new System.Drawing.Size(139, 23);
            this.lblCercaPerTitolo.TabIndex = 226;
            this.lblCercaPerTitolo.Text = "Cerca per Titolo";
            // 
            // btnVisualizza
            // 
            this.btnVisualizza.Font = new System.Drawing.Font("Coolvetica", 14.25F);
            this.btnVisualizza.Location = new System.Drawing.Point(629, 103);
            this.btnVisualizza.Name = "btnVisualizza";
            this.btnVisualizza.Size = new System.Drawing.Size(117, 34);
            this.btnVisualizza.TabIndex = 188;
            this.btnVisualizza.Text = "👁️Visualizza";
            this.btnVisualizza.UseVisualStyleBackColor = true;
            this.btnVisualizza.Click += new System.EventHandler(this.btnVisualizza_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Font = new System.Drawing.Font("Coolvetica", 14.25F);
            this.btnElimina.Location = new System.Drawing.Point(629, 185);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(118, 34);
            this.btnElimina.TabIndex = 187;
            this.btnElimina.Text = "🗑️Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Font = new System.Drawing.Font("Coolvetica", 14.25F);
            this.btnModifica.Location = new System.Drawing.Point(629, 143);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(118, 34);
            this.btnModifica.TabIndex = 186;
            this.btnModifica.Text = "✍️Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // nudAnno
            // 
            this.nudAnno.Location = new System.Drawing.Point(58, 263);
            this.nudAnno.Name = "nudAnno";
            this.nudAnno.Size = new System.Drawing.Size(167, 30);
            this.nudAnno.TabIndex = 279;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(54, 199);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 33);
            this.textBox1.TabIndex = 281;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 25);
            this.label3.TabIndex = 282;
            this.label3.Text = "🪪";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(23, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 280;
            this.label4.Text = "Sezione*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 25);
            this.label1.TabIndex = 284;
            this.label1.Text = "🎓";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(23, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 283;
            this.label2.Text = "Anno*";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sigla";
            this.columnHeader5.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Aula";
            this.columnHeader6.Width = 79;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Indirizzo";
            this.columnHeader1.Width = 155;
            // 
            // FrmClassi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 570);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmClassi";
            this.Text = "FrmClassi";
            this.Load += new System.EventHandler(this.FrmClassi_Load);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TextBox tbTitolo;
        private System.Windows.Forms.Label lblIconDataProduzione2;
        private System.Windows.Forms.Label lblTitolo2;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNumRecordTrovati;
        private System.Windows.Forms.ListView lvClassi;
        private System.Windows.Forms.Label lblIconEdizione;
        private System.Windows.Forms.TextBox tbFiltroNome;
        private System.Windows.Forms.Label lblCercaPerTitolo;
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAnno;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}