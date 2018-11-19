namespace LibraryManagement_Presentation_Layer
{
    partial class ReturnBook
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
            this.studentNumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // studentNumberTextBox
            // 
            this.studentNumberTextBox.Location = new System.Drawing.Point(192, 59);
            this.studentNumberTextBox.Name = "studentNumberTextBox";
            this.studentNumberTextBox.Size = new System.Drawing.Size(182, 20);
            this.studentNumberTextBox.TabIndex = 5;
            this.studentNumberTextBox.Leave += new System.EventHandler(this.studentNumberTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Student Number";
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Location = new System.Drawing.Point(14, 120);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.Size = new System.Drawing.Size(748, 299);
            this.resultDataGridView.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Return Book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 478);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.studentNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultDataGridView);
            this.Name = "ReturnBook";
            this.Text = "ReturnBook";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.Button button1;
    }
}