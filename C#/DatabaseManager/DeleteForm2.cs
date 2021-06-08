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
     public partial class DeleteForm2 : Form
     {

          public DeleteForm2()
          {
               InitializeComponent();
          }

          private void DeleteForm2_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable dtRecord = new DataTable();
               string list = "SELECT table_name FROM COLOR_DB.information_schema.tables ORDER BY table_name ASC";
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               dataadapter.Fill(dtRecord); // get the tables to select from
               connection.Close();
               comboBox1.DataSource = dtRecord;
               comboBox1.ValueMember = "table_name";
          }

          private void button1_Click(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               string list = "SELECT COUNT(*) FROM COLOR_DB.dbo.[" + comboBox1.SelectedValue.ToString() + "]";
               try
               {
                    using (SqlCommand sqlcommand = new SqlCommand(list, connection))
                    {
                         if ((int)sqlcommand.ExecuteScalar() != 0) // check that the table is not empty
                         {
                              this.Close();
                              DeleteForm2_2 deleteForm2_2 = new DeleteForm2_2();
                              deleteForm2_2.selection = comboBox1.SelectedValue.ToString();
                              deleteForm2_2.Text += " - " + deleteForm2_2.selection;
                              deleteForm2_2.ShowDialog();
                         }
                         else
                         {
                              MessageBox.Show("The selected table is empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         }
                    }
               }
               catch
               {
                    MessageBox.Show("An unexpected error occurred. Please contact the system administrator. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
               }

          }
     }
}
