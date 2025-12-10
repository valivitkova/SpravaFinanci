using Microsoft.EntityFrameworkCore;

namespace SpravaFinanci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NacistAObnovitData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPridat formular = new FormPridat();
            formular.DataUlozena += NacistAObnovitData;
            formular.ShowDialog();
        }

        public void NacistAObnovitData()
        {
            try
            {
                using (var db = new AppDbKontext())
                {
                    // kdyby to byl první start aplikace
                    db.Database.EnsureCreated();

                    var seznamVsechZaznamu = db.Zaznamy.ToList();

                    dgvPrehled.DataSource = null;
                    dgvPrehled.DataSource = seznamVsechZaznamu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi naèítání dat: " + ex.Message);
            }
        }
    }
}