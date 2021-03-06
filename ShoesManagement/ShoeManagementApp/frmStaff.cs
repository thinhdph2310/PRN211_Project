using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeManagementApp
{
    public partial class frmStaff : Form
    {
        public User currentUser { get; set; }
        public frmStaff()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.currentUser = null;
            this.Hide();
            frmLogin newWindow = new frmLogin();
            newWindow.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOrder newWindow = new frmOrder
            {
                currentUser = this.currentUser
            };
            this.currentUser = null;
            newWindow.Show();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("You're not allowed to use this", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStaffProduct newWindow = new frmStaffProduct
            {
                currentUser = this.currentUser
            };
            this.currentUser = null;
            newWindow.Show();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNewOrder newWindow = new frmNewOrder
            {
                currentUser = this.currentUser
            };
            this.currentUser = null;
            newWindow.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCustomer newWindow = new frmCustomer
            {
                currentUser = this.currentUser
            };
            this.currentUser = null;
            newWindow.Show();
        }
    }
}
