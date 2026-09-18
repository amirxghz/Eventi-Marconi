namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmPartecipa
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
            this.btnPartecipa = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.lvAttività = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitolo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEvento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrezzo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPartecipa
            // 
            this.btnPartecipa.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPartecipa.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartecipa.Location = new System.Drawing.Point(62, 525);
            this.btnPartecipa.Name = "btnPartecipa";
            this.btnPartecipa.Size = new System.Drawing.Size(337, 66);
            this.btnPartecipa.TabIndex = 236;
            this.btnPartecipa.Text = "Iscriviti";
            this.btnPartecipa.UseVisualStyleBackColor = false;
            this.btnPartecipa.Click += new System.EventHandler(this.btnPartecipa_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulla.Location = new System.Drawing.Point(3, 2);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(55, 66);
            this.btnAnnulla.TabIndex = 237;
            this.btnAnnulla.Text = "↩️  ";
            this.btnAnnulla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // lvAttività
            // 
            this.lvAttività.AllowDrop = true;
            this.lvAttività.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvAttività.Font = new System.Drawing.Font("Coolvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAttività.FullRowSelect = true;
            this.lvAttività.HideSelection = false;
            this.lvAttività.Location = new System.Drawing.Point(62, 194);
            this.lvAttività.Name = "lvAttività";
            this.lvAttività.Size = new System.Drawing.Size(337, 249);
            this.lvAttività.TabIndex = 238;
            this.lvAttività.UseCompatibleStateImageBehavior = false;
            this.lvAttività.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Titolo";
            this.columnHeader6.Width = 179;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Dalle";
            this.columnHeader7.Width = 68;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Alle";
            this.columnHeader8.Width = 78;
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTitolo.Location = new System.Drawing.Point(55, 153);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(123, 38);
            this.lblTitolo.TabIndex = 239;
            this.lblTitolo.Text = "Attività";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(55, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 38);
            this.label1.TabIndex = 240;
            this.label1.Text = "Evento";
            // 
            // cbEvento
            // 
            this.cbEvento.FormattingEnabled = true;
            this.cbEvento.Location = new System.Drawing.Point(62, 104);
            this.cbEvento.Name = "cbEvento";
            this.cbEvento.Size = new System.Drawing.Size(337, 30);
            this.cbEvento.TabIndex = 283;
            this.cbEvento.SelectedIndexChanged += new System.EventHandler(this.CbEvento_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(55, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 38);
            this.label2.TabIndex = 284;
            this.label2.Text = "Prezzo";
            // 
            // lblPrezzo
            // 
            this.lblPrezzo.AutoSize = true;
            this.lblPrezzo.Font = new System.Drawing.Font("Coolvetica", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezzo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrezzo.Location = new System.Drawing.Point(55, 484);
            this.lblPrezzo.Name = "lblPrezzo";
            this.lblPrezzo.Size = new System.Drawing.Size(98, 38);
            this.lblPrezzo.TabIndex = 285;
            this.lblPrezzo.Text = "Gratis";
            // 
            // FrmPartecipa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 602);
            this.Controls.Add(this.lblPrezzo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEvento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitolo);
            this.Controls.Add(this.lvAttività);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnPartecipa);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmPartecipa";
            this.Text = "FrmPartecipa";
            this.Load += new System.EventHandler(this.FrmPartecipa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPartecipa;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.ListView lvAttività;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrezzo;
    }
}