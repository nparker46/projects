﻿namespace DatabaseManager
{
     partial class CreateForm
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.button1 = new System.Windows.Forms.Button();
               this.comboBox1 = new System.Windows.Forms.ComboBox();
               this.label1 = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(135, 133);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(75, 23);
               this.button1.TabIndex = 3;
               this.button1.Text = "Create";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // comboBox1
               // 
               this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.comboBox1.Items.AddRange(new object[] {
            "Entire database"});
               this.comboBox1.Location = new System.Drawing.Point(112, 54);
               this.comboBox1.Name = "comboBox1";
               this.comboBox1.Size = new System.Drawing.Size(121, 21);
               this.comboBox1.TabIndex = 0;
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(12, 25);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(122, 13);
               this.label1.TabIndex = 4;
               this.label1.Text = "Select the Sample Data:";
               // 
               // CreateForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(284, 262);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.comboBox1);
               this.Controls.Add(this.button1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "CreateForm";
               this.Text = "Create Table - Select";
               this.Load += new System.EventHandler(this.CreateForm_Load);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.ComboBox comboBox1;
          private System.Windows.Forms.Label label1;
     }
}