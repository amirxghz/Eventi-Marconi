namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmIndirizzi
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.lblIconDataProduzione2 = new System.Windows.Forms.Label();
            this.lblTitolo2 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumRecordTrovati = new System.Windows.Forms.Label();
            this.lvIndirizzi = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblIconEdizione = new System.Windows.Forms.Label();
            this.tbFiltroNome = new System.Windows.Forms.TextBox();
            this.lblCercaPerNome = new System.Windows.Forms.Label();
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.pnlDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.tbNome);
            this.pnlDetails.Controls.Add(this.lblIconDataProduzione2);
            this.pnlDetails.Controls.Add(this.lblTitolo2);
            this.pnlDetails.Controls.Add(this.btnAnnulla);
            this.pnlDetails.Controls.Add(this.btnAggiungi);
            this.pnlDetails.Controls.Add(this.lblTitolo);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(754, 0);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(510, 566);
            this.pnlDetails.TabIndex = 97;
            // 
            // tbNome
            // 
            this.tbNome.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNome.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbNome.Location = new System.Drawing.Point(50, 106);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(369, 33);
            this.tbNome.TabIndex = 1;
            // 
            // lblIconDataProduzione2
            // 
            this.lblIconDataProduzione2.AutoSize = true;
            this.lblIconDataProduzione2.BackColor = System.Drawing.Color.Transparent;
            this.lblIconDataProduzione2.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconDataProduzione2.ForeColor = System.Drawing.Color.Black;
            this.lblIconDataProduzione2.Location = new System.Drawing.Point(18, 109);
            this.lblIconDataProduzione2.Name = "lblIconDataProduzione2";
            this.lblIconDataProduzione2.Size = new System.Drawing.Size(34, 25);
            this.lblIconDataProduzione2.TabIndex = 228;
            this.lblIconDataProduzione2.Text = "🪪";
            // 
            // lblTitolo2
            // 
            this.lblTitolo2.AutoSize = true;
            this.lblTitolo2.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo2.ForeColor = System.Drawing.Color.Gray;
            this.lblTitolo2.Location = new System.Drawing.Point(19, 80);
            this.lblTitolo2.Name = "lblTitolo2";
            this.lblTitolo2.Size = new System.Drawing.Size(65, 23);
            this.lblTitolo2.TabIndex = 226;
            this.lblTitolo2.Text = "Nome*";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulla.Location = new System.Drawing.Point(302, 148);
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
            this.btnAggiungi.Location = new System.Drawing.Point(23, 145);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(273, 36);
            this.btnAggiungi.TabIndex = 2;
            this.btnAggiungi.Text = "➕Aggiungi";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(16, 42);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(191, 38);
            this.lblTitolo.TabIndex = 192;
            this.lblTitolo.Text = "Crea Indirizzo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNumRecordTrovati);
            this.panel2.Controls.Add(this.lvIndirizzi);
            this.panel2.Controls.Add(this.lblIconEdizione);
            this.panel2.Controls.Add(this.tbFiltroNome);
            this.panel2.Controls.Add(this.lblCercaPerNome);
            this.panel2.Controls.Add(this.btnVisualizza);
            this.panel2.Controls.Add(this.btnElimina);
            this.panel2.Controls.Add(this.btnModifica);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 566);
            this.panel2.TabIndex = 96;
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
            // lvIndirizzi
            // 
            this.lvIndirizzi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader1});
            this.lvIndirizzi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvIndirizzi.FullRowSelect = true;
            this.lvIndirizzi.HideSelection = false;
            this.lvIndirizzi.Location = new System.Drawing.Point(39, 103);
            this.lvIndirizzi.Name = "lvIndirizzi";
            this.lvIndirizzi.Size = new System.Drawing.Size(584, 442);
            this.lvIndirizzi.TabIndex = 229;
            this.lvIndirizzi.UseCompatibleStateImageBehavior = false;
            this.lvIndirizzi.View = System.Windows.Forms.View.Details;
            this.lvIndirizzi.SelectedIndexChanged += new System.EventHandler(this.lvIndirizzi_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nome";
            this.columnHeader3.Width = 343;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Numero Iscritti";
            this.columnHeader1.Width = 146;
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
            this.tbFiltroNome.Location = new System.Drawing.Point(76, 66);
            this.tbFiltroNome.Name = "tbFiltroNome";
            this.tbFiltroNome.Size = new System.Drawing.Size(302, 30);
            this.tbFiltroNome.TabIndex = 227;
            this.tbFiltroNome.TextChanged += new System.EventHandler(this.tbFiltroNome_TextChanged);
            // 
            // lblCercaPerNome
            // 
            this.lblCercaPerNome.AutoSize = true;
            this.lblCercaPerNome.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCercaPerNome.ForeColor = System.Drawing.Color.Gray;
            this.lblCercaPerNome.Location = new System.Drawing.Point(35, 39);
            this.lblCercaPerNome.Name = "lblCercaPerNome";
            this.lblCercaPerNome.Size = new System.Drawing.Size(139, 23);
            this.lblCercaPerNome.TabIndex = 226;
            this.lblCercaPerNome.Text = "Cerca per Titolo";
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
            // FrmIndirizzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 566);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmIndirizzi";
            this.Text = "FrmIndirizzi";
            this.Load += new System.EventHandler(this.FrmIndirizzi_Load);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label lblIconDataProduzione2;
        private System.Windows.Forms.Label lblTitolo2;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNumRecordTrovati;
        private System.Windows.Forms.ListView lvIndirizzi;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblIconEdizione;
        private System.Windows.Forms.TextBox tbFiltroNome;
        private System.Windows.Forms.Label lblCercaPerNome;
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnModifica;
    }
}

