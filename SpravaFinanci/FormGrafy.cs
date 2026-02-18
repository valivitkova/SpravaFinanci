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

        public FormGrafy(List<FinancniZaznam> data)
        {
            InitializeComponent();

            this.Padding = new Padding(10); //okraje okolo

            //pokud nejsou data, nic se nekreslí
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Nejsou k dispozici žádná data pro grafy.");
                return;
            }

            puvodniData = data;

            NastavitRozsahDatum(data);

            VykreslitKolac(data);
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

            var orezaneData = puvodniData
                .Where(x => x.Datum >= datumOd && x.Datum <= datumDo)
                .ToList();

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

            //nadpis
            Title nadpis = chartKolac.Titles.Add("Za co utrácím (výdaje)");
            nadpis.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            nadpis.ForeColor = Color.DarkSlateGray;

            //nové data
            Series serie = new Series("Výdaje");
            serie.ChartType = SeriesChartType.Doughnut; //typ koblizek
            serie["PieLabelStyle"] = "Disabled"; //vypneme popisky
            serie.BorderColor = Color.White;
            serie.BorderWidth = 3;

            //vezmeme jen výdaje a dáme je podle kategorií
            var vsechnySkupiny = data
                .Where(x => x.JePrijem == false)
                .GroupBy(x => x.Popis)
                .Select(g => new { Kategorie = g.Key, Celkem = g.Sum(x => x.Castka) })
                .OrderByDescending(x => x.Celkem)
                .ToList();

            int limitPoctu = 6; // kolik kategorií bude v legendě

            var topKategorie = vsechnySkupiny.Take(limitPoctu).ToList();
            var zbytekCastka = vsechnySkupiny.Skip(limitPoctu).Sum(x => x.Celkem);

            var finalniData = topKategorie.Select(x => new { x.Kategorie, x.Celkem }).ToList();

            if(zbytekCastka > 0)
            {
                finalniData.Add(new { Kategorie = "Ostatní", Celkem = zbytekCastka });
            }
            //naplnění grafu
            foreach (var polozka in finalniData)
            {
                //X = název kategorie, Y = Částka
                int index = serie.Points.AddXY(polozka.Kategorie, polozka.Celkem);
                DataPoint bod = serie.Points[index];

                bod.Color = ZiskatBarvuProKategorii(polozka.Kategorie);

                //aby se v grafu ukazovala i hodnota a název
                bod.ToolTip = polozka.Celkem + "Kč";
                bod.LegendText = polozka.Kategorie;
            }

            chartKolac.Series.Add(serie);

            // Nastavení Legendy (dole, čistá)
            if (chartKolac.Legends.Count > 0)
            {
                chartKolac.Legends[0].Docking = Docking.Bottom;
                chartKolac.Legends[0].Alignment = StringAlignment.Center;
                chartKolac.Legends[0].Font = new Font("Segoe UI", 9);
                chartKolac.Legends[0].BackColor = Color.Transparent;
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
            serie.ToolTip = "Zůstatek: #VALY{C0}";

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

        private Chart chartKolac;
        private DateTimePicker dtpOd;
        private DateTimePicker dtpDo;
        private Label label1;
        private Label label2;
        private Button btnFiltrovat;
        private Button btnReset;
        private Chart chartKrivka;

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
            label1 = new Label();
            label2 = new Label();
            btnFiltrovat = new Button();
            btnReset = new Button();
            ((ISupportInitialize)chartKolac).BeginInit();
            ((ISupportInitialize)chartKrivka).BeginInit();
            SuspendLayout();
            // 
            // chartKolac
            // 
            chartArea1.Name = "ChartArea1";
            chartKolac.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartKolac.Legends.Add(legend1);
            chartKolac.Location = new Point(12, 12);
            chartKolac.Name = "chartKolac";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartKolac.Series.Add(series1);
            chartKolac.Size = new Size(871, 375);
            chartKolac.TabIndex = 0;
            chartKolac.Text = "chart1";
            // 
            // chartKrivka
            // 
            chartArea2.Name = "ChartArea1";
            chartKrivka.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartKrivka.Legends.Add(legend2);
            chartKrivka.Location = new Point(10, 393);
            chartKrivka.Name = "chartKrivka";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartKrivka.Series.Add(series2);
            chartKrivka.Size = new Size(873, 375);
            chartKrivka.TabIndex = 1;
            chartKrivka.Text = "chart2";
            // 
            // dtpOd
            // 
            dtpOd.Location = new Point(62, 23);
            dtpOd.Name = "dtpOd";
            dtpOd.Size = new Size(200, 27);
            dtpOd.TabIndex = 2;
            // 
            // dtpDo
            // 
            dtpDo.Location = new Point(62, 56);
            dtpDo.Name = "dtpDo";
            dtpDo.Size = new Size(200, 27);
            dtpDo.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 4;
            label1.Text = "Od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 5;
            label2.Text = "Do:";
            // 
            // btnFiltrovat
            // 
            btnFiltrovat.Location = new Point(73, 96);
            btnFiltrovat.Name = "btnFiltrovat";
            btnFiltrovat.Size = new Size(76, 32);
            btnFiltrovat.TabIndex = 6;
            btnFiltrovat.Text = "Filtrovat";
            btnFiltrovat.UseVisualStyleBackColor = true;
            btnFiltrovat.Click += btnFiltrovat_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(173, 98);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(76, 29);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // FormGrafy
            // 
            ClientSize = new Size(895, 781);
            Controls.Add(btnReset);
            Controls.Add(btnFiltrovat);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpDo);
            Controls.Add(dtpOd);
            Controls.Add(chartKrivka);
            Controls.Add(chartKolac);
            Name = "FormGrafy";
            ShowIcon = false;
            Text = "Grafy";
            ((ISupportInitialize)chartKolac).EndInit();
            ((ISupportInitialize)chartKrivka).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
