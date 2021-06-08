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
     public partial class SelectForm : Form
     {
          public SelectForm()
          {
               InitializeComponent();
          }

          private void selectForm_Load(object sender, EventArgs e)
          {

               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable dtRecord = new DataTable();
               string list = "SELECT table_name FROM COLOR_DB.information_schema.tables ORDER BY table_name ASC";
               SqlDataAdapter dataadapter = new SqlDataAdapter(list, connection);
               dataadapter.Fill(dtRecord);
               comboBox1.DataSource = dtRecord;
               comboBox1.ValueMember = "table_name";
               connection.Close();
          }

          private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          private void button1_Click(object sender, EventArgs e)
          {
               DisplayForm displayForm = new DisplayForm();
               displayForm.selection = comboBox1.SelectedValue.ToString();
               displayForm.Show();
               this.Close();
          }

          public string getSelectedText()
          {
               string table = comboBox1.SelectedValue.ToString();
               return table;
          }
     }
}
