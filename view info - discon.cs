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
    public partial class view_info___discon : Form
    {
        public view_info___discon()
        {
            InitializeComponent();
        }
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl;User Id=scott;Password=tiger;";
            string cmdstr = "";
            if (radioButton1.Checked)
            {
                cmdstr = "select firstname,lastname ,email ,studentid ,deptnum  from student";
            }
            else if (radioButton2.Checked)
            {
                cmdstr = "select firstname ,lastname ,email ,profid , rank   from staff";
                
            }
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
