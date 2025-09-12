using FinancailCrm.Models;
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

namespace FinancailCrm
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺";

            var lastProcess = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcess.Text = lastProcess.ToString() + " ₺";

            //Chart 1 Kodları
            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();

            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //Chart 2 Kodları
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Series2");
            series2.ChartType= System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Renko;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            count++;

            if (count % 4 == 1)
            {
                var elektrik = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").
                    Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrik.ToString() + " ₺";
            }
            if (count % 4 == 2)
            {
                var dogalgaz = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").
                    Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = dogalgaz.ToString() + " ₺";
            }
            if (count % 4 == 3)
            {
                var su = db.Bills.Where(x => x.BillTitle == "Su Faturası").
                    Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = su.ToString() + " ₺";
            }
            if (count % 4 == 4)
            {
                var internet = db.Bills.Where(x => x.BillTitle == "Internet Faturası").
                    Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Internet Faturası";
                lblBillAmount.Text = internet.ToString() + " ₺";
            }
        }
    }
}
