namespace TwitterAwareTokenizer
{
    partial class SettingsForm_TwitterAwareTokenizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm_TwitterAwareTokenizer));
            this.OKButton = new System.Windows.Forms.Button();
            this.ReduceElongationCheckbox = new System.Windows.Forms.CheckBox();
            this.LowercaseCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(186, 249);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ReduceElongationCheckbox
            // 
            this.ReduceElongationCheckbox.AutoSize = true;
            this.ReduceElongationCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReduceElongationCheckbox.Location = new System.Drawing.Point(34, 145);
            this.ReduceElongationCheckbox.Name = "ReduceElongationCheckbox";
            this.ReduceElongationCheckbox.Size = new System.Drawing.Size(142, 20);
            this.ReduceElongationCheckbox.TabIndex = 7;
            this.ReduceElongationCheckbox.Text = "Reduce Elongation";
            this.ReduceElongationCheckbox.UseVisualStyleBackColor = true;
            // 
            // LowercaseCheckbox
            // 
            this.LowercaseCheckbox.AutoSize = true;
            this.LowercaseCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowercaseCheckbox.Location = new System.Drawing.Point(34, 54);
            this.LowercaseCheckbox.Name = "LowercaseCheckbox";
            this.LowercaseCheckbox.Size = new System.Drawing.Size(190, 20);
            this.LowercaseCheckbox.TabIndex = 8;
            this.LowercaseCheckbox.Text = "Convert Text to Lower Case";
            this.LowercaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "This option will make tokens more uniform by converting them to lower case";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(423, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "This option attempts to trim \"elongations\" (e.g., the extra letters in the word \"" +
    "loooooong\")";
            // 
            // SettingsForm_TwitterAwareTokenizer
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LowercaseCheckbox);
            this.Controls.Add(this.ReduceElongationCheckbox);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm_TwitterAwareTokenizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckBox ReduceElongationCheckbox;
        private System.Windows.Forms.CheckBox LowercaseCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}