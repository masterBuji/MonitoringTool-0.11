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
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9SB5A08\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                                     TrustServerCertificate=False;Initial Catalog=TIETOKANTA;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //Inserts data to sql table
            SqlCommand insert = new SqlCommand("insert into [ACCOUNTS] (USERNAME, PASSWORD,FirstName,LastName) values(@USERNAME, @PASSWORD,@FirstName,@LastName)", conn);
            insert.Parameters.AddWithValue("@USERNAME", textBox1.Text);
            insert.Parameters.AddWithValue("@PASSWORD", textBox2.Text);
            insert.Parameters.AddWithValue("@FirstName", textBox3.Text);
            insert.Parameters.AddWithValue("@LastName", textBox4.Text);

            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "You need add username!";
                return;
            }
            else if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "You need to add password!";
            }
            else if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "You need to add firstname";
            }
            else
            {
                conn.Open();
                insert.ExecuteNonQuery();
                MessageBox.Show("Register done !");
            }

        }
    }
}
