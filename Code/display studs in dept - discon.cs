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
    public partial class display_studs_in_dept___discon : Form
    {
        OracleCommandBuilder builder;
        OracleDataAdapter adapter;
        DataSet ds1;
        public display_studs_in_dept___discon()
        {
            InitializeComponent();
        }

        private void display_studs_in_dept___discon_Load(object sender, EventArgs e)
        {
            string data = "Data source = orcl; User Id = scott; Password=tiger";

            OracleConnection conn = new OracleConnection(data);
            conn.Open();
           
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select deptname from cdept";
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                comboBox1.Items.Add(dr[0].ToString());
            dr.Close();
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl;User Id=scott;Password=tiger;";

            string cmdstr = @"select student.firstname,student.lastname,student.email, student.studentid
                               from student   , cdept 
                            where  student.deptnum= cdept.deptnum and cdept.deptname =  :n";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("n", comboBox1.SelectedItem.ToString());
            ds1 = new DataSet();
            adapter.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
