namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmAttivita
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rtbDescrizione = new System.Windows.Forms.RichTextBox();
            this.lblSinossi = new System.Windows.Forms.Label();
            this.lblIconSinossi = new System.Windows.Forms.Label();
            this.lblDataProduzione = new System.Windows.Forms.Label();
            this.lblIconDataProduzione = new System.Windows.Forms.Label();
            this.dtpDataProduzione = new System.Windows.Forms.DateTimePicker();
            this.tbTitolo = new System.Windows.Forms.TextBox();
            this.lblIconDataProduzione2 = new System.Windows.Forms.Label();
            this.lblTitolo2 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumRecordTrovati = new System.Windows.Forms.Label();
            this.lvAttività = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblIconEdizione = new System.Windows.Forms.Label();
            this.tbFiltroNome = new System.Windows.Forms.TextBox();
            this.lblCercaPerTitolo = new System.Windows.Forms.Label();
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.dateTimePicker1);
            this.pnlDetails.Controls.Add(this.rtbDescrizione);
            this.pnlDetails.Controls.Add(this.lblSinossi);
            this.pnlDetails.Controls.Add(this.lblIconSinossi);
            this.pnlDetails.Controls.Add(this.lblDataProduzione);
            this.pnlDetails.Controls.Add(this.lblIconDataProduzione);
            this.pnlDetails.Controls.Add(this.dtpDataProduzione);
            this.pnlDetails.Controls.Add(this.tbTitolo);
            this.pnlDetails.Controls.Add(this.lblIconDataProduzione2);
            this.pnlDetails.Controls.Add(this.lblTitolo2);
            this.pnlDetails.Controls.Add(this.btnAnnulla);
            this.pnlDetails.Controls.Add(this.btnAggiungi);
            this.pnlDetails.Controls.Add(this.lblTitolo);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(799, 0);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(510, 662);
            this.pnlDetails.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(232, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 277;
            this.label1.Text = "Alle*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(231, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 278;
            this.label2.Text = "🗓️";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(271, 204);
            this.dateTimePicker1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 30);
            this.dateTimePicker1.TabIndex = 276;
            // 
            // rtbDescrizione
            // 
            this.rtbDescrizione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescrizione.Location = new System.Drawing.Point(66, 281);
            this.rtbDescrizione.Name = "rtbDescrizione";
            this.rtbDescrizione.Size = new System.Drawing.Size(365, 225);
            this.rtbDescrizione.TabIndex = 237;
            this.rtbDescrizione.Text = "";
            // 
            // lblSinossi
            // 
            this.lblSinossi.AutoSize = true;
            this.lblSinossi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinossi.ForeColor = System.Drawing.Color.Gray;
            this.lblSinossi.Location = new System.Drawing.Point(31, 255);
            this.lblSinossi.Name = "lblSinossi";
            this.lblSinossi.Size = new System.Drawing.Size(57, 23);
            this.lblSinossi.TabIndex = 248;
            this.lblSinossi.Text = "Testo";
            // 
            // lblIconSinossi
            // 
            this.lblIconSinossi.AutoSize = true;
            this.lblIconSinossi.BackColor = System.Drawing.Color.Transparent;
            this.lblIconSinossi.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconSinossi.ForeColor = System.Drawing.Color.Black;
            this.lblIconSinossi.Location = new System.Drawing.Point(30, 284);
            this.lblIconSinossi.Name = "lblIconSinossi";
            this.lblIconSinossi.Size = new System.Drawing.Size(34, 25);
            this.lblIconSinossi.TabIndex = 249;
            this.lblIconSinossi.Text = "💬";
            // 
            // lblDataProduzione
            // 
            this.lblDataProduzione.AutoSize = true;
            this.lblDataProduzione.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataProduzione.ForeColor = System.Drawing.Color.Gray;
            this.lblDataProduzione.Location = new System.Drawing.Point(27, 176);
            this.lblDataProduzione.Name = "lblDataProduzione";
            this.lblDataProduzione.Size = new System.Drawing.Size(59, 23);
            this.lblDataProduzione.TabIndex = 233;
            this.lblDataProduzione.Text = "Dalle*";
            // 
            // lblIconDataProduzione
            // 
            this.lblIconDataProduzione.AutoSize = true;
            this.lblIconDataProduzione.BackColor = System.Drawing.Color.Transparent;
            this.lblIconDataProduzione.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconDataProduzione.ForeColor = System.Drawing.Color.Black;
            this.lblIconDataProduzione.Location = new System.Drawing.Point(26, 205);
            this.lblIconDataProduzione.Name = "lblIconDataProduzione";
            this.lblIconDataProduzione.Size = new System.Drawing.Size(34, 25);
            this.lblIconDataProduzione.TabIndex = 234;
            this.lblIconDataProduzione.Text = "🗓️";
            // 
            // dtpDataProduzione
            // 
            this.dtpDataProduzione.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDataProduzione.Location = new System.Drawing.Point(66, 205);
            this.dtpDataProduzione.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataProduzione.Name = "dtpDataProduzione";
            this.dtpDataProduzione.Size = new System.Drawing.Size(156, 30);
            this.dtpDataProduzione.TabIndex = 232;
            // 
            // tbTitolo
            // 
            this.tbTitolo.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitolo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbTitolo.Location = new System.Drawing.Point(54, 129);
            this.tbTitolo.Name = "tbTitolo";
            this.tbTitolo.Size = new System.Drawing.Size(369, 33);
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
            this.lblIconDataProduzione2.Text = "🪪";
            // 
            // lblTitolo2
            // 
            this.lblTitolo2.AutoSize = true;
            this.lblTitolo2.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo2.ForeColor = System.Drawing.Color.Gray;
            this.lblTitolo2.Location = new System.Drawing.Point(23, 103);
            this.lblTitolo2.Name = "lblTitolo2";
            this.lblTitolo2.Size = new System.Drawing.Size(68, 23);
            this.lblTitolo2.TabIndex = 226;
            this.lblTitolo2.Text = "Titolo*";
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
            this.btnAggiungi.Location = new System.Drawing.Point(27, 509);
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
            this.lblTitolo.Size = new System.Drawing.Size(192, 38);
            this.lblTitolo.TabIndex = 192;
            this.lblTitolo.Text = "Crea Attività";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNumRecordTrovati);
            this.panel2.Controls.Add(this.lvAttività);
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
            this.panel2.Size = new System.Drawing.Size(771, 662);
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
            // lvAttività
            // 
            this.lvAttività.AllowDrop = true;
            this.lvAttività.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvAttività.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAttività.FullRowSelect = true;
            this.lvAttività.HideSelection = false;
            this.lvAttività.Location = new System.Drawing.Point(39, 103);
            this.lvAttività.Name = "lvAttività";
            this.lvAttività.Size = new System.Drawing.Size(584, 442);
            this.lvAttività.TabIndex = 229;
            this.lvAttività.UseCompatibleStateImageBehavior = false;
            this.lvAttività.View = System.Windows.Forms.View.Details;
            this.lvAttività.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvAttività_ItemDrag);
            this.lvAttività.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvAttività_DragDrop);
            this.lvAttività.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvAttività_DragEnter);
            this.lvAttività.DragOver += new System.Windows.Forms.DragEventHandler(this.lvAttività_DragOver);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titolo";
            this.columnHeader1.Width = 217;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dalle";
            this.columnHeader2.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alle";
            this.columnHeader3.Width = 134;
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
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ordine";
            this.columnHeader4.Width = 67;
            // 
            // FrmAttivita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 662);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmAttivita";
            this.Text = "FrmAttivita";
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RichTextBox rtbDescrizione;
        private System.Windows.Forms.Label lblSinossi;
        private System.Windows.Forms.Label lblIconSinossi;
        private System.Windows.Forms.Label lblDataProduzione;
        private System.Windows.Forms.Label lblIconDataProduzione;
        private System.Windows.Forms.DateTimePicker dtpDataProduzione;
        private System.Windows.Forms.TextBox tbTitolo;
        private System.Windows.Forms.Label lblIconDataProduzione2;
        private System.Windows.Forms.Label lblTitolo2;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNumRecordTrovati;
        private System.Windows.Forms.ListView lvAttività;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblIconEdizione;
        private System.Windows.Forms.TextBox tbFiltroNome;
        private System.Windows.Forms.Label lblCercaPerTitolo;
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnModifica;
    }
}