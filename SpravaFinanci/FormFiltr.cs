using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpravaFinanci
{
    public partial class FormFiltr : Form
    {
        // Veřejná vlastnost, přes kterou si hlavní okno vyzvedne výsledek
        public FiltrData VysledekFiltru { get; private set; }

        // Upravený konstruktor, který přijímá seznam kategorií z hlavního okna
        public FormFiltr(List<string> existujiciKategorie)
        {
            InitializeComponent();

            //naplnění comboBoxu kategorií
            cmbKategorie.Items.Add("Vše");
            foreach (string kat in existujiciKategorie)
            {
                //přidáme jen neprázdné kategorie
                if (!string.IsNullOrEmpty(kat))
                {
                    cmbKategorie.Items.Add(kat);
                }
            }
            cmbKategorie.SelectedIndex = 0;

            dtpOd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDo.Value = DateTime.Now.Date;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            VysledekFiltru = new FiltrData();

            //Datumy
            if(chkPouzitDatum.Checked)
            {
                DateTime d1 = dtpOd.Value.Date;
                DateTime d2 = dtpDo.Value.Date;

                // POJISTKA: Pokud je "Od" větší než "Do", prohodíme je
                if (d1 > d2)
                {
                    DateTime pom = d1;
                    d1 = d2;
                    d2 = pom;
                }

                VysledekFiltru.DatumOd = d1;
                VysledekFiltru.DatumDo = d2.AddDays(1).AddSeconds(-1);
            }

            //Částky
            if(chkPouzitCastku.Checked)
            {
                VysledekFiltru.CastkaOd = numOd.Value;
                VysledekFiltru.CastkaDo = numDo.Value;
            }

            //Kategorie
            if (chkPouzitKategorii.Checked)
            {
                if (cmbKategorie.SelectedItem != null && cmbKategorie.SelectedItem.ToString() != "Vše")
                {
                    VysledekFiltru.Kategorie = cmbKategorie.SelectedItem.ToString();
                }

                //Typ
                if (cmbTyp.SelectedItem != null && cmbTyp.SelectedItem.ToString() != "Vše")
                {
                    string vybranyTyp = cmbTyp.SelectedItem.ToString();
                    if (vybranyTyp == "Příjem")
                    {
                        VysledekFiltru.JePrijem = true;
                    }
                    else if (vybranyTyp == "Výdaj")
                    {
                        VysledekFiltru.JePrijem = false;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkPouzitDatum_CheckedChanged(object sender, EventArgs e)
        {
            grpDatum.Enabled = chkPouzitDatum.Checked;
        }

        private void chkPouzitCastku_CheckedChanged(object sender, EventArgs e)
        {
            grpCastka.Enabled = chkPouzitCastku.Checked;
        }

        private void chkPouzitKategorii_CheckedChanged(object sender, EventArgs e)
        {
            grpOstatni.Enabled = chkPouzitKategorii.Checked;
        }
    }
}
