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
    public partial class FormPridat : Form
    {
        public FormPridat()
        {
            InitializeComponent();
        }

        private void FormPridat_Load(object sender, EventArgs e)
        {
            // Přidání položek do ComboBoxu
            cmbUcel.Items.Add("Jídlo");
            cmbUcel.Items.Add("Doprava");
            cmbUcel.Items.Add("Bydlení");
            cmbUcel.Items.Add("Zábava");
            cmbUcel.Items.Add("Oblečení");
            cmbUcel.Items.Add("Vlastní...");
            cmbUcel.SelectedIndex = 0;

            cmbTyp.Items.Add("Vklad");
            cmbTyp.Items.Add("Výběr");
            cmbTyp.SelectedIndex = 0;
        }

        private void cmbUcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUcel.SelectedItem.ToString() == "Vlastní...")
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
            string ucel;

            if (cmbUcel.SelectedItem.ToString() == "Vlasní...")
            {
                ucel = txtVlastniUcel.Text;

                if (!string.IsNullOrWhiteSpace(ucel))
                {
                    //přidá vlastní účel do ComboBoxu (Před položku Vlastni...)
                    cmbUcel.Items.Insert(cmbUcel.Items.Count - 1, ucel);
                }
            }
            else
            {
                ucel = cmbUcel.SelectedItem.ToString();
            }
        }
    }
}
