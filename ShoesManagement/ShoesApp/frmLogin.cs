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

namespace ShoesApp
{
    public partial class frmLogin : Form
    {
        IUserRepository userRepository = new UserRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtUsername.Text;
            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Your Username or Password are invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var user = userRepository.CheckLogin(username, password);
                if(user != null)
                {
                    if(user.RoleId == 1)
                    {

                    }else if(user.RoleId == 2)
                    {
                        frmManager newWindow = new frmManager
                        {
                            currentUser = user
                        };
                        this.Hide();
                        newWindow.Show();
                    }else if(user.RoleId == 3)
                    {

                    }
                }
            }
        }
    }
}
