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

namespace FinancailCrm
{
    public partial class frmBilling : Form
    {
        public frmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void frmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList(); 
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = Decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriot.Text;

            Bills bill = new Bills();
            bill.BillTitle = title;
            bill.BillAmount = amount;
            bill.BillPeriod = period;
            db.Bills.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı");

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            string id = txtBillId.Text;
            int billId = Int32.Parse(id);
            var removedValues = db.Bills.Find(billId);
            db.Bills.Remove(removedValues);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = Decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriot.Text;
            string id = txtBillId.Text;
            int billId = Int32.Parse(id);

            var updatedValues = db.Bills.Find(billId);

            updatedValues.BillTitle = title;
            updatedValues.BillAmount = amount;
            updatedValues.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı");

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }
    }
}
