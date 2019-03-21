using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class add_student_info : Form 
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\project\lb.mdf;Integrated Security=True;Connect Timeout=30");
        /* string pwd;
         string pwd = Class1.GetRandomPassword(20);
         string wanted_path;*/
        public add_student_info()
        {
            InitializeComponent();
        }

         private void button2_Click(object sender, EventArgs e) /*filedialogForimage */
        {

             /*
             wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
             DialogResult result = openFileDialog1.ShowDialog();
             openFileDialog1.Filter = " JPEG Files (*.jpeg)| .jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg|*jpg|GIF files (*.gif)|*.gif ";
             if (result == DialogResult.OK)
             {
                 pictureBox1.ImageLocation = openFileDialog1.FileName;
                 pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
             } */
         }
        
        private void button1_Click(object sender, EventArgs e) /*Save */

        {
            try { 

           /*  string img_path;
             File.Copy(openFileDialog1.FileName, wanted_path + "\\Save_Image\\" + pwd + ".jpg"); 
             img_path = "Save_Image\\" + pwd + ".jpg";*/
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into stu_info values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "') ";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
