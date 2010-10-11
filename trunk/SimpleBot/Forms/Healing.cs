using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleBot.ModuleHost.Constants;
using SimpleBot.ModuleHost.Objects;

namespace SimpleBot.Forms
{
    public partial class Healing : Form
    {
        #region Definitions
        ActionType healType = ActionType.DoNothing;
        ActionType manaType = ActionType.DoNothing;
        #endregion

        #region Form Initializing and Events

        public Healing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds events to TextBoxes and FormClosing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Healing_Load(object sender, EventArgs e)
        {
            uxHealthItemID.TextChanged += new EventHandler(CheckNumbers);
            uxManaItemID.TextChanged += new EventHandler(CheckNumbers);
            this.FormClosing += delegate(object fsender, FormClosingEventArgs fe)
            {
                fe.Cancel = true;
                this.Hide();
            };
        }

        /// <summary>
        /// Checks TextBox if all characters all digits
        /// Thanks to Wronq
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNumbers(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            string txt = txtBox.Text;
            int Out;
            for (int i = 0; i < txt.Length; i++)
            {
                if (!Int32.TryParse(txt[i].ToString(), out Out))
                    txt = txt.Replace(txt[i].ToString(), "");
            }
            txtBox.Text = txt;
            txtBox.SelectionStart = txt.Length;
        }

        private void SetTextToZeroIfNull(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = "0";
        }

        #endregion

        #region Health

        private void uxHealthPercent_Scroll(object sender, ScrollEventArgs e)
        {
            uxHealthBelowLabel.Text = string.Format("When HP% is below: {0}%", uxHealthPercent.Value.ToString());
        }

        /// <summary>
        /// Sets ID TextBox text to GetItemId.Get result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxHealthGetItemId_Click(object sender, EventArgs e)
        {
            uxHealthItemID.Text = GetItemId.Get();
        }

        private void uxHealthDoNothing_CheckedChanged(object sender, EventArgs e)
        {
            if (uxHealthDoNothing.Checked)
                healType = ActionType.DoNothing;
        }

        private void uxHealthUseItem_CheckedChanged(object sender, EventArgs e)
        {
            if (uxHealthUseItem.Checked)
                healType = ActionType.UseItem;
        }

        private void uxHealthCastSpell_CheckedChanged(object sender, EventArgs e)
        {
            if (uxHealthCastSpell.Checked)
                healType = ActionType.Spell;
        }

        #endregion

        #region Mana

        private void uxManaPercent_Scroll(object sender, ScrollEventArgs e)
        {
            uxManaBelowLabel.Text = string.Format("When MP% is below: {0}%", uxManaPercent.Value.ToString());
        }

        /// <summary>
        /// Sets ID TextBox text to GetItemId.Get result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxManaGetItemId_Click(object sender, EventArgs e)
        {
            uxManaItemID.Text = GetItemId.Get();
        }

        private void uxManaDoNothing_CheckedChanged(object sender, EventArgs e)
        {
            if (uxManaDoNothing.Checked)
                manaType = ActionType.DoNothing;
        }

        private void uxManaUseItem_CheckedChanged(object sender, EventArgs e)
        {
            if (uxManaUseItem.Checked)
                manaType = ActionType.UseItem;
        }

        private void uxManaCastSpell_CheckedChanged(object sender, EventArgs e)
        {
            if (uxManaCastSpell.Checked)
                manaType = ActionType.Spell;
        }

        #endregion

        #region List Management

        private void uxHealingListAdd_Click(object sender, EventArgs e)
        {
            SetTextToZeroIfNull(uxHealthItemID);
            SetTextToZeroIfNull(uxManaItemID);
            Program.ModuleHost.Healing.HealingRules.Add(new ModuleHost.Objects.HealInfo((uint)uxHealthPercent.Value,
                uint.Parse(uxHealthItemID.Text), uxHealthSpell.Text, healType,
                (uint)uxManaPercent.Value, uint.Parse(uxManaItemID.Text), uxManaSpell.Text, manaType));
            refreshList();
        }

        private void uxHealingListRemove_Click(object sender, EventArgs e)
        {
            if (uxHealingList.SelectedIndices.Count > 0)
            {
                Program.ModuleHost.Healing.HealingRules.RemoveAt(uxHealingList.SelectedIndices[0]);
                refreshList();
            }
            else
                MessageBox.Show("First select one!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void uxHealingListClear_Click(object sender, EventArgs e)
        {
            Program.ModuleHost.Healing.HealingRules.Clear();
            refreshList();
        }

        public void refreshList()
        {
            uxHealingList.Items.Clear();
            foreach (HealInfo currentRule in Program.ModuleHost.Healing.HealingRules)
            {
                string[] listViewText = new string[4];
                listViewText[0] = string.Format("{0}%", currentRule.HealthPercent.ToString());
                listViewText[2] = string.Format("{0}%", currentRule.ManaPercent.ToString());
                switch (currentRule.HealthActionType)
                {
                    case ActionType.DoNothing:
                        listViewText[1] = "Do nothing";
                        break;
                    case ActionType.UseItem:
                        listViewText[1] = string.Format("Use item: {0}", currentRule.HealthItemId.ToString());
                        break;
                    case ActionType.Spell:
                        listViewText[1] = string.Format("Spell: {0}", currentRule.HealthSpell);
                        break;
                }
                switch (currentRule.ManaActionType)
                {
                    case ActionType.DoNothing:
                        listViewText[3] = "Do nothing";
                        break;
                    case ActionType.UseItem:
                        listViewText[3] = string.Format("Use item: {0}", currentRule.ManaItemId.ToString());
                        break;
                    case ActionType.Spell:
                        listViewText[3] = string.Format("Spell: {0}", currentRule.ManaSpell);
                        break;
                }
                uxHealingList.Items.Add(new ListViewItem(listViewText));
            }
        }

        #endregion
    }
}
