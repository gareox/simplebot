namespace SimpleBot
{
    partial class Main
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
            this.settingsTab = new System.Windows.Forms.TabControl();
            this.uxSettingsTab1 = new System.Windows.Forms.TabPage();
            this.uxSettingsTab2 = new System.Windows.Forms.TabPage();
            this.uxSettingsTab3 = new System.Windows.Forms.TabPage();
            this.uxSettingsTab4 = new System.Windows.Forms.TabPage();
            this.uxSettingsTab5 = new System.Windows.Forms.TabPage();
            this.uxClearSettings = new System.Windows.Forms.Button();
            this.uxSaveSettings = new System.Windows.Forms.Button();
            this.uxLoadSettings = new System.Windows.Forms.Button();
            this.uxShowExtras = new System.Windows.Forms.Button();
            this.uxShowTargeting = new System.Windows.Forms.Button();
            this.uxShowCavebot = new System.Windows.Forms.Button();
            this.uxShowHealing = new System.Windows.Forms.Button();
            this.settingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.uxSettingsTab1);
            this.settingsTab.Controls.Add(this.uxSettingsTab2);
            this.settingsTab.Controls.Add(this.uxSettingsTab3);
            this.settingsTab.Controls.Add(this.uxSettingsTab4);
            this.settingsTab.Controls.Add(this.uxSettingsTab5);
            this.settingsTab.Location = new System.Drawing.Point(12, 124);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 0;
            this.settingsTab.Size = new System.Drawing.Size(213, 21);
            this.settingsTab.TabIndex = 4;
            // 
            // uxSettingsTab1
            // 
            this.uxSettingsTab1.Location = new System.Drawing.Point(4, 22);
            this.uxSettingsTab1.Name = "uxSettingsTab1";
            this.uxSettingsTab1.Padding = new System.Windows.Forms.Padding(3);
            this.uxSettingsTab1.Size = new System.Drawing.Size(205, 0);
            this.uxSettingsTab1.TabIndex = 0;
            this.uxSettingsTab1.Text = "#1";
            this.uxSettingsTab1.UseVisualStyleBackColor = true;
            // 
            // uxSettingsTab2
            // 
            this.uxSettingsTab2.Location = new System.Drawing.Point(4, 22);
            this.uxSettingsTab2.Name = "uxSettingsTab2";
            this.uxSettingsTab2.Padding = new System.Windows.Forms.Padding(3);
            this.uxSettingsTab2.Size = new System.Drawing.Size(205, 0);
            this.uxSettingsTab2.TabIndex = 1;
            this.uxSettingsTab2.Text = "#2";
            this.uxSettingsTab2.UseVisualStyleBackColor = true;
            // 
            // uxSettingsTab3
            // 
            this.uxSettingsTab3.Location = new System.Drawing.Point(4, 22);
            this.uxSettingsTab3.Name = "uxSettingsTab3";
            this.uxSettingsTab3.Size = new System.Drawing.Size(205, 0);
            this.uxSettingsTab3.TabIndex = 2;
            this.uxSettingsTab3.Text = "#3";
            this.uxSettingsTab3.UseVisualStyleBackColor = true;
            // 
            // uxSettingsTab4
            // 
            this.uxSettingsTab4.Location = new System.Drawing.Point(4, 22);
            this.uxSettingsTab4.Name = "uxSettingsTab4";
            this.uxSettingsTab4.Size = new System.Drawing.Size(205, 0);
            this.uxSettingsTab4.TabIndex = 3;
            this.uxSettingsTab4.Text = "#4";
            this.uxSettingsTab4.UseVisualStyleBackColor = true;
            // 
            // uxSettingsTab5
            // 
            this.uxSettingsTab5.Location = new System.Drawing.Point(4, 22);
            this.uxSettingsTab5.Name = "uxSettingsTab5";
            this.uxSettingsTab5.Size = new System.Drawing.Size(205, 0);
            this.uxSettingsTab5.TabIndex = 4;
            this.uxSettingsTab5.Text = "#5";
            this.uxSettingsTab5.UseVisualStyleBackColor = true;
            // 
            // uxClearSettings
            // 
            this.uxClearSettings.Image = global::SimpleBot.Properties.Resources.Delete;
            this.uxClearSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxClearSettings.Location = new System.Drawing.Point(12, 218);
            this.uxClearSettings.Name = "uxClearSettings";
            this.uxClearSettings.Size = new System.Drawing.Size(211, 27);
            this.uxClearSettings.TabIndex = 7;
            this.uxClearSettings.Text = "Clear Settings #1   ";
            this.uxClearSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxClearSettings.UseVisualStyleBackColor = true;
            this.uxClearSettings.Click += new System.EventHandler(this.uxClearSettings_Click);
            // 
            // uxSaveSettings
            // 
            this.uxSaveSettings.Image = global::SimpleBot.Properties.Resources.Save;
            this.uxSaveSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxSaveSettings.Location = new System.Drawing.Point(12, 185);
            this.uxSaveSettings.Name = "uxSaveSettings";
            this.uxSaveSettings.Size = new System.Drawing.Size(211, 27);
            this.uxSaveSettings.TabIndex = 6;
            this.uxSaveSettings.Text = "Save Settings #1   ";
            this.uxSaveSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxSaveSettings.UseVisualStyleBackColor = true;
            this.uxSaveSettings.Click += new System.EventHandler(this.uxSaveSettings_Click);
            // 
            // uxLoadSettings
            // 
            this.uxLoadSettings.Image = global::SimpleBot.Properties.Resources.Open;
            this.uxLoadSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxLoadSettings.Location = new System.Drawing.Point(12, 152);
            this.uxLoadSettings.Name = "uxLoadSettings";
            this.uxLoadSettings.Size = new System.Drawing.Size(211, 27);
            this.uxLoadSettings.TabIndex = 5;
            this.uxLoadSettings.Text = "Load Settings #1   ";
            this.uxLoadSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxLoadSettings.UseVisualStyleBackColor = true;
            this.uxLoadSettings.Click += new System.EventHandler(this.uxLoadSettings_Click);
            // 
            // uxShowExtras
            // 
            this.uxShowExtras.Image = global::SimpleBot.Properties.Resources.Universal_Tool;
            this.uxShowExtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxShowExtras.Location = new System.Drawing.Point(123, 12);
            this.uxShowExtras.Name = "uxShowExtras";
            this.uxShowExtras.Size = new System.Drawing.Size(100, 50);
            this.uxShowExtras.TabIndex = 3;
            this.uxShowExtras.Text = "Extras     ";
            this.uxShowExtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxShowExtras.UseVisualStyleBackColor = true;
            this.uxShowExtras.Click += new System.EventHandler(this.uxShowExtras_Click);
            // 
            // uxShowTargeting
            // 
            this.uxShowTargeting.Image = global::SimpleBot.Properties.Resources.Magic_Longsword;
            this.uxShowTargeting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxShowTargeting.Location = new System.Drawing.Point(123, 68);
            this.uxShowTargeting.Name = "uxShowTargeting";
            this.uxShowTargeting.Size = new System.Drawing.Size(100, 50);
            this.uxShowTargeting.TabIndex = 2;
            this.uxShowTargeting.Text = "Targeting";
            this.uxShowTargeting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxShowTargeting.UseVisualStyleBackColor = true;
            // 
            // uxShowCavebot
            // 
            this.uxShowCavebot.Image = global::SimpleBot.Properties.Resources.Knight_Male;
            this.uxShowCavebot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxShowCavebot.Location = new System.Drawing.Point(12, 68);
            this.uxShowCavebot.Name = "uxShowCavebot";
            this.uxShowCavebot.Size = new System.Drawing.Size(100, 50);
            this.uxShowCavebot.TabIndex = 1;
            this.uxShowCavebot.Text = "Cavebot ";
            this.uxShowCavebot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxShowCavebot.UseVisualStyleBackColor = true;
            this.uxShowCavebot.Click += new System.EventHandler(this.uxShowCavebot_Click);
            // 
            // uxShowHealing
            // 
            this.uxShowHealing.Image = global::SimpleBot.Properties.Resources.Ultimate_Health_Potion;
            this.uxShowHealing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxShowHealing.Location = new System.Drawing.Point(12, 12);
            this.uxShowHealing.Name = "uxShowHealing";
            this.uxShowHealing.Size = new System.Drawing.Size(100, 50);
            this.uxShowHealing.TabIndex = 0;
            this.uxShowHealing.Text = "Healing   ";
            this.uxShowHealing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxShowHealing.UseVisualStyleBackColor = true;
            this.uxShowHealing.Click += new System.EventHandler(this.uxShowHealing_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 257);
            this.Controls.Add(this.uxClearSettings);
            this.Controls.Add(this.uxSaveSettings);
            this.Controls.Add(this.uxLoadSettings);
            this.Controls.Add(this.settingsTab);
            this.Controls.Add(this.uxShowExtras);
            this.Controls.Add(this.uxShowTargeting);
            this.Controls.Add(this.uxShowCavebot);
            this.Controls.Add(this.uxShowHealing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SimpleBot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.settingsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxShowHealing;
        private System.Windows.Forms.Button uxShowCavebot;
        private System.Windows.Forms.Button uxShowTargeting;
        private System.Windows.Forms.Button uxShowExtras;
        private System.Windows.Forms.TabControl settingsTab;
        private System.Windows.Forms.TabPage uxSettingsTab1;
        private System.Windows.Forms.TabPage uxSettingsTab2;
        private System.Windows.Forms.TabPage uxSettingsTab3;
        private System.Windows.Forms.TabPage uxSettingsTab4;
        private System.Windows.Forms.TabPage uxSettingsTab5;
        private System.Windows.Forms.Button uxSaveSettings;
        private System.Windows.Forms.Button uxLoadSettings;
        private System.Windows.Forms.Button uxClearSettings;



    }
}

