namespace SpravaFinanci
{
    partial class FormPridat
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
            txtCastka = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbKategorie = new ComboBox();
            label3 = new Label();
            cmbTyp = new ComboBox();
            btnPridat = new Button();
            txtVlastniUcel = new TextBox();
            dtpDatum = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            txtPoznamka = new TextBox();
            btnZrusit = new Button();
            panel1 = new Panel();
            label6 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtCastka
            // 
            txtCastka.Font = new Font("Microsoft Sans Serif", 16F);
            txtCastka.Location = new Point(131, 139);
            txtCastka.Margin = new Padding(3, 4, 3, 4);
            txtCastka.Name = "txtCastka";
            txtCastka.Size = new Size(248, 38);
            txtCastka.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 144);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 1;
            label1.Text = "Částka: ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 200);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 2;
            label2.Text = "Kategorie:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbKategorie
            // 
            cmbKategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategorie.FormattingEnabled = true;
            cmbKategorie.Location = new Point(131, 199);
            cmbKategorie.Margin = new Padding(3, 4, 3, 4);
            cmbKategorie.Name = "cmbKategorie";
            cmbKategorie.Size = new Size(228, 28);
            cmbKategorie.TabIndex = 3;
            cmbKategorie.SelectedIndexChanged += cmbUcel_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 81);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 4;
            label3.Text = "Typ: ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTyp
            // 
            cmbTyp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTyp.FormattingEnabled = true;
            cmbTyp.Location = new Point(131, 80);
            cmbTyp.Margin = new Padding(3, 4, 3, 4);
            cmbTyp.Name = "cmbTyp";
            cmbTyp.Size = new Size(248, 28);
            cmbTyp.TabIndex = 5;
            // 
            // btnPridat
            // 
            btnPridat.BackColor = Color.DarkGray;
            btnPridat.FlatStyle = FlatStyle.Flat;
            btnPridat.Location = new Point(195, 1);
            btnPridat.Margin = new Padding(3, 4, 3, 4);
            btnPridat.Name = "btnPridat";
            btnPridat.Size = new Size(113, 46);
            btnPridat.TabIndex = 6;
            btnPridat.Text = "Uložit";
            btnPridat.UseVisualStyleBackColor = false;
            btnPridat.Click += btnUlozit_Click;
            // 
            // txtVlastniUcel
            // 
            txtVlastniUcel.Location = new Point(131, 245);
            txtVlastniUcel.Margin = new Padding(3, 4, 3, 4);
            txtVlastniUcel.Name = "txtVlastniUcel";
            txtVlastniUcel.Size = new Size(212, 27);
            txtVlastniUcel.TabIndex = 8;
            txtVlastniUcel.Visible = false;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(131, 27);
            dtpDatum.Margin = new Padding(3, 4, 3, 4);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(248, 27);
            dtpDatum.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 30);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 10;
            label4.Text = "Datum:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 296);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 11;
            label5.Text = "Poznámka: ";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPoznamka
            // 
            txtPoznamka.Location = new Point(131, 295);
            txtPoznamka.Margin = new Padding(3, 4, 3, 4);
            txtPoznamka.Multiline = true;
            txtPoznamka.Name = "txtPoznamka";
            txtPoznamka.Size = new Size(221, 109);
            txtPoznamka.TabIndex = 12;
            // 
            // btnZrusit
            // 
            btnZrusit.BackColor = Color.DarkGray;
            btnZrusit.FlatStyle = FlatStyle.Flat;
            btnZrusit.Location = new Point(330, 1);
            btnZrusit.Margin = new Padding(3, 4, 3, 4);
            btnZrusit.Name = "btnZrusit";
            btnZrusit.Size = new Size(116, 46);
            btnZrusit.TabIndex = 13;
            btnZrusit.Text = "Zrušit";
            btnZrusit.UseVisualStyleBackColor = false;
            btnZrusit.Click += btnZrusit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 62, 80);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(467, 50);
            panel1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 10);
            label6.Name = "label6";
            label6.Size = new Size(168, 29);
            label6.TabIndex = 11;
            label6.Text = "TRANSAKCE";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnPridat);
            panel2.Controls.Add(btnZrusit);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 488);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(467, 60);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.Controls.Add(label7);
            panel3.Controls.Add(cmbKategorie);
            panel3.Controls.Add(txtCastka);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtPoznamka);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(cmbTyp);
            panel3.Controls.Add(dtpDatum);
            panel3.Controls.Add(txtVlastniUcel);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 50);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20);
            panel3.Size = new Size(467, 438);
            panel3.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 16F);
            label7.Location = new Point(385, 146);
            label7.Name = "label7";
            label7.Size = new Size(46, 31);
            label7.TabIndex = 13;
            label7.Text = "Kč";
            // 
            // FormPridat
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(467, 548);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 10.2F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPridat";
            ShowIcon = false;
            Text = "Přidat transakci";
            Load += FormPridat_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtCastka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKategorie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTyp;
        private System.Windows.Forms.Button btnPridat;
        private System.Windows.Forms.TextBox txtVlastniUcel;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPoznamka;
        private System.Windows.Forms.Button btnZrusit;
        private Panel panel1;
        private Label label6;
        private Panel panel2;
        private Panel panel3;
        private Label label7;
    }
}