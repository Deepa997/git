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
    public partial class student : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter sda;
        public student()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            con.Open();
            string sqlstr = " select course_id from tbl_course where course_name='"+comboBox1.SelectedValue+"'";
            sda = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int course_id = int.Parse(dt.Rows[0][0].ToString());
            cmd=new SqlCommand("insert into tbl_studentdb(id,name,address,course_id,year) values("+textBox1.Text+",'"+textBox2.Text+"','"+textBox3.Text+"','"+course_id+"','"+comboBox2.SelectedItem+"')",con);
            cmd.CommandType = CommandType.Text;
            int j = cmd.ExecuteNonQuery();
            if (j > 0)
            {
                MessageBox.Show("inserted succesfully");
            }
            else
            {
                MessageBox.Show("not inserted");
            }
          
            con.Close();

        }

        private void student_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            con.Open();
            string str = "select course_name from tbl_course";
            sda = new SqlDataAdapter(str, con);
            ds = new DataSet();
            sda.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "course_name";
            con.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
