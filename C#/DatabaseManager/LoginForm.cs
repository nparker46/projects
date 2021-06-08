using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManager
{
     public partial class LoginForm : Form
     {
          public bool check = false;

          public LoginForm()
          {
               InitializeComponent();
          }

          private void LoginForm_Load(object sender, EventArgs e)
          {
               textBox1.Select();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               Variables.user = textBox2.Text; // these are variables used to connect to the SQL Server
               Variables.pass = textBox3.Text;
               Variables.server = textBox1.Text;

               Variables.login = "Persist Security Info=False;User ID=" + textBox2.Text + ";Password=" + textBox3.Text + ";Initial Catalog=master;Server=" + textBox1.Text;
               SqlConnection connection = new SqlConnection(Variables.login);
               try
               {
                    connection.Open();
                    check = true;
                    MessageBox.Show("The connection was successful.");
                    connection.Close();
                    this.Close();
               }
               catch (Exception)
               {
                    MessageBox.Show("The connection failed. Please check the username and password.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
               }
          }

          private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
          {
               if(check == false)
                    Application.Exit();
          }
     }
}
