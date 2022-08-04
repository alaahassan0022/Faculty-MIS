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
    public partial class search_staff : Form
    {
        string data = "Data source = orcl; User Id = scott; Password=tiger";
        OracleConnection conn;
        public search_staff()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(data);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "retrive";
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("name", textBox1.Text);
            comm.Parameters.Add("staffnid", OracleDbType.Int32, ParameterDirection.Output);
            comm.Parameters.Add("last_name", OracleDbType.Varchar2, 20, "", ParameterDirection.Output);
            comm.Parameters.Add("staffemail", OracleDbType.Varchar2, 30, "", ParameterDirection.Output);
            comm.Parameters.Add("staffrank", OracleDbType.Varchar2, 20, "", ParameterDirection.Output);
            comm.ExecuteNonQuery();
            textBox2.Text = comm.Parameters["last_name"].Value.ToString();
            textBox3.Text = Convert.ToString(comm.Parameters["staffnid"].Value);
            textBox4.Text = comm.Parameters["staffemail"].Value.ToString();
            textBox5.Text = comm.Parameters["staffrank"].Value.ToString();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
