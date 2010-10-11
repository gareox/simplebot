namespace SimpleBot.Forms
{
    partial class Healing
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
            this.uxHealthGetItemId = new System.Windows.Forms.Button();
            this.uxHealingList = new System.Windows.Forms.ListView();
            this.uxHealingListHP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxHealingListHPAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxHealingListMP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxHealingListMPAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxHealthGroup = new System.Windows.Forms.GroupBox();
            this.uxHealthDoNothing = new System.Windows.Forms.RadioButton();
            this.uxHealthPercent = new System.Windows.Forms.HScrollBar();
            this.uxHealthBelowLabel = new System.Windows.Forms.Label();
            this.uxHealthSpell = new System.Windows.Forms.TextBox();
            this.uxHealthCastSpell = new System.Windows.Forms.RadioButton();
            this.uxHealthItemID = new System.Windows.Forms.TextBox();
            this.uxHealthUseItem = new System.Windows.Forms.RadioButton();
            this.uxManaGroup = new System.Windows.Forms.GroupBox();
            this.uxManaDoNothing = new System.Windows.Forms.RadioButton();
            this.uxManaPercent = new System.Windows.Forms.HScrollBar();
            this.uxManaBelowLabel = new System.Windows.Forms.Label();
            this.uxManaSpell = new System.Windows.Forms.TextBox();
            this.uxManaCastSpell = new System.Windows.Forms.RadioButton();
            this.uxManaItemID = new System.Windows.Forms.TextBox();
            this.uxManaUseItem = new System.Windows.Forms.RadioButton();
            this.uxManaGetItemId = new System.Windows.Forms.Button();
            this.uxMultihealWarning = new System.Windows.Forms.Label();
            this.uxHealingListClear = new System.Windows.Forms.Button();
            this.uxHealingListRemove = new System.Windows.Forms.Button();
            this.uxHealingListAdd = new System.Windows.Forms.Button();
            this.uxHealthGroup.SuspendLayout();
            this.uxManaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxHealthGetItemId
            // 
            this.uxHealthGetItemId.BackColor = System.Drawing.SystemColors.Control;
            this.uxHealthGetItemId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxHealthGetItemId.Location = new System.Drawing.Point(120, 99);
            this.uxHealthGetItemId.Name = "uxHealthGetItemId";
            this.uxHealthGetItemId.Size = new System.Drawing.Size(32, 20);
            this.uxHealthGetItemId.TabIndex = 61;
            this.uxHealthGetItemId.Text = "Get";
            this.uxHealthGetItemId.UseVisualStyleBackColor = true;
            this.uxHealthGetItemId.Click += new System.EventHandler(this.uxHealthGetItemId_Click);
            // 
            // uxHealingList
            // 
            this.uxHealingList.BackColor = System.Drawing.Color.White;
            this.uxHealingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxHealingListHP,
            this.uxHealingListHPAction,
            this.uxHealingListMP,
            this.uxHealingListMPAction});
            this.uxHealingList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxHealingList.FullRowSelect = true;
            this.uxHealingList.GridLines = true;
            this.uxHealingList.Location = new System.Drawing.Point(12, 12);
            this.uxHealingList.MultiSelect = false;
            this.uxHealingList.Name = "uxHealingList";
            this.uxHealingList.Size = new System.Drawing.Size(318, 130);
            this.uxHealingList.TabIndex = 84;
            this.uxHealingList.UseCompatibleStateImageBehavior = false;
            this.uxHealingList.View = System.Windows.Forms.View.Details;
            // 
            // uxHealingListHP
            // 
            this.uxHealingListHP.Text = "HP%";
            this.uxHealingListHP.Width = 40;
            // 
            // uxHealingListHPAction
            // 
            this.uxHealingListHPAction.Text = "Action";
            this.uxHealingListHPAction.Width = 117;
            // 
            // uxHealingListMP
            // 
            this.uxHealingListMP.Text = "MP%";
            this.uxHealingListMP.Width = 40;
            // 
            // uxHealingListMPAction
            // 
            this.uxHealingListMPAction.Text = "Action";
            this.uxHealingListMPAction.Width = 117;
            // 
            // uxHealthGroup
            // 
            this.uxHealthGroup.Controls.Add(this.uxHealthDoNothing);
            this.uxHealthGroup.Controls.Add(this.uxHealthPercent);
            this.uxHealthGroup.Controls.Add(this.uxHealthBelowLabel);
            this.uxHealthGroup.Controls.Add(this.uxHealthSpell);
            this.uxHealthGroup.Controls.Add(this.uxHealthCastSpell);
            this.uxHealthGroup.Controls.Add(this.uxHealthItemID);
            this.uxHealthGroup.Controls.Add(this.uxHealthUseItem);
            this.uxHealthGroup.Controls.Add(this.uxHealthGetItemId);
            this.uxHealthGroup.Location = new System.Drawing.Point(12, 165);
            this.uxHealthGroup.Name = "uxHealthGroup";
            this.uxHealthGroup.Size = new System.Drawing.Size(156, 174);
            this.uxHealthGroup.TabIndex = 85;
            this.uxHealthGroup.TabStop = false;
            this.uxHealthGroup.Text = "HP Settings";
            // 
            // uxHealthDoNothing
            // 
            this.uxHealthDoNothing.AutoSize = true;
            this.uxHealthDoNothing.Checked = true;
            this.uxHealthDoNothing.Location = new System.Drawing.Point(9, 53);
            this.uxHealthDoNothing.Name = "uxHealthDoNothing";
            this.uxHealthDoNothing.Size = new System.Drawing.Size(77, 17);
            this.uxHealthDoNothing.TabIndex = 66;
            this.uxHealthDoNothing.TabStop = true;
            this.uxHealthDoNothing.Text = "Do nothing";
            this.uxHealthDoNothing.UseVisualStyleBackColor = true;
            this.uxHealthDoNothing.CheckedChanged += new System.EventHandler(this.uxHealthDoNothing_CheckedChanged);
            // 
            // uxHealthPercent
            // 
            this.uxHealthPercent.LargeChange = 1;
            this.uxHealthPercent.Location = new System.Drawing.Point(9, 33);
            this.uxHealthPercent.Name = "uxHealthPercent";
            this.uxHealthPercent.Size = new System.Drawing.Size(143, 17);
            this.uxHealthPercent.TabIndex = 65;
            this.uxHealthPercent.Value = 60;
            this.uxHealthPercent.Scroll += new System.Windows.Forms.ScrollEventHandler(this.uxHealthPercent_Scroll);
            // 
            // uxHealthBelowLabel
            // 
            this.uxHealthBelowLabel.AutoSize = true;
            this.uxHealthBelowLabel.Location = new System.Drawing.Point(6, 16);
            this.uxHealthBelowLabel.Name = "uxHealthBelowLabel";
            this.uxHealthBelowLabel.Size = new System.Drawing.Size(129, 13);
            this.uxHealthBelowLabel.TabIndex = 64;
            this.uxHealthBelowLabel.Text = "When HP% is below: 60%";
            // 
            // uxHealthSpell
            // 
            this.uxHealthSpell.Location = new System.Drawing.Point(14, 148);
            this.uxHealthSpell.Name = "uxHealthSpell";
            this.uxHealthSpell.Size = new System.Drawing.Size(100, 20);
            this.uxHealthSpell.TabIndex = 63;
            // 
            // uxHealthCastSpell
            // 
            this.uxHealthCastSpell.AutoSize = true;
            this.uxHealthCastSpell.Location = new System.Drawing.Point(9, 125);
            this.uxHealthCastSpell.Name = "uxHealthCastSpell";
            this.uxHealthCastSpell.Size = new System.Drawing.Size(75, 17);
            this.uxHealthCastSpell.TabIndex = 62;
            this.uxHealthCastSpell.Text = "Cast Spell:";
            this.uxHealthCastSpell.UseVisualStyleBackColor = true;
            this.uxHealthCastSpell.CheckedChanged += new System.EventHandler(this.uxHealthCastSpell_CheckedChanged);
            // 
            // uxHealthItemID
            // 
            this.uxHealthItemID.Location = new System.Drawing.Point(14, 99);
            this.uxHealthItemID.Name = "uxHealthItemID";
            this.uxHealthItemID.Size = new System.Drawing.Size(100, 20);
            this.uxHealthItemID.TabIndex = 1;
            this.uxHealthItemID.Text = "0";
            // 
            // uxHealthUseItem
            // 
            this.uxHealthUseItem.AutoSize = true;
            this.uxHealthUseItem.Location = new System.Drawing.Point(9, 76);
            this.uxHealthUseItem.Name = "uxHealthUseItem";
            this.uxHealthUseItem.Size = new System.Drawing.Size(105, 17);
            this.uxHealthUseItem.TabIndex = 0;
            this.uxHealthUseItem.Text = "Use item with ID:";
            this.uxHealthUseItem.UseVisualStyleBackColor = true;
            this.uxHealthUseItem.CheckedChanged += new System.EventHandler(this.uxHealthUseItem_CheckedChanged);
            // 
            // uxManaGroup
            // 
            this.uxManaGroup.Controls.Add(this.uxManaDoNothing);
            this.uxManaGroup.Controls.Add(this.uxManaPercent);
            this.uxManaGroup.Controls.Add(this.uxManaBelowLabel);
            this.uxManaGroup.Controls.Add(this.uxManaSpell);
            this.uxManaGroup.Controls.Add(this.uxManaCastSpell);
            this.uxManaGroup.Controls.Add(this.uxManaItemID);
            this.uxManaGroup.Controls.Add(this.uxManaUseItem);
            this.uxManaGroup.Controls.Add(this.uxManaGetItemId);
            this.uxManaGroup.Location = new System.Drawing.Point(174, 165);
            this.uxManaGroup.Name = "uxManaGroup";
            this.uxManaGroup.Size = new System.Drawing.Size(156, 174);
            this.uxManaGroup.TabIndex = 86;
            this.uxManaGroup.TabStop = false;
            this.uxManaGroup.Text = "MP Settings";
            // 
            // uxManaDoNothing
            // 
            this.uxManaDoNothing.AutoSize = true;
            this.uxManaDoNothing.Checked = true;
            this.uxManaDoNothing.Location = new System.Drawing.Point(9, 53);
            this.uxManaDoNothing.Name = "uxManaDoNothing";
            this.uxManaDoNothing.Size = new System.Drawing.Size(77, 17);
            this.uxManaDoNothing.TabIndex = 66;
            this.uxManaDoNothing.TabStop = true;
            this.uxManaDoNothing.Text = "Do nothing";
            this.uxManaDoNothing.UseVisualStyleBackColor = true;
            this.uxManaDoNothing.CheckedChanged += new System.EventHandler(this.uxManaDoNothing_CheckedChanged);
            // 
            // uxManaPercent
            // 
            this.uxManaPercent.LargeChange = 1;
            this.uxManaPercent.Location = new System.Drawing.Point(9, 33);
            this.uxManaPercent.Name = "uxManaPercent";
            this.uxManaPercent.Size = new System.Drawing.Size(143, 17);
            this.uxManaPercent.TabIndex = 65;
            this.uxManaPercent.Value = 60;
            this.uxManaPercent.Scroll += new System.Windows.Forms.ScrollEventHandler(this.uxManaPercent_Scroll);
            // 
            // uxManaBelowLabel
            // 
            this.uxManaBelowLabel.AutoSize = true;
            this.uxManaBelowLabel.Location = new System.Drawing.Point(6, 16);
            this.uxManaBelowLabel.Name = "uxManaBelowLabel";
            this.uxManaBelowLabel.Size = new System.Drawing.Size(130, 13);
            this.uxManaBelowLabel.TabIndex = 64;
            this.uxManaBelowLabel.Text = "When MP% is below: 60%";
            // 
            // uxManaSpell
            // 
            this.uxManaSpell.Location = new System.Drawing.Point(14, 148);
            this.uxManaSpell.Name = "uxManaSpell";
            this.uxManaSpell.Size = new System.Drawing.Size(100, 20);
            this.uxManaSpell.TabIndex = 63;
            // 
            // uxManaCastSpell
            // 
            this.uxManaCastSpell.AutoSize = true;
            this.uxManaCastSpell.Location = new System.Drawing.Point(9, 125);
            this.uxManaCastSpell.Name = "uxManaCastSpell";
            this.uxManaCastSpell.Size = new System.Drawing.Size(75, 17);
            this.uxManaCastSpell.TabIndex = 62;
            this.uxManaCastSpell.Text = "Cast Spell:";
            this.uxManaCastSpell.UseVisualStyleBackColor = true;
            this.uxManaCastSpell.CheckedChanged += new System.EventHandler(this.uxManaCastSpell_CheckedChanged);
            // 
            // uxManaItemID
            // 
            this.uxManaItemID.Location = new System.Drawing.Point(14, 99);
            this.uxManaItemID.Name = "uxManaItemID";
            this.uxManaItemID.Size = new System.Drawing.Size(100, 20);
            this.uxManaItemID.TabIndex = 1;
            // 
            // uxManaUseItem
            // 
            this.uxManaUseItem.AutoSize = true;
            this.uxManaUseItem.Location = new System.Drawing.Point(9, 76);
            this.uxManaUseItem.Name = "uxManaUseItem";
            this.uxManaUseItem.Size = new System.Drawing.Size(105, 17);
            this.uxManaUseItem.TabIndex = 0;
            this.uxManaUseItem.Text = "Use item with ID:";
            this.uxManaUseItem.UseVisualStyleBackColor = true;
            this.uxManaUseItem.CheckedChanged += new System.EventHandler(this.uxManaUseItem_CheckedChanged);
            // 
            // uxManaGetItemId
            // 
            this.uxManaGetItemId.BackColor = System.Drawing.SystemColors.Control;
            this.uxManaGetItemId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxManaGetItemId.Location = new System.Drawing.Point(120, 99);
            this.uxManaGetItemId.Name = "uxManaGetItemId";
            this.uxManaGetItemId.Size = new System.Drawing.Size(32, 20);
            this.uxManaGetItemId.TabIndex = 61;
            this.uxManaGetItemId.Text = "Get";
            this.uxManaGetItemId.UseVisualStyleBackColor = true;
            this.uxManaGetItemId.Click += new System.EventHandler(this.uxManaGetItemId_Click);
            // 
            // uxMultihealWarning
            // 
            this.uxMultihealWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxMultihealWarning.ForeColor = System.Drawing.Color.Red;
            this.uxMultihealWarning.Location = new System.Drawing.Point(12, 145);
            this.uxMultihealWarning.Name = "uxMultihealWarning";
            this.uxMultihealWarning.Size = new System.Drawing.Size(318, 17);
            this.uxMultihealWarning.TabIndex = 90;
            this.uxMultihealWarning.Text = "When setting muliple rules set smaller % first";
            this.uxMultihealWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uxHealingListClear
            // 
            this.uxHealingListClear.Image = global::SimpleBot.Properties.Resources.Delete;
            this.uxHealingListClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxHealingListClear.Location = new System.Drawing.Point(255, 345);
            this.uxHealingListClear.Name = "uxHealingListClear";
            this.uxHealingListClear.Size = new System.Drawing.Size(75, 25);
            this.uxHealingListClear.TabIndex = 89;
            this.uxHealingListClear.Text = "Clear";
            this.uxHealingListClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxHealingListClear.UseVisualStyleBackColor = true;
            this.uxHealingListClear.Click += new System.EventHandler(this.uxHealingListClear_Click);
            // 
            // uxHealingListRemove
            // 
            this.uxHealingListRemove.Image = global::SimpleBot.Properties.Resources.Remove;
            this.uxHealingListRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxHealingListRemove.Location = new System.Drawing.Point(131, 345);
            this.uxHealingListRemove.Name = "uxHealingListRemove";
            this.uxHealingListRemove.Size = new System.Drawing.Size(75, 25);
            this.uxHealingListRemove.TabIndex = 88;
            this.uxHealingListRemove.Text = "Remove ";
            this.uxHealingListRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxHealingListRemove.UseVisualStyleBackColor = true;
            this.uxHealingListRemove.Click += new System.EventHandler(this.uxHealingListRemove_Click);
            // 
            // uxHealingListAdd
            // 
            this.uxHealingListAdd.Image = global::SimpleBot.Properties.Resources.Add;
            this.uxHealingListAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxHealingListAdd.Location = new System.Drawing.Point(12, 345);
            this.uxHealingListAdd.Name = "uxHealingListAdd";
            this.uxHealingListAdd.Size = new System.Drawing.Size(75, 25);
            this.uxHealingListAdd.TabIndex = 87;
            this.uxHealingListAdd.Text = "Add";
            this.uxHealingListAdd.UseVisualStyleBackColor = true;
            this.uxHealingListAdd.Click += new System.EventHandler(this.uxHealingListAdd_Click);
            // 
            // Healing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 382);
            this.Controls.Add(this.uxMultihealWarning);
            this.Controls.Add(this.uxHealingListClear);
            this.Controls.Add(this.uxHealingListRemove);
            this.Controls.Add(this.uxHealingListAdd);
            this.Controls.Add(this.uxManaGroup);
            this.Controls.Add(this.uxHealthGroup);
            this.Controls.Add(this.uxHealingList);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Healing";
            this.Text = "Healing";
            this.Load += new System.EventHandler(this.Healing_Load);
            this.uxHealthGroup.ResumeLayout(false);
            this.uxHealthGroup.PerformLayout();
            this.uxManaGroup.ResumeLayout(false);
            this.uxManaGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button uxHealthGetItemId;
        public System.Windows.Forms.ListView uxHealingList;
        public System.Windows.Forms.ColumnHeader uxHealingListHP;
        public System.Windows.Forms.ColumnHeader uxHealingListHPAction;
        public System.Windows.Forms.ColumnHeader uxHealingListMP;
        public System.Windows.Forms.Button uxManaGetItemId;
        public System.Windows.Forms.GroupBox uxManaGroup;
        public System.Windows.Forms.RadioButton uxManaDoNothing;
        public System.Windows.Forms.HScrollBar uxManaPercent;
        public System.Windows.Forms.Label uxManaBelowLabel;
        public System.Windows.Forms.TextBox uxManaSpell;
        public System.Windows.Forms.RadioButton uxManaCastSpell;
        public System.Windows.Forms.TextBox uxManaItemID;
        public System.Windows.Forms.RadioButton uxManaUseItem;
        public System.Windows.Forms.Button uxHealingListAdd;
        public System.Windows.Forms.Button uxHealingListRemove;
        public System.Windows.Forms.Button uxHealingListClear;
        public System.Windows.Forms.ColumnHeader uxHealingListMPAction;
        public System.Windows.Forms.GroupBox uxHealthGroup;
        public System.Windows.Forms.RadioButton uxHealthDoNothing;
        public System.Windows.Forms.HScrollBar uxHealthPercent;
        public System.Windows.Forms.Label uxHealthBelowLabel;
        public System.Windows.Forms.TextBox uxHealthSpell;
        public System.Windows.Forms.RadioButton uxHealthCastSpell;
        public System.Windows.Forms.TextBox uxHealthItemID;
        public System.Windows.Forms.RadioButton uxHealthUseItem;
        private System.Windows.Forms.Label uxMultihealWarning;

    }
}