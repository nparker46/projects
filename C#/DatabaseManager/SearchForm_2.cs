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
     public partial class SearchForm_2 : Form
     {
          public string tableSelection;
          public string columnSelection;
          public string textInput;

          public SearchForm_2()
          {
               InitializeComponent();
          }

          private void SearchForm_2_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               string list = "SELECT * FROM " + tableSelection + " WHERE " + columnSelection + " ='" + textInput + "'";
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               DataSet ds = new DataSet();
               dataadapter.Fill(ds, "login");
               dataGridView1.DataSource = ds.Tables[0]; // display the search results
               ds.Tables[0].Rows.Add();
               CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
               currencyManager.SuspendBinding();
               dataGridView1.Rows[dataGridView1.RowCount - 1].Visible = false;
               currencyManager.ResumeBinding();
               if (dataGridView1.RowCount <= 1)
               {
                    this.Close();
                    connection.Close();
                    MessageBox.Show("No records were found with the specified text.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               }
               connection.Close();
          }
     }
}
