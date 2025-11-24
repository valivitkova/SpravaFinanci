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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Částka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poznámka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "Přidat transakci";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "Smazat transakci";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(494, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 81);
            this.button3.TabIndex = 2;
            this.button3.Text = "Zobrazit přehled (grafy)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datum,
            this.Typ,
            this.Částka,
            this.Kategorie,
            this.Poznámka});
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(678, 240);
            this.dataGridView1.TabIndex = 3;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.MinimumWidth = 6;
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 125;
            // 
            // Typ
            // 
            this.Typ.HeaderText = "Typ";
            this.Typ.MinimumWidth = 6;
            this.Typ.Name = "Typ";
            this.Typ.ReadOnly = true;
            this.Typ.Width = 125;
            // 
            // Částka
            // 
            this.Částka.HeaderText = "Částka";
            this.Částka.MinimumWidth = 6;
            this.Částka.Name = "Částka";
            this.Částka.ReadOnly = true;
            this.Částka.Width = 125;
            // 
            // Kategorie
            // 
            this.Kategorie.HeaderText = "Kategorie";
            this.Kategorie.MinimumWidth = 6;
            this.Kategorie.Name = "Kategorie";
            this.Kategorie.ReadOnly = true;
            this.Kategorie.Width = 125;
            // 
            // Poznámka
            // 
            this.Poznámka.HeaderText = "Poznámka";
            this.Poznámka.MinimumWidth = 6;
            this.Poznámka.Name = "Poznámka";
            this.Poznámka.ReadOnly = true;
            this.Poznámka.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(449, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zůstatek:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Správa osobních financí";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Částka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poznámka;
        private System.Windows.Forms.Label label1;
    }
}

