namespace Loader
{
    partial class Loader
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
            this.uxClientList = new System.Windows.Forms.ComboBox();
            this.uxChoose = new System.Windows.Forms.Button();
            this.uxRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxClientList
            // 
            this.uxClientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxClientList.FormattingEnabled = true;
            this.uxClientList.Location = new System.Drawing.Point(12, 12);
            this.uxClientList.Name = "uxClientList";
            this.uxClientList.Size = new System.Drawing.Size(214, 21);
            this.uxClientList.TabIndex = 0;
            // 
            // uxChoose
            // 
            this.uxChoose.Location = new System.Drawing.Point(232, 12);
            this.uxChoose.Name = "uxChoose";
            this.uxChoose.Size = new System.Drawing.Size(52, 21);
            this.uxChoose.TabIndex = 1;
            this.uxChoose.Text = "Choose";
            this.uxChoose.UseVisualStyleBackColor = true;
            this.uxChoose.Click += new System.EventHandler(this.uxChoose_Click);
            // 
            // uxRefresh
            // 
            this.uxRefresh.Location = new System.Drawing.Point(290, 12);
            this.uxRefresh.Name = "uxRefresh";
            this.uxRefresh.Size = new System.Drawing.Size(52, 21);
            this.uxRefresh.TabIndex = 2;
            this.uxRefresh.Text = "Refresh";
            this.uxRefresh.UseVisualStyleBackColor = true;
            this.uxRefresh.Click += new System.EventHandler(this.uxRefresh_Click);
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 45);
            this.Controls.Add(this.uxRefresh);
            this.Controls.Add(this.uxChoose);
            this.Controls.Add(this.uxClientList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Loader";
            this.Text = "Loader";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Loader_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox uxClientList;
        private System.Windows.Forms.Button uxChoose;
        private System.Windows.Forms.Button uxRefresh;
    }
}