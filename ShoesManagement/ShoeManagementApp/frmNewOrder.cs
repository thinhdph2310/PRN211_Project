using DataAccess.DataAccess;
using DataAccess.Repository;
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
    public partial class frmNewOrder : Form
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        public User currentUser { get; set; }
        BindingSource customerSource;
        public frmNewOrder()
        {
            InitializeComponent();
        }

        public void LoadCustomerList(IEnumerable<Customer> customers)
        {
            try
            {
                customerSource = new BindingSource();
                customerSource.DataSource = customers;

                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = customerSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Product List");
            }
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("You're not allowed to use this", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            LoadCustomerList(customerRepository.GetCustomers());
            dgvCustomer.ClearSelection();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadCustomerList(customerRepository.GetCustomers());
            dgvCustomer.ClearSelection();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStaff newWindow = new frmStaff
            {
                currentUser = this.currentUser
            };
            this.currentUser = null;
            this.Hide();
            newWindow.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.currentUser = null;
            this.Hide();
            frmLogin newWindow = new frmLogin();
            newWindow.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search = txtSearch.Text.Trim();
            var searchCat = comboSearch.SelectedItem;
            if (!string.IsNullOrEmpty(search) && searchCat == null)
            {
                MessageBox.Show("You must select search category first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (searchCat != null)
            {
                if (searchCat.ToString().Equals("Name"))
                {
                    LoadCustomerList(customerRepository.GetCustomersByName(search));
                    dgvCustomer.ClearSelection();

                }
                if (searchCat.ToString().Equals("ID"))
                {
                    LoadCustomerList(customerRepository.GetCustomerByIDNumber(search));
                    dgvCustomer.ClearSelection();
                }
            }
        }
    }
}
