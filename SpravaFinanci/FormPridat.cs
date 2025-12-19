using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaFinanci
{
    public partial class FormPridat : Form
    {
        // Proměnná, která si pamatuje ID záznamu, pokud ho upravujeme
        private int? idUpravovanehoZaznamu = null;

        private FinancniZaznam docasnyZaznamProEditaci = null;

        public event Action DataUlozena;
        public FormPridat()
        {
            InitializeComponent();
        }

        private void FormPridat_Load(object sender, EventArgs e)
        {
            // Přidání položek do ComboBoxu
            cmbKategorie.Items.Add("");
            cmbKategorie.Items.Add("Jídlo");
            cmbKategorie.Items.Add("Doprava");
            cmbKategorie.Items.Add("Bydlení");
            cmbKategorie.Items.Add("Zábava");
            cmbKategorie.Items.Add("Oblečení");
            cmbKategorie.Items.Add("Vlastní...");
            cmbKategorie.SelectedIndex = 0;

            cmbTyp.Items.Add("Příjem");
            cmbTyp.Items.Add("Výdaj");
            cmbTyp.SelectedIndex = 0;

            if (docasnyZaznamProEditaci != null)
            {
                idUpravovanehoZaznamu = docasnyZaznamProEditaci.Id;

                //Změna textu na tlačítku a v záhlaví
                btnPridat.Text = "Upravit záznam";
                this.Text = "Úprava transakce";

                dtpDatum.Value = docasnyZaznamProEditaci.Datum;
                txtCastka.Text = docasnyZaznamProEditaci.Castka.ToString();

                txtPoznamka.Text = docasnyZaznamProEditaci.Poznamka;

                if (docasnyZaznamProEditaci.JePrijem == true)
                {
                    cmbTyp.SelectedItem = "Příjem";
                }
                else
                {
                    cmbTyp.SelectedItem = "Výdaj";
                }

                if(cmbKategorie.Items.Contains(docasnyZaznamProEditaci.Popis))
                {
                    cmbKategorie.SelectedItem = docasnyZaznamProEditaci.Popis;
                }
                else
                {
                    cmbKategorie.SelectedItem = "Vlastní...";
                    txtVlastniUcel.Text = docasnyZaznamProEditaci.Popis;
                    txtVlastniUcel.Visible = true;
                }
            }
        }

        private void cmbUcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKategorie.SelectedItem.ToString() == "Vlastní...")
            {
                txtVlastniUcel.Visible = true;  //ukáže textové pole
                txtVlastniUcel.Text = "";
                txtVlastniUcel.Focus();
            }
            else
            {
                txtVlastniUcel.Visible = false;     //skryje textové pole
            }
        }

        private void btnUlozit_Click(object sender, EventArgs e)
        {
            //validace castky
            if (!decimal.TryParse(txtCastka.Text, out decimal castka))
            {
                MessageBox.Show("Zadej platnou částku!");
                return;
            }

            string kategorie;

            if (cmbKategorie.SelectedItem.ToString() == "Vlastní...")
            {
                kategorie = txtVlastniUcel.Text;

                if (string.IsNullOrWhiteSpace(kategorie))
                {
                    MessageBox.Show("Musíš vyplnit vlastní účel!");
                    txtVlastniUcel.Focus();
                    return;
                }

                cmbKategorie.Items.Insert(cmbKategorie.Items.Count - 1, kategorie);
            }
            else
            {
                kategorie = cmbKategorie.SelectedItem.ToString();
            }

            string typ = cmbTyp.SelectedItem.ToString();
            DateTime datum = dtpDatum.Value.Date;

            bool JePrijem = (typ == "Příjem");

            string poznamka = txtPoznamka.Text;


            // ***uložení do databáze***
            try
            {
                using (var db = new AppDbKontext())
                {
                    db.Database.EnsureCreated();

                    //Upravuje se nebo se přidává?
                    if (idUpravovanehoZaznamu != null)
                    {
                        // Najdeme záznam díky ID 
                        var existujiciZaznam = db.Zaznamy.Find(idUpravovanehoZaznamu);

                        if (existujiciZaznam != null)
                        {                           
                            existujiciZaznam.Datum = datum;
                            existujiciZaznam.Popis = kategorie;
                            existujiciZaznam.Castka = castka;
                            existujiciZaznam.JePrijem = JePrijem;
                            existujiciZaznam.Poznamka = txtPoznamka.Text;

                            MessageBox.Show("Záznam byl úspěšně upraven.");
                        }
                        else
                        {
                            MessageBox.Show("Chyba: Záznam k úpravě nebyl nalezen.");
                        }
                    }
                    else
                    {
                        FinancniZaznam novyZaznam = new FinancniZaznam()
                        {
                            Datum = datum,
                            Popis = kategorie,
                            Castka = castka,
                            JePrijem = JePrijem,
                            Poznamka = poznamka

                        };

                        db.Zaznamy.Add(novyZaznam);
                        MessageBox.Show("Nový záznam byl úspěšně uložen.");
                    }

                    db.SaveChanges();
                }

                // Zavoláme událost pro aktualizaci seznamu na hlavním okně
                DataUlozena?.Invoke();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při ukládání do databáze:\n" + ex.Message);
            }
        }

        public void PripravitProEditaci(FinancniZaznam zaznamKEditaci)
        {
            docasnyZaznamProEditaci = zaznamKEditaci;

            
        }

        private void btnZrusit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
