using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_Management_System_.PAL.User_Control
{
    public partial class UserControlAddStudent : UserControl
    {
        private string sql = @"Data Source = LAPTOP-3G37GPHR\sqlexpress;
                                Initial Catalog = Attendance_Management_System2;
                                Integrated Security = True; Encrypt=False";

        private string SID = "" , gender ="";

        public UserControlAddStudent()
        {
            InitializeComponent();
        }

        public void ClearTextBox()
        {
            textBoxName.Clear();
            textBoxRegNo.Clear();
            comboBoxClass.SelectedIndex = -1;
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;
            tabControlAddStudent.SelectedTab = tabPageAddStudent;

        }

        private void ClearTextBox1()
        {
            textBoxName1.Clear();
            textBoxRegNo1.Clear();
            comboBoxClass1.SelectedIndex = -1;
            radioButtonMale1.Checked = false;
            radioButtonFemale1.Checked = false;
            SID = "";

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPageAddStudent_Click(object sender, EventArgs e)
        {

        }

        private void tabPageUPClass_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxSearch_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void tabPageSearchStudent_Enter(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            comboBoxSearchBy.SelectedIndex = -1;
            Attendance.Attendance.DisplayAndSearchAllData("SELECT Student_ID, Student_Name, Student_Reg, Student_Gender,Class_Name FROM Student_Table INNER JOIN Class_Table ON Student_Table.Class_ID=Class_Table.Class_ID;", dataGridViewStudent, sql);
            dataGridViewStudent.Columns[0].Visible = false;
            labelCountStudent.Text = dataGridViewStudent.Rows.Count.ToString();

        }

        private void tabPageAddStudent_Enter(object sender, EventArgs e)
        {
            ClearTextBox1();
        }

        private void tabPageAddStudent_Leave(object sender, EventArgs e)
        {
            ClearTextBox1();
        }

        private void tabPageUPStudent_Enter(object sender, EventArgs e)
        {
            ClearTextBox1();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (radioButtonMale.Checked)
                gender = "Male";
            if (radioButtonFemale.Checked)
                gender = "Female";

            if (textBoxName.Text.Trim() == string.Empty || textBoxRegNo.Text.Trim() == string.Empty || comboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (radioButtonMale.Checked == false && radioButtonFemale.Checked == false)
            {
                MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool check = Attendance.Attendance.AddStudent(textBoxName.Text.Trim(), textBoxRegNo.Text.Trim(), comboBoxClass.SelectedItem.ToString(), gender, sql);

                if (check)
                    ClearTextBox();
            }
        }

        private void comboBoxClass_Click(object sender, EventArgs e)
        {
            comboBoxClass.Items.Clear();
            Attendance.Attendance.FillComboBox("SELECT DISTINCT (Class_Name) FROM Class_Table;", comboBoxClass, sql);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedIndex == 0)
                Attendance.Attendance.DisplayAndSearchAllData("SELECT Student_ID, Student_Name, Student_Reg, Student_Gender,Class_Name FROM Student_Table INNER JOIN Class_Table ON Student_Table.Class_ID=Class_Table.Class_ID WHERE Student_Name LIKE '%" + textBoxSearch.Text.Trim() + "%'", dataGridViewStudent, sql);
            if (comboBoxSearchBy.SelectedIndex == 1)
                Attendance.Attendance.DisplayAndSearchAllData("SELECT Student_ID, Student_Name, Student_Reg, Student_Gender,Class_Name FROM Student_Table INNER JOIN Class_Table ON Student_Table.Class_ID=Class_Table.Class_ID WHERE Student_Reg LIKE '%" + textBoxSearch.Text.Trim() + "%'", dataGridViewStudent, sql);
            if (comboBoxSearchBy.SelectedIndex == 2)
                Attendance.Attendance.DisplayAndSearchAllData("SELECT Student_ID, Student_Name, Student_Reg, Student_Gender,Class_Name FROM Student_Table INNER JOIN Class_Table ON Student_Table.Class_ID=Class_Table.Class_ID WHERE Class_Name LIKE '%" + textBoxSearch.Text.Trim() + "%'", dataGridViewStudent, sql);

        }

        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewStudent.Rows[e.RowIndex];
                SID = row.Cells["Column1"].Value.ToString();
                textBoxName1.Text = row.Cells["Column2"].Value.ToString();
                textBoxRegNo1.Text = row.Cells["Column3"].Value.ToString();
                comboBoxClass1.Items.Clear();
                Attendance.Attendance.FillComboBox("SELECT DISTINCT (Class_Name) FROM Class_Table;", comboBoxClass1, sql);
                comboBoxClass1.SelectedItem = row.Cells["Column4"].Value.ToString();
                if (row.Cells["Column5"].Value.ToString() == "Male")
                    radioButtonMale1.Checked = true;
                if (row.Cells["Column5"].Value.ToString() == "Female")
                    radioButtonFemale1.Checked = true;


            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (SID != "")
            {
                if (radioButtonMale1.Checked)
                    gender = "Male";
                if (radioButtonFemale1.Checked)
                    gender = "Female";

                if (textBoxName1.Text.Trim() == string.Empty || textBoxRegNo1.Text.Trim() == string.Empty || comboBoxClass1.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (radioButtonMale1.Checked == false && radioButtonFemale1.Checked == false)
                {
                    MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    bool check = Attendance.Attendance.UpdateStudent(SID, textBoxName1.Text.Trim(), textBoxRegNo1.Text.Trim(), comboBoxClass1.SelectedItem.ToString(), gender, sql);

                    if (check)
                        ClearTextBox1();
                }
            }


            else
                MessageBox.Show("Select row from Table.", "Select row", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserControlAddStudent_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (SID != "")
            {
                if (radioButtonMale1.Checked)
                    gender = "Male";
                if (radioButtonFemale1.Checked)
                    gender = "Female";

                if (textBoxName1.Text.Trim() == string.Empty || textBoxRegNo1.Text.Trim() == string.Empty || comboBoxClass1.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (radioButtonMale1.Checked == false && radioButtonFemale1.Checked == false)
                {
                    MessageBox.Show("Fill out all the fields.", "Required all Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete this Student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bool check = Attendance.Attendance.DeleteStudent(SID, sql);

                        if (check)
                            ClearTextBox();
                    }
                }
            }
            else
                MessageBox.Show("Select row from Table.", "Select row", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
