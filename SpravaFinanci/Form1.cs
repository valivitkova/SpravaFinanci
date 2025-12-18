using Microsoft.EntityFrameworkCore;
using SpravaFinanci;

namespace SpravaFinanci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NacistAObnovitData();
        }

        private void btnPridat_Click(object sender, EventArgs e)
        {
            FormPridat formular = new FormPridat();
            formular.DataUlozena += NacistAObnovitData;
            formular.ShowDialog();
        }

        private void dgvPrehled_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ObarvitRadkyPodleKategorie();
        }

        private void btnSmazat_Click(object sender, EventArgs e)
        {
            if (dgvPrehled.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nejdøív musíš vybrat øádek!");
                return;
            }

            try
            {
                DataGridViewRow vybranyRadek = dgvPrehled.SelectedRows[0];

                FinancniZaznam zaznamKeSmazani = (FinancniZaznam)vybranyRadek.DataBoundItem;
                int idKeSmazani = zaznamKeSmazani.Id;

                DialogResult odpoved = MessageBox.Show(
                    "Opravdu chceš smazat tento záznam:\n\n" + zaznamKeSmazani.Popis + " (" + zaznamKeSmazani.Castka + " Kè)?",
                    "Potvrzení smazání",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (odpoved == DialogResult.No)
                {
                    return;
                }

                using (var db = new AppDbKontext())
                {
                    var zaznamVDatabazi = db.Zaznamy.Find(idKeSmazani);

                    if (zaznamVDatabazi != null)
                    {
                        db.Zaznamy.Remove(zaznamVDatabazi);
                        db.SaveChanges();
                    }
                }

                NacistAObnovitData();

                MessageBox.Show("Záznam byl smazán.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi mazání: " + ex.Message);
            }
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

                    //Pøijmy, Vydaje a Zustatek v labelech
                    decimal celkemPrijmy = seznamVsechZaznamu
                                    .Where(zaznam => zaznam.JePrijem == true)
                                    .Sum(zaznam => zaznam.Castka);

                    decimal celkemVydaje = seznamVsechZaznamu
                                    .Where(zaznam => zaznam.JePrijem == false)
                                    .Sum(zaznam => zaznam.Castka);

                    decimal Zustatek = celkemPrijmy - celkemVydaje;

                    PrijemCislo.Text = "+ " + celkemPrijmy.ToString("C2");
                    VydajCislo.Text = "- " + celkemVydaje.ToString("C2");
                    ZustatekCislo.Text = Zustatek.ToString("C2");

                    if (Zustatek >= 0)
                    {
                        lblZustatek.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblZustatek.ForeColor = Color.Red;
                    }

                    dgvPrehled.DataSource = null;
                    dgvPrehled.DataSource = seznamVsechZaznamu;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi naèítání dat: " + ex.Message);
            }
        }

        private void ObarvitRadkyPodleKategorie()
        {
            foreach (DataGridViewRow radek in dgvPrehled.Rows)
            {
                FinancniZaznam zaznam = (FinancniZaznam)radek.DataBoundItem;

                if (zaznam == null)
                    continue;

                switch (zaznam.Popis)
                {
                    case "Jídlo":
                        radek.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;

                    case "Doprava":
                        radek.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                        break;

                    case "Bydlení":
                        radek.DefaultCellStyle.BackColor = Color.LightGray;
                        break;

                    case "Zábava":
                        radek.DefaultCellStyle.BackColor = Color.LightPink;
                        break;

                    case "Obleèení":
                        radek.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        break;

                    default:
                        radek.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;

                }
            }
        }

    }
}