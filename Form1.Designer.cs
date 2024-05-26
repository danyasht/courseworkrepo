namespace KeyValidationApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxCorrectKey = new System.Windows.Forms.TextBox();
            this.buttonUpdateCorrectKey = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(12, 12);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(260, 20);
            this.textBoxKey.TabIndex = 0;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(278, 10);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 373);
            this.dataGridView1.TabIndex = 2;
            // 
            // textBoxCorrectKey
            // 
            this.textBoxCorrectKey.Location = new System.Drawing.Point(12, 38);
            this.textBoxCorrectKey.Name = "textBoxCorrectKey";
            this.textBoxCorrectKey.Size = new System.Drawing.Size(260, 20);
            this.textBoxCorrectKey.TabIndex = 3;
            // 
            // buttonUpdateCorrectKey
            // 
            this.buttonUpdateCorrectKey.Location = new System.Drawing.Point(278, 36);
            this.buttonUpdateCorrectKey.Name = "buttonUpdateCorrectKey";
            this.buttonUpdateCorrectKey.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateCorrectKey.TabIndex = 4;
            this.buttonUpdateCorrectKey.Text = "Update Key";
            this.buttonUpdateCorrectKey.UseVisualStyleBackColor = true;
            this.buttonUpdateCorrectKey.Click += new System.EventHandler(this.buttonUpdateCorrectKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUpdateCorrectKey);
            this.Controls.Add(this.textBoxCorrectKey);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxKey);
            this.Name = "Form1";
            this.Text = "Key Validation App";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxCorrectKey;
        private System.Windows.Forms.Button buttonUpdateCorrectKey;
    }
}
