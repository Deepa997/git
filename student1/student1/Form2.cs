using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace student1
{
    public partial class Form2 : Form
    {
        SqlConnection st;
        
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            st.Open();
            cmd=new SqlCommand("insert into tbl_course(course_id,course_name) values("+textBox1.Text+",'"+textBox2.Text+"')",st);
            int j=cmd.ExecuteNonQuery();
            if(j>0)
            {
                MessageBox.Show("course added successfully'"+textBox1.Text+"'");
            }
            else
            {
                MessageBox.Show("failed");
            }
            st.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        
        }
    }
}
