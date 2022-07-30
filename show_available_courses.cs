using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SWE_Project
{
    public partial class show_available_courses : Form
    {
        string data = "Data source = orcl; User Id = scott; Password=tiger";
        OracleConnection conn;

        public show_available_courses()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(data);
            conn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(data);
            conn.Open();


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            dataGridView1.Rows.Clear();


            cmd.CommandText = "select c.coursename, c.courseid, c.credithours, p.firstname from course c , course_dept cd, student s , staff p where c.courseid = cd.courseid and cd.deptnum = s.deptnum and c.profid = p.profid and s.studentid =:n";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("n", login.id);
            OracleDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                dataGridView1.Rows.Add(dr1[0], dr1[1], dr1[2], dr1[3]);
            }

            dr1.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            search_staff f5 = new search_staff();
            this.Hide();
            f5.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
