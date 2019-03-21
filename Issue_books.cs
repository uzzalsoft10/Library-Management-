using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Issue_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project\lb.mdf;Integrated Security=True;Connect Timeout=30");
        public Issue_books()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int books_qty = 0 ;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select *from books_info where book_name='" + st_bookName.Text + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach(DataRow dr2 in dt2.Rows)
            {
                books_qty = Convert.ToInt32(dr2["available_quantity"].ToString());
            }
            if (books_qty > 0)
            { 

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into issue_books values ('" + St_name.Text + "','" + st_smstr.Text + "','" + st_email.Text + "','" + st_dept.Text + "','" + st_Contact.Text + "','" + st_bookName.Text + "','"+dateTimePicker1.Value.ToShortDateString()+"','')";
            cmd.ExecuteNonQuery();


            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update books_info set available_quantity = available_quantity -1 where book_name='" + st_bookName.Text+"'" ;
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Books Issue successfully done");
        }
            else
            {
                MessageBox.Show("Books are not available");
            }
        }

        private void Issue_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from stu_info where student_enrollNo ='" + textBox8.Text +"'" ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString()); 
            if (i == 0)
            {
                MessageBox.Show("This Enrollment No. not found");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    St_name.Text = dr["student_name"].ToString();
                    st_dept.Text = dr["student_dept"].ToString();
                    st_smstr.Text = dr["student_semester"].ToString();
                    st_email.Text = dr["student_email"].ToString();
                    st_Contact.Text = dr["student_contact"].ToString();

                }
            }
            
        }

        private void st_bookName_KeyUp(object sender, KeyEventArgs e)
        {
            try
                
            {
                int count = 0;
                if (e.KeyCode !=Keys.Enter)
                {

                    listBox1.Items.Clear();
           
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " select *from Books_info where book_name like ('%" + st_bookName.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                    count = Convert.ToInt32(dt.Rows.Count.ToString());
               

                if (count > 0)
                    {
                        listBox1.Visible = true;
                        foreach(DataRow dr in dt.Rows)
                        {
                            listBox1.Items.Add(dr["book_name"]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void st_bookName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                st_bookName.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            st_bookName.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }
    }
}
