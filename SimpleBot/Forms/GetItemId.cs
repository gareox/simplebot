using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleBot.Forms
{
    public partial class GetItemId : Form
    {
        private static string itemId = "0";
        public GetItemId()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (itemList.SelectedIndex > -1)
            {
                string selectedItem = itemList.SelectedItem.ToString();
                string ItemId = selectedItem.Split(new char[] { '-' })[0].Trim();
                itemId = ItemId;
                this.Dispose();
            }
            else
                MessageBox.Show("Choose one first");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Shows form with item ID's and allows to choose one
        /// </summary>
        /// <returns>Item ID</returns>
        public static string Get()
        {
            Forms.GetItemId ItemIdForm = new GetItemId();
            ItemIdForm.ShowDialog();
            return itemId;
        }
    }
}
