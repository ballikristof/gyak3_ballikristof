using gyak6.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gyak6.Entities;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;

namespace gyak6
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            var mnbservice = new MNBArfolyamServiceSoapClient();

            var request = new GetCurrencyUnitsRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString()
            };

            var response = mnbservice.GetCurrencyUnits(request);

            var result = response.GetCurrencyUnitsResult;

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(result);

            

            foreach (XmlElement element in xmldoc.DocumentElement)
            {
                string currency = "";
                Currencies.Add(currency);

                var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null)
                    continue;
                currency = childElement.GetAttribute("curr");
                
            }
            RefreshDate();
            Console.WriteLine(result);
        }

        public void ServiceHivas()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        public void Diagram()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartarea = chartRateData.ChartAreas[0];
            chartarea.AxisX.MajorGrid.Enabled = false;
            chartarea.AxisY.MajorGrid.Enabled = false;
            chartarea.AxisY.IsStartedFromZero = false;
        }

        public void RefreshDate()
        {
            Rates.Clear();
            ServiceHivas();
            dataGridView1.DataSource = Rates;
            Diagram();
            comboBox1.DataSource = Currencies;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshDate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshDate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDate();
        }
    }
}
