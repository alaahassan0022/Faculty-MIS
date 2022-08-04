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
    public partial class register : Form
    {
        int dno;
        public static int x = 0;

        string data = "Data source = orcl; User Id = scott; Password=tiger";
        OracleConnection conn;
        public register()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(data);
            conn.Open();
            label7.Hide();
            textBox7.Hide();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select deptname from cdept";
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                   comboBox1.Items.Add(dr[0].ToString());
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            x = 0;
            if (!checkBox1.Checked) //stud
            {
                x = 1;
            
                c.CommandText = "insert into student values (:fisrtname , :lastname ,:password , :email , :id , :dept )";
                
                c.Parameters.Add("firstname", textBox1.Text);
                c.Parameters.Add("lastname", textBox2.Text);
                c.Parameters.Add("password", textBox3.Text);
                c.Parameters.Add("email", textBox4.Text);

                c.Parameters.Add("id", int.Parse(textBox5.Text));
                c.Parameters.Add("dept", dno);

                // id is unique
                // dept must be found 
            }

            else
            {
                c.CommandText = "insert into staff values (:fisrtname , :lastname ,:password , :email , :id, :rank)";
                c.Parameters.Add("firstname", textBox1.Text);
                c.Parameters.Add("lastname", textBox2.Text);
                c.Parameters.Add("password", textBox3.Text);
                c.Parameters.Add("email", textBox4.Text);
                c.Parameters.Add("id", int.Parse(textBox5.Text));
                c.Parameters.Add("rank", textBox7.Text);
            }





            c.CommandType = CommandType.Text;
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("User Registered Successfully");
                this.Hide();
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label7.Show();
                textBox7.Show();
                label6.Hide();
                comboBox1.Hide();
            }
            else {
                label7.Hide();
                textBox7.Hide();
                label6.Show();
                comboBox1.Show();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select deptnum from cdept where deptname =:d";
            cmd.Parameters.Add("d", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                dno = int.Parse(dr[0].ToString());
            dr.Close();
        }
    }
}
