using Microsoft.EntityFrameworkCore;
using SpravaFinanci;

namespace SpravaFinanci
{
    public partial class Form1 : Form
    {

        private List<FinancniZaznam> hlavniSeznamDat = new List<FinancniZaznam>();
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

                    hlavniSeznamDat = db.Zaznamy.OrderByDescending(FinancniZaznam => FinancniZaznam.Datum).ToList();

                    //Pøijmy, Vydaje a Zustatek v labelech
                    decimal celkemPrijmy = hlavniSeznamDat
                                    .Where(zaznam => zaznam.JePrijem == true)
                                    .Sum(zaznam => zaznam.Castka);

                    decimal celkemVydaje = hlavniSeznamDat
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
                    dgvPrehled.DataSource = hlavniSeznamDat;

                    if (dgvPrehled.Columns["Id"] != null)
                        dgvPrehled.Columns["Id"].Visible = false;

                    if (dgvPrehled.Columns["JePrijem"] != null)
                        dgvPrehled.Columns["JePrijem"].Visible = false;

                    if (dgvPrehled.Columns["TypTextem"] != null)
                    {
                        dgvPrehled.Columns["TypTextem"].HeaderText = "Typ";
                        dgvPrehled.Columns["TypTextem"].DisplayIndex = 2;
                    }

                    if (dgvPrehled.Columns["Datum"] != null)
                    {
                        dgvPrehled.Columns["Datum"].DefaultCellStyle.Format = "d";
                    }

                    if (dgvPrehled.Columns["Popis"] != null)
                        dgvPrehled.Columns["Popis"].HeaderText = "Kategorie";

                    if (dgvPrehled.Columns["Castka"] != null)
                        dgvPrehled.Columns["Castka"].HeaderText = "Èástka";

                    if (dgvPrehled.Columns["Poznamka"] != null)
                        dgvPrehled.Columns["Poznamka"].HeaderText = "Poznámka";
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

        private void dgvPrehled_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow vybranyRadek = dgvPrehled.Rows[e.RowIndex];
                FinancniZaznam zaznamKUprave = (FinancniZaznam)vybranyRadek.DataBoundItem;

                FormPridat formularEditace = new FormPridat();

                formularEditace.PripravitProEditaci(zaznamKUprave);

                formularEditace.ShowDialog();

                NacistAObnovitData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi otevírání editace: " + ex.Message);
            }
        }

        private void btnFiltrovat_Click(object sender, EventArgs e)
        {
            // 1. Získáme seznam všech použitých kategorií pro naplnìní ComboBoxu
            List<string> seznamKategorii = hlavniSeznamDat
                                            .Select(FinancniZaznam => FinancniZaznam.Popis)
                                            .Distinct()
                                            .ToList();
            // 2. Vytvoøíme a otevøeme filtrovací okno
            FormFiltr filtrForm = new FormFiltr(seznamKategorii);

            // ShowDialog zobrazí okno a èeká, dokud ho uživatel nezavøe
            //Pokud ho zavøel tlaèítkem "POUŽÍT", jdeme filtrovat
            if (filtrForm.ShowDialog() == DialogResult.OK)
            {
                //3. nastavení filtru
                FiltrData filtr = filtrForm.VysledekFiltru;

                //4. aplikace filtru
                //zaène se s kompletním seznamem a postupnì se bude oøezávat
                //AsQueryable - mužeme øetìzit podmínky 'Where'
                var filtrovanySeznamQuery = hlavniSeznamDat.AsQueryable();

                //pokud je zadán datum od, filtrujeme 
                if (filtr.DatumOd.HasValue)
                {
                    //filtr podle datumu (Od - Do)
                    filtrovanySeznamQuery = filtrovanySeznamQuery.Where(x => x.Datum >= filtr.DatumOd);
                }

                //pokud je zadán datum do, filtrujeme
                if (filtr.DatumDo.HasValue)
                {
                    // pøidáme jeden den, abychom zahrnuli i celý koncový den
                    filtrovanySeznamQuery = filtrovanySeznamQuery.Where(x => x.Datum < filtr.DatumDo.Value.AddDays(1));
                }

                //pokud je zadána minimální èástka, filtrujeme
                if (filtr.CastkaOd.HasValue)
                {
                    filtrovanySeznamQuery = filtrovanySeznamQuery.Where(x => x.Castka >= filtr.CastkaOd.Value);
                }

                //pokud je zadána maximální èástka, filtrujeme
                if (filtr.CastkaDo.HasValue)
                {
                    filtrovanySeznamQuery = filtrovanySeznamQuery.Where(x => x.Castka <= filtr.CastkaDo.Value);
                }

                //pokud je vybrána konkrétní kategorie (není null), filtrujeme
                if (filtr.Kategorie != null)
                {
                    filtrovanySeznamQuery = filtrovanySeznamQuery.Where(x => x.Popis == filtr.Kategorie);
                }

                //pokud je vybrán typ (true/false), filtrujeme. 
                if (filtr.JePrijem.HasValue)
                {
                    filtrovanySeznamQuery = filtrovanySeznamQuery.Where(x => x.JePrijem == filtr.JePrijem.Value);
                }

                //5. výsledek pøevedeme na seznam, seøadíme a pošleme do tabulky
                var financniSeznam = filtrovanySeznamQuery.OrderBy(x => x.Datum).ToList();

                dgvPrehled.DataSource = null;
                dgvPrehled.DataSource = financniSeznam;

                NastavitSloupceTabulky();
            }

        }

        private void txtHledat_TextChanged(object sender, EventArgs e)
        {
            if (txtHledat.Text == "Hledat podle kategorií...")
            {
                return;
            }

            string hledanyText = txtHledat.Text.ToLower();

            var filtrovanySeznam = hlavniSeznamDat
                .Where(zaznam =>
                    (zaznam.Popis != null && zaznam.Popis.ToLower().Contains(hledanyText)) ||
                    (zaznam.Poznamka != null && zaznam.Poznamka.ToLower().Contains(hledanyText))
                )
                .OrderByDescending(FinancniZaznam => FinancniZaznam.Datum)
                .ToList();

            dgvPrehled.DataSource = null;
            dgvPrehled.DataSource = filtrovanySeznam;

            NastavitSloupceTabulky();
        }
        private void txtHledat_Enter(object sender, EventArgs e)
        {
            if (txtHledat.Text == "Hledat podle kategorií...")
            {
                txtHledat.Text = "";
                txtHledat.ForeColor = Color.Black;
            }
        }

        private void txtHledat_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHledat.Text))
            {
                txtHledat.Text = "Hledat podle kategorií...";
                txtHledat.ForeColor = SystemColors.GrayText;
            }
        }

        private void NastavitSloupceTabulky()
        {
            if (dgvPrehled.Columns["Id"] != null)
                dgvPrehled.Columns["Id"].Visible = false;

            if (dgvPrehled.Columns["JePrijem"] != null)
                dgvPrehled.Columns["JePrijem"].Visible = false;

            if (dgvPrehled.Columns["TypTextem"] != null)
            {
                dgvPrehled.Columns["TypTextem"].HeaderText = "Typ";
                dgvPrehled.Columns["TypTextem"].DisplayIndex = 2;
            }

            if (dgvPrehled.Columns["Datum"] != null)
            {
                dgvPrehled.Columns["Datum"].DefaultCellStyle.Format = "d";
            }

            if (dgvPrehled.Columns["Popis"] != null)
                dgvPrehled.Columns["Popis"].HeaderText = "Kategorie";

            if (dgvPrehled.Columns["Castka"] != null)
                dgvPrehled.Columns["Castka"].HeaderText = "Èástka";

            if (dgvPrehled.Columns["Poznamka"] != null)
                dgvPrehled.Columns["Poznamka"].HeaderText = "Poznámka";
        }

        private void btnZobrazGraf_Click(object sender, EventArgs e)
        {
            FormGrafy formGrafy = new FormGrafy(hlavniSeznamDat);
            formGrafy.ShowDialog();
        }
    }
}