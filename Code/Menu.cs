using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWE_Project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yourDepartmentCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_available_courses show_Available_Courses = new show_available_courses();
            show_Available_Courses.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (!login.staff)
            {
                reportsToolStripMenuItem.Visible = false;
                manageInfoToolStripMenuItem.Visible = false;
            }
            else
            {
                staffToolStripMenuItem.Visible = false;
                yourDepartmentCoursesToolStripMenuItem.Visible = false;
            }
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void displayInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_information ui = new user_information();
            ui.Show();

        }

        private void searchStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search_staff s = new search_staff();
            s.Show();
        }

        private void studentDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stud_dept s = new stud_dept();
            s.Show();
        }

        private void coursesDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            course_dept cd = new course_dept();
            cd.Show();
        }

        private void manageStudentAndStaffInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_info___discon v = new view_info___discon();
            v.Show();
        }

        private void manageStudentsInDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_studs_in_dept___discon dsd = new display_studs_in_dept___discon();
            dsd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
