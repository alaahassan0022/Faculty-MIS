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
    public partial class user_information : Form
    {
        public int ii = login.id;
        public static int sd;

        string data = "Data source = orcl; User Id = scott; Password=tiger";
        OracleConnection conn;
        public user_information()
        {
            InitializeComponent();
        }

        private void user_information_Load(object sender, EventArgs e)
        {
            int ii = login.id;
            Console.WriteLine(login.id);
            conn = new OracleConnection(data);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;

            c.CommandType = CommandType.Text;
            if (login.staff) {
                button1.Hide();
                dataGridView1.Hide();
                c.CommandText = "select firstname,lastname,email,profid, rank from staff where profid =:id";
                label5.Text = "Rank";
            }
            else 
                c.CommandText = "select firstname,lastname,email,studentid, deptnum from student where studentid =:id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", login.id);

            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                a1.Text = dr[0].ToString();
                a2.Text = dr[1].ToString();
                a4.Text = dr[2].ToString();
                a5.Text = dr[3].ToString();
                if(login.staff)
                    a6.Text = dr[4].ToString();
                if (!login.staff) {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select deptname from cdept where deptnum = :d ";
                    cmd.Parameters.Add("d", dr[4].ToString());
                    OracleDataReader dr2=  cmd.ExecuteReader();
                    if(dr2.Read())
                    a6.Text = dr2[0].ToString();
                    dr2.Close();
                    sd = int.Parse(dr[4].ToString());
                }

            }

            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "stud_c";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("dep", sd);
            
            cmd.Parameters.Add("CID", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr1 = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (dr1.Read())
            {
                dataGridView1.Rows.Add(dr1[0], dr1[1], dr1[2]);
            }
            dr1.Close();
        }

        private void user_information_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
