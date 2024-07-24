using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_Management_System_.PAL.User_Control
{
    public partial class UserControlDashboard : UserControl
    {

       private string sql = @"Data Source = LAPTOP-3G37GPHR\sqlexpress;
                                Initial Catalog = Attendance_Management_System2;
                                Integrated Security = True; Encrypt=False";


        public UserControlDashboard()
        {
            InitializeComponent();
        }
        public void Count()
        { 
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            Count();
        }
    }
}
