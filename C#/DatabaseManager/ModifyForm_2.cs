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
     public partial class ModifyForm_2 : Form
     {
          public string selection;
          string[] sql = new string[1000];
          int numID = -1;

          public ModifyForm_2()
          {
               InitializeComponent();
          }

          private void ModifyForm_2_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               SelectForm selectForm = new SelectForm();
               string list = "SELECT * FROM COLOR_DB.dbo." + selection;
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               DataSet ds = new DataSet();
               dataadapter.Fill(ds, "login");
               dgv.DataSource = ds.Tables[0];
               dgv.AllowUserToAddRows = false;
               connection.Close();

               selectColumn.DisplayIndex = dgv.ColumnCount - 1;

               for (int i = dgv.ColumnCount - 1; i > 0; i--)
                    dgv.Columns[i].ReadOnly = true;

               for (int row = 0; row < dgv.RowCount; row++)
                    dgv.Rows[row].Cells[selectColumn.Index].Value = false;
          }

          private void button1_Click(object sender, EventArgs e)
          {
               int numChk = 0;
               int numEqual = 0;
               bool isError = false;

               for (int i = 0; i < dgv.RowCount; i++)
               {
                    if (dgv.Rows[i].Cells[selectColumn.Index].Value.Equals(true) == true)
                         numChk++;

                    if(sql[i + 1] != null)
                         numEqual++;
               }

               if (!(numChk <= numEqual)) // check that changes applied are equal to checked boxes
               {
                    isError = true;
                    MessageBox.Show("Some checkboxes were checked but their values were left unchanged. Please correct before proceeding.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               }

               if (isError == false)
               {
     
                    SqlConnection connection = new SqlConnection(Variables.login);
                    int count;
                    string update = "";
                    for (int i = 0; i < sql.Length; i++) // prepare the sql statement
                         update += sql[i];
                    connection.Open();
                    try
                    {
                         using (SqlCommand sqlcommand = new SqlCommand(update, connection)) // change the records
                              count = sqlcommand.ExecuteNonQuery();
                         MessageBox.Show("The " + count + " records were successfully changed.");
                         this.Close();
                    }
                    catch
                    {
                         MessageBox.Show("An unexpected error occurred. Please contact the system administrator. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         Application.Exit();
                    }
               }
          }

          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox1.Checked == true)
               {
                    for (int row = 0; row < dgv.RowCount; row++)
                         dgv.Rows[row].Cells[selectColumn.Index].Value = true;

                    for (int i = 0; i < dgv.RowCount; i++)
                         for (int j = dgv.ColumnCount - 1; j > 0; j--)
                         {
                              if (dgv.Columns[j].Name != "ID")
                              {
                                   dgv.Rows[i].Cells[j].ReadOnly = false;
                                   dgv.Rows[i].Cells[dgv.ColumnCount - 1].ReadOnly = false;
                              }
                         }
               }

               if (checkBox1.Checked == false)
               {
                    for (int row = 0; row < dgv.RowCount; row++)
                         dgv.Rows[row].Cells[selectColumn.Index].Value = false;

                    for (int i = 0; i < dgv.RowCount; i++)
                         for (int j = dgv.ColumnCount - 1; j > 0; j-- )
                         {
                              if (dgv.Columns[j].Name != "ID")
                              {
                                   dgv.Rows[i].Cells[j].ReadOnly = true;
                                   dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                              }
                         }
                    for (int i = 0; i < sql.Length; i++)
                         sql[i] = null;
               }
          }

          private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
          {
               string total = "";

               if (dgv.Columns[e.ColumnIndex].Name != selectColumn.Name)
               {
                    if (sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value] == null || (int)dgv.Rows[e.RowIndex].Cells["ID"].Value == numID)
                         if (sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value] != "UPDATE " + selection + " SET " + dgv.Columns[e.ColumnIndex].Name + " = '" + dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "' WHERE [ID] = " + dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString() + '\n')
                         {
                              sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value] += "UPDATE " + selection + " SET " + dgv.Columns[e.ColumnIndex].Name + " = '" + dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "' WHERE [ID] = " + dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString() + '\n';
                              dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                              dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                         }
                         else
                         {
                              sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value] = null;
                              sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value] += "UPDATE " + selection + " SET " + dgv.Columns[e.ColumnIndex].Name + " = '" + dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "' WHERE [ID] = " + dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString() + '\n';
                              dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                              dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                         }
                    string str = sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value].Substring(sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value].LastIndexOf(' ') + 1);
                    numID = int.Parse(str);

                         for (int k = 0; k < sql.Length; k++)
                              total += sql[k];
               }
          }

          private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
               if (dgv.Columns[e.ColumnIndex].Name == selectColumn.Name)
               {
                    if ((bool)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == false)
                         for (int i = selectColumn.Index + 1; i < dgv.ColumnCount; i++)
                         {
                              if (dgv.Columns[i].Name != "ID")
                                   dgv.Rows[e.RowIndex].Cells[i].ReadOnly = false;
                         }

                    if ((bool)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
                         for (int i = selectColumn.Index + 1; i < dgv.ColumnCount; i++)
                         {
                              dgv.Rows[e.RowIndex].Cells[i].ReadOnly = true;
                              for (int j = 1; j < dgv.ColumnCount; j++)
                              {
                                   if (dgv.Columns[j].Name != "ID")
                                        sql[(int)dgv.Rows[e.RowIndex].Cells["ID"].Value] = null;
                              }
                              dgv.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.White;
                              dgv.Rows[e.RowIndex].Cells[i - 1].Style.BackColor = Color.White;
                         }
               }
          }


          private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
          {
               if ((dgv.Columns[e.ColumnIndex].Name == "ID"))
                    MessageBox.Show("The primary key can not be modified.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }

          private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
          {
               if (e.ColumnIndex != selectColumn.Index)
               {
                    MessageBox.Show("The data entered is not valid.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               }
          }
     }
}