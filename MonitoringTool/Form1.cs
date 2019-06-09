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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Create sql connection
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9SB5A08\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                                     TrustServerCertificate=False;Initial Catalog=TIETOKANTA;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlDataAdapter sqa = new SqlDataAdapter ("SELECT COUNT (*) from ACCOUNTS where USERNAME ='" + txtUsername.Text +"' and PASSWORD = '" 
                                                        + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sqa.Fill(dt);

            //Makes sure that username and password matches from database
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form2 main = new Form2();
                main.Show();
                MessageBox.Show("Hello " + txtUsername.Text + ", welcome back!");

            }
            else
            {
                MessageBox.Show("Username/Password is incorrect. Please try again");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 create = new Form3();
            create.Show();

        }
    }
}
