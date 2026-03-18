using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SpravaFinanci
{
    public partial class FormGrafy : Form
    {
        private List<FinancniZaznam> puvodniData;

        //prvky formuláře
        private Chart chartKolac;
        private Chart chartKrivka;
        private DateTimePicker dtpOd;
        private DateTimePicker dtpDo;
        private Label lblOd;
        private Label lblDo;
        private Button btnFiltrovat;
        private Panel panel1;
        private Button btnReset;
        

        public FormGrafy(List<FinancniZaznam> data)
        {
            InitializeComponent();

            //pokud nejsou data, nic se nekreslí
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Nejsou k dispozici žádná data pro grafy.");
                return;
            }

            //seřadit data podle času
            puvodniData = data.OrderBy(x => x.Datum).ToList();

            NastavitRozsahDatum(data);

            VykreslitKolac(puvodniData);
            VykreslitKrivku(data);
        }

        private void NastavitRozsahDatum(List<FinancniZaznam> data)
        {
            if (data.Count > 0)
            {
                dtpOd.Value = data.Min(x => x.Datum);
                dtpDo.Value = data.Max(x => x.Datum);
            }
        }

        private void btnFiltrovat_Click(object sender, EventArgs e)
        {
            DateTime datumOd = dtpOd.Value.Date;
            DateTime datumDo = dtpDo.Value.Date.AddDays(1).AddSeconds(-1); // do konce dne

            //vyfiltrujeme data podle vybraného časového úseku
            var orezaneData = puvodniData
                .Where(x => x.Datum >= datumOd && x.Datum <= datumDo)
                .ToList();

            //pokud po oříznutí data nebylo nic, upozorníme uživatele
            if (orezaneData.Count == 0)
            {
                MessageBox.Show("V tomto období nejsou žádná data.");
                return;
            }

            VykreslitKolac(orezaneData);
            VykreslitKrivku(orezaneData);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            NastavitRozsahDatum(puvodniData);
            VykreslitKolac(puvodniData);
            VykreslitKrivku(puvodniData);
        }

        private Color ZiskatBarvuProKategorii(string kategorie)
        {

            switch (kategorie)
            {
                case "Jídlo":
                    return Color.LightGreen;
                case "Doprava":
                    return Color.Violet;
                case "Bydlení":
                    return Color.LightSalmon;
                case "Zábava":
                    return Color.LightPink;
                case "Oblečení":
                    return Color.LightSteelBlue;
                default:
                    return Color.Khaki;
            }
        }

        private void VykreslitKolac(List<FinancniZaznam> data)
        {
            //vyčistit stará data
            chartKolac.Series.Clear();
            chartKolac.Titles.Clear();

            // Zapneme vyhlazování hran pro hezčí vzhled
            chartKolac.AntiAliasing = AntiAliasingStyles.All;

            //nadpis
            Title nadpis = chartKolac.Titles.Add("Za co utrácím (výdaje)");
            nadpis.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            nadpis.ForeColor = Color.DarkSlateGray;

            //nové data
            Series serie = new Series("Výdaje");
            serie.ChartType = SeriesChartType.Pie; //typ kolac
            serie["PieLabelStyle"] = "Disabled"; //vypneme popisky
            serie.BorderColor = Color.White;
            serie.BorderWidth = 2;

            string[] vychoziKategorie = { "Jídlo", "Bydlení", "Doprava", "Zábava", "Oblečení" };

            //vezmeme jen výdaje a dáme je podle kategorií
            var vsechnySkupiny = data
                .Where(x => x.JePrijem == false)
                // Pokud Popis JE v seznamu výchozích, necháme ho. Jinak ho přejmenujeme na "Ostatní".
                .GroupBy(x => vychoziKategorie.Contains(x.Popis) ? x.Popis : "Ostatní")
                .Select(g => new { Kategorie = g.Key, Celkem = g.Sum(x => x.Castka) })
                .OrderByDescending(x => x.Celkem)
                .ToList();

            foreach (var polozka in vsechnySkupiny)
            {
                int idx = serie.Points.AddXY(polozka.Kategorie, polozka.Celkem);
                DataPoint bod = serie.Points[idx];

                // Získání barvy (metoda ZiskatBarvuProKategorii se postará o "Ostatní")
                bod.Color = ZiskatBarvuProKategorii(polozka.Kategorie);
                bod.ToolTip = polozka.Kategorie + ": " + polozka.Celkem.ToString("N0") + " Kč";
                bod.LegendText = polozka.Kategorie + " (" + polozka.Celkem.ToString("N0") + " Kč)";

                bod.BorderColor = Color.White;
                bod.BorderWidth = 2;
            }

            chartKolac.Series.Add(serie);

            ChartArea plocha = chartKolac.ChartAreas[0];
            plocha.Position.Auto = true;

            if (chartKolac.Legends.Count > 0)
            {
                Legend leg = chartKolac.Legends[0];
                leg.Position.Auto = true;

                leg.Docking = Docking.Right;
                leg.Alignment = StringAlignment.Center;
                leg.LegendStyle = LegendStyle.Column;

                leg.Font = new Font("Segoe UI", 9);
                leg.BackColor = Color.Transparent;
            }
        }

        private void VykreslitKrivku(List<FinancniZaznam> data)
        {
            //vyčistit
            chartKrivka.Series.Clear();
            chartKrivka.Titles.Clear();

            //nadpis
            Title nadpis = chartKrivka.Titles.Add("Vývoj zůstatku v čase");
            nadpis.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            nadpis.ForeColor = Color.DarkSlateGray;

            //mřížka
            ChartArea oblast = chartKrivka.ChartAreas[0];
            oblast.AxisX.MajorGrid.LineColor = Color.LightGray;
            oblast.AxisY.MajorGrid.LineColor = Color.LightGray;
            oblast.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            oblast.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);

            oblast.AxisX.LabelStyle.Angle = -45; //text šikmo
            oblast.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount; //automatický rozestup

            //serie
            Series serie = new Series("Zůstatek");
            serie.ChartType = SeriesChartType.Line; //typ čára
            serie.BorderWidth = 3; // Tlustší čára
            serie.Color = Color.SteelBlue; // Profesionální modrá
            serie.MarkerStyle = MarkerStyle.Circle; // Puntíky na bodech
            serie.MarkerSize = 8;
            serie.MarkerColor = Color.White;
            serie.MarkerBorderColor = Color.SteelBlue;
            serie.MarkerBorderWidth = 2;

            // Přidáme tooltip (po najetí myší se ukáže hodnota)
            serie.ToolTip = "Datum: #VALX\nZůstatek: #VALY Kč";

            //data seřadit od nejstaršího
            var serazenaData = data.OrderBy(x => x.Datum).ToList();
            decimal aktualniZustatek = 0;

            //projdeme transakce a počítame průběžný stav
            foreach (var polozka in serazenaData)
            {
                if (polozka.JePrijem)
                    aktualniZustatek += polozka.Castka;
                else
                    aktualniZustatek -= polozka.Castka;

                //přidání bodu do grafu
                serie.Points.AddXY(polozka.Datum, aktualniZustatek);
            }

            chartKrivka.Series.Add(serie);

            //formatovani osy x
            oblast.AxisX.LabelStyle.Format = "dd.MM";
        }

        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();
            chartKolac = new Chart();
            chartKrivka = new Chart();
            dtpOd = new DateTimePicker();
            dtpDo = new DateTimePicker();
            lblOd = new Label();
            lblDo = new Label();
            btnFiltrovat = new Button();
            btnReset = new Button();
            panel1 = new Panel();
            ((ISupportInitialize)chartKolac).BeginInit();
            ((ISupportInitialize)chartKrivka).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // chartKolac
            // 
            chartArea1.Name = "ChartArea1";
            chartKolac.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartKolac.Legends.Add(legend1);
            chartKolac.Location = new Point(11, 43);
            chartKolac.Name = "chartKolac";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartKolac.Series.Add(series1);
            chartKolac.Size = new Size(871, 341);
            chartKolac.TabIndex = 0;
            chartKolac.Text = "chart1";
            // 
            // chartKrivka
            // 
            chartArea2.Name = "ChartArea1";
            chartKrivka.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartKrivka.Legends.Add(legend2);
            chartKrivka.Location = new Point(10, 384);
            chartKrivka.Name = "chartKrivka";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartKrivka.Series.Add(series2);
            chartKrivka.Size = new Size(873, 383);
            chartKrivka.TabIndex = 1;
            chartKrivka.Text = "chart2";
            // 
            // dtpOd
            // 
            dtpOd.Location = new Point(48, 10);
            dtpOd.Name = "dtpOd";
            dtpOd.Size = new Size(201, 27);
            dtpOd.TabIndex = 2;
            // 
            // dtpDo
            // 
            dtpDo.Location = new Point(308, 10);
            dtpDo.Name = "dtpDo";
            dtpDo.Size = new Size(200, 27);
            dtpDo.TabIndex = 3;
            // 
            // lblOd
            // 
            lblOd.AutoSize = true;
            lblOd.Location = new Point(10, 11);
            lblOd.Name = "lblOd";
            lblOd.Size = new Size(32, 20);
            lblOd.TabIndex = 4;
            lblOd.Text = "Od:";
            // 
            // lblDo
            // 
            lblDo.AutoSize = true;
            lblDo.Location = new Point(270, 12);
            lblDo.Name = "lblDo";
            lblDo.Size = new Size(32, 20);
            lblDo.TabIndex = 5;
            lblDo.Text = "Do:";
            // 
            // btnFiltrovat
            // 
            btnFiltrovat.Location = new Point(544, 6);
            btnFiltrovat.Name = "btnFiltrovat";
            btnFiltrovat.Size = new Size(76, 32);
            btnFiltrovat.TabIndex = 6;
            btnFiltrovat.Text = "Filtrovat";
            btnFiltrovat.UseVisualStyleBackColor = true;
            btnFiltrovat.Click += btnFiltrovat_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(647, 6);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(76, 32);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblOd);
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(dtpOd);
            panel1.Controls.Add(btnFiltrovat);
            panel1.Controls.Add(lblDo);
            panel1.Controls.Add(dtpDo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(895, 40);
            panel1.TabIndex = 8;
            // 
            // FormGrafy
            // 
            ClientSize = new Size(895, 781);
            Controls.Add(panel1);
            Controls.Add(chartKrivka);
            Controls.Add(chartKolac);
            Name = "FormGrafy";
            ShowIcon = false;
            Text = "Grafy";
            ((ISupportInitialize)chartKolac).EndInit();
            ((ISupportInitialize)chartKrivka).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
    }
}
