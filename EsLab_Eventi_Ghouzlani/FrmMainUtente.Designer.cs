namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmMainUtente
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
            this.lblTitolo = new System.Windows.Forms.Label();
            this.lvAttività = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lvEventi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPartecipa = new System.Windows.Forms.Button();
            this.lblIconEdizione = new System.Windows.Forms.Label();
            this.tbFiltroEventi = new System.Windows.Forms.TextBox();
            this.lblCercaPerTitolo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFiltroAttivita = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIscritto = new System.Windows.Forms.Label();
            this.lblCodicePartecipazione = new System.Windows.Forms.Label();
            this.btnCopia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Location = new System.Drawing.Point(12, 22);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(101, 38);
            this.lblTitolo.TabIndex = 231;
            this.lblTitolo.Text = "Eventi";
            // 
            // lvAttività
            // 
            this.lvAttività.AllowDrop = true;
            this.lvAttività.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvAttività.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAttività.FullRowSelect = true;
            this.lvAttività.HideSelection = false;
            this.lvAttività.Location = new System.Drawing.Point(634, 122);
            this.lvAttività.Name = "lvAttività";
            this.lvAttività.Size = new System.Drawing.Size(584, 442);
            this.lvAttività.TabIndex = 232;
            this.lvAttività.UseCompatibleStateImageBehavior = false;
            this.lvAttività.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ordine";
            this.columnHeader5.Width = 67;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Titolo";
            this.columnHeader6.Width = 179;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 3;
            this.columnHeader7.Text = "Dalle";
            this.columnHeader7.Width = 68;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 4;
            this.columnHeader8.Text = "Alle";
            this.columnHeader8.Width = 78;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 2;
            this.columnHeader9.Text = "Descrizione";
            this.columnHeader9.Width = 184;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(627, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 38);
            this.label1.TabIndex = 233;
            this.label1.Text = "Attività";
            // 
            // lvEventi
            // 
            this.lvEventi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader10});
            this.lvEventi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvEventi.FullRowSelect = true;
            this.lvEventi.HideSelection = false;
            this.lvEventi.Location = new System.Drawing.Point(19, 122);
            this.lvEventi.Name = "lvEventi";
            this.lvEventi.Size = new System.Drawing.Size(584, 442);
            this.lvEventi.TabIndex = 234;
            this.lvEventi.UseCompatibleStateImageBehavior = false;
            this.lvEventi.View = System.Windows.Forms.View.Details;
            this.lvEventi.SelectedIndexChanged += new System.EventHandler(this.lvEventi_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titolo";
            this.columnHeader1.Width = 186;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Descrizione";
            this.columnHeader4.Width = 183;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dal";
            this.columnHeader2.Width = 63;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Al";
            this.columnHeader3.Width = 59;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Prezzo";
            this.columnHeader10.Width = 86;
            // 
            // btnPartecipa
            // 
            this.btnPartecipa.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPartecipa.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartecipa.Location = new System.Drawing.Point(19, 570);
            this.btnPartecipa.Name = "btnPartecipa";
            this.btnPartecipa.Size = new System.Drawing.Size(177, 66);
            this.btnPartecipa.TabIndex = 235;
            this.btnPartecipa.Text = "Iscriviti";
            this.btnPartecipa.UseVisualStyleBackColor = false;
            this.btnPartecipa.Visible = false;
            this.btnPartecipa.Click += new System.EventHandler(this.btnPartecipa_Click);
            // 
            // lblIconEdizione
            // 
            this.lblIconEdizione.AutoSize = true;
            this.lblIconEdizione.BackColor = System.Drawing.Color.Transparent;
            this.lblIconEdizione.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconEdizione.ForeColor = System.Drawing.Color.Black;
            this.lblIconEdizione.Location = new System.Drawing.Point(20, 90);
            this.lblIconEdizione.Name = "lblIconEdizione";
            this.lblIconEdizione.Size = new System.Drawing.Size(32, 23);
            this.lblIconEdizione.TabIndex = 238;
            this.lblIconEdizione.Text = "🔍";
            // 
            // tbFiltroEventi
            // 
            this.tbFiltroEventi.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltroEventi.Location = new System.Drawing.Point(58, 86);
            this.tbFiltroEventi.Name = "tbFiltroEventi";
            this.tbFiltroEventi.Size = new System.Drawing.Size(302, 30);
            this.tbFiltroEventi.TabIndex = 237;
            this.tbFiltroEventi.TextChanged += new System.EventHandler(this.TbFiltroEventi_TextChanged);
            // 
            // lblCercaPerTitolo
            // 
            this.lblCercaPerTitolo.AutoSize = true;
            this.lblCercaPerTitolo.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCercaPerTitolo.ForeColor = System.Drawing.Color.Gray;
            this.lblCercaPerTitolo.Location = new System.Drawing.Point(12, 60);
            this.lblCercaPerTitolo.Name = "lblCercaPerTitolo";
            this.lblCercaPerTitolo.Size = new System.Drawing.Size(139, 23);
            this.lblCercaPerTitolo.TabIndex = 236;
            this.lblCercaPerTitolo.Text = "Cerca per Titolo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(638, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 241;
            this.label2.Text = "🔍";
            // 
            // tbFiltroAttivita
            // 
            this.tbFiltroAttivita.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltroAttivita.Location = new System.Drawing.Point(676, 87);
            this.tbFiltroAttivita.Name = "tbFiltroAttivita";
            this.tbFiltroAttivita.Size = new System.Drawing.Size(302, 30);
            this.tbFiltroAttivita.TabIndex = 240;
            this.tbFiltroAttivita.TextChanged += new System.EventHandler(this.TbFiltroAttivita_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(630, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 23);
            this.label3.TabIndex = 239;
            this.label3.Text = "Cerca per Titolo";
            // 
            // lblIscritto
            // 
            this.lblIscritto.AutoSize = true;
            this.lblIscritto.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIscritto.ForeColor = System.Drawing.Color.Gray;
            this.lblIscritto.Location = new System.Drawing.Point(202, 570);
            this.lblIscritto.Name = "lblIscritto";
            this.lblIscritto.Size = new System.Drawing.Size(267, 23);
            this.lblIscritto.TabIndex = 242;
            this.lblIscritto.Text = "Sei già iscritto a questo evento";
            // 
            // lblCodicePartecipazione
            // 
            this.lblCodicePartecipazione.AutoSize = true;
            this.lblCodicePartecipazione.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodicePartecipazione.Location = new System.Drawing.Point(202, 593);
            this.lblCodicePartecipazione.Name = "lblCodicePartecipazione";
            this.lblCodicePartecipazione.Size = new System.Drawing.Size(443, 38);
            this.lblCodicePartecipazione.TabIndex = 243;
            this.lblCodicePartecipazione.Text = "Codice Partecipazione: #XXXXX ";
            // 
            // btnCopia
            // 
            this.btnCopia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopia.Location = new System.Drawing.Point(642, 597);
            this.btnCopia.Name = "btnCopia";
            this.btnCopia.Size = new System.Drawing.Size(93, 34);
            this.btnCopia.TabIndex = 244;
            this.btnCopia.Text = "📋 copia";
            this.btnCopia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopia.UseVisualStyleBackColor = true;
            this.btnCopia.Visible = false;
            this.btnCopia.Click += new System.EventHandler(this.btnCopia_Click);
            // 
            // FrmMainUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 648);
            this.Controls.Add(this.btnCopia);
            this.Controls.Add(this.lblCodicePartecipazione);
            this.Controls.Add(this.lblIscritto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFiltroAttivita);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIconEdizione);
            this.Controls.Add(this.tbFiltroEventi);
            this.Controls.Add(this.lblCercaPerTitolo);
            this.Controls.Add(this.btnPartecipa);
            this.Controls.Add(this.lvEventi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvAttività);
            this.Controls.Add(this.lblTitolo);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmMainUtente";
            this.Text = "FrmMainStudente";
            this.Load += new System.EventHandler(this.FrmMainUtente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.ListView lvAttività;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvEventi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnPartecipa;
        private System.Windows.Forms.Label lblIconEdizione;
        private System.Windows.Forms.TextBox tbFiltroEventi;
        private System.Windows.Forms.Label lblCercaPerTitolo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFiltroAttivita;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIscritto;
        private System.Windows.Forms.Label lblCodicePartecipazione;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button btnCopia;
    }
}