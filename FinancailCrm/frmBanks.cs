using FinancailCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancailCrm
{
    public partial class frmBanks : Form
    {
        public frmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void frmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri
            var ziraatBanklBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").
                Select(y => y.BankBalance).FirstOrDefault();
            var vakıfBanklBalance = db.Banks.Where(x => x.BankTitle == "VakıfBank").
                Select(y => y.BankBalance).FirstOrDefault();
            var ışBanklBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").
                Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBanklBalance.ToString() + " ₺";
            lblVakıfBankBalance.Text = vakıfBanklBalance.ToString() + " ₺";
            lblIsBankBalance.Text = ışBanklBalance.ToString() + " ₺";

            //Banka Hareketleri
            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblProcess1.Text = bankProcess1.Descripcition + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblProcess2.Text = bankProcess2.Descripcition + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblProcess3.Text = bankProcess3.Descripcition + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblProcess4.Text = bankProcess4.Descripcition + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblProcess5.Text = bankProcess5.Descripcition + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;
        }

    }
}
