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
     public partial class InsertForm : Form
     {

          public InsertForm()
          {
               InitializeComponent();
          }

          private void InsertForm_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable dtRecord = new DataTable();
               string table = "SELECT table_name FROM COLOR_DB.information_schema.tables ORDER BY table_name ASC";
               SqlDataAdapter dataadapter = new SqlDataAdapter(table, connection);
               dataadapter.Fill(dtRecord);
               comboBox1.DataSource = dtRecord;
               comboBox1.ValueMember = "table_name"; // choose the table in which to insert into

               connection.Close();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               this.Close();
               InsertForm_2 insertForm_2 = new InsertForm_2();
               insertForm_2.tableSelection = comboBox1.Text;
               insertForm_2.Text = "Insert Records - " + insertForm_2.tableSelection;
               insertForm_2.ShowDialog();
          }
     }
}
