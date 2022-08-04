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
    public partial class Form1 : Form
    {
        public static int user_name = 0;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            login f2 = new login();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register f4 = new register();
            f4.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
