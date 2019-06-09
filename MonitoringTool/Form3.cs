using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringTool
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9SB5A08\MSSQLSERVER01;Integrated Security=True;Connect 
                                                    Timeout=30;Encrypt=False;
                                                     TrustServerCertificate=False;Initial Catalog=TIETOKANTA;
                                                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //Inserts data to sql table
            SqlCommand insert = new SqlCommand("insert into [ACCOUNTS] (USERNAME, PASSWORD,FirstName,LastName)" +
                                                " values(@USERNAME, @PASSWORD,@FirstName,@LastName)", conn);
            insert.Parameters.AddWithValue("@USERNAME", textBox1.Text);
            insert.Parameters.AddWithValue("@PASSWORD", textBox2.Text);
            insert.Parameters.AddWithValue("@FirstName", textBox3.Text);
            insert.Parameters.AddWithValue("@LastName", textBox4.Text);

            if (textBox1.Text + textBox2.Text + textBox3.Text == string.Empty)
            {
                label6.Text = "Please fill all missing information";
                string a = "*";
                label7.Text = a;
                label8.Text = a;
                label9.Text = a;
                return;
            }
            else
            {
                conn.Open();
                insert.ExecuteNonQuery();
                MessageBox.Show("Register done !");
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                label6.Text = string.Empty;
                label7.Text = string.Empty;
                label8.Text = string.Empty;
                label9.Text = string.Empty;
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }
    }
}
