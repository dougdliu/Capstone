namespace Capstone_v1
{
    partial class View_Test
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
            this.File_Path_Label = new System.Windows.Forms.Label();
            this.file_path = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.enter_button = new System.Windows.Forms.Button();
            this.gain_button = new System.Windows.Forms.Button();
            this.phase_change_button = new System.Windows.Forms.Button();
            this.Output_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.Location = new System.Drawing.Point(139, 22);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(332, 29);
            this.Title_Label.TabIndex = 0;
            this.Title_Label.Text = "View Previous Test Results";
            // 
            // File_Path_Label
            // 
            this.File_Path_Label.AutoSize = true;
            this.File_Path_Label.Location = new System.Drawing.Point(50, 86);
            this.File_Path_Label.Name = "File_Path_Label";
            this.File_Path_Label.Size = new System.Drawing.Size(75, 20);
            this.File_Path_Label.TabIndex = 1;
            this.File_Path_Label.Text = "File Path:";
            // 
            // file_path
            // 
            this.file_path.Location = new System.Drawing.Point(54, 109);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(341, 26);
            this.file_path.TabIndex = 2;
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(445, 109);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(102, 35);
            this.browse_button.TabIndex = 3;
            this.browse_button.Text = "Browse...";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // enter_button
            // 
            this.enter_button.BackColor = System.Drawing.Color.Green;
            this.enter_button.Location = new System.Drawing.Point(445, 150);
            this.enter_button.Name = "enter_button";
            this.enter_button.Size = new System.Drawing.Size(102, 33);
            this.enter_button.TabIndex = 4;
            this.enter_button.Text = "Enter";
            this.enter_button.UseVisualStyleBackColor = false;
            this.enter_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // gain_button
            // 
            this.gain_button.Location = new System.Drawing.Point(123, 299);
            this.gain_button.Name = "gain_button";
            this.gain_button.Size = new System.Drawing.Size(138, 74);
            this.gain_button.TabIndex = 5;
            this.gain_button.Text = "View Gain Results";
            this.gain_button.UseVisualStyleBackColor = true;
            this.gain_button.Visible = false;
            this.gain_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // phase_change_button
            // 
            this.phase_change_button.Location = new System.Drawing.Point(356, 299);
            this.phase_change_button.Name = "phase_change_button";
            this.phase_change_button.Size = new System.Drawing.Size(140, 74);
            this.phase_change_button.TabIndex = 6;
            this.phase_change_button.Text = "View Phase Change Results";
            this.phase_change_button.UseVisualStyleBackColor = true;
            this.phase_change_button.Visible = false;
            this.phase_change_button.Click += new System.EventHandler(this.button4_Click);
            // 
            // Output_Label
            // 
            this.Output_Label.AutoSize = true;
            this.Output_Label.Location = new System.Drawing.Point(140, 249);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(0, 20);
            this.Output_Label.TabIndex = 7;
            // 
            // View_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 436);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.phase_change_button);
            this.Controls.Add(this.gain_button);
            this.Controls.Add(this.enter_button);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.file_path);
            this.Controls.Add(this.File_Path_Label);
            this.Controls.Add(this.Title_Label);
            this.Name = "View_Test";
            this.Text = "View_Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Label File_Path_Label;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.Button enter_button;
        private System.Windows.Forms.Button gain_button;
        private System.Windows.Forms.Button phase_change_button;
        private System.Windows.Forms.Label Output_Label;
    }
}