using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace car2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=localhost;Initial Catalog=car3;User ID=sa;Password=ab12AB34");
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter the password and username!");
            }
            else
            {


                connect.Open();
                string user;
                string password;
                user = textBox4.Text;
                password = textBox3.Text;
                SqlCommand command = new SqlCommand("Select * from register where Nickname='" + user + "' and Password='" +Cryptology.Encryption(password,2) + "'", connect);
                SqlDataReader rd = command.ExecuteReader();
                if (rd.Read())
                {
                    MessageBox.Show("Welcome " + user + "");
                    
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong User Name or Password!");
                }
                connect.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter the password and username!");
            }
            else
            {

                connect.Open();
                string newUser;
                string newPassword;
                newUser = textBox1.Text;
                newPassword = textBox2.Text;
                SqlCommand command = new SqlCommand("Select * from register where Nickname='" + textBox1.Text + "'", connect);
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("This username is used.");
                }
                else
                {
                    read.Close();
                    SqlCommand add = new SqlCommand("insert into register(Nickname,Password)values('" +newUser+ "','" +Cryptology.Decryption(newPassword,2)+ "')", connect);
                    add.ExecuteNonQuery();
                    MessageBox.Show("Registration Succesful");

                }
                connect.Close();
            }
        }
    }
}
