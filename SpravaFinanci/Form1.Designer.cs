namespace SpravaFinanci
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            btnPridat = new Button();
            btnSmazat = new Button();
            btnZobrazGraf = new Button();
            dgvPrehled = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrehled).BeginInit();
            SuspendLayout();
            // 
            // btnPridat
            // 
            btnPridat.Location = new Point(12, 17);
            btnPridat.Name = "btnPridat";
            btnPridat.Size = new Size(203, 86);
            btnPridat.TabIndex = 0;
            btnPridat.Text = "Přidat transakci";
            btnPridat.UseVisualStyleBackColor = true;
            btnPridat.Click += btnPridat_Click;
            // 
            // btnSmazat
            // 
            btnSmazat.Location = new Point(251, 17);
            btnSmazat.Name = "btnSmazat";
            btnSmazat.Size = new Size(206, 86);
            btnSmazat.TabIndex = 1;
            btnSmazat.Text = "Smazat transakci";
            btnSmazat.UseVisualStyleBackColor = true;
            btnSmazat.Click += btnSmazat_Click;
            // 
            // btnZobrazGraf
            // 
            btnZobrazGraf.Location = new Point(494, 17);
            btnZobrazGraf.Name = "btnZobrazGraf";
            btnZobrazGraf.Size = new Size(196, 86);
            btnZobrazGraf.TabIndex = 2;
            btnZobrazGraf.Text = "Zobrazit přehled (grafy)";
            btnZobrazGraf.UseVisualStyleBackColor = true;
            // 
            // dgvPrehled
            // 
            dgvPrehled.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrehled.Location = new Point(12, 123);
            dgvPrehled.Name = "dgvPrehled";
            dgvPrehled.ReadOnly = true;
            dgvPrehled.RowHeadersWidth = 51;
            dgvPrehled.RowTemplate.Height = 24;
            dgvPrehled.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrehled.Size = new Size(678, 255);
            dgvPrehled.TabIndex = 3;
            dgvPrehled.DataBindingComplete += dgvPrehled_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(449, 418);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 4;
            label1.Text = "Zůstatek:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(548, 424);
            label2.Name = "label2";
            label2.Size = new Size(108, 17);
            label2.TabIndex = 5;
            label2.Text = "Častka zůstatku";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 478);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPrehled);
            Controls.Add(btnZobrazGraf);
            Controls.Add(btnSmazat);
            Controls.Add(btnPridat);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "Form1";
            ShowIcon = false;
            Text = "Správa osobních financí";
            ((System.ComponentModel.ISupportInitialize)dgvPrehled).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnPridat;
        private System.Windows.Forms.Button btnSmazat;
        private System.Windows.Forms.Button btnZobrazGraf;
        private System.Windows.Forms.DataGridView dgvPrehled;
        private System.Windows.Forms.Label label1;
        private Label label2;
    }
}

