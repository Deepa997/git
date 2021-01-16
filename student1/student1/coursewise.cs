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
    public partial class coursewise : Form
    {
        SqlConnection con;
        SqlDataAdapter da,da1;
        DataSet ds,ds1;
        public coursewise()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void coursewise_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            con.Open();
            string sqlstr = "select course_name from tbl_course";
            da = new SqlDataAdapter(sqlstr, con);
            ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "course_name";
            comboBox1.DisplayMember = "course_name";
            loaddata();
            con.Close();
        }
        public void loaddata()
        {
            con = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            con.Open();
            string str = "select * from tbl_studentdb,tbl_course where tbl_course.course_id=tbl_studentdb.course_id and tbl_course.course_name='" + comboBox1.SelectedValue + "'";
            da1 = new SqlDataAdapter(str, con);
            ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
        }
    }
}
