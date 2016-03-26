namespace Capstone_v1
{
    partial class Set_Workspace
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
            this.Workspace_Label = new System.Windows.Forms.Label();
            this.Workspace_Text = new System.Windows.Forms.TextBox();
            this.Enter_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Browse_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Workspace_Label
            // 
            this.Workspace_Label.AutoSize = true;
            this.Workspace_Label.Location = new System.Drawing.Point(209, 50);
            this.Workspace_Label.Name = "Workspace_Label";
            this.Workspace_Label.Size = new System.Drawing.Size(138, 20);
            this.Workspace_Label.TabIndex = 0;
            this.Workspace_Label.Text = "Select Workspace";
            // 
            // Workspace_Text
            // 
            this.Workspace_Text.Location = new System.Drawing.Point(65, 95);
            this.Workspace_Text.Name = "Workspace_Text";
            this.Workspace_Text.Size = new System.Drawing.Size(365, 26);
            this.Workspace_Text.TabIndex = 1;
            // 
            // Enter_Button
            // 
            this.Enter_Button.Location = new System.Drawing.Point(457, 119);
            this.Enter_Button.Name = "Enter_Button";
            this.Enter_Button.Size = new System.Drawing.Size(100, 35);
            this.Enter_Button.TabIndex = 2;
            this.Enter_Button.Text = "Enter";
            this.Enter_Button.UseVisualStyleBackColor = true;
            this.Enter_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 3;
            // 
            // Browse_Button
            // 
            this.Browse_Button.Location = new System.Drawing.Point(457, 69);
            this.Browse_Button.Name = "Browse_Button";
            this.Browse_Button.Size = new System.Drawing.Size(100, 35);
            this.Browse_Button.TabIndex = 4;
            this.Browse_Button.Text = "Browse...";
            this.Browse_Button.UseVisualStyleBackColor = true;
            this.Browse_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Set_Workspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 213);
            this.Controls.Add(this.Browse_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Enter_Button);
            this.Controls.Add(this.Workspace_Text);
            this.Controls.Add(this.Workspace_Label);
            this.Name = "Set_Workspace";
            this.Text = "Set_Workspace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Workspace_Label;
        private System.Windows.Forms.TextBox Workspace_Text;
        private System.Windows.Forms.Button Enter_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Browse_Button;
    }
}