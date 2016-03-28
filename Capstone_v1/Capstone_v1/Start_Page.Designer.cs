namespace Capstone_v1
{
    partial class Start_Page
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
            this.Title_Label = new System.Windows.Forms.Label();
            this.Action_Label = new System.Windows.Forms.Label();
            this.Action_Type = new System.Windows.Forms.ComboBox();
            this.Enter_Button = new System.Windows.Forms.Button();
            this.Error_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.Location = new System.Drawing.Point(41, 19);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(654, 32);
            this.Title_Label.TabIndex = 0;
            this.Title_Label.Text = "Welcome to the Squidstat EIS Module Software";
            // 
            // Action_Label
            // 
            this.Action_Label.AutoSize = true;
            this.Action_Label.Location = new System.Drawing.Point(122, 95);
            this.Action_Label.Name = "Action_Label";
            this.Action_Label.Size = new System.Drawing.Size(298, 20);
            this.Action_Label.TabIndex = 1;
            this.Action_Label.Text = "What Action Would You Like to Perform?";
            // 
            // Action_Type
            // 
            this.Action_Type.FormattingEnabled = true;
            this.Action_Type.Items.AddRange(new object[] {
            "Start a New Test",
            "View an Old Test"});
            this.Action_Type.Location = new System.Drawing.Point(126, 127);
            this.Action_Type.Name = "Action_Type";
            this.Action_Type.Size = new System.Drawing.Size(294, 28);
            this.Action_Type.TabIndex = 2;
            this.Action_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Enter_Button
            // 
            this.Enter_Button.BackColor = System.Drawing.Color.Green;
            this.Enter_Button.ForeColor = System.Drawing.Color.White;
            this.Enter_Button.Location = new System.Drawing.Point(466, 126);
            this.Enter_Button.Name = "Enter_Button";
            this.Enter_Button.Size = new System.Drawing.Size(101, 41);
            this.Enter_Button.TabIndex = 3;
            this.Enter_Button.Text = "Enter";
            this.Enter_Button.UseVisualStyleBackColor = false;
            this.Enter_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Error_Label
            // 
            this.Error_Label.AutoSize = true;
            this.Error_Label.Location = new System.Drawing.Point(462, 170);
            this.Error_Label.Name = "Error_Label";
            this.Error_Label.Size = new System.Drawing.Size(0, 20);
            this.Error_Label.TabIndex = 4;
            // 
            // Start_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 244);
            this.Controls.Add(this.Error_Label);
            this.Controls.Add(this.Enter_Button);
            this.Controls.Add(this.Action_Type);
            this.Controls.Add(this.Action_Label);
            this.Controls.Add(this.Title_Label);
            this.Name = "Start_Page";
            this.Text = "Start_Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Label Action_Label;
        private System.Windows.Forms.ComboBox Action_Type;
        private System.Windows.Forms.Button Enter_Button;
        private System.Windows.Forms.Label Error_Label;
    }
}