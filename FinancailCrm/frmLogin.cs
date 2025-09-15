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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text;
            var pass = txtPassword.Text;

            var user = db.Users.FirstOrDefault(x => x.UserName == username);

            if (user != null && user.Password == pass)
            {
                if (user.Password == pass)
                {
                    MessageBox.Show("Giriş Başarılı");
                    this.Hide();
                    frmDashboard dashboard = new frmDashboard();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Şifre Yanlış");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı");

            }
        }
    }
}
