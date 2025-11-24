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
            this.cmbUcel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTyp = new System.Windows.Forms.ComboBox();
            this.btnPridat = new System.Windows.Forms.Button();
            this.listTransakce = new System.Windows.Forms.ListView();
            this.txtVlastniUcel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCastka
            // 
            this.txtCastka.Location = new System.Drawing.Point(74, 28);
            this.txtCastka.Name = "txtCastka";
            this.txtCastka.Size = new System.Drawing.Size(170, 22);
            this.txtCastka.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Částka: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Účel:";
            // 
            // cmbUcel
            // 
            this.cmbUcel.FormattingEnabled = true;
            this.cmbUcel.Location = new System.Drawing.Point(74, 77);
            this.cmbUcel.Name = "cmbUcel";
            this.cmbUcel.Size = new System.Drawing.Size(170, 24);
            this.cmbUcel.TabIndex = 3;
            this.cmbUcel.SelectedIndexChanged += new System.EventHandler(this.cmbUcel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Typ: ";
            // 
            // cmbTyp
            // 
            this.cmbTyp.FormattingEnabled = true;
            this.cmbTyp.Location = new System.Drawing.Point(74, 119);
            this.cmbTyp.Name = "cmbTyp";
            this.cmbTyp.Size = new System.Drawing.Size(170, 24);
            this.cmbTyp.TabIndex = 5;
            // 
            // btnPridat
            // 
            this.btnPridat.Location = new System.Drawing.Point(19, 192);
            this.btnPridat.Name = "btnPridat";
            this.btnPridat.Size = new System.Drawing.Size(120, 50);
            this.btnPridat.TabIndex = 6;
            this.btnPridat.Text = "button1";
            this.btnPridat.UseVisualStyleBackColor = true;
            this.btnPridat.Click += new System.EventHandler(this.btnPridat_Click);
            // 
            // listTransakce
            // 
            this.listTransakce.HideSelection = false;
            this.listTransakce.Location = new System.Drawing.Point(326, 31);
            this.listTransakce.Name = "listTransakce";
            this.listTransakce.Size = new System.Drawing.Size(167, 246);
            this.listTransakce.TabIndex = 7;
            this.listTransakce.UseCompatibleStateImageBehavior = false;
            // 
            // txtVlastniUcel
            // 
            this.txtVlastniUcel.Location = new System.Drawing.Point(144, 296);
            this.txtVlastniUcel.Name = "txtVlastniUcel";
            this.txtVlastniUcel.Size = new System.Drawing.Size(100, 22);
            this.txtVlastniUcel.TabIndex = 8;
            this.txtVlastniUcel.Visible = false;
            // 
            // FormPridat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtVlastniUcel);
            this.Controls.Add(this.listTransakce);
            this.Controls.Add(this.btnPridat);
            this.Controls.Add(this.cmbTyp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbUcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCastka);
            this.Name = "FormPridat";
            this.Text = "FormPridat";
            this.Load += new System.EventHandler(this.FormPridat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCastka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTyp;
        private System.Windows.Forms.Button btnPridat;
        private System.Windows.Forms.ListView listTransakce;
        private System.Windows.Forms.TextBox txtVlastniUcel;
    }
}