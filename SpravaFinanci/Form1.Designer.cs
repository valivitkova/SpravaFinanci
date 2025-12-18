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
            lblZustatek = new Label();
            lblPrijmy = new Label();
            lblVydaje = new Label();
            PrijemCislo = new Label();
            VydajCislo = new Label();
            ZustatekCislo = new Label();
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
            // lblZustatek
            // 
            lblZustatek.AutoSize = true;
            lblZustatek.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblZustatek.Location = new Point(388, 422);
            lblZustatek.Name = "lblZustatek";
            lblZustatek.Size = new Size(93, 25);
            lblZustatek.TabIndex = 4;
            lblZustatek.Text = "Zůstatek:";
            // 
            // lblPrijmy
            // 
            lblPrijmy.AutoSize = true;
            lblPrijmy.Font = new Font("Microsoft Sans Serif", 12F);
            lblPrijmy.Location = new Point(12, 396);
            lblPrijmy.Name = "lblPrijmy";
            lblPrijmy.Size = new Size(76, 25);
            lblPrijmy.TabIndex = 5;
            lblPrijmy.Text = "Příjmy: ";
            // 
            // lblVydaje
            // 
            lblVydaje.AutoSize = true;
            lblVydaje.Font = new Font("Microsoft Sans Serif", 12F);
            lblVydaje.Location = new Point(12, 447);
            lblVydaje.Name = "lblVydaje";
            lblVydaje.Size = new Size(84, 25);
            lblVydaje.TabIndex = 6;
            lblVydaje.Text = "Výdaje: ";
            // 
            // PrijemCislo
            // 
            PrijemCislo.AutoSize = true;
            PrijemCislo.Font = new Font("Microsoft Sans Serif", 12F);
            PrijemCislo.Location = new Point(90, 396);
            PrijemCislo.Name = "PrijemCislo";
            PrijemCislo.Size = new Size(64, 25);
            PrijemCislo.TabIndex = 7;
            PrijemCislo.Text = "label1";
            // 
            // VydajCislo
            // 
            VydajCislo.AutoSize = true;
            VydajCislo.Font = new Font("Microsoft Sans Serif", 12F);
            VydajCislo.Location = new Point(97, 447);
            VydajCislo.Name = "VydajCislo";
            VydajCislo.Size = new Size(64, 25);
            VydajCislo.TabIndex = 8;
            VydajCislo.Text = "label2";
            // 
            // ZustatekCislo
            // 
            ZustatekCislo.AutoSize = true;
            ZustatekCislo.Font = new Font("Microsoft Sans Serif", 12F);
            ZustatekCislo.Location = new Point(483, 422);
            ZustatekCislo.Name = "ZustatekCislo";
            ZustatekCislo.Size = new Size(64, 25);
            ZustatekCislo.TabIndex = 9;
            ZustatekCislo.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 492);
            Controls.Add(ZustatekCislo);
            Controls.Add(VydajCislo);
            Controls.Add(PrijemCislo);
            Controls.Add(lblVydaje);
            Controls.Add(lblPrijmy);
            Controls.Add(lblZustatek);
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
        private System.Windows.Forms.Label lblZustatek;
        private Label lblPrijmy;
        private Label lblVydaje;
        private Label PrijemCislo;
        private Label VydajCislo;
        private Label ZustatekCislo;
    }
}

