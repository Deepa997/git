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
    public partial class yearwise : Form
    {
        SqlConnection con;
        DataSet ds, ds1;
        SqlDataAdapter da, da1;
        public yearwise()
        {
            InitializeComponent();
        }

        private void yearwise_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            con.Open();
            string sqlstr = "select year from tbl_studentdb";
            da = new SqlDataAdapter(sqlstr, con);
            ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "year";
            comboBox1.DisplayMember = "year";
            loaddata();
            con.Close();

        }
        public void loaddata()
        {
            con = new SqlConnection(@"Data Source=desktop-bttfkh6\sqlexpress;Initial Catalog=student1;Integrated Security=True");
            con.Open();
            string str = "select * from tbl_studentdb,tbl_course where tbl_course.course_id=tbl_studentdb.course_id and tbl_studentdb.year='" + comboBox1.SelectedValue + "'";
            da1 = new SqlDataAdapter(str, con);
            ds1 = new DataSet();
            da1.Fill(ds1);
            
            dataGridView1.DataSource = ds1.Tables[0];
        } 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
