using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ANDREICSLIB.ClassExtras;
using ANDREICSLIB.ClassReplacements;
using ANDREICSLIB.Helpers;
using ANDREICSLIB.NewControls;
using Meal_Chooser.Controller;

using SelectItem = ANDREICSLIB.NewControls.SelectItemFromListBox.SelectItem;

namespace Meal_Chooser.Controller
{
    public partial class controller
    {
        private const string basepath = "Files";
        private const string ingredientpath = basepath + "/ingredients.txt";
        private const string mealpath = basepath + "/meals.txt";
        private const string optionpath = basepath + "/options.txt";
        private const string peoplepath = basepath + "/people.txt";
        public static Form1 baseform;

        public static Data Data;

        #region initialisers

        public controller(Form1 baseformIN)
        {
            baseform = baseformIN;
        }

        public static async Task initFiles()
        {
            if (Directory.Exists(basepath) == false)
                Directory.CreateDirectory(basepath);

            Data = await Data.Get();
            UpdateFormFromData();

            //initPeopleList();
            //UpdatePeopleTastePreferences();
            //updateingrlistedit();
            //updatemeallistedit();
        }

        #endregion

        public static void UpdateFormFromData(bool save = false)
        {
            if (save)
                AsyncHelpers.RunSync(Data.Save);

            //meals
            baseform.editmeallbox.Items.Clear();
            var items = Data.Meals.Select(s => s.Name).Cast<object>().ToArray();
            baseform.editmeallbox.Items.AddRange(items);
            baseform.editmeallbox.Sorted = true;

            //ingredients
            baseform.editingrbox.Items.Clear();
            var ingrs = Data.Ingredients.Select(s => s.Name).Cast<object>().ToArray();
            baseform.editingrbox.Items.AddRange(ingrs);
            baseform.editingrbox.Sorted = true;
        }

        //#region ingredient



        //private static void UpdatePeopleTastePreferences()
        //{
        //    //initIngrList();
        //    //initSubIngr();
        //}


        //private static void initIngrList()
        //{
        //    if (ingredientsRAW.Children == null)
        //        return;
        //    baseform.ingredientlistbox.Items.Clear();
        //    baseform.mealchecklist.Items.Clear();
        //    foreach (var t in ingredientsRAW.Children)
        //    {
        //        baseform.ingredientlistbox.Items.Add(t.Name);
        //    }

        //    var a = 0;
        //    foreach (var m in mealsRAW.Children)
        //    {
        //        baseform.mealchecklist.Items.Add(m.Name);
        //        baseform.mealchecklist.SetItemChecked(a, true);
        //        a++;
        //    }
        //}

        //public static void initSubIngr()
        //{
        //    if (baseform.ingredientlistbox.SelectedItem == null)
        //        return;
        //    baseform.subingrpanel.Controls.Clear();

        //    //get list of sub ingredients for selected ingredient type
        //    var ing = ingredientsRAW.GetChildByName(baseform.ingredientlistbox.SelectedItem.ToString());
        //    if (ing == null)
        //        return;

        //    //get the list of options
        //    var op = optionsRAW.Children;

        //    ////var vs = new VScrollBar();
        //    //vs.Dock = DockStyle.Right;
        //    //subingrpanel.Controls.Add(vs);

        //    foreach (var v in ing.Children)
        //    {
        //        var c = op.Count;
        //        var count = 0;

        //        var gp = new PanelReplacement();
        //        gp.BorderWidth = 1;
        //        gp.Width = baseform.subingrpanel.Width;
        //        gp.Height = 1;

        //        gp.Anchor = AnchorStyles.Right;
        //        var l = new Label { Height = 20, Text = v.Name };
        //        gp.AddControl(l, true, 10, 20);

        //        gp.BumpLastPosition(0, -5);
        //        var acheck = false;
        //        var middle = MathExtras.Ceiling(op.Count / 2);
        //        RadioButton middleRB = null;
        //        foreach (var o in op)
        //        {
        //            var rb = new RadioButton();
        //            rb.Click += Form1.rb_Click;
        //            rb.Width = 100;
        //            rb.BackColor = ColorExtras.GetRedGreenBlendedColour(int.Parse(o.Children[0].Name));
        //            rb.ForeColor = ColorExtras.GetNegativeColour(rb.BackColor);
        //            //link to person
        //            var p = peopleRAW.GetChildByName(baseform.peoplelist.Text);
        //            var p1 = p.GetChildByName(o.Name);
        //            if (p1 != null && acheck == false)
        //            {
        //                var p2 = p1.GetChildByName(v.Name);
        //                if (p2 != null)
        //                {
        //                    rb.Checked = true;
        //                    acheck = true;
        //                }
        //            }
        //            if (count == middle)
        //                middleRB = rb;

        //            rb.Tag = p;
        //            rb.Name = l.Text;
        //            rb.Text = o.Name;
        //            gp.AddControl(rb, count != (c - 1));
        //            count++;
        //        }

        //        //default = neutral
        //        if (acheck == false)
        //            middleRB.Checked = true;

        //        gp.AutoSize = true;
        //        baseform.subingrpanel.Controls.Add(gp);
        //    }

        //    //var vb = new VScrollBar();
        //    //vb.Dock = DockStyle.Right;
        //    //subingrpanel.Controls.Add(vb);
        //    //vb.BringToFront();
        //    //vb.SendToBack();
        //}

        //private static void updateingrlistedit()
        //{
        //    baseform.editingrbox.Items.Clear();
        //    foreach (var v in ingredientsRAW.Children)
        //    {
        //        if (v.Children == null)
        //            v.Children = new List<tree>();

        //        foreach (var v2 in v.Children)
        //        {
        //            if (baseform.editingrbox.Items.Contains(v2.Name) == false)
        //                baseform.editingrbox.Items.Add(v2.Name);
        //        }
        //    }
        //    baseform.editingrbox.Sorted = true;
        //}

        //private static void saveFileIngredients()
        //{
        //    ANDREICSLIB.Helpers.BTree.SaveFileIntoTree(ingredientpath, ingredientsRAW);
        //    updateingrlistedit();
        //}


    }
}