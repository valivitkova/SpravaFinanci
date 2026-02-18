namespace SpravaFinanci
{
    partial class FormFiltr
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
            panel1 = new Panel();
            label6 = new Label();
            grpDatum = new GroupBox();
            dtpDo = new DateTimePicker();
            dtpOd = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            chkPouzitDatum = new CheckBox();
            grpCastka = new GroupBox();
            label7 = new Label();
            label5 = new Label();
            numDo = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            numOd = new NumericUpDown();
            chkPouzitCastku = new CheckBox();
            grpOstatni = new GroupBox();
            cmbTyp = new ComboBox();
            cmbKategorie = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            chkPouzitKategorii = new CheckBox();
            btnZrusit = new Button();
            btnOk = new Button();
            panel1.SuspendLayout();
            grpDatum.SuspendLayout();
            grpCastka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numOd).BeginInit();
            grpOstatni.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 62, 80);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 50);
            panel1.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 10);
            label6.Name = "label6";
            label6.Size = new Size(163, 29);
            label6.TabIndex = 11;
            label6.Text = "FILTROVÁNÍ";
            // 
            // grpDatum
            // 
            grpDatum.Controls.Add(dtpDo);
            grpDatum.Controls.Add(dtpOd);
            grpDatum.Controls.Add(label2);
            grpDatum.Controls.Add(label1);
            grpDatum.Dock = DockStyle.Top;
            grpDatum.Enabled = false;
            grpDatum.Location = new Point(0, 50);
            grpDatum.Name = "grpDatum";
            grpDatum.Size = new Size(433, 110);
            grpDatum.TabIndex = 16;
            grpDatum.TabStop = false;
            // 
            // dtpDo
            // 
            dtpDo.Location = new Point(56, 68);
            dtpDo.Name = "dtpDo";
            dtpDo.Size = new Size(250, 27);
            dtpDo.TabIndex = 3;
            // 
            // dtpOd
            // 
            dtpOd.Location = new Point(56, 26);
            dtpOd.Name = "dtpOd";
            dtpOd.Size = new Size(250, 27);
            dtpOd.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 1;
            label2.Text = "Do:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 0;
            label1.Text = "Od:";
            // 
            // chkPouzitDatum
            // 
            chkPouzitDatum.AutoSize = true;
            chkPouzitDatum.Location = new Point(5, 50);
            chkPouzitDatum.Name = "chkPouzitDatum";
            chkPouzitDatum.Size = new Size(76, 24);
            chkPouzitDatum.TabIndex = 21;
            chkPouzitDatum.Text = "Datum";
            chkPouzitDatum.UseVisualStyleBackColor = true;
            chkPouzitDatum.CheckedChanged += chkPouzitDatum_CheckedChanged;
            // 
            // grpCastka
            // 
            grpCastka.Controls.Add(label7);
            grpCastka.Controls.Add(label5);
            grpCastka.Controls.Add(numDo);
            grpCastka.Controls.Add(label4);
            grpCastka.Controls.Add(label3);
            grpCastka.Controls.Add(numOd);
            grpCastka.Dock = DockStyle.Top;
            grpCastka.Enabled = false;
            grpCastka.Location = new Point(0, 160);
            grpCastka.Name = "grpCastka";
            grpCastka.Size = new Size(433, 110);
            grpCastka.TabIndex = 17;
            grpCastka.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(218, 76);
            label7.Name = "label7";
            label7.Size = new Size(25, 20);
            label7.TabIndex = 5;
            label7.Text = "Kč";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 37);
            label5.Name = "label5";
            label5.Size = new Size(25, 20);
            label5.TabIndex = 4;
            label5.Text = "Kč";
            // 
            // numDo
            // 
            numDo.Location = new Point(59, 72);
            numDo.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDo.Name = "numDo";
            numDo.Size = new Size(150, 27);
            numDo.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 68);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 2;
            label4.Text = "Max:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 34);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 1;
            label3.Text = "Min:";
            // 
            // numOd
            // 
            numOd.Location = new Point(59, 32);
            numOd.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numOd.Name = "numOd";
            numOd.Size = new Size(150, 27);
            numOd.TabIndex = 0;
            // 
            // chkPouzitCastku
            // 
            chkPouzitCastku.AutoSize = true;
            chkPouzitCastku.Location = new Point(5, 159);
            chkPouzitCastku.Name = "chkPouzitCastku";
            chkPouzitCastku.Size = new Size(74, 24);
            chkPouzitCastku.TabIndex = 6;
            chkPouzitCastku.Text = "Částka";
            chkPouzitCastku.UseVisualStyleBackColor = true;
            chkPouzitCastku.CheckedChanged += chkPouzitCastku_CheckedChanged;
            // 
            // grpOstatni
            // 
            grpOstatni.Controls.Add(cmbTyp);
            grpOstatni.Controls.Add(cmbKategorie);
            grpOstatni.Controls.Add(label9);
            grpOstatni.Controls.Add(label8);
            grpOstatni.Dock = DockStyle.Top;
            grpOstatni.Enabled = false;
            grpOstatni.Location = new Point(0, 270);
            grpOstatni.Name = "grpOstatni";
            grpOstatni.Size = new Size(433, 110);
            grpOstatni.TabIndex = 18;
            grpOstatni.TabStop = false;
            // 
            // cmbTyp
            // 
            cmbTyp.FormattingEnabled = true;
            cmbTyp.Items.AddRange(new object[] { "Vše", "Příjem", "Výdej" });
            cmbTyp.Location = new Point(95, 69);
            cmbTyp.Name = "cmbTyp";
            cmbTyp.Size = new Size(151, 28);
            cmbTyp.TabIndex = 3;
            // 
            // cmbKategorie
            // 
            cmbKategorie.FormattingEnabled = true;
            cmbKategorie.Location = new Point(95, 29);
            cmbKategorie.Name = "cmbKategorie";
            cmbKategorie.Size = new Size(151, 28);
            cmbKategorie.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 68);
            label9.Name = "label9";
            label9.Size = new Size(35, 20);
            label9.TabIndex = 1;
            label9.Text = "Typ:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 32);
            label8.Name = "label8";
            label8.Size = new Size(77, 20);
            label8.TabIndex = 0;
            label8.Text = "Kategorie:";
            // 
            // chkPouzitKategorii
            // 
            chkPouzitKategorii.AutoSize = true;
            chkPouzitKategorii.Location = new Point(5, 270);
            chkPouzitKategorii.Name = "chkPouzitKategorii";
            chkPouzitKategorii.Size = new Size(78, 24);
            chkPouzitKategorii.TabIndex = 4;
            chkPouzitKategorii.Text = "Ostatní";
            chkPouzitKategorii.UseVisualStyleBackColor = true;
            chkPouzitKategorii.CheckedChanged += chkPouzitKategorii_CheckedChanged;
            // 
            // btnZrusit
            // 
            btnZrusit.DialogResult = DialogResult.Cancel;
            btnZrusit.Location = new Point(202, 386);
            btnZrusit.Name = "btnZrusit";
            btnZrusit.Size = new Size(102, 39);
            btnZrusit.TabIndex = 19;
            btnZrusit.Text = "Zrušit";
            btnZrusit.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(310, 386);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 39);
            btnOk.TabIndex = 20;
            btnOk.Text = "Použít";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // FormFiltr
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 433);
            Controls.Add(chkPouzitKategorii);
            Controls.Add(chkPouzitDatum);
            Controls.Add(chkPouzitCastku);
            Controls.Add(btnOk);
            Controls.Add(btnZrusit);
            Controls.Add(grpOstatni);
            Controls.Add(grpCastka);
            Controls.Add(grpDatum);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFiltr";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormFiltr";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpDatum.ResumeLayout(false);
            grpDatum.PerformLayout();
            grpCastka.ResumeLayout(false);
            grpCastka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numOd).EndInit();
            grpOstatni.ResumeLayout(false);
            grpOstatni.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private GroupBox grpDatum;
        private DateTimePicker dtpDo;
        private DateTimePicker dtpOd;
        private Label label2;
        private Label label1;
        private GroupBox grpCastka;
        private GroupBox grpOstatni;
        private Label label5;
        private NumericUpDown numDo;
        private Label label4;
        private Label label3;
        private NumericUpDown numOd;
        private Label label7;
        private ComboBox cmbTyp;
        private ComboBox cmbKategorie;
        private Label label9;
        private Label label8;
        private Button btnZrusit;
        private Button btnOk;
        private CheckBox chkPouzitCastku;
        private CheckBox chkPouzitKategorii;
        private CheckBox chkPouzitDatum;
    }
}