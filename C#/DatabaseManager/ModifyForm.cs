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
     public partial class ModifyForm : Form
     {

          public ModifyForm()
          {
               InitializeComponent();
          }

          private void ModifyForm_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable dtRecord = new DataTable();
               string list = "SELECT table_name FROM COLOR_DB.information_schema.tables ORDER BY table_name ASC";
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               dataadapter.Fill(dtRecord);
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
                         if ((int)sqlcommand.ExecuteScalar() != 0) // check table to not be empty
                         {
                              this.Close();
                              ModifyForm_2 modifyForm_2 = new ModifyForm_2();
                              modifyForm_2.selection = comboBox1.SelectedValue.ToString();
                              modifyForm_2.Text += " - " + modifyForm_2.selection;
                              modifyForm_2.ShowDialog();
                         }
                         else
                         {
                              MessageBox.Show("The selected table is empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         }
                    }
               }
               catch(Exception ex)
               {
                    MessageBox.Show("An unexpected error occurred. Please contact the system administrator. " + ex, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
               }

          }
     }
}
