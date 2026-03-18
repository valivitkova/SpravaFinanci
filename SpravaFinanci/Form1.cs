using Microsoft.EntityFrameworkCore;
using SpravaFinanci;

namespace SpravaFinanci
{
    public partial class Form1 : Form
    {
        //hlavní seznam dat naètených z databáze
        private List<FinancniZaznam> hlavniSeznamDat = new List<FinancniZaznam>();
        public Form1()
        {
            InitializeComponent();

            NacistAObnovitData();
        }

        private void btnPridat_Click(object sender, EventArgs e)
        {
            FormPridat formular = new FormPridat();
            //po uložení dat se znovu naètou data v hlavním formuláøi
            formular.DataUlozena += NacistAObnovitData;
            formular.ShowDialog();
        }

        private void dgvPrehled_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ObarvitRadkyPodleKategorie();
        }

        private void btnSmazat_Click(object sender, EventArgs e)
        {
            //kontrola, zda je vybraný nìjaký øádek
            if (dgvPrehled.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nejdøív musíš vybrat øádek!");
                return;
            }

            try
            {
                //získání konkrétního vybraného øádku z tabulky
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

                //pøipojení k datbázi
                using (var db = new AppDbKontext())
                {
                    //najdeme záznam podle ID
                    var zaznamVDatabazi = db.Zaznamy.Find(idKeSmazani);

                    if (zaznamVDatabazi != null)
                    {
                        //odstranìní záznamu
                        db.Zaznamy.Remove(zaznamVDatabazi);
                        //uložení zmìn do databáze
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
                    // kdyby to byl první start aplikace (databáze neexistuje? vytvoøí se)
                    db.Database.EnsureCreated();

                    //naètení všech záznamù seøazených podle data
                    hlavniSeznamDat = db.Zaznamy
                                        .OrderByDescending(x => x.Datum)
                                        .ThenByDescending(x => x.Id)
                                        .ToList();

                    //Pøijmy, Vydaje a Zustatek v labelech
                    decimal celkemPrijmy = hlavniSeznamDat
                                    .Where(zaznam => zaznam.JePrijem == true)
                                    .Sum(zaznam => zaznam.Castka);

                    decimal celkemVydaje = hlavniSeznamDat
                                    .Where(zaznam => zaznam.JePrijem == false)
                                    .Sum(zaznam => zaznam.Castka);

                    decimal Zustatek = celkemPrijmy - celkemVydaje;

                    //C2 je formát mìny (Currency) na 2 desetinná místa
                    PrijemCislo.Text = "+ " + celkemPrijmy.ToString("N2");
                    VydajCislo.Text = "- " + celkemVydaje.ToString("N2");
                    ZustatekCislo.Text = Zustatek.ToString("N2");

                    //zmìna barvy zùstatku
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

                    NastavitSloupceTabulky();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi naèítání dat: " + ex.Message);
            }
        }

        private void ObarvitRadkyPodleKategorie()
        {
            //projedeme každý øádek v tabulce
            foreach (DataGridViewRow radek in dgvPrehled.Rows)
            {
                FinancniZaznam zaznam = (FinancniZaznam)radek.DataBoundItem;

                if (zaznam == null)
                    continue;

                //obarvime øádky podle kategorie
                switch (zaznam.Popis)
                {
                    case "Jídlo":
                        radek.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;

                    case "Doprava":
                        radek.DefaultCellStyle.BackColor = Color.Violet;
                        break;

                    case "Bydlení":
                        radek.DefaultCellStyle.BackColor = Color.LightSalmon;
                        break;

                    case "Zábava":
                        radek.DefaultCellStyle.BackColor = Color.LightPink;
                        break;

                    case "Obleèení":
                        radek.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        break;

                    default:
                        radek.DefaultCellStyle.BackColor = Color.Khaki;
                        break;

                }
            }
        }

        private void dgvPrehled_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //pokud uživatel klikl mimo planá data
            if (e.RowIndex < 0)
                return;

            try
            {
                //najdeme záznam, na který bylo kliknuto
                DataGridViewRow vybranyRadek = dgvPrehled.Rows[e.RowIndex];
                FinancniZaznam zaznamKUprave = (FinancniZaznam)vybranyRadek.DataBoundItem;

                //otevøeme stejný formuláø, jako na pøidání záznamu
                FormPridat formularEditace = new FormPridat();

                //pøedvyplníme ho daty z vybraného záznamu
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
                var financniSeznam = filtrovanySeznamQuery.OrderByDescending(x => x.Datum)
                                                          .ThenByDescending(x => x.Id)
                                                          .ToList();

                dgvPrehled.DataSource = null;
                dgvPrehled.DataSource = financniSeznam;

                NastavitSloupceTabulky();
            }

        }

        private void txtHledat_TextChanged(object sender, EventArgs e)
        {
            //ignoruje výchozí nápovìdný text 
            if (txtHledat.Text == "Hledat podle kategorií...")
            {
                return;
            }

            //pøevedeme hledaný text na malá písmena, aby vyhledávání nezáviselo na velkých/malých znacích
            string hledanyText = txtHledat.Text.ToLower();

            //vytvoøíme nový seznam, kde Popis neo Poznámka obsahuje hledaný text
            var filtrovanySeznam = hlavniSeznamDat
                .Where(zaznam =>
                    (zaznam.Popis != null && zaznam.Popis.ToLower().Contains(hledanyText)) ||
                    (zaznam.Poznamka != null && zaznam.Poznamka.ToLower().Contains(hledanyText))
                )
                .OrderByDescending(x => x.Datum)
                .ThenByDescending(x => x.Id)
                .ToList();

            dgvPrehled.DataSource = null;
            dgvPrehled.DataSource = filtrovanySeznam;

            NastavitSloupceTabulky();
        }
        private void txtHledat_Enter(object sender, EventArgs e)
        {
            //pokud je tam nápovìdný text, vymaže ho a zmìní barvu písma na èernou
            if (txtHledat.Text == "Hledat podle kategorií...")
            {
                txtHledat.Text = "";
                txtHledat.ForeColor = Color.Black;
            }
        }

        private void txtHledat_Leave(object sender, EventArgs e)
        {
            //pokud vyhledávací pole nechal prázdné, vrátí tam nápovìdný šedý text
            if (string.IsNullOrEmpty(txtHledat.Text))
            {
                txtHledat.Text = "Hledat podle kategorií...";
                txtHledat.ForeColor = SystemColors.GrayText;
            }
        }

        private void NastavitSloupceTabulky()
        {
            //skryjeme sloupec s ID
            if (dgvPrehled.Columns["Id"] != null)
                dgvPrehled.Columns["Id"].Visible = false;

            //skryjeme hodnotu true/false
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

            //nadpisy sloupcù v tabulce
            if (dgvPrehled.Columns["Popis"] != null)
                dgvPrehled.Columns["Popis"].HeaderText = "Kategorie";

            if (dgvPrehled.Columns["Castka"] != null)
            {
                dgvPrehled.Columns["Castka"].HeaderText = "Èástka";
                dgvPrehled.Columns["Castka"].DefaultCellStyle.Format = "N2";
            }
                

            if (dgvPrehled.Columns["Poznamka"] != null)
                dgvPrehled.Columns["Poznamka"].HeaderText = "Poznámka";
        }

        private void btnZobrazGraf_Click(object sender, EventArgs e)
        {
            //pokud jsou v tabulce vyfiltrovana data, ukazou se tyto data i v grafu
            List<FinancniZaznam> aktualniData = (List<FinancniZaznam>)dgvPrehled.DataSource;

            if (aktualniData == null || aktualniData.Count == 0)
            {
                MessageBox.Show("V tabulce nejsou žádná data k zobrazení.");
                return;
            }

            FormGrafy formGrafy = new FormGrafy(aktualniData);
            formGrafy.ShowDialog();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}