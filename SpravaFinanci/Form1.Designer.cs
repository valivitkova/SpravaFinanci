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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            button1 = new Button();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPrehled).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnPridat
            // 
            btnPridat.BackColor = Color.DodgerBlue;
            btnPridat.FlatStyle = FlatStyle.Flat;
            btnPridat.Location = new Point(14, 11);
            btnPridat.Margin = new Padding(4);
            btnPridat.Name = "btnPridat";
            btnPridat.Size = new Size(148, 50);
            btnPridat.TabIndex = 0;
            btnPridat.Text = "Přidat transakci";
            btnPridat.UseVisualStyleBackColor = false;
            btnPridat.Click += btnPridat_Click;
            // 
            // btnSmazat
            // 
            btnSmazat.BackColor = Color.LightCoral;
            btnSmazat.FlatStyle = FlatStyle.Flat;
            btnSmazat.Location = new Point(183, 11);
            btnSmazat.Margin = new Padding(4);
            btnSmazat.Name = "btnSmazat";
            btnSmazat.Size = new Size(156, 50);
            btnSmazat.TabIndex = 1;
            btnSmazat.Text = "Smazat transakci";
            btnSmazat.UseVisualStyleBackColor = false;
            btnSmazat.Click += btnSmazat_Click;
            // 
            // btnZobrazGraf
            // 
            btnZobrazGraf.BackColor = Color.FromArgb(242, 231, 6);
            btnZobrazGraf.FlatStyle = FlatStyle.Flat;
            btnZobrazGraf.Location = new Point(360, 11);
            btnZobrazGraf.Margin = new Padding(4);
            btnZobrazGraf.Name = "btnZobrazGraf";
            btnZobrazGraf.Size = new Size(159, 50);
            btnZobrazGraf.TabIndex = 2;
            btnZobrazGraf.Text = "Zobrazit přehled (grafy)";
            btnZobrazGraf.UseVisualStyleBackColor = false;
            // 
            // dgvPrehled
            // 
            dgvPrehled.BackgroundColor = Color.LightGray;
            dgvPrehled.BorderStyle = BorderStyle.None;
            dgvPrehled.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPrehled.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrehled.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrehled.Dock = DockStyle.Fill;
            dgvPrehled.EnableHeadersVisualStyles = false;
            dgvPrehled.Location = new Point(0, 0);
            dgvPrehled.Margin = new Padding(4);
            dgvPrehled.Name = "dgvPrehled";
            dgvPrehled.ReadOnly = true;
            dgvPrehled.RowHeadersWidth = 51;
            dgvPrehled.RowTemplate.Height = 24;
            dgvPrehled.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrehled.Size = new Size(700, 378);
            dgvPrehled.TabIndex = 3;
            dgvPrehled.CellDoubleClick += dgvPrehled_CellDoubleClick;
            dgvPrehled.DataBindingComplete += dgvPrehled_DataBindingComplete;
            // 
            // lblZustatek
            // 
            lblZustatek.AutoSize = true;
            lblZustatek.Font = new Font("Microsoft Sans Serif", 9F);
            lblZustatek.ForeColor = Color.Gray;
            lblZustatek.Location = new Point(465, 15);
            lblZustatek.Margin = new Padding(4, 0, 4, 0);
            lblZustatek.Name = "lblZustatek";
            lblZustatek.Size = new Size(123, 18);
            lblZustatek.TabIndex = 4;
            lblZustatek.Text = "AKTUÁLNÍ STAV:";
            // 
            // lblPrijmy
            // 
            lblPrijmy.AutoSize = true;
            lblPrijmy.Font = new Font("Microsoft Sans Serif", 9F);
            lblPrijmy.ForeColor = Color.Gray;
            lblPrijmy.Location = new Point(14, 15);
            lblPrijmy.Margin = new Padding(4, 0, 4, 0);
            lblPrijmy.Name = "lblPrijmy";
            lblPrijmy.Size = new Size(109, 18);
            lblPrijmy.TabIndex = 5;
            lblPrijmy.Text = "Příjmy celkem: ";
            // 
            // lblVydaje
            // 
            lblVydaje.AutoSize = true;
            lblVydaje.Font = new Font("Microsoft Sans Serif", 9F);
            lblVydaje.ForeColor = Color.Gray;
            lblVydaje.Location = new Point(231, 15);
            lblVydaje.Margin = new Padding(4, 0, 4, 0);
            lblVydaje.Name = "lblVydaje";
            lblVydaje.Size = new Size(111, 18);
            lblVydaje.TabIndex = 6;
            lblVydaje.Text = "Výdaje celkem: ";
            // 
            // PrijemCislo
            // 
            PrijemCislo.AutoSize = true;
            PrijemCislo.Font = new Font("Microsoft Sans Serif", 11F);
            PrijemCislo.ForeColor = Color.ForestGreen;
            PrijemCislo.Location = new Point(14, 56);
            PrijemCislo.Margin = new Padding(4, 0, 4, 0);
            PrijemCislo.Name = "PrijemCislo";
            PrijemCislo.Size = new Size(60, 24);
            PrijemCislo.TabIndex = 7;
            PrijemCislo.Text = "label1";
            // 
            // VydajCislo
            // 
            VydajCislo.AutoSize = true;
            VydajCislo.Font = new Font("Microsoft Sans Serif", 12F);
            VydajCislo.ForeColor = Color.Firebrick;
            VydajCislo.Location = new Point(231, 56);
            VydajCislo.Margin = new Padding(4, 0, 4, 0);
            VydajCislo.Name = "VydajCislo";
            VydajCislo.Size = new Size(64, 25);
            VydajCislo.TabIndex = 8;
            VydajCislo.Text = "label2";
            // 
            // ZustatekCislo
            // 
            ZustatekCislo.AutoSize = true;
            ZustatekCislo.Font = new Font("Microsoft Sans Serif", 16F);
            ZustatekCislo.Location = new Point(465, 49);
            ZustatekCislo.Margin = new Padding(4, 0, 4, 0);
            ZustatekCislo.Name = "ZustatekCislo";
            ZustatekCislo.Size = new Size(86, 31);
            ZustatekCislo.TabIndex = 9;
            ZustatekCislo.Text = "label3";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 62, 80);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 50);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 10);
            label1.Name = "label1";
            label1.Size = new Size(203, 29);
            label1.TabIndex = 11;
            label1.Text = "MOJE FINANCE";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblPrijmy);
            panel2.Controls.Add(PrijemCislo);
            panel2.Controls.Add(ZustatekCislo);
            panel2.Controls.Add(lblVydaje);
            panel2.Controls.Add(lblZustatek);
            panel2.Controls.Add(VydajCislo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(700, 100);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Controls.Add(btnPridat);
            panel3.Controls.Add(btnSmazat);
            panel3.Controls.Add(btnZobrazGraf);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 150);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(700, 90);
            panel3.TabIndex = 12;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(10, 184, 57);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(533, 11);
            button1.Name = "button1";
            button1.Size = new Size(159, 50);
            button1.TabIndex = 3;
            button1.Text = "Filtrovat";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvPrehled);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 240);
            panel4.Name = "panel4";
            panel4.Size = new Size(700, 378);
            panel4.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(700, 618);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(4);
            Name = "Form1";
            ShowIcon = false;
            Text = "Správa osobních financí";
            ((System.ComponentModel.ISupportInitialize)dgvPrehled).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button button1;
    }
}

