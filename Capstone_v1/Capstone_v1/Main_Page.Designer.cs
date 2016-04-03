namespace Capstone_v1
{
    partial class Main_Page
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
            this.f_start_val = new System.Windows.Forms.TextBox();
            this.amp_val = new System.Windows.Forms.TextBox();
            this.rate = new System.Windows.Forms.TextBox();
            this.frequency = new System.Windows.Forms.Label();
            this.amp = new System.Windows.Forms.Label();
            this.sweep_rate = new System.Windows.Forms.Label();
            this.run_test_button = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.gain_results_button = new System.Windows.Forms.Button();
            this.phase_change_results_button = new System.Windows.Forms.Button();
            this.f_unit = new System.Windows.Forms.Label();
            this.amp_unit = new System.Windows.Forms.Label();
            this.rate_type = new System.Windows.Forms.ComboBox();
            this.rate_unit = new System.Windows.Forms.Label();
            this.test_output_label = new System.Windows.Forms.Label();
            this.f_end_val = new System.Windows.Forms.TextBox();
            this.f_start = new System.Windows.Forms.Label();
            this.f_end = new System.Windows.Forms.Label();
            this.dc_val = new System.Windows.Forms.TextBox();
            this.dc = new System.Windows.Forms.Label();
            this.dc_unit = new System.Windows.Forms.Label();
            this.f_range = new System.Windows.Forms.Label();
            this.amp_range = new System.Windows.Forms.Label();
            this.rate_range = new System.Windows.Forms.Label();
            this.dc_range = new System.Windows.Forms.Label();
            this.file_name_val = new System.Windows.Forms.TextBox();
            this.file_name_label = new System.Windows.Forms.Label();
            this.csv_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // f_start_val
            // 
            this.f_start_val.Location = new System.Drawing.Point(367, 82);
            this.f_start_val.Name = "f_start_val";
            this.f_start_val.Size = new System.Drawing.Size(142, 26);
            this.f_start_val.TabIndex = 0;
            this.f_start_val.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // amp_val
            // 
            this.amp_val.Location = new System.Drawing.Point(367, 155);
            this.amp_val.Name = "amp_val";
            this.amp_val.Size = new System.Drawing.Size(303, 26);
            this.amp_val.TabIndex = 1;
            this.amp_val.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // rate
            // 
            this.rate.Location = new System.Drawing.Point(367, 224);
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Size = new System.Drawing.Size(303, 26);
            this.rate.TabIndex = 2;
            this.rate.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // frequency
            // 
            this.frequency.AutoSize = true;
            this.frequency.Location = new System.Drawing.Point(216, 82);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(121, 20);
            this.frequency.TabIndex = 3;
            this.frequency.Text = "Frequency in hz";
            // 
            // amp
            // 
            this.amp.AutoSize = true;
            this.amp.Location = new System.Drawing.Point(216, 155);
            this.amp.Name = "amp";
            this.amp.Size = new System.Drawing.Size(111, 20);
            this.amp.TabIndex = 4;
            this.amp.Text = "Amplitude in V";
            // 
            // sweep_rate
            // 
            this.sweep_rate.AutoSize = true;
            this.sweep_rate.Location = new System.Drawing.Point(38, 222);
            this.sweep_rate.Name = "sweep_rate";
            this.sweep_rate.Size = new System.Drawing.Size(97, 20);
            this.sweep_rate.TabIndex = 5;
            this.sweep_rate.Text = "Sweep Rate";
            // 
            // run_test_button
            // 
            this.run_test_button.BackColor = System.Drawing.Color.Green;
            this.run_test_button.Location = new System.Drawing.Point(480, 389);
            this.run_test_button.Name = "run_test_button";
            this.run_test_button.Size = new System.Drawing.Size(176, 41);
            this.run_test_button.TabIndex = 6;
            this.run_test_button.Text = "Run Test";
            this.run_test_button.UseVisualStyleBackColor = false;
            this.run_test_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(363, 24);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(123, 26);
            this.Title.TabIndex = 7;
            this.Title.Text = "EIS Inputs";
            // 
            // gain_results_button
            // 
            this.gain_results_button.Location = new System.Drawing.Point(220, 489);
            this.gain_results_button.Name = "gain_results_button";
            this.gain_results_button.Size = new System.Drawing.Size(176, 53);
            this.gain_results_button.TabIndex = 8;
            this.gain_results_button.Text = "View Gain Results";
            this.gain_results_button.UseVisualStyleBackColor = true;
            this.gain_results_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // phase_change_results_button
            // 
            this.phase_change_results_button.Location = new System.Drawing.Point(480, 489);
            this.phase_change_results_button.Name = "phase_change_results_button";
            this.phase_change_results_button.Size = new System.Drawing.Size(176, 53);
            this.phase_change_results_button.TabIndex = 9;
            this.phase_change_results_button.Text = "View Phase Change Results";
            this.phase_change_results_button.UseVisualStyleBackColor = true;
            this.phase_change_results_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // f_unit
            // 
            this.f_unit.AutoSize = true;
            this.f_unit.Location = new System.Drawing.Point(676, 88);
            this.f_unit.Name = "f_unit";
            this.f_unit.Size = new System.Drawing.Size(26, 20);
            this.f_unit.TabIndex = 10;
            this.f_unit.Text = "hz";
            // 
            // amp_unit
            // 
            this.amp_unit.AutoSize = true;
            this.amp_unit.Location = new System.Drawing.Point(676, 161);
            this.amp_unit.Name = "amp_unit";
            this.amp_unit.Size = new System.Drawing.Size(20, 20);
            this.amp_unit.TabIndex = 11;
            this.amp_unit.Text = "V";
            // 
            // rate_type
            // 
            this.rate_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rate_type.FormattingEnabled = true;
            this.rate_type.Items.AddRange(new object[] {
            "Logarithmic (decades/s)",
            "Linear (Hz/s)"});
            this.rate_type.Location = new System.Drawing.Point(154, 222);
            this.rate_type.Name = "rate_type";
            this.rate_type.Size = new System.Drawing.Size(183, 28);
            this.rate_type.TabIndex = 12;
            this.rate_type.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rate_unit
            // 
            this.rate_unit.AutoSize = true;
            this.rate_unit.Location = new System.Drawing.Point(676, 230);
            this.rate_unit.Name = "rate_unit";
            this.rate_unit.Size = new System.Drawing.Size(0, 20);
            this.rate_unit.TabIndex = 13;
            // 
            // test_output_label
            // 
            this.test_output_label.AutoSize = true;
            this.test_output_label.Location = new System.Drawing.Point(402, 434);
            this.test_output_label.Name = "test_output_label";
            this.test_output_label.Size = new System.Drawing.Size(0, 20);
            this.test_output_label.TabIndex = 14;
            // 
            // f_end_val
            // 
            this.f_end_val.Location = new System.Drawing.Point(524, 82);
            this.f_end_val.Name = "f_end_val";
            this.f_end_val.Size = new System.Drawing.Size(146, 26);
            this.f_end_val.TabIndex = 15;
            this.f_end_val.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // f_start
            // 
            this.f_start.AutoSize = true;
            this.f_start.Location = new System.Drawing.Point(363, 59);
            this.f_start.Name = "f_start";
            this.f_start.Size = new System.Drawing.Size(44, 20);
            this.f_start.TabIndex = 16;
            this.f_start.Text = "Start";
            // 
            // f_end
            // 
            this.f_end.AutoSize = true;
            this.f_end.Location = new System.Drawing.Point(520, 59);
            this.f_end.Name = "f_end";
            this.f_end.Size = new System.Drawing.Size(38, 20);
            this.f_end.TabIndex = 17;
            this.f_end.Text = "End";
            // 
            // dc_val
            // 
            this.dc_val.Location = new System.Drawing.Point(367, 289);
            this.dc_val.Name = "dc_val";
            this.dc_val.Size = new System.Drawing.Size(303, 26);
            this.dc_val.TabIndex = 18;
            this.dc_val.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // dc
            // 
            this.dc.AutoSize = true;
            this.dc.Location = new System.Drawing.Point(216, 289);
            this.dc.Name = "dc";
            this.dc.Size = new System.Drawing.Size(80, 20);
            this.dc.TabIndex = 19;
            this.dc.Text = "DC Offset";
            // 
            // dc_unit
            // 
            this.dc_unit.AutoSize = true;
            this.dc_unit.Location = new System.Drawing.Point(676, 295);
            this.dc_unit.Name = "dc_unit";
            this.dc_unit.Size = new System.Drawing.Size(20, 20);
            this.dc_unit.TabIndex = 20;
            this.dc_unit.Text = "V";
            // 
            // f_range
            // 
            this.f_range.AutoSize = true;
            this.f_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_range.Location = new System.Drawing.Point(363, 111);
            this.f_range.Name = "f_range";
            this.f_range.Size = new System.Drawing.Size(146, 15);
            this.f_range.TabIndex = 21;
            this.f_range.Text = "1Hz-400kHz (400,000Hz)";
            // 
            // amp_range
            // 
            this.amp_range.AutoSize = true;
            this.amp_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amp_range.Location = new System.Drawing.Point(364, 184);
            this.amp_range.Name = "amp_range";
            this.amp_range.Size = new System.Drawing.Size(63, 15);
            this.amp_range.TabIndex = 22;
            this.amp_range.Text = "0.005V-2V";
            // 
            // rate_range
            // 
            this.rate_range.AutoSize = true;
            this.rate_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rate_range.Location = new System.Drawing.Point(364, 253);
            this.rate_range.Name = "rate_range";
            this.rate_range.Size = new System.Drawing.Size(0, 15);
            this.rate_range.TabIndex = 23;
            // 
            // dc_range
            // 
            this.dc_range.AutoSize = true;
            this.dc_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dc_range.Location = new System.Drawing.Point(363, 318);
            this.dc_range.Name = "dc_range";
            this.dc_range.Size = new System.Drawing.Size(80, 15);
            this.dc_range.TabIndex = 24;
            this.dc_range.Text = "(-)10V-(+)10V";
            // 
            // file_name_val
            // 
            this.file_name_val.Location = new System.Drawing.Point(220, 393);
            this.file_name_val.Name = "file_name_val";
            this.file_name_val.Size = new System.Drawing.Size(133, 26);
            this.file_name_val.TabIndex = 25;
            // 
            // file_name_label
            // 
            this.file_name_label.AutoSize = true;
            this.file_name_label.Location = new System.Drawing.Point(216, 370);
            this.file_name_label.Name = "file_name_label";
            this.file_name_label.Size = new System.Drawing.Size(137, 20);
            this.file_name_label.TabIndex = 26;
            this.file_name_label.Text = "Output File Name:";
            // 
            // csv_label
            // 
            this.csv_label.AutoSize = true;
            this.csv_label.Location = new System.Drawing.Point(359, 399);
            this.csv_label.Name = "csv_label";
            this.csv_label.Size = new System.Drawing.Size(36, 20);
            this.csv_label.TabIndex = 27;
            this.csv_label.Text = ".csv";
            // 
            // Main_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 578);
            this.Controls.Add(this.csv_label);
            this.Controls.Add(this.file_name_label);
            this.Controls.Add(this.file_name_val);
            this.Controls.Add(this.dc_range);
            this.Controls.Add(this.rate_range);
            this.Controls.Add(this.amp_range);
            this.Controls.Add(this.f_range);
            this.Controls.Add(this.dc_unit);
            this.Controls.Add(this.dc);
            this.Controls.Add(this.dc_val);
            this.Controls.Add(this.f_end);
            this.Controls.Add(this.f_start);
            this.Controls.Add(this.f_end_val);
            this.Controls.Add(this.test_output_label);
            this.Controls.Add(this.rate_unit);
            this.Controls.Add(this.rate_type);
            this.Controls.Add(this.amp_unit);
            this.Controls.Add(this.f_unit);
            this.Controls.Add(this.phase_change_results_button);
            this.Controls.Add(this.gain_results_button);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.run_test_button);
            this.Controls.Add(this.sweep_rate);
            this.Controls.Add(this.amp);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.amp_val);
            this.Controls.Add(this.f_start_val);
            this.Name = "Main_Page";
            this.Text = "Main_Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox f_start_val;
        private System.Windows.Forms.TextBox amp_val;
        private System.Windows.Forms.TextBox rate;
        private System.Windows.Forms.Label frequency;
        private System.Windows.Forms.Label amp;
        private System.Windows.Forms.Label sweep_rate;
        private System.Windows.Forms.Button run_test_button;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button gain_results_button;
        private System.Windows.Forms.Button phase_change_results_button;
        private System.Windows.Forms.Label f_unit;
        private System.Windows.Forms.Label amp_unit;
        private System.Windows.Forms.ComboBox rate_type;
        private System.Windows.Forms.Label rate_unit;
        private System.Windows.Forms.Label test_output_label;
        private System.Windows.Forms.TextBox f_end_val;
        private System.Windows.Forms.Label f_start;
        private System.Windows.Forms.Label f_end;
        private System.Windows.Forms.TextBox dc_val;
        private System.Windows.Forms.Label dc;
        private System.Windows.Forms.Label dc_unit;
        private System.Windows.Forms.Label f_range;
        private System.Windows.Forms.Label amp_range;
        private System.Windows.Forms.Label rate_range;
        private System.Windows.Forms.Label dc_range;
        private System.Windows.Forms.TextBox file_name_val;
        private System.Windows.Forms.Label file_name_label;
        private System.Windows.Forms.Label csv_label;
    }
}

