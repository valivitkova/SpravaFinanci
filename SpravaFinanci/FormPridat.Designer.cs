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
            this.txtCastka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKategorie = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTyp = new System.Windows.Forms.ComboBox();
            this.btnPridat = new System.Windows.Forms.Button();
            this.txtVlastniUcel = new System.Windows.Forms.TextBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCastka
            // 
            this.txtCastka.Location = new System.Drawing.Point(74, 113);
            this.txtCastka.Name = "txtCastka";
            this.txtCastka.Size = new System.Drawing.Size(200, 22);
            this.txtCastka.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Částka: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategorie:";
            // 
            // cmbUcel
            // 
            this.cmbKategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategorie.FormattingEnabled = true;
            this.cmbKategorie.Location = new System.Drawing.Point(90, 161);
            this.cmbKategorie.Name = "cmbUcel";
            this.cmbKategorie.Size = new System.Drawing.Size(184, 24);
            this.cmbKategorie.TabIndex = 3;
            this.cmbKategorie.SelectedIndexChanged += new System.EventHandler(this.cmbUcel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Typ: ";
            // 
            // cmbTyp
            // 
            this.cmbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTyp.FormattingEnabled = true;
            this.cmbTyp.Location = new System.Drawing.Point(74, 66);
            this.cmbTyp.Name = "cmbTyp";
            this.cmbTyp.Size = new System.Drawing.Size(200, 24);
            this.cmbTyp.TabIndex = 5;
            // 
            // btnPridat
            // 
            this.btnPridat.Location = new System.Drawing.Point(325, 25);
            this.btnPridat.Name = "btnPridat";
            this.btnPridat.Size = new System.Drawing.Size(187, 80);
            this.btnPridat.TabIndex = 6;
            this.btnPridat.Text = "Uložit";
            this.btnPridat.UseVisualStyleBackColor = true;
            this.btnPridat.Click += new System.EventHandler(this.btnPridat_Click);
            // 
            // txtVlastniUcel
            // 
            this.txtVlastniUcel.Location = new System.Drawing.Point(325, 265);
            this.txtVlastniUcel.Name = "txtVlastniUcel";
            this.txtVlastniUcel.Size = new System.Drawing.Size(170, 22);
            this.txtVlastniUcel.TabIndex = 8;
            this.txtVlastniUcel.Visible = false;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(74, 20);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 22);
            this.dtpDatum.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Datum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Poznámka: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 199);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 88);
            this.textBox1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 86);
            this.button1.TabIndex = 13;
            this.button1.Text = "Zrušit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPridat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.txtVlastniUcel);
            this.Controls.Add(this.btnPridat);
            this.Controls.Add(this.cmbTyp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbKategorie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCastka);
            this.Name = "FormPridat";
            this.ShowIcon = false;
            this.Text = "Přidat transakci";
            this.Load += new System.EventHandler(this.FormPridat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}