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
     public partial class DeleteForm2_2 : Form
     {
          public string selection;

          public DeleteForm2_2()
          {
               InitializeComponent();
          }

          private void DeleteForm2_2_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               SelectForm selectForm = new SelectForm();
               string list = "SELECT * FROM COLOR_DB.dbo." + selection;
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               DataSet ds = new DataSet();
               dataadapter.Fill(ds, "login");
               dataGridView1.DataSource = ds.Tables[0];
               connection.Close();

               DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
               dataGridView1.Columns.Add(chk);
               chk.HeaderText = "Select";
               chk.Name = "chk";
               dataGridView1.AllowUserToAddRows = false;

               for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                    dataGridView1.Columns[i].ReadOnly = true;

               for(int row = 0; row < dataGridView1.RowCount - 1; row++)
                    dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Value = false;
          }

          private void button1_Click(object sender, EventArgs e)
          {
               string sql = "DELETE FROM " + selection + " WHERE [ID] IN ("; // prepare the sql statement

               for (int row = 0; row < dataGridView1.RowCount; row++)
               {
                    if (dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Value.Equals(true) == true)
                         sql = sql + dataGridView1.Rows[row].Cells["ID"].Value.ToString() + ", ";
               }

               sql = sql.Trim();
               sql = sql.TrimEnd(',');
               sql = sql + ")";


               SqlConnection connection = new SqlConnection(Variables.login);
               DataTable dtRecord = new DataTable();
               int count;
               connection.Open();
               try
               {
                    using (SqlCommand sqlcommand = new SqlCommand(sql, connection)) // deletes the records
                         count = sqlcommand.ExecuteNonQuery();
                    MessageBox.Show("The " + count + " records were successfully deleted.");
                    this.Close();
               }
               catch
               {
                    MessageBox.Show("An unexpected error occurred. Please contact the system administrator. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
               }
          }

          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {
               if(checkBox1.Checked == true)
                    for (int row = 0; row < dataGridView1.RowCount; row++)
                         dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Value = true;

               if (checkBox1.Checked == false)
                    for (int row = 0; row < dataGridView1.RowCount; row++)
                         dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Value = false;
          }

     }
}
