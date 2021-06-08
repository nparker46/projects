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
     public partial class DeleteForm : Form
     {
          string selection;

          public DeleteForm()
          {
               InitializeComponent();
          }

          private void DeleteForm_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable dtRecord = new DataTable();
               string list = "SELECT table_name FROM COLOR_DB.information_schema.tables ORDER BY table_name ASC";
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               dataadapter.Fill(dtRecord);
               comboBox1.DataSource = dtRecord;
               comboBox1.ValueMember = "table_name";
          }

          private void button1_Click(object sender, EventArgs e)
          {
               selection = (string)comboBox1.SelectedValue;
               int count = 0;
               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               string list = "DROP TABLE " + selection;
               try
               {
                    using(SqlCommand sqlcommand = new SqlCommand(list, connection)) // drops the table
                         count = sqlcommand.ExecuteNonQuery();
                    MessageBox.Show("The table was successfully dropped.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.Close();
               }
               catch
               {
                    MessageBox.Show("An unexpected error occurred. Please contact the system administrator. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
               }
          }
     }
}
