namespace DatabaseManager
{
     partial class InsertForm_2
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
               this.button3 = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // button3
               // 
               this.button3.Location = new System.Drawing.Point(205, 254);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(76, 23);
               this.button3.TabIndex = 7;
               this.button3.Text = "Insert Records";
               this.button3.UseVisualStyleBackColor = true;
               this.button3.Click += new System.EventHandler(this.button3_Click);
               // 
               // InsertForm_2
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(308, 285);
               this.Controls.Add(this.button3);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "InsertForm_2";
               this.Text = "Insert Records";
               this.Load += new System.EventHandler(this.InsertForm_2_Load);
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Button button3;
     }
}