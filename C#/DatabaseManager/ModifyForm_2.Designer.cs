namespace DatabaseManager
{
     partial class ModifyForm_2
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
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
               System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
               this.dgv = new System.Windows.Forms.DataGridView();
               this.selectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
               this.button1 = new System.Windows.Forms.Button();
               this.checkBox1 = new System.Windows.Forms.CheckBox();
               ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
               this.SuspendLayout();
               // 
               // dgv
               // 
               this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
               this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
               dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
               dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
               dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
               this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectColumn});
               dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
               dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
               dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
               this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
               this.dgv.Location = new System.Drawing.Point(0, 0);
               this.dgv.Margin = new System.Windows.Forms.Padding(3, 3, 1, 1);
               this.dgv.Name = "dgv";
               dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
               dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
               dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
               dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
               dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
               dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
               this.dgv.Size = new System.Drawing.Size(510, 309);
               this.dgv.TabIndex = 1;
               this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
               this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
               this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
               this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
               // 
               // selectColumn
               // 
               this.selectColumn.HeaderText = "Select";
               this.selectColumn.Name = "selectColumn";
               // 
               // button1
               // 
               this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
               this.button1.Location = new System.Drawing.Point(185, 313);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(165, 23);
               this.button1.TabIndex = 2;
               this.button1.Text = "Modify Selected Rows";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // checkBox1
               // 
               this.checkBox1.AutoSize = true;
               this.checkBox1.Location = new System.Drawing.Point(408, 317);
               this.checkBox1.Name = "checkBox1";
               this.checkBox1.Size = new System.Drawing.Size(70, 17);
               this.checkBox1.TabIndex = 3;
               this.checkBox1.Text = "Select All";
               this.checkBox1.UseVisualStyleBackColor = true;
               this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
               // 
               // ModifyForm_2
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(512, 339);
               this.Controls.Add(this.checkBox1);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.dgv);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "ModifyForm_2";
               this.Text = "Modify Records";
               this.Load += new System.EventHandler(this.ModifyForm_2_Load);
               ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.DataGridView dgv;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.CheckBox checkBox1;
          private System.Windows.Forms.DataGridViewCheckBoxColumn selectColumn;

     }
}