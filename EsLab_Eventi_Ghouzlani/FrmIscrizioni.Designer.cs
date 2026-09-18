namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmIscrizioni
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
            this.lblIconEdizione = new System.Windows.Forms.Label();
            this.tbFiltroEventi = new System.Windows.Forms.TextBox();
            this.lblCercaPerTitolo = new System.Windows.Forms.Label();
            this.lvEventi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitolo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFiltroNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvIscrizioni = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.chxbPagato = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbDescrizione = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblIconEdizione
            // 
            this.lblIconEdizione.AutoSize = true;
            this.lblIconEdizione.BackColor = System.Drawing.Color.Transparent;
            this.lblIconEdizione.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconEdizione.ForeColor = System.Drawing.Color.Black;
            this.lblIconEdizione.Location = new System.Drawing.Point(15, 100);
            this.lblIconEdizione.Name = "lblIconEdizione";
            this.lblIconEdizione.Size = new System.Drawing.Size(32, 23);
            this.lblIconEdizione.TabIndex = 243;
            this.lblIconEdizione.Text = "🔍";
            // 
            // tbFiltroEventi
            // 
            this.tbFiltroEventi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltroEventi.Location = new System.Drawing.Point(53, 96);
            this.tbFiltroEventi.Name = "tbFiltroEventi";
            this.tbFiltroEventi.Size = new System.Drawing.Size(302, 30);
            this.tbFiltroEventi.TabIndex = 242;
            this.tbFiltroEventi.TextChanged += new System.EventHandler(this.tbFiltroEventi_TextChanged);
            // 
            // lblCercaPerTitolo
            // 
            this.lblCercaPerTitolo.AutoSize = true;
            this.lblCercaPerTitolo.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCercaPerTitolo.ForeColor = System.Drawing.Color.Gray;
            this.lblCercaPerTitolo.Location = new System.Drawing.Point(7, 70);
            this.lblCercaPerTitolo.Name = "lblCercaPerTitolo";
            this.lblCercaPerTitolo.Size = new System.Drawing.Size(139, 23);
            this.lblCercaPerTitolo.TabIndex = 241;
            this.lblCercaPerTitolo.Text = "Cerca per Titolo";
            // 
            // lvEventi
            // 
            this.lvEventi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvEventi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvEventi.FullRowSelect = true;
            this.lvEventi.HideSelection = false;
            this.lvEventi.Location = new System.Drawing.Point(9, 132);
            this.lvEventi.Name = "lvEventi";
            this.lvEventi.Size = new System.Drawing.Size(584, 442);
            this.lvEventi.TabIndex = 240;
            this.lvEventi.UseCompatibleStateImageBehavior = false;
            this.lvEventi.View = System.Windows.Forms.View.Details;
            this.lvEventi.SelectedIndexChanged += new System.EventHandler(this.lvEventi_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titolo";
            this.columnHeader1.Width = 349;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dal";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Al";
            this.columnHeader3.Width = 105;
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(7, 32);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(101, 38);
            this.lblTitolo.TabIndex = 239;
            this.lblTitolo.Text = "Eventi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(664, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 248;
            this.label1.Text = "🔍";
            // 
            // tbFiltroNome
            // 
            this.tbFiltroNome.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltroNome.Location = new System.Drawing.Point(707, 96);
            this.tbFiltroNome.Name = "tbFiltroNome";
            this.tbFiltroNome.Size = new System.Drawing.Size(302, 30);
            this.tbFiltroNome.TabIndex = 247;
            this.tbFiltroNome.TextChanged += new System.EventHandler(this.tbFiltroNome_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(661, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 246;
            this.label2.Text = "Cerca per Nome";
            // 
            // lvIscrizioni
            // 
            this.lvIscrizioni.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8});
            this.lvIscrizioni.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvIscrizioni.FullRowSelect = true;
            this.lvIscrizioni.HideSelection = false;
            this.lvIscrizioni.Location = new System.Drawing.Point(668, 132);
            this.lvIscrizioni.Name = "lvIscrizioni";
            this.lvIscrizioni.Size = new System.Drawing.Size(584, 442);
            this.lvIscrizioni.TabIndex = 245;
            this.lvIscrizioni.UseCompatibleStateImageBehavior = false;
            this.lvIscrizioni.View = System.Windows.Forms.View.Details;
            this.lvIscrizioni.SelectedIndexChanged += new System.EventHandler(this.lvIscrizioni_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Nominativo";
            this.columnHeader9.Width = 319;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Classe";
            this.columnHeader5.Width = 76;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Partecipato";
            this.columnHeader7.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Pagato";
            this.columnHeader8.Width = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(661, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 38);
            this.label3.TabIndex = 244;
            this.label3.Text = "Iscrizioni";
            // 
            // chxbPagato
            // 
            this.chxbPagato.AutoSize = true;
            this.chxbPagato.Enabled = false;
            this.chxbPagato.Location = new System.Drawing.Point(1258, 163);
            this.chxbPagato.Name = "chxbPagato";
            this.chxbPagato.Size = new System.Drawing.Size(130, 26);
            this.chxbPagato.TabIndex = 249;
            this.chxbPagato.Text = "Ha pagato?";
            this.chxbPagato.UseVisualStyleBackColor = true;
            this.chxbPagato.CheckedChanged += new System.EventHandler(this.chxbPagato_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Coolvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 577);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 250;
            this.label4.Text = "Descrizione";
            // 
            // rtbDescrizione
            // 
            this.rtbDescrizione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescrizione.Location = new System.Drawing.Point(9, 606);
            this.rtbDescrizione.Name = "rtbDescrizione";
            this.rtbDescrizione.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbDescrizione.Size = new System.Drawing.Size(584, 96);
            this.rtbDescrizione.TabIndex = 251;
            this.rtbDescrizione.Text = "";
            // 
            // FrmIscrizioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 712);
            this.Controls.Add(this.rtbDescrizione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chxbPagato);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFiltroNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvIscrizioni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIconEdizione);
            this.Controls.Add(this.tbFiltroEventi);
            this.Controls.Add(this.lblCercaPerTitolo);
            this.Controls.Add(this.lvEventi);
            this.Controls.Add(this.lblTitolo);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmIscrizioni";
            this.Text = "FrmIscrizioni";
            this.Load += new System.EventHandler(this.FrmIscrizioni_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIconEdizione;
        private System.Windows.Forms.TextBox tbFiltroEventi;
        private System.Windows.Forms.Label lblCercaPerTitolo;
        private System.Windows.Forms.ListView lvEventi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFiltroNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvIscrizioni;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.CheckBox chxbPagato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbDescrizione;
    }
}
