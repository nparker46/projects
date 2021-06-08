//Program Name: Database Manager
//Author: Niko Parker
//Description: This program allows the user to manage a database and create a database with sample data,
// drop tables, display records, insert records, delete records, modify records, and search for records

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
     public partial class Form1 : Form
     {
          public Form1()
          {
               InitializeComponent();
          }


          private void Form1_Load(object sender, EventArgs e)
          {
               LoginForm loginForm = new LoginForm(); // load the login form
               loginForm.ShowDialog();
               if (loginForm.check == false)
                    this.Close();

               if(Variables.login.Contains("Initial Catalog=master"))
                    MessageBox.Show("Please click on the create button first to create the database.");
               Variables.login = Variables.login.Replace("Initial Catalog=master", "Initial Catalog=COLOR_DB");
          }

          private void button1_Click(object sender, EventArgs e)
          {
               CreateForm createForm = new CreateForm();
               createForm.ShowDialog();
          }

          private void button2_Click(object sender, EventArgs e)
          {
               DeleteForm deleteForm = new DeleteForm();
               deleteForm.ShowDialog();
          }

          private void button3_Click(object sender, EventArgs e)
          {
               SelectForm selectForm = new SelectForm();
               selectForm.ShowDialog();
          }

          private void button4_Click(object sender, EventArgs e)
          {
               InsertForm insertForm = new InsertForm();
               insertForm.ShowDialog();
          }

          private void button6_Click(object sender, EventArgs e)
          {
               DeleteForm2 deleteForm2 = new DeleteForm2();
               deleteForm2.ShowDialog();
          }

          private void button7_Click(object sender, EventArgs e)
          {
               ModifyForm modifyForm = new ModifyForm();
               modifyForm.ShowDialog();
          }

          private void button8_Click(object sender, EventArgs e)
          {
               SearchForm searchForm = new SearchForm();
               searchForm.ShowDialog();
          }

          private void button9_Click(object sender, EventArgs e)
          {
               Application.Exit();
          }
     }
}
