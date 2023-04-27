using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Analysis
{
    public partial class frmSalesAnalysis : Form
    {
        public frmSalesAnalysis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile = File.OpenText("Sales.txt");

                List<string> sales = new List<string>();

                while(!inputFile.EndOfStream)
                {
                    sales.Add(inputFile.ReadLine());
                }

                inputFile.Close();

                foreach(string sale in sales)
                {
                    lboxSalesList.Items.Add(sale);
                }

                double average = GetAverageSale(sales);
                double highest = GetHighestSale(sales);
                double lowest = GetLowestSale(sales);

                lblAverage.Text = average.ToString("c");
                lblHighest.Text = highest.ToString("c");
                lblLowest.Text = lowest.ToString("c");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double GetLowestSale(List<string> sales)
        {
            double lowestSale = double.Parse(sales[0]);

            foreach(string sale in sales)
            {
                if(lowestSale > double.Parse(sale))
                {
                    lowestSale = double.Parse(sale);
                }
            }

            return lowestSale;
        }

        private double GetHighestSale(List<string> sales)
        {
            double higestSale = double.Parse(sales[0]);

            foreach (string sale in sales)
            {
                if (higestSale < double.Parse(sale))
                {
                    higestSale = double.Parse(sale);
                }
            }

            return higestSale;
        }

        private double GetAverageSale(List<string> sales)
        {
            double total = 0;

            foreach(string sale in sales)
            {
                total += double.Parse(sale);
            }

            double average = total / sales.Count;

            return average;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lboxSalesList.Items.Clear();
            lblAverage.Text = "";
            lblHighest.Text = "";
            lblLowest.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
