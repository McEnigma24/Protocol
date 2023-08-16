
namespace Shutdown_Protocol
{
    partial class Shutdown_Protocol
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
            this.textBox_user_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_user_text
            // 
            this.textBox_user_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox_user_text.Location = new System.Drawing.Point(30, 50);
            this.textBox_user_text.Multiline = true;
            this.textBox_user_text.Name = "textBox_user_text";
            this.textBox_user_text.Size = new System.Drawing.Size(237, 193);
            this.textBox_user_text.TabIndex = 0;
            this.textBox_user_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(96, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Protocol";
            // 
            // Shutdown_Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_user_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Shutdown_Protocol";
            this.Text = "Shutdown Protocol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_user_text;
        private System.Windows.Forms.Label label1;
    }
}

