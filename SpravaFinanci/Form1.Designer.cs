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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dgvPrehled = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrehled).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 17);
            button1.Name = "button1";
            button1.Size = new Size(203, 86);
            button1.TabIndex = 0;
            button1.Text = "Přidat transakci";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(251, 17);
            button2.Name = "button2";
            button2.Size = new Size(206, 86);
            button2.TabIndex = 1;
            button2.Text = "Smazat transakci";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(494, 17);
            button3.Name = "button3";
            button3.Size = new Size(196, 86);
            button3.TabIndex = 2;
            button3.Text = "Zobrazit přehled (grafy)";
            button3.UseVisualStyleBackColor = true;
            // 
            // dgvPrehled
            // 
            dgvPrehled.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrehled.Location = new Point(12, 123);
            dgvPrehled.Name = "dgvPrehled";
            dgvPrehled.ReadOnly = true;
            dgvPrehled.RowHeadersWidth = 51;
            dgvPrehled.RowTemplate.Height = 24;
            dgvPrehled.Size = new Size(678, 255);
            dgvPrehled.TabIndex = 3;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 478);
            Controls.Add(label1);
            Controls.Add(dgvPrehled);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "Form1";
            ShowIcon = false;
            Text = "Správa osobních financí";
            ((System.ComponentModel.ISupportInitialize)dgvPrehled).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgvPrehled;
        private System.Windows.Forms.Label label1;
    }
}

