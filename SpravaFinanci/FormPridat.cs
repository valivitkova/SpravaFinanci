using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaFinanci
{
    public partial class FormPridat : Form
    {
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

            cmbTyp.Items.Add("Vklad");
            cmbTyp.Items.Add("Výběr");
            cmbTyp.SelectedIndex = 0;

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

        private void btnPridat_Click(object sender, EventArgs e)
        {
            //validace castky
            if (!decimal.TryParse(txtCastka.Text, out decimal castka))
            {
                MessageBox.Show("Zadej platnou částku!");
                return;
            }

            string kategorie;

            if (cmbKategorie.SelectedItem.ToString() == "Vlasní...")
            {
                kategorie = txtVlastniUcel.Text;

                if (!string.IsNullOrWhiteSpace(kategorie))
                {
                    //přidá vlastní účel do ComboBoxu (Před položku Vlastni...)
                    cmbKategorie.Items.Insert(cmbKategorie.Items.Count - 1, kategorie);
                }
            }
            else
            {
                kategorie = cmbKategorie.SelectedItem.ToString();
            }

            string typ = cmbTyp.SelectedItem.ToString();
            DateTime datum = dtpDatum.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
