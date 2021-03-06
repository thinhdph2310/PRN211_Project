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
    public partial class frmProductAdd : Form
    {
        IProductRepository productRepository = new ProductRepository();
        public Product UpdateInfor { get; set; }
        public User currentUser { get; set; }
        public frmProduct oldWindow { get; set; }
        public frmProductAdd()
        {
            InitializeComponent();
        }
        private Boolean MyValidate()
        {
            Boolean isValid = true;
            String message = "";
            String productName = txtProductName.Text.Trim();
            if (String.IsNullOrEmpty(productName))
            {
                message += "Your Product Name is invalid\n";
                isValid = false;
            }
            else if (productRepository.GetProductByName(productName) != null)
            {
                message += "Product Name is already exist\n";
                isValid = false;
            }
            if (String.IsNullOrEmpty(txtPrice.Text))
            {
                message += "Your Price is invalid\n";
                isValid = false;
            }
            else
            {
                Boolean checkPrice = decimal.TryParse(txtPrice.Text.Trim(), out decimal unitNumber);
                if (checkPrice == false)
                {
                    message += "Price only accept positive number\n";
                    isValid = false;
                }
                else if (unitNumber <= 0)
                {
                    message += "Price can't be negative\n";
                    isValid = false;
                }
            }
            if (String.IsNullOrEmpty(txtStock.Text.Trim()))
            {
                message += "Stock is invalid\n";
                isValid = false;
            }
            else
            {
                Boolean checkStock = int.TryParse(txtStock.Text.Trim(), out int stockNumber);
                if (checkStock == false)
                {
                    message += "Stock only accept number\n";
                    isValid = false;
                }
                else if (stockNumber <= 0)
                {
                    message += "Stock can't be negative\n";
                    isValid = false;
                }
            }
            if (!isValid)
            {
                MessageBox.Show(message, "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MyValidate())
            {
                try
                {
                    var product = new Product
                    {
                        ProductName = txtProductName.Text.Trim(),
                        Price = Decimal.Parse(txtPrice.Text.Trim()),
                        QuantityInStock = int.Parse(txtStock.Text.Trim()),
                        Status = true
                    };
                    productRepository.InsertProduct(product);
                    MessageBox.Show("Added successfully, press load to refresh data", "Message", MessageBoxButtons.OK);
                    oldWindow.LoadProductList(productRepository.GetProducts());
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("You're not allowed to use this", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            else
            {
                txtProductID.Enabled = false;
            }
        }
    }
}
