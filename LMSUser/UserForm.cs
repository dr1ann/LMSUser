using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LMSUser
{
    public partial class UserForm : Form
    {
        public Panel UserPanelControl => UserPanel;
        public string FullName { get; private set; }
        public string Status { get; private set; }
        public int UserID { get; private set; }

        public UserForm(string fullName, string status, int userID)
        {
            InitializeComponent();
            FullName = fullName;
            Status = status;
            UserID = userID;

            // Load default control (like UserDashboard)
            var dashboard = new UserDashboard(FullName, Status, UserID, this);
            dashboard.Dock = DockStyle.Fill;
            UserPanel.Controls.Add(dashboard);
        }
    }
}
