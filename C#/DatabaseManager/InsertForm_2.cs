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
     public partial class InsertForm_2 : Form
     {
          public string tableSelection;
          public string columnSelection;

          TextBox[] textBoxes = new TextBox[0];
          CheckBox[] checkBoxes = new CheckBox[0];
          int t = 0;

          public InsertForm_2()
          {
               InitializeComponent();
          }

          private void button1_Click(object sender, EventArgs e)
          {

               if (t < 9)
               {
                    TextBox newTextBox = new TextBox();
                    newTextBox.Name = "newTextBox" + t++;
                    newTextBox.Location = new System.Drawing.Point(12, 41 + (20 * t));
                    newTextBox.Size = new System.Drawing.Size(240, 20);
                    newTextBox.MaxLength = 128;
                    this.Controls.Add(newTextBox);
               }
               else
                    MessageBox.Show("This program does not support more than ten columns. Please use Microsoft SQL Server Management Studio instead.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

          private void button2_Click(object sender, EventArgs e)
          {
          }

          private void button3_Click(object sender, EventArgs e)
          {
               string sql = "INSERT INTO " + tableSelection + " (";


               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable columns = new DataTable();
               string column = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableSelection + "'";
               SqlDataAdapter columnIn = new SqlDataAdapter(column, connection);
               columnIn.Fill(columns); // load the columns from the selected table
               connection.Close();

               for (int i = 0; i < columns.Rows.Count; i++) // prepare the sql statement
               {
                    if(columns.Rows[i][0].ToString() != "" && textBoxes[i].Enabled == true)
                         sql += columns.Rows[i][0].ToString() + ", ";
               }

               sql = sql.TrimEnd(',', ' ');

               sql += ") VALUES (";

               for (int i = 0; i < textBoxes.Length; i++)
                    if(textBoxes[i].Text != "" && textBoxes[i].Enabled == true)
                         sql += textBoxes[i].Text + ", ";

               sql = sql.TrimEnd(',', ' ');
               sql.Trim();
               sql.TrimEnd(',');
               sql += ")";

               SqlConnection con = new SqlConnection(Variables.login);
               int count;
               con.Open();
               try
               {
                    using (SqlCommand sqlcommand = new SqlCommand(sql, con)) // insert the records
                         count = sqlcommand.ExecuteNonQuery();
                    MessageBox.Show("The " + count + " records were successfully inserted.");
                    this.Close();
               }
               catch
               {
                    MessageBox.Show("An unexpected error occurred. Please contact the system administrator. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
               }
          }

          private void InsertForm_2_Load(object sender, EventArgs e)
          {


               SqlConnection connection = new SqlConnection(Variables.login);
               connection.Open();
               DataTable columns = new DataTable();
               string column = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableSelection + "'";
               SqlDataAdapter columnIn = new SqlDataAdapter(column, connection);
               columnIn.Fill(columns);

               textBoxes = new TextBox[columns.Rows.Count];
               checkBoxes = new CheckBox[columns.Rows.Count];

               for (int i = 0; i < columns.Rows.Count; i++)
               {
                         Label newLabel = new Label();
                         newLabel.Name = "newLabel" + t++;
                         newLabel.Text = columns.Rows[i][0].ToString();
                         newLabel.Location = new System.Drawing.Point(12, -10 + (20 * t));
                         newLabel.Size = new System.Drawing.Size(240, 20);

                         TextBox newTextBox = new TextBox();
                         newTextBox.Name = "newTextBox" + t++;
                         newTextBox.Location = new System.Drawing.Point(12, -10 + (20 * t));
                         button3.Location = new System.Drawing.Point(205, 15 + (20 * t));
                         newTextBox.Size = new System.Drawing.Size(240, 20);
                         newTextBox.Enabled = false;
                         newTextBox.MaxLength = 128;

                         CheckBox newChkBox = new CheckBox();
                         newChkBox.Name = "newChkBox" + t++;
                         newChkBox.Location = new System.Drawing.Point(260, -10 + (20 * (t-1)));
                         newChkBox.Size = new System.Drawing.Size(15, 14);
                         newChkBox.CheckedChanged += new EventHandler(CheckedChanged);

                         this.Controls.Add(newLabel);
                         this.Controls.Add(newTextBox);
                         this.Controls.Add(newChkBox);

                         textBoxes[i] = newTextBox;
                         checkBoxes[i] = newChkBox;

                         if (i > 5)
                         {
                              Height += 40;
                         }
               }
          }
          void CheckedChanged(object sender, EventArgs e)
          {
               for (int i = 0; i < textBoxes.Length; i++)
                    if(checkBoxes[i].Checked)
                         textBoxes[i].Enabled = true;

               for (int i = 0; i < textBoxes.Length; i++)
                    if (!checkBoxes[i].Checked)
                         textBoxes[i].Enabled = false;
          }

     }
}
