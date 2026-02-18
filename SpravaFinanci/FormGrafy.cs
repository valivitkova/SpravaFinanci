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
        public FormGrafy(List<FinancniZaznam> data)
        {
            InitializeComponent();

            //pokud nejsou data, nic se nekreslí
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Nejsou k dispozici žádná data pro grafy.");
                return;
            }

            VykreslitKolac(data);
            VykreslitKrivku(data);
        }

        private void VykreslitKolac(List<FinancniZaznam> data)
        {
            //vyčistit stará data
            chartKolac.Series.Clear();
            chartKolac.Titles.Clear();

            //nadpis
            chartKolac.Titles.Add("Rozložení výdajů podle kategorií");

            //nové data
            Series serie = new Series("Výdaje");
            serie.ChartType = SeriesChartType.Pie; //typ koláčový

            //vezmeme jen výdaje a dáme je podle kategorií
            var dataProGraf = data
                .Where(x => x.JePrijem == false)
                .GroupBy(x => x.Popis)
                .Select(g => new { Kategorie = g.Key, Celkem = g.Sum(x => x.Castka) })
                .ToList();

            //naplnění grafu
            foreach(var polozka in dataProGraf)
            {
                //X = název kategorie, Y = Částka
                int index = serie.Points.AddXY(polozka.Kategorie, polozka.Celkem);


                //aby se v grafu ukazovala i hodnota a název
                serie.Points[index].Label = polozka.Kategorie + ": " + polozka.Celkem + "Kč";
                serie.Points[index].LegendText = polozka.Kategorie;
            }

            chartKolac.Series.Add(serie);
        }

        private void VykreslitKrivku(List<FinancniZaznam> data)
        {
            //vyčistit
            chartKrivka.Series.Clear();
            chartKrivka.Titles.Clear();

            //nadpis
            chartKrivka.Titles.Add("Vývoj zůstatku v čase");

            //serie
            Series serie = new Series("Zůstatek");
            serie.ChartType = SeriesChartType.Line; //typ čára
            serie.BorderWidth = 3; //tlustsi cara
            serie.Color = Color.Blue;

            //data seřadit od nejstaršího
            var serazenaData = data.OrderBy(x => x.Datum).ToList();

            decimal aktualniZustatek = 0;

            //projdeme transakce a počítame průběžný stav
            foreach(var polozka in serazenaData)
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
            chartKrivka.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM";
        }

        private Chart chartKolac;
        private Chart chartKrivka;

        private void InitializeComponent()
        {
            ChartArea chartArea3 = new ChartArea();
            Legend legend3 = new Legend();
            Series series3 = new Series();
            ChartArea chartArea4 = new ChartArea();
            Legend legend4 = new Legend();
            Series series4 = new Series();
            chartKolac = new Chart();
            chartKrivka = new Chart();
            ((ISupportInitialize)chartKolac).BeginInit();
            ((ISupportInitialize)chartKrivka).BeginInit();
            SuspendLayout();
            // 
            // chartKolac
            // 
            chartArea3.Name = "ChartArea1";
            chartKolac.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartKolac.Legends.Add(legend3);
            chartKolac.Location = new Point(12, 12);
            chartKolac.Name = "chartKolac";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartKolac.Series.Add(series3);
            chartKolac.Size = new Size(375, 375);
            chartKolac.TabIndex = 0;
            chartKolac.Text = "chart1";
            // 
            // chartKrivka
            // 
            chartArea4.Name = "ChartArea1";
            chartKrivka.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartKrivka.Legends.Add(legend4);
            chartKrivka.Location = new Point(414, 12);
            chartKrivka.Name = "chartKrivka";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartKrivka.Series.Add(series4);
            chartKrivka.Size = new Size(375, 375);
            chartKrivka.TabIndex = 1;
            chartKrivka.Text = "chart2";
            // 
            // FormGrafy
            // 
            ClientSize = new Size(803, 411);
            Controls.Add(chartKrivka);
            Controls.Add(chartKolac);
            Name = "FormGrafy";
            Text = "Grafy";
            ((ISupportInitialize)chartKolac).EndInit();
            ((ISupportInitialize)chartKrivka).EndInit();
            ResumeLayout(false);
        }

    }
}
