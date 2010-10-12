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
    public partial class Extras : Form
    {
        public Extras()
        {
            InitializeComponent();
        }

        private void Extras_Load(object sender, EventArgs e)
        {
            //Fills the uxCheckedListBoxFoods with enum food values
            foreach (Tibia.Objects.Food food in Tibia.Constants.ItemLists.Foods.Values)
                uxCheckedListBoxFoods.Items.Add(food.Name);

            this.FormClosing += delegate(object fsender, FormClosingEventArgs fe)
            {
                fe.Cancel = true;
                this.Hide();
            };
        }

        private void uxCheckEatFood_CheckedChanged(object sender, EventArgs e)
        {
            if (uxCheckEatFood.Checked)
            {

                //Create a new food list to clear the old one
                Program.ModuleHost.Extras.foodList = new List<uint>();

                //Check for checked foods and loop through them
                if (uxCheckedListBoxFoods.CheckedItems.Count != 0)
                    for (int i = 0; i < uxCheckedListBoxFoods.CheckedItems.Count; i++)
                    {
                        //Get the food object of the checked food via name
                        Tibia.Objects.Food currentFood = Tibia.Constants.ItemLists.Foods.Values.FirstOrDefault(food => food.Name.ToString() == uxCheckedListBoxFoods.CheckedItems[i].ToString());
                        if (currentFood != null)
                            //Add food Id to the food list
                            Program.ModuleHost.Extras.foodList.Add(currentFood.Id);
                    }
            }

            Program.ModuleHost.Extras.EatFood = uxCheckEatFood.Checked;
        }

        private void uxCheckFullLight_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.FullLight = uxCheckFullLight.Checked;
        }

        private void uxCheckXRay_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.XRay = uxCheckXRay.Checked;
        }

        private void uxCheckFramerateControl_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.FramerateControl = uxCheckFramerateControl.Checked;
        }

        private void uxReplaceTrees_Click(object sender, EventArgs e)
        {
            Program.Client.Map.ReplaceTrees();
        }
    }
}
