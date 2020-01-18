namespace ListWizard
{
    partial class SerenaQuestions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerenaQuestions));
            this.q1 = new System.Windows.Forms.RichTextBox();
            this.q2 = new System.Windows.Forms.RichTextBox();
            this.q3 = new System.Windows.Forms.RichTextBox();
            this.q4 = new System.Windows.Forms.RichTextBox();
            this.ab1 = new System.Windows.Forms.ComboBox();
            this.ab2 = new System.Windows.Forms.ComboBox();
            this.ab4 = new System.Windows.Forms.ComboBox();
            this.ab3 = new System.Windows.Forms.ComboBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.endBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // q1
            // 
            this.q1.Location = new System.Drawing.Point(12, 41);
            this.q1.Name = "q1";
            this.q1.Size = new System.Drawing.Size(122, 67);
            this.q1.TabIndex = 12;
            this.q1.Text = "";
            // 
            // q2
            // 
            this.q2.Location = new System.Drawing.Point(140, 41);
            this.q2.Name = "q2";
            this.q2.Size = new System.Drawing.Size(122, 67);
            this.q2.TabIndex = 13;
            this.q2.Text = "";
            // 
            // q3
            // 
            this.q3.Location = new System.Drawing.Point(268, 41);
            this.q3.Name = "q3";
            this.q3.Size = new System.Drawing.Size(122, 67);
            this.q3.TabIndex = 14;
            this.q3.Text = "";
            // 
            // q4
            // 
            this.q4.Location = new System.Drawing.Point(396, 41);
            this.q4.Name = "q4";
            this.q4.Size = new System.Drawing.Size(122, 67);
            this.q4.TabIndex = 15;
            this.q4.Text = "";
            this.q4.TextChanged += new System.EventHandler(this.richTextBox5_TextChanged);
            // 
            // ab1
            // 
            this.ab1.FormattingEnabled = true;
            this.ab1.Location = new System.Drawing.Point(12, 114);
            this.ab1.Name = "ab1";
            this.ab1.Size = new System.Drawing.Size(121, 21);
            this.ab1.TabIndex = 17;
            this.ab1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ab2
            // 
            this.ab2.FormattingEnabled = true;
            this.ab2.Location = new System.Drawing.Point(141, 114);
            this.ab2.Name = "ab2";
            this.ab2.Size = new System.Drawing.Size(121, 21);
            this.ab2.TabIndex = 18;
            this.ab2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // ab4
            // 
            this.ab4.FormattingEnabled = true;
            this.ab4.Location = new System.Drawing.Point(398, 114);
            this.ab4.Name = "ab4";
            this.ab4.Size = new System.Drawing.Size(121, 21);
            this.ab4.TabIndex = 20;
            // 
            // ab3
            // 
            this.ab3.FormattingEnabled = true;
            this.ab3.Location = new System.Drawing.Point(269, 114);
            this.ab3.Name = "ab3";
            this.ab3.Size = new System.Drawing.Size(121, 21);
            this.ab3.TabIndex = 19;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(13, 13);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 21;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            // 
            // endBtn
            // 
            this.endBtn.Location = new System.Drawing.Point(95, 12);
            this.endBtn.Name = "endBtn";
            this.endBtn.Size = new System.Drawing.Size(75, 23);
            this.endBtn.TabIndex = 22;
            this.endBtn.Text = "End";
            this.endBtn.UseVisualStyleBackColor = true;
            // 
            // SerenaQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 248);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.ab4);
            this.Controls.Add(this.ab3);
            this.Controls.Add(this.ab2);
            this.Controls.Add(this.ab1);
            this.Controls.Add(this.q4);
            this.Controls.Add(this.q3);
            this.Controls.Add(this.q2);
            this.Controls.Add(this.q1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerenaQuestions";
            this.Text = "Serena\'s Questions";
            this.Load += new System.EventHandler(this.SerenaQuestions_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox q1;
        private System.Windows.Forms.RichTextBox q2;
        private System.Windows.Forms.RichTextBox q3;
        private System.Windows.Forms.RichTextBox q4;
        private System.Windows.Forms.ComboBox ab1;
        private System.Windows.Forms.ComboBox ab2;
        private System.Windows.Forms.ComboBox ab4;
        private System.Windows.Forms.ComboBox ab3;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button endBtn;
    }
}