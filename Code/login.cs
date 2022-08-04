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
    public partial class login : Form
    {
        public static int id = 0;
        public static bool staff = false;

        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        string data = "Data source = orcl; User Id = scott; Password=tiger";
        OracleConnection conn;

        public login()
        {
            InitializeComponent();
            staff = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(data);
            conn.Open();
            staff = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            if (!checkBox1.Checked)     //stud
            {
                cmd.CommandText = "select * from student where studentid=:n and password = :p";
            }
            else
            {
                staff = true;
                cmd.CommandText = "select * from staff where profid=:n and password = :p";

            }
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("n", textBox1.Text);
            cmd.Parameters.Add("p", textBox2.Text);
            OracleDataReader rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                MessageBox.Show("Invalid Data...!!!");
            }
            else
            {
                id = int.Parse(textBox1.Text);
                /*login fun*/
                this.Hide();

                Menu m = new Menu();
                m.Show();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            staff = !staff;
        }
    }
}
