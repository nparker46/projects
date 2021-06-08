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
     public partial class SearchForm : Form
     {
          bool first = true;

          public SearchForm()
          {
               InitializeComponent();
          }

          private void SearchForm_Load(object sender, EventArgs e)
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


               DataTable columns = new DataTable();
               string column = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBox1.SelectedValue + "'";
               SqlDataAdapter columnIn = new SqlDataAdapter(column, connection);
               columnIn.Fill(columns);

               for (int i = 0; i < columns.Rows.Count; i++)
                    comboBox2.Items.Add(columns.Rows[i][0]);

               comboBox2.ValueMember = "column_name";
               comboBox2.SelectedIndex = 0;
               first = false;
               connection.Close();
          }

          private void getColumns()
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable columns = new DataTable();
               string column = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBox1.SelectedValue + "'";
               SqlDataAdapter columnIn = new SqlDataAdapter(column, connection);
               columnIn.Fill(columns);

               for (int i = 0; i < columns.Rows.Count; i++)
                    comboBox2.Items.Add(columns.Rows[i][0]);

               comboBox2.ValueMember = "column_name";
               comboBox2.SelectedIndex = 0;
               connection.Close();
          }

          private void button1_Click(object sender, EventArgs e) // select the table and column to search
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               string list = "SELECT COUNT(*) FROM COLOR_DB.dbo.[" + comboBox1.SelectedValue.ToString() + "]";
               try
               {
                    using (SqlCommand sqlcommand = new SqlCommand(list, connection))
                    {
                         if ((int)sqlcommand.ExecuteScalar() != 0)
                         {
                              SearchForm_2 searchForm_2 = new SearchForm_2();
                              searchForm_2.tableSelection = comboBox1.Text;
                              searchForm_2.columnSelection = comboBox2.Text;
                              searchForm_2.textInput = textBox1.Text;
                              searchForm_2.Text = "Search Records - " + searchForm_2.tableSelection;
                              searchForm_2.ShowDialog();
                         }
                         else
                         {
                              MessageBox.Show("The selected table is empty.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         }
                    }
               }
               catch (Exception ex)
               {
                    MessageBox.Show("An unexpected error occurred. Please contact the system administrator. " + ex, "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
               }
          }

          private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
          {
               if (first == false)
               {
                    comboBox2.Items.Clear();
                    getColumns();
               }
          }
     }
}
