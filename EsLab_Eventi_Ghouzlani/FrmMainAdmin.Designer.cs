namespace EsLab_Eventi_Ghouzlani
{
    partial class FrmMainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUtenti = new System.Windows.Forms.Button();
            this.btnClassi = new System.Windows.Forms.Button();
            this.btnEventi = new System.Windows.Forms.Button();
            this.btnIndirizzi = new System.Windows.Forms.Button();
            this.btnIscrizioni = new System.Windows.Forms.Button();
            this.btnValida = new System.Windows.Forms.Button();
            this.btnAttività = new System.Windows.Forms.Button();
            this.btnProfilo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBenvenuto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(66)))), ((int)(((byte)(137)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnProfilo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 83);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(66)))), ((int)(((byte)(137)))));
            this.flowLayoutPanel1.Controls.Add(this.lblBenvenuto);
            this.flowLayoutPanel1.Controls.Add(this.btnEventi);
            this.flowLayoutPanel1.Controls.Add(this.btnAttività);
            this.flowLayoutPanel1.Controls.Add(this.btnIscrizioni);
            this.flowLayoutPanel1.Controls.Add(this.btnValida);
            this.flowLayoutPanel1.Controls.Add(this.btnUtenti);
            this.flowLayoutPanel1.Controls.Add(this.btnClassi);
            this.flowLayoutPanel1.Controls.Add(this.btnIndirizzi);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 83);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(201, 598);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnUtenti
            // 
            this.btnUtenti.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtenti.Location = new System.Drawing.Point(3, 329);
            this.btnUtenti.Name = "btnUtenti";
            this.btnUtenti.Size = new System.Drawing.Size(193, 61);
            this.btnUtenti.TabIndex = 0;
            this.btnUtenti.Text = "👥Utenti";
            this.btnUtenti.UseVisualStyleBackColor = true;
            this.btnUtenti.Click += new System.EventHandler(this.btnUtenti_Click);
            // 
            // btnClassi
            // 
            this.btnClassi.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassi.Location = new System.Drawing.Point(3, 396);
            this.btnClassi.Name = "btnClassi";
            this.btnClassi.Size = new System.Drawing.Size(193, 61);
            this.btnClassi.TabIndex = 1;
            this.btnClassi.Text = "📚Classi";
            this.btnClassi.UseVisualStyleBackColor = true;
            this.btnClassi.Click += new System.EventHandler(this.btnClassi_Click);
            // 
            // btnEventi
            // 
            this.btnEventi.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventi.Location = new System.Drawing.Point(3, 61);
            this.btnEventi.Name = "btnEventi";
            this.btnEventi.Size = new System.Drawing.Size(193, 61);
            this.btnEventi.TabIndex = 2;
            this.btnEventi.Text = "🎉Eventi";
            this.btnEventi.UseVisualStyleBackColor = true;
            this.btnEventi.Click += new System.EventHandler(this.btnEventi_Click);
            // 
            // btnIndirizzi
            // 
            this.btnIndirizzi.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndirizzi.Location = new System.Drawing.Point(3, 463);
            this.btnIndirizzi.Name = "btnIndirizzi";
            this.btnIndirizzi.Size = new System.Drawing.Size(193, 61);
            this.btnIndirizzi.TabIndex = 3;
            this.btnIndirizzi.Text = "🎓Indirizzo";
            this.btnIndirizzi.UseVisualStyleBackColor = true;
            this.btnIndirizzi.Click += new System.EventHandler(this.btnIndirizzi_Click);
            // 
            // btnIscrizioni
            // 
            this.btnIscrizioni.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIscrizioni.Location = new System.Drawing.Point(3, 195);
            this.btnIscrizioni.Name = "btnIscrizioni";
            this.btnIscrizioni.Size = new System.Drawing.Size(193, 61);
            this.btnIscrizioni.TabIndex = 4;
            this.btnIscrizioni.Text = "🔔Iscrizioni";
            this.btnIscrizioni.UseVisualStyleBackColor = true;
            this.btnIscrizioni.Click += new System.EventHandler(this.btnIscrizioni_Click);
            // 
            // btnValida
            // 
            this.btnValida.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValida.Location = new System.Drawing.Point(3, 262);
            this.btnValida.Name = "btnValida";
            this.btnValida.Size = new System.Drawing.Size(193, 61);
            this.btnValida.TabIndex = 5;
            this.btnValida.Text = "🎟️Valida Accesso";
            this.btnValida.UseVisualStyleBackColor = true;
            this.btnValida.Click += new System.EventHandler(this.btnValida_Click);
            // 
            // btnAttività
            // 
            this.btnAttività.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttività.Location = new System.Drawing.Point(3, 128);
            this.btnAttività.Name = "btnAttività";
            this.btnAttività.Size = new System.Drawing.Size(193, 61);
            this.btnAttività.TabIndex = 6;
            this.btnAttività.Text = "✨Attività";
            this.btnAttività.UseVisualStyleBackColor = true;
            this.btnAttività.Click += new System.EventHandler(this.btnAttività_Click);
            // 
            // btnProfilo
            // 
            this.btnProfilo.Font = new System.Drawing.Font("Helvetica", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfilo.Location = new System.Drawing.Point(1153, 22);
            this.btnProfilo.Name = "btnProfilo";
            this.btnProfilo.Size = new System.Drawing.Size(108, 48);
            this.btnProfilo.TabIndex = 7;
            this.btnProfilo.Text = "👤Profilo";
            this.btnProfilo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "Eventi Marconi";
            // 
            // lblBenvenuto
            // 
            this.lblBenvenuto.AutoSize = true;
            this.lblBenvenuto.Font = new System.Drawing.Font("Helvetica", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenvenuto.ForeColor = System.Drawing.Color.White;
            this.lblBenvenuto.Location = new System.Drawing.Point(3, 0);
            this.lblBenvenuto.Name = "lblBenvenuto";
            this.lblBenvenuto.Size = new System.Drawing.Size(183, 58);
            this.lblBenvenuto.TabIndex = 10;
            this.lblBenvenuto.Text = "Benvenuto, \r\nDiego D\'Amico";
            // 
            // FrmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmMainAdmin";
            this.Text = "FrmMain";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnUtenti;
        private System.Windows.Forms.Button btnClassi;
        private System.Windows.Forms.Button btnEventi;
        private System.Windows.Forms.Button btnIndirizzi;
        private System.Windows.Forms.Button btnIscrizioni;
        private System.Windows.Forms.Button btnValida;
        private System.Windows.Forms.Button btnAttività;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProfilo;
        private System.Windows.Forms.Label lblBenvenuto;
    }
}