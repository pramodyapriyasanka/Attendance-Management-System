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
    public partial class UserControlAddClass : UserControl
    {
        private string sql = @"Data Source = LAPTOP-3G37GPHR\sqlexpress;
                                Initial Catalog = Attendance_Management_System2;
                                Integrated Security = True; Encrypt=False";

        private string CID = "";


        public UserControlAddClass()
        {
            InitializeComponent();
        }

        private void IntegerType(KeyPressEventArgs e)
        { 
            if(!(Char.IsDigit(e.KeyChar)  ||  (e.KeyChar == (Char)Keys.Back)))
                e.Handled = true;
        }

        public void ClearTextBox()
        {
            textBoxName.Clear();
            textBoxNoStudents.Clear();
            textBoxMale.Clear();
            textBoxFemale.Clear();
            tabControlAddClass.SelectedTab = tabPageAddClass;

        }

        private void ClearTextBox1()
        {
            textBoxName1.Clear();
            textBoxNoStudents1.Clear();
            textBoxMale1.Clear();
            textBoxFemale1.Clear();
            CID = "";
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Attendance.Attendance.DisplayAndSearchAllData("SELECT * FROM Class_Table WHERE Class_Name LIKE '%" + textBoxSearch.Text + "%';", dataGridViewClass, sql);
        }

        private void tabPageSearchClass_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBoxSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBoxSearch, "Search");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == string.Empty || textBoxNoStudents.Text.Trim() == string.Empty || textBoxMale.Text.Trim() == string.Empty || textBoxFemale.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool check = Attendance.Attendance.AddClass(textBoxName.Text.Trim(), textBoxNoStudents.Text.Trim(), textBoxMale.Text.Trim(), textBoxFemale.Text.Trim(), sql);   

                if (check)
                    ClearTextBox();
            }
        }

        private void tabPageUPClass_Leave(object sender, EventArgs e)
        {
            ClearTextBox1();
        }

        private void tabPageSearchClass_Enter(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            Attendance.Attendance.DisplayAndSearchAllData("SELECT * FROM Class_Table;", dataGridViewClass, sql);
            dataGridViewClass.Columns[0].Visible = false;
            labelCountClass.Text = dataGridViewClass.Rows.Count.ToString();

        }

        private void tabPageAddClass_Enter(object sender, EventArgs e)
        {
            ClearTextBox1();
        }

        private void tabPageAddClass_Leave(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void textBoxNoStudents_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntegerType(e);
        }

        private void textBoxMale_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntegerType(e);
        }

        private void textBoxFemale_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntegerType(e);
        }

        private void textBoxNoStudents1_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntegerType(e);
        }

        private void textBoxMale1_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntegerType(e);
        }

        private void textBoxFemale1_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntegerType(e);
        }

        private void dataGridViewClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewClass.Rows[e.RowIndex];
                CID = row.Cells[0].Value.ToString();
                textBoxName1.Text = row.Cells[1].Value.ToString();
                textBoxNoStudents1.Text= row.Cells[2].Value.ToString();
                textBoxMale1.Text = row.Cells[3].Value.ToString();  
                textBoxFemale1.Text = row.Cells[4].Value.ToString();    
                 
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (CID != "")
            {
                if (textBoxName1.Text.Trim() == string.Empty || textBoxNoStudents1.Text.Trim() == string.Empty || textBoxMale1.Text.Trim() == string.Empty || textBoxFemale1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bool check = Attendance.Attendance.UpdateClass(CID, textBoxName1.Text.Trim(), textBoxNoStudents1.Text.Trim(), textBoxMale1.Text.Trim(), textBoxFemale1.Text.Trim(), sql);

                    if (check)
                        ClearTextBox();
                }
            }
            else
                MessageBox.Show("Select row from Table.", "Select row", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CID != "")
            {
                if (textBoxName1.Text.Trim() == string.Empty || textBoxNoStudents1.Text.Trim() == string.Empty || textBoxMale1.Text.Trim() == string.Empty || textBoxFemale1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete this class?", "Delete Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dialogResult == DialogResult.Yes) 
                    {
                        bool check = Attendance.Attendance.DeleteClass(CID, sql);

                        if (check)
                            ClearTextBox();
                    }
                }
            }
            else
                MessageBox.Show("Select row from Table.", "Select row", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
