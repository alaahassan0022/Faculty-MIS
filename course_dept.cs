using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SWE_Project
{
    public partial class course_dept : Form
    {
        crystalreport_deptcourses cry1;
        public course_dept()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cry1 = new crystalreport_deptcourses();
            foreach (ParameterDiscreteValue v in cry1.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cry1;
            cry1.SetParameterValue(0, comboBox1.Text);

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
