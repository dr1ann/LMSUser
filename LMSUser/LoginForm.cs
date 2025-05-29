using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSUser
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        

        switchUserControl(new UserLogin(this));
        }



        public void switchUserControl(UserControl userControl)
        {
            LoginPanel.Controls.Clear();
            LoginPanel.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;

        }
    }
}
