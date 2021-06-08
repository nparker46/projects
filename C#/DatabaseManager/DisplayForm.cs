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
     public partial class DisplayForm : Form
     {
          public string selection;

          public DisplayForm()
          {
               InitializeComponent();
          }

          private void DisplayForm_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               SelectForm selectForm = new SelectForm();
               string list = "SELECT * FROM COLOR_DB.dbo." + selection;
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               DataSet records = new DataSet();
               dataadapter.Fill(records, Variables.login);
               dataGridView1.DataSource = records.Tables[0]; // display the records of the selected table
               connection.Close();
          }

          private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {

          }

          private void dataGridView1_Resize(object sender, EventArgs e)
          {
               this.Width = dataGridView1.Width;
               this.Height = dataGridView1.Height;
               this.Size = dataGridView1.Size;
          }
     }
}
