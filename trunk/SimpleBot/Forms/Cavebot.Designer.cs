namespace SimpleBot.Forms
{
    partial class Cavebot
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
            this.uxWaypointsList = new System.Windows.Forms.ListBox();
            this.uxWptAddMove = new System.Windows.Forms.Button();
            this.uxWptAddStackItems = new System.Windows.Forms.Button();
            this.uxWptAddLabel = new System.Windows.Forms.Button();
            this.uxWptLabelName = new System.Windows.Forms.TextBox();
            this.uxWptAddSay = new System.Windows.Forms.Button();
            this.uxWptSleepTime1 = new System.Windows.Forms.TextBox();
            this.uxWptAddSleep = new System.Windows.Forms.Button();
            this.uxWptSleepTime2 = new System.Windows.Forms.TextBox();
            this.uxWptSleepBetweenLabel = new System.Windows.Forms.Label();
            this.uxWptMilisecondsLabel = new System.Windows.Forms.Label();
            this.uxWptAddReachDepot = new System.Windows.Forms.Button();
            this.uxWptAddDepositItem = new System.Windows.Forms.Button();
            this.uxWptSayTypes = new System.Windows.Forms.ComboBox();
            this.uxWptDepositItemID = new System.Windows.Forms.TextBox();
            this.uxWptListAddConditional = new System.Windows.Forms.Button();
            this.uxWptListMoveUp = new System.Windows.Forms.Button();
            this.uxWptListMoveDown = new System.Windows.Forms.Button();
            this.uxConditionalVarType = new System.Windows.Forms.ComboBox();
            this.uxConditionalCheckType = new System.Windows.Forms.ComboBox();
            this.uxWptSayText = new System.Windows.Forms.TextBox();
            this.uxConditionalOutput = new System.Windows.Forms.TextBox();
            this.uxCondtionalThenGotoLabel = new System.Windows.Forms.Label();
            this.uxConditionalLabelName = new System.Windows.Forms.TextBox();
            this.uxConditionalItemIDLabel = new System.Windows.Forms.Label();
            this.uxConditionalItemID = new System.Windows.Forms.TextBox();
            this.uxWaypointDiffType = new System.Windows.Forms.ComboBox();
            this.uxWptAddRope = new System.Windows.Forms.Button();
            this.uxWptAddLadder = new System.Windows.Forms.Button();
            this.uxWptAddShovel = new System.Windows.Forms.Button();
            this.uxWptListClear = new System.Windows.Forms.Button();
            this.uxWptListRemove = new System.Windows.Forms.Button();
            this.uxCavebotEnabled = new System.Windows.Forms.CheckBox();
            this.uxWptListLoad = new System.Windows.Forms.Button();
            this.uxWptListSave = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // uxWaypointsList
            // 
            this.uxWaypointsList.FormattingEnabled = true;
            this.uxWaypointsList.Location = new System.Drawing.Point(12, 12);
            this.uxWaypointsList.Name = "uxWaypointsList";
            this.uxWaypointsList.Size = new System.Drawing.Size(202, 160);
            this.uxWaypointsList.TabIndex = 0;
            this.uxWaypointsList.SelectedIndexChanged += new System.EventHandler(this.uxWaypointsList_SelectedIndexChanged);
            // 
            // uxWptAddMove
            // 
            this.uxWptAddMove.Location = new System.Drawing.Point(252, 12);
            this.uxWptAddMove.Name = "uxWptAddMove";
            this.uxWptAddMove.Size = new System.Drawing.Size(45, 25);
            this.uxWptAddMove.TabIndex = 1;
            this.uxWptAddMove.Text = "Move";
            this.uxWptAddMove.UseVisualStyleBackColor = true;
            this.uxWptAddMove.Click += new System.EventHandler(this.uxWptAddMove_Click);
            // 
            // uxWptAddStackItems
            // 
            this.uxWptAddStackItems.Location = new System.Drawing.Point(384, 74);
            this.uxWptAddStackItems.Name = "uxWptAddStackItems";
            this.uxWptAddStackItems.Size = new System.Drawing.Size(75, 25);
            this.uxWptAddStackItems.TabIndex = 2;
            this.uxWptAddStackItems.Text = "Stack Items";
            this.uxWptAddStackItems.UseVisualStyleBackColor = true;
            this.uxWptAddStackItems.Click += new System.EventHandler(this.uxWptAddStackItems_Click);
            // 
            // uxWptAddLabel
            // 
            this.uxWptAddLabel.Location = new System.Drawing.Point(252, 74);
            this.uxWptAddLabel.Name = "uxWptAddLabel";
            this.uxWptAddLabel.Size = new System.Drawing.Size(45, 25);
            this.uxWptAddLabel.TabIndex = 3;
            this.uxWptAddLabel.Text = "Label";
            this.uxWptAddLabel.UseVisualStyleBackColor = true;
            this.uxWptAddLabel.Click += new System.EventHandler(this.uxWptAddLabel_Click);
            // 
            // uxWptLabelName
            // 
            this.uxWptLabelName.Location = new System.Drawing.Point(303, 77);
            this.uxWptLabelName.Name = "uxWptLabelName";
            this.uxWptLabelName.Size = new System.Drawing.Size(75, 20);
            this.uxWptLabelName.TabIndex = 4;
            this.uxWptLabelName.Text = "labelName";
            // 
            // uxWptAddSay
            // 
            this.uxWptAddSay.Location = new System.Drawing.Point(252, 105);
            this.uxWptAddSay.Name = "uxWptAddSay";
            this.uxWptAddSay.Size = new System.Drawing.Size(45, 25);
            this.uxWptAddSay.TabIndex = 5;
            this.uxWptAddSay.Text = "Say";
            this.uxWptAddSay.UseVisualStyleBackColor = true;
            this.uxWptAddSay.Click += new System.EventHandler(this.uxWptAddSay_Click);
            // 
            // uxWptSleepTime1
            // 
            this.uxWptSleepTime1.Location = new System.Drawing.Point(303, 139);
            this.uxWptSleepTime1.Name = "uxWptSleepTime1";
            this.uxWptSleepTime1.Size = new System.Drawing.Size(42, 20);
            this.uxWptSleepTime1.TabIndex = 8;
            this.uxWptSleepTime1.Text = "1000";
            // 
            // uxWptAddSleep
            // 
            this.uxWptAddSleep.Location = new System.Drawing.Point(252, 136);
            this.uxWptAddSleep.Name = "uxWptAddSleep";
            this.uxWptAddSleep.Size = new System.Drawing.Size(45, 25);
            this.uxWptAddSleep.TabIndex = 7;
            this.uxWptAddSleep.Text = "Sleep";
            this.uxWptAddSleep.UseVisualStyleBackColor = true;
            this.uxWptAddSleep.Click += new System.EventHandler(this.uxWptAddSleep_Click);
            // 
            // uxWptSleepTime2
            // 
            this.uxWptSleepTime2.Location = new System.Drawing.Point(367, 139);
            this.uxWptSleepTime2.Name = "uxWptSleepTime2";
            this.uxWptSleepTime2.Size = new System.Drawing.Size(42, 20);
            this.uxWptSleepTime2.TabIndex = 9;
            this.uxWptSleepTime2.Text = "1800";
            // 
            // uxWptSleepBetweenLabel
            // 
            this.uxWptSleepBetweenLabel.AutoSize = true;
            this.uxWptSleepBetweenLabel.Location = new System.Drawing.Point(351, 142);
            this.uxWptSleepBetweenLabel.Name = "uxWptSleepBetweenLabel";
            this.uxWptSleepBetweenLabel.Size = new System.Drawing.Size(10, 13);
            this.uxWptSleepBetweenLabel.TabIndex = 10;
            this.uxWptSleepBetweenLabel.Text = "-";
            // 
            // uxWptMilisecondsLabel
            // 
            this.uxWptMilisecondsLabel.AutoSize = true;
            this.uxWptMilisecondsLabel.Location = new System.Drawing.Point(415, 142);
            this.uxWptMilisecondsLabel.Name = "uxWptMilisecondsLabel";
            this.uxWptMilisecondsLabel.Size = new System.Drawing.Size(20, 13);
            this.uxWptMilisecondsLabel.TabIndex = 11;
            this.uxWptMilisecondsLabel.Text = "ms";
            // 
            // uxWptAddReachDepot
            // 
            this.uxWptAddReachDepot.Enabled = false;
            this.uxWptAddReachDepot.Location = new System.Drawing.Point(252, 165);
            this.uxWptAddReachDepot.Name = "uxWptAddReachDepot";
            this.uxWptAddReachDepot.Size = new System.Drawing.Size(81, 36);
            this.uxWptAddReachDepot.TabIndex = 12;
            this.uxWptAddReachDepot.Text = "Reach and Open Depot";
            this.uxWptAddReachDepot.UseVisualStyleBackColor = true;
            // 
            // uxWptAddDepositItem
            // 
            this.uxWptAddDepositItem.Location = new System.Drawing.Point(252, 207);
            this.uxWptAddDepositItem.Name = "uxWptAddDepositItem";
            this.uxWptAddDepositItem.Size = new System.Drawing.Size(81, 25);
            this.uxWptAddDepositItem.TabIndex = 13;
            this.uxWptAddDepositItem.Text = "Deposit Item";
            this.uxWptAddDepositItem.UseVisualStyleBackColor = true;
            this.uxWptAddDepositItem.Click += new System.EventHandler(this.uxWptAddDepositItem_Click);
            // 
            // uxWptSayTypes
            // 
            this.uxWptSayTypes.DisplayMember = "0";
            this.uxWptSayTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxWptSayTypes.FormattingEnabled = true;
            this.uxWptSayTypes.Items.AddRange(new object[] {
            "Default",
            "NPC",
            "Trade"});
            this.uxWptSayTypes.Location = new System.Drawing.Point(384, 107);
            this.uxWptSayTypes.Name = "uxWptSayTypes";
            this.uxWptSayTypes.Size = new System.Drawing.Size(75, 21);
            this.uxWptSayTypes.TabIndex = 14;
            this.uxWptSayTypes.ValueMember = "0";
            this.uxWptSayTypes.SelectedIndexChanged += new System.EventHandler(this.uxWptSayTypes_SelectedIndexChanged);
            // 
            // uxWptDepositItemID
            // 
            this.uxWptDepositItemID.Location = new System.Drawing.Point(339, 209);
            this.uxWptDepositItemID.Name = "uxWptDepositItemID";
            this.uxWptDepositItemID.Size = new System.Drawing.Size(42, 20);
            this.uxWptDepositItemID.TabIndex = 15;
            this.uxWptDepositItemID.Text = "3031";
            // 
            // uxWptListAddConditional
            // 
            this.uxWptListAddConditional.Location = new System.Drawing.Point(12, 240);
            this.uxWptListAddConditional.Name = "uxWptListAddConditional";
            this.uxWptListAddConditional.Size = new System.Drawing.Size(75, 23);
            this.uxWptListAddConditional.TabIndex = 16;
            this.uxWptListAddConditional.Text = "Conditional";
            this.uxWptListAddConditional.UseVisualStyleBackColor = true;
            this.uxWptListAddConditional.Click += new System.EventHandler(this.uxWptListAddConditional_Click);
            // 
            // uxWptListMoveUp
            // 
            this.uxWptListMoveUp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxWptListMoveUp.Location = new System.Drawing.Point(220, 12);
            this.uxWptListMoveUp.Name = "uxWptListMoveUp";
            this.uxWptListMoveUp.Size = new System.Drawing.Size(26, 56);
            this.uxWptListMoveUp.TabIndex = 17;
            this.uxWptListMoveUp.Text = "↑";
            this.uxWptListMoveUp.UseVisualStyleBackColor = true;
            // 
            // uxWptListMoveDown
            // 
            this.uxWptListMoveDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxWptListMoveDown.Location = new System.Drawing.Point(220, 116);
            this.uxWptListMoveDown.Name = "uxWptListMoveDown";
            this.uxWptListMoveDown.Size = new System.Drawing.Size(26, 56);
            this.uxWptListMoveDown.TabIndex = 18;
            this.uxWptListMoveDown.Text = "↓";
            this.uxWptListMoveDown.UseVisualStyleBackColor = true;
            // 
            // uxConditionalVarType
            // 
            this.uxConditionalVarType.DisplayMember = "0";
            this.uxConditionalVarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxConditionalVarType.FormattingEnabled = true;
            this.uxConditionalVarType.Items.AddRange(new object[] {
            "Cap",
            "HP",
            "MP",
            "Count Items",
            "Level",
            "MLevel",
            "Exp",
            "ExpLeft"});
            this.uxConditionalVarType.Location = new System.Drawing.Point(93, 241);
            this.uxConditionalVarType.Name = "uxConditionalVarType";
            this.uxConditionalVarType.Size = new System.Drawing.Size(75, 21);
            this.uxConditionalVarType.TabIndex = 19;
            this.uxConditionalVarType.ValueMember = "0";
            this.uxConditionalVarType.SelectedIndexChanged += new System.EventHandler(this.uxConditionalVarType_SelectedIndexChanged);
            // 
            // uxConditionalCheckType
            // 
            this.uxConditionalCheckType.DisplayMember = "0";
            this.uxConditionalCheckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxConditionalCheckType.FormattingEnabled = true;
            this.uxConditionalCheckType.Items.AddRange(new object[] {
            "==",
            ">",
            ">=",
            "<",
            "<=",
            "!="});
            this.uxConditionalCheckType.Location = new System.Drawing.Point(174, 241);
            this.uxConditionalCheckType.Name = "uxConditionalCheckType";
            this.uxConditionalCheckType.Size = new System.Drawing.Size(41, 21);
            this.uxConditionalCheckType.TabIndex = 21;
            this.uxConditionalCheckType.ValueMember = "0";
            this.uxConditionalCheckType.SelectedIndexChanged += new System.EventHandler(this.uxConditionalCheckType_SelectedIndexChanged);
            // 
            // uxWptSayText
            // 
            this.uxWptSayText.Location = new System.Drawing.Point(303, 108);
            this.uxWptSayText.Name = "uxWptSayText";
            this.uxWptSayText.Size = new System.Drawing.Size(75, 20);
            this.uxWptSayText.TabIndex = 22;
            this.uxWptSayText.Text = "Hello!";
            // 
            // uxConditionalOutput
            // 
            this.uxConditionalOutput.Location = new System.Drawing.Point(221, 242);
            this.uxConditionalOutput.Name = "uxConditionalOutput";
            this.uxConditionalOutput.Size = new System.Drawing.Size(58, 20);
            this.uxConditionalOutput.TabIndex = 23;
            // 
            // uxCondtionalThenGotoLabel
            // 
            this.uxCondtionalThenGotoLabel.AutoSize = true;
            this.uxCondtionalThenGotoLabel.Location = new System.Drawing.Point(218, 271);
            this.uxCondtionalThenGotoLabel.Name = "uxCondtionalThenGotoLabel";
            this.uxCondtionalThenGotoLabel.Size = new System.Drawing.Size(87, 13);
            this.uxCondtionalThenGotoLabel.TabIndex = 24;
            this.uxCondtionalThenGotoLabel.Text = "Then go to label:";
            // 
            // uxConditionalLabelName
            // 
            this.uxConditionalLabelName.Location = new System.Drawing.Point(311, 268);
            this.uxConditionalLabelName.Name = "uxConditionalLabelName";
            this.uxConditionalLabelName.Size = new System.Drawing.Size(58, 20);
            this.uxConditionalLabelName.TabIndex = 25;
            this.uxConditionalLabelName.Text = "labelName";
            // 
            // uxConditionalItemIDLabel
            // 
            this.uxConditionalItemIDLabel.AutoSize = true;
            this.uxConditionalItemIDLabel.Location = new System.Drawing.Point(43, 271);
            this.uxConditionalItemIDLabel.Name = "uxConditionalItemIDLabel";
            this.uxConditionalItemIDLabel.Size = new System.Drawing.Size(44, 13);
            this.uxConditionalItemIDLabel.TabIndex = 26;
            this.uxConditionalItemIDLabel.Text = "Item ID:";
            this.uxConditionalItemIDLabel.Visible = false;
            // 
            // uxConditionalItemID
            // 
            this.uxConditionalItemID.Location = new System.Drawing.Point(93, 268);
            this.uxConditionalItemID.Name = "uxConditionalItemID";
            this.uxConditionalItemID.Size = new System.Drawing.Size(58, 20);
            this.uxConditionalItemID.TabIndex = 27;
            this.uxConditionalItemID.Text = "3031";
            this.uxConditionalItemID.Visible = false;
            // 
            // uxWaypointDiffType
            // 
            this.uxWaypointDiffType.DisplayMember = "0";
            this.uxWaypointDiffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxWaypointDiffType.FormattingEnabled = true;
            this.uxWaypointDiffType.Items.AddRange(new object[] {
            "Center",
            "North",
            "North-West",
            "North-East",
            "West",
            "East",
            "South",
            "South-West",
            "South-East"});
            this.uxWaypointDiffType.Location = new System.Drawing.Point(303, 14);
            this.uxWaypointDiffType.Name = "uxWaypointDiffType";
            this.uxWaypointDiffType.Size = new System.Drawing.Size(75, 21);
            this.uxWaypointDiffType.TabIndex = 28;
            this.uxWaypointDiffType.ValueMember = "0";
            this.uxWaypointDiffType.SelectedIndexChanged += new System.EventHandler(this.uxWaypointDiffType_SelectedIndexChanged);
            // 
            // uxWptAddRope
            // 
            this.uxWptAddRope.Location = new System.Drawing.Point(252, 43);
            this.uxWptAddRope.Name = "uxWptAddRope";
            this.uxWptAddRope.Size = new System.Drawing.Size(45, 25);
            this.uxWptAddRope.TabIndex = 29;
            this.uxWptAddRope.Text = "Rope";
            this.uxWptAddRope.UseVisualStyleBackColor = true;
            this.uxWptAddRope.Click += new System.EventHandler(this.uxWptAddRope_Click);
            // 
            // uxWptAddLadder
            // 
            this.uxWptAddLadder.Location = new System.Drawing.Point(303, 43);
            this.uxWptAddLadder.Name = "uxWptAddLadder";
            this.uxWptAddLadder.Size = new System.Drawing.Size(50, 25);
            this.uxWptAddLadder.TabIndex = 30;
            this.uxWptAddLadder.Text = "Ladder";
            this.uxWptAddLadder.UseVisualStyleBackColor = true;
            this.uxWptAddLadder.Click += new System.EventHandler(this.uxWptAddLadder_Click);
            // 
            // uxWptAddShovel
            // 
            this.uxWptAddShovel.Location = new System.Drawing.Point(359, 43);
            this.uxWptAddShovel.Name = "uxWptAddShovel";
            this.uxWptAddShovel.Size = new System.Drawing.Size(50, 25);
            this.uxWptAddShovel.TabIndex = 31;
            this.uxWptAddShovel.Text = "Shovel";
            this.uxWptAddShovel.UseVisualStyleBackColor = true;
            this.uxWptAddShovel.Click += new System.EventHandler(this.uxWptAddShovel_Click);
            // 
            // uxWptListClear
            // 
            this.uxWptListClear.Location = new System.Drawing.Point(12, 209);
            this.uxWptListClear.Name = "uxWptListClear";
            this.uxWptListClear.Size = new System.Drawing.Size(55, 25);
            this.uxWptListClear.TabIndex = 32;
            this.uxWptListClear.Text = "Clear";
            this.uxWptListClear.UseVisualStyleBackColor = true;
            this.uxWptListClear.Click += new System.EventHandler(this.uxWptListClear_Click);
            // 
            // uxWptListRemove
            // 
            this.uxWptListRemove.Location = new System.Drawing.Point(12, 178);
            this.uxWptListRemove.Name = "uxWptListRemove";
            this.uxWptListRemove.Size = new System.Drawing.Size(55, 25);
            this.uxWptListRemove.TabIndex = 33;
            this.uxWptListRemove.Text = "Remove";
            this.uxWptListRemove.UseVisualStyleBackColor = true;
            this.uxWptListRemove.Click += new System.EventHandler(this.uxWptListRemove_Click);
            // 
            // uxCavebotEnabled
            // 
            this.uxCavebotEnabled.AutoSize = true;
            this.uxCavebotEnabled.Location = new System.Drawing.Point(12, 294);
            this.uxCavebotEnabled.Name = "uxCavebotEnabled";
            this.uxCavebotEnabled.Size = new System.Drawing.Size(65, 17);
            this.uxCavebotEnabled.TabIndex = 34;
            this.uxCavebotEnabled.Text = "Enabled";
            this.uxCavebotEnabled.UseVisualStyleBackColor = true;
            this.uxCavebotEnabled.CheckedChanged += new System.EventHandler(this.uxCavebotEnabled_CheckedChanged);
            // 
            // uxWptListLoad
            // 
            this.uxWptListLoad.Location = new System.Drawing.Point(159, 178);
            this.uxWptListLoad.Name = "uxWptListLoad";
            this.uxWptListLoad.Size = new System.Drawing.Size(55, 25);
            this.uxWptListLoad.TabIndex = 35;
            this.uxWptListLoad.Text = "Load";
            this.uxWptListLoad.UseVisualStyleBackColor = true;
            this.uxWptListLoad.Click += new System.EventHandler(this.uxWptListLoad_Click);
            // 
            // uxWptListSave
            // 
            this.uxWptListSave.Location = new System.Drawing.Point(159, 209);
            this.uxWptListSave.Name = "uxWptListSave";
            this.uxWptListSave.Size = new System.Drawing.Size(55, 25);
            this.uxWptListSave.TabIndex = 36;
            this.uxWptListSave.Text = "Save";
            this.uxWptListSave.UseVisualStyleBackColor = true;
            this.uxWptListSave.Click += new System.EventHandler(this.uxWptListSave_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "Cavebot files (*.txt)|*.txt";
            this.openFile.Title = "Open SimpleBot script";
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Cavebot files (*.txt)|*.txt";
            this.saveFile.Title = "Save SimpleBot script";
            // 
            // Cavebot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 323);
            this.Controls.Add(this.uxWptListSave);
            this.Controls.Add(this.uxWptListLoad);
            this.Controls.Add(this.uxCavebotEnabled);
            this.Controls.Add(this.uxWptListRemove);
            this.Controls.Add(this.uxWptListClear);
            this.Controls.Add(this.uxWptAddShovel);
            this.Controls.Add(this.uxWptAddLadder);
            this.Controls.Add(this.uxWptAddRope);
            this.Controls.Add(this.uxWaypointDiffType);
            this.Controls.Add(this.uxConditionalItemID);
            this.Controls.Add(this.uxConditionalItemIDLabel);
            this.Controls.Add(this.uxConditionalLabelName);
            this.Controls.Add(this.uxCondtionalThenGotoLabel);
            this.Controls.Add(this.uxConditionalOutput);
            this.Controls.Add(this.uxWptSayText);
            this.Controls.Add(this.uxConditionalCheckType);
            this.Controls.Add(this.uxConditionalVarType);
            this.Controls.Add(this.uxWptListMoveDown);
            this.Controls.Add(this.uxWptListMoveUp);
            this.Controls.Add(this.uxWptListAddConditional);
            this.Controls.Add(this.uxWptDepositItemID);
            this.Controls.Add(this.uxWptSayTypes);
            this.Controls.Add(this.uxWptAddDepositItem);
            this.Controls.Add(this.uxWptAddReachDepot);
            this.Controls.Add(this.uxWptMilisecondsLabel);
            this.Controls.Add(this.uxWptSleepBetweenLabel);
            this.Controls.Add(this.uxWptSleepTime2);
            this.Controls.Add(this.uxWptSleepTime1);
            this.Controls.Add(this.uxWptAddSleep);
            this.Controls.Add(this.uxWptAddSay);
            this.Controls.Add(this.uxWptLabelName);
            this.Controls.Add(this.uxWptAddLabel);
            this.Controls.Add(this.uxWptAddStackItems);
            this.Controls.Add(this.uxWptAddMove);
            this.Controls.Add(this.uxWaypointsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cavebot";
            this.Text = "Cavebot";
            this.Load += new System.EventHandler(this.Cavebot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox uxWaypointsList;
        public System.Windows.Forms.Button uxWptAddMove;
        public System.Windows.Forms.Button uxWptAddStackItems;
        public System.Windows.Forms.Button uxWptAddLabel;
        public System.Windows.Forms.TextBox uxWptLabelName;
        public System.Windows.Forms.Button uxWptAddSay;
        public System.Windows.Forms.TextBox uxWptSleepTime1;
        public System.Windows.Forms.Button uxWptAddSleep;
        public System.Windows.Forms.TextBox uxWptSleepTime2;
        public System.Windows.Forms.Label uxWptSleepBetweenLabel;
        public System.Windows.Forms.Label uxWptMilisecondsLabel;
        public System.Windows.Forms.Button uxWptAddReachDepot;
        public System.Windows.Forms.Button uxWptAddDepositItem;
        public System.Windows.Forms.ComboBox uxWptSayTypes;
        public System.Windows.Forms.TextBox uxWptDepositItemID;
        public System.Windows.Forms.Button uxWptListAddConditional;
        public System.Windows.Forms.Button uxWptListMoveUp;
        public System.Windows.Forms.Button uxWptListMoveDown;
        public System.Windows.Forms.ComboBox uxConditionalVarType;
        public System.Windows.Forms.ComboBox uxConditionalCheckType;
        public System.Windows.Forms.TextBox uxWptSayText;
        public System.Windows.Forms.TextBox uxConditionalOutput;
        public System.Windows.Forms.Label uxCondtionalThenGotoLabel;
        public System.Windows.Forms.TextBox uxConditionalLabelName;
        public System.Windows.Forms.Label uxConditionalItemIDLabel;
        public System.Windows.Forms.TextBox uxConditionalItemID;
        public System.Windows.Forms.ComboBox uxWaypointDiffType;
        public System.Windows.Forms.Button uxWptAddRope;
        public System.Windows.Forms.Button uxWptAddLadder;
        public System.Windows.Forms.Button uxWptAddShovel;
        public System.Windows.Forms.Button uxWptListClear;
        public System.Windows.Forms.Button uxWptListRemove;
        public System.Windows.Forms.CheckBox uxCavebotEnabled;
        public System.Windows.Forms.Button uxWptListLoad;
        public System.Windows.Forms.Button uxWptListSave;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;


    }
}