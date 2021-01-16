using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            coursewise cw = new coursewise();
            cw.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            student st = new student();
            st.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yearwise yw = new yearwise();
            yw.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
