using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace car2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        static string constring = ("Data Source=localhost;Initial Catalog=car3;User ID=sa;Password=ab12AB34");
        SqlConnection connect = new SqlConnection(constring);

        public void comeToCars()
        {
            connect.Open();
            string comeTo = "Select * From car3";
            SqlCommand command = new SqlCommand(comeTo, connect);
            SqlDataAdapter ad = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        public void deleteCar(int ID)
        {
            
            string delete = "Delete From car3 Where ID =@ID";
            SqlCommand command = new SqlCommand(delete, connect);
            connect.Open();
            command.Parameters.AddWithValue("@ID",ID);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'car3DataSet.car3' table. You can move, or remove it, as needed.
            this.car3TableAdapter.Fill(this.car3DataSet.car3);
           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    string insert = "insert into car3 (Brand,Model,Type,ModelYear,Gear,Colors,Fuel)values(@brand,@model,@type,@modelYear,@gear,@colors,@fuel)";
                    SqlCommand command = new SqlCommand( insert , connect);
                    command.Parameters.AddWithValue("@Brand", textBox1.Text);
                    command.Parameters.AddWithValue("@Model", textBox2.Text);
                    command.Parameters.AddWithValue("@Type", comboBox1.Text);
                    command.Parameters.AddWithValue("@ModelYear",Convert.ToInt32(textBox3.Text));
                    command.Parameters.AddWithValue("@Gear", comboBox2.Text);
                   if(radioButton1.Checked)
                    {
                        command.Parameters.AddWithValue("@Colors",radioButton1.Text);
                    }
                   else if(radioButton2.Checked)
                    {
                        command.Parameters.AddWithValue("@Colors", radioButton2.Text);
                    }
                    else if (radioButton3.Checked)
                    {
                        command.Parameters.AddWithValue("@Colors", radioButton3.Text);
                    }
                    else if (radioButton4.Checked)
                    {
                        command.Parameters.AddWithValue("@Colors", radioButton4.Text);
                    }
                    else if (radioButton5.Checked)
                    {
                        command.Parameters.AddWithValue("@Colors", radioButton5.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please Select Color!");
                    }
                     if (radioButton6.Checked)
                    {
                        command.Parameters.AddWithValue("@Fuel", radioButton6.Text);
                    }
                    else if (radioButton7.Checked)
                    {
                        command.Parameters.AddWithValue("@Fuel", radioButton7.Text);
                    }
                    else if (radioButton8.Checked)
                    {
                        command.Parameters.AddWithValue("@Fuel", radioButton8.Text);
                    }
                    else if (radioButton9.Checked)
                    {
                        command.Parameters.AddWithValue("@Fuel", radioButton9.Text);
                    }
                    else if (radioButton10.Checked)
                    {
                        command.Parameters.AddWithValue("@Fuel", radioButton10.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please Select Color!");
                    }

                    command.ExecuteNonQuery();

                    MessageBox.Show("Car successfully added.");
                    connect.Close();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("There is error." + error.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comeToCars();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int ID = Convert.ToInt32(drow.Cells[0].Value);
                deleteCar(ID);
                comeToCars();
            }
        }
        int i=0;
        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            string updateCar =("Update car3 Set Brand = @Brand, Model = @Model,Type = @type,ModelYear=@modelYear,Gear=@gear,Colors=@colors,Fuel=@fuel where ID=@ID"); ;
            SqlCommand command = new SqlCommand(updateCar, connect);

            command.Parameters.AddWithValue("@Brand", textBox1.Text);
            command.Parameters.AddWithValue("@Model", textBox2.Text);
            command.Parameters.AddWithValue("@Type", comboBox1.Text);
            command.Parameters.AddWithValue("@ModelYear", Convert.ToInt32(textBox3.Text));
            command.Parameters.AddWithValue("@Gear", comboBox2.Text);
            if (radioButton1.Checked)
            {
                command.Parameters.AddWithValue("@Colors", radioButton1.Text);
            }
            else if (radioButton2.Checked)
            {
                command.Parameters.AddWithValue("@Colors", radioButton2.Text);
            }
            else if (radioButton3.Checked)
            {
                command.Parameters.AddWithValue("@Colors", radioButton3.Text);
            }
            else if (radioButton4.Checked)
            {
                command.Parameters.AddWithValue("@Colors", radioButton4.Text);
            }
            else if (radioButton5.Checked)
            {
                command.Parameters.AddWithValue("@Colors", radioButton5.Text);
            }
            else
            {
                MessageBox.Show("Please Select Color!");
            }
            if (radioButton6.Checked)
            {
                command.Parameters.AddWithValue("@Fuel", radioButton6.Text);
            }
            else if (radioButton7.Checked)
            {
                command.Parameters.AddWithValue("@Fuel", radioButton7.Text);
            }
            else if (radioButton8.Checked)
            {
                command.Parameters.AddWithValue("@Fuel", radioButton8.Text);
            }
            else if (radioButton9.Checked)
            {
                command.Parameters.AddWithValue("@Fuel", radioButton9.Text);
            }
            else if (radioButton10.Checked)
            {
                command.Parameters.AddWithValue("@Fuel", radioButton10.Text);
            }
            else
            {
                MessageBox.Show("Please Select Fuel!");
            }
            command.Parameters.AddWithValue("ID", dataGridView1.Rows[i].Cells[0].Value);
            command.ExecuteNonQuery();
            connect.Close();
            comeToCars();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            groupBox1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            groupBox2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataView dv = dt.DefaultView;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from car3 where Brand LIKE '%" + textBox4.Text + "%'",connect);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
    }
}
