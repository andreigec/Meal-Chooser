using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ANDREICSLIB;
using ANDREICSLIB.ClassExtras;
using ANDREICSLIB.ClassReplacements;
using ANDREICSLIB.NewControls;
using tree = ANDREICSLIB.Helpers.Btree<System.String>;
using SelectItem = ANDREICSLIB.NewControls.SelectItemFromListBox.SelectItem;

namespace Meal_Chooser_2
{
    public class controller
    {
        private const string basepath = "Files";
        private const string ingredientpath = basepath + "/ingredients.txt";
        private const string mealpath = basepath + "/meals.txt";
        private const string optionpath = basepath + "/options.txt";
        private const string peoplepath = basepath + "/people.txt";
        public static Form1 baseform;

        public static tree ingredientsRAW = new tree();
        public static tree peopleRAW = new tree();
        public static tree mealsRAW = new tree();
        public static tree optionsRAW = new tree();

        #region initialisers

        public controller(Form1 baseformIN)
        {
            baseform = baseformIN;
        }

        public static void initFiles()
        {
            if (Directory.Exists(basepath) == false)
                Directory.CreateDirectory(basepath);

            ANDREICSLIB.Helpers.BTree.LoadFileIntoTree(ingredientpath, ingredientsRAW);
            ANDREICSLIB.Helpers.BTree.LoadFileIntoTree(optionpath, optionsRAW);
            ANDREICSLIB.Helpers.BTree.LoadFileIntoTree(mealpath, mealsRAW);
            ANDREICSLIB.Helpers.BTree.LoadFileIntoTree(peoplepath, peopleRAW);

            initPeopleList();
            UpdatePeopleTastePreferences();
            updateingrlistedit();
            updatemeallistedit();
        }

        #endregion

        #region meal

        public static void addMeal()
        {
            var gsb = new GetStringBox();
            var mealname = gsb.ShowDialog("Enter name for new meal", "question");
            if (string.IsNullOrEmpty(mealname))
                return;

            var cats = new List<SelectItem>();
            foreach (var c in mealsRAW.Children) //meal categories
            {
                cats.Add(new SelectItem(c.Name, false));
            }
            var catreturn = SelectItemFromListBox.ShowDialog("Select category of this meal", "question", cats, false, 1);

            if (catreturn == null || catreturn.Count == 0)
                return;
            var category = catreturn[0];

            if (mealsRAW.Children.Any(ch => ch.GetChildByName(mealname) != null))
            {
                MessageBox.Show("Error, meal with this name already exists in the category");
                return;
            }

            cats = new List<SelectItem>();
            foreach (var c2 in ingredientsRAW.Children)
            {
                foreach (var c in c2.Children)
                {
                    cats.Add(new SelectItem(c.Name, false));
                }
            }

            var ingredients = SelectItemFromListBox.ShowDialog("Select ingredients in this meal", "question", cats, true, 1);

            if (ingredients == null || ingredients.Count == 0)
                return;
            mealsRAW.GetChildByName(category).AddChild(mealname);
            var t = mealsRAW.GetChildByName(category).GetChildByName(mealname);
            foreach (var ingr in ingredients)
            {
                t.AddChild(ingr);
            }

            saveMeals();
        }

        public static void editMeal(String mealstr)
        {
            var cats = new List<SelectItem>();
            var meal = getMeal(mealstr);
            foreach (var c1 in ingredientsRAW.Children)
            {
                foreach (var c in c1.Children)
                {
                    var selected = false;
                    if (meal.GetChildByName(c.Name) != null)
                        selected = true;
                    cats.Add(new SelectItem(c.Name, selected));
                }
            }
            cats.Sort();

            var ingredients = SelectItemFromListBox.ShowDialog(
                "Select ingredients you want to have in the meal. remove all ingredients to delete meal all together", "question",
                cats, true, 0);

            if (ingredients == null)
                return;

            if (ingredients.Count == 0)
            {
                meal.Parent.RemoveChild(meal.Name);
            }
            else
            {
                meal.ClearChildren();
                foreach (var c in ingredients)
                {
                    meal.AddChild(c);
                }
            }
            saveMeals();
        }

        public static tree getMeal(String mealname)
        {
            foreach (var v1 in mealsRAW.Children)
            {
                foreach (var v2 in v1.Children)
                {
                    if (v2.Name.Equals(mealname))
                        return v2;
                }
            }
            return null;
        }

        private static void updatemeallistedit()
        {
            baseform.editmeallbox.Items.Clear();
            foreach (var v in mealsRAW.Children)
            {
                foreach (var v2 in v.Children)
                {
                    if (baseform.editmeallbox.Items.Contains(v2.Name) == false)
                        baseform.editmeallbox.Items.Add(v2.Name);
                }
            }
            baseform.editmeallbox.Sorted = true;
        }

        private static void saveMeals()
        {
            ANDREICSLIB.Helpers.BTree.SaveFileIntoTree(mealpath, mealsRAW);
            updatemeallistedit();
        }

        #endregion

        #region ingredient
        public static void EditCategory()
        {
            const string cr = "Create";
            const string ren = "Rename";
            const string del = "Delete";
            const string canc = "Cancel";
            //get options type

            var ls = new List<string>();
            ls.Add(cr);
            ls.Add(ren);
            ls.Add(del);
            ls.Add(canc);

            var mmb = new MultipleMessageBox("Edit Category", "Choose Mode", ls);
            mmb.ShowDialog();

            if (mmb.IsSet == false || mmb.Result == canc)
                return;

            if (mmb.Result.Equals(cr))
            {
                var gsb = new GetStringBox();
                var res = gsb.ShowDialog("Enter Category Name to create:", "Edit Category");
                if (string.IsNullOrWhiteSpace(res))
                    return;
                if (ingredientsRAW.Children.Any(s => s.Name.Equals(res)))
                {
                    MessageBox.Show("Error, a category with that name already exists");
                    return;
                }

                ingredientsRAW.AddChild(res);
            }

            else if (mmb.Result.Equals(ren))
            {
                var cats = GetCategoryList();

                var res = SelectItemFromListBox.ShowDialog("Select category to rename", "Rename Category", cats, false, 1);
                if (res == null)
                    return;

                var rename = new GetStringBox();
                var res2 = rename.ShowDialog("Enter new category name", "Rename Category");

                if (string.IsNullOrWhiteSpace(res2))
                    return;

                if (ingredientsRAW.Children.Any(s => s.Name.Equals(res)))
                {
                    MessageBox.Show("Error, a category with that name already exists");
                    return;
                }

                try
                {
                    ingredientsRAW.Children.Where(s => s.Name.Equals(res)).First().Name = res2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured:" + ex);
                    return;
                }
            }

            else if (mmb.Result.Equals(del))
            {
                var cats = GetCategoryList();

                var res = SelectItemFromListBox.ShowDialog("Select category to delete", "Delete Category", cats, false, 1);
                if (res == null)
                    return;

                foreach (var cat in res)
                {
                    ingredientsRAW.RemoveChild(cat);
                }
            }

            UpdatePeopleTastePreferences();
            saveFileIngredients();
        }

        private static void UpdatePeopleTastePreferences()
        {
            initIngrList();
            initSubIngr();
        }

        public static List<SelectItem> GetCategoryList()
        {
            var cats = new List<SelectItem>();
            foreach (var c in ingredientsRAW.Children)
            {
                cats.Add(new SelectItem(c.Name, false));
            }
            return cats;
        }

        public static void addIngredient()
        {
            var gsb = new GetStringBox();
            var option = gsb.ShowDialog("Enter name for new ingredient", "question");
            if (string.IsNullOrEmpty(option))
                return;

            var cats = GetCategoryList();

            var catreturn = SelectItemFromListBox.ShowDialog("Select categories that include this ingredient", "question", cats, true,
                                                       1);

            if (catreturn == null || catreturn.Count == 0)
                return;

            foreach (var ch in ingredientsRAW.Children)
            {
                if (ch.GetChildByName(option) != null)
                {
                    MessageBox.Show("Error, ingredient:" + option + " exists already in category:" + ch.Name);
                    return;
                }
            }
            foreach (var catr in catreturn)
            {
                ingredientsRAW.GetChildByName(catr).AddChild(option);
            }

            saveFileIngredients();
        }

        public static void editIngredient()
        {
            var ingr = baseform.editingrbox.SelectedItem.ToString();

            var cats = new List<SelectItem>();
            foreach (var c in ingredientsRAW.Children)
            {
                var selected = false;
                if (c.GetChildByName(ingr) != null)
                    selected = true;
                cats.Add(new SelectItem(c.Name, selected));
            }

            var catreturn =
                SelectItemFromListBox.ShowDialog(
                    "Select categories you want to have the ingredient in. remove all categories to delete ingredient all together",
                    "question", cats, true, 0);

            if (catreturn == null)
                return;

            foreach (var c in ingredientsRAW.Children)
            {
                //delete ingr category if not selected
                if (c.GetChildByName(ingr) != null && catreturn.Contains(c.Name) == false)
                {
                    c.RemoveChild(ingr);
                    peopleRemoveIng(ingr);
                }
                //add if not there to start
                if (c.GetChildByName(ingr) == null && catreturn.Contains(c.Name))
                    c.AddChild(ingr);
            }
            saveFileIngredients();
        }

        private static void initIngrList()
        {
            if (ingredientsRAW.Children == null)
                return;
            baseform.ingredientlistbox.Items.Clear();
            baseform.mealchecklist.Items.Clear();
            foreach (var t in ingredientsRAW.Children)
            {
                baseform.ingredientlistbox.Items.Add(t.Name);
            }

            var a = 0;
            foreach (var m in mealsRAW.Children)
            {
                baseform.mealchecklist.Items.Add(m.Name);
                baseform.mealchecklist.SetItemChecked(a, true);
                a++;
            }
        }

        public static void initSubIngr()
        {
            if (baseform.ingredientlistbox.SelectedItem == null)
                return;
            baseform.subingrpanel.Controls.Clear();

            //get list of sub ingredients for selected ingredient type
            var ing = ingredientsRAW.GetChildByName(baseform.ingredientlistbox.SelectedItem.ToString());
            if (ing == null)
                return;

            //get the list of options
            var op = optionsRAW.Children;

            ////var vs = new VScrollBar();
            //vs.Dock = DockStyle.Right;
            //subingrpanel.Controls.Add(vs);

            foreach (var v in ing.Children)
            {
                var c = op.Count;
                var count = 0;

                var gp = new PanelReplacement();
                gp.BorderWidth = 1;
                gp.Width = baseform.subingrpanel.Width;
                gp.Height = 1;

                gp.Anchor = AnchorStyles.Right;
                var l = new Label { Height = 20, Text = v.Name };
                gp.AddControl(l, true, 10, 20);

                gp.BumpLastPosition(0, -5);
                var acheck = false;
                var middle = MathExtras.Ceiling(op.Count / 2);
                RadioButton middleRB = null;
                foreach (var o in op)
                {
                    var rb = new RadioButton();
                    rb.Click += Form1.rb_Click;
                    rb.Width = 100;
                    rb.BackColor = ColorExtras.GetRedGreenBlendedColour(int.Parse(o.Children[0].Name));
                    rb.ForeColor = ColorExtras.GetNegativeColour(rb.BackColor);
                    //link to person
                    var p = peopleRAW.GetChildByName(baseform.peoplelist.Text);
                    var p1 = p.GetChildByName(o.Name);
                    if (p1 != null && acheck == false)
                    {
                        var p2 = p1.GetChildByName(v.Name);
                        if (p2 != null)
                        {
                            rb.Checked = true;
                            acheck = true;
                        }
                    }
                    if (count == middle)
                        middleRB = rb;

                    rb.Tag = p;
                    rb.Name = l.Text;
                    rb.Text = o.Name;
                    gp.AddControl(rb, count != (c - 1));
                    count++;
                }

                //default = neutral
                if (acheck == false)
                    middleRB.Checked = true;

                gp.AutoSize = true;
                baseform.subingrpanel.Controls.Add(gp);
            }

            //var vb = new VScrollBar();
            //vb.Dock = DockStyle.Right;
            //subingrpanel.Controls.Add(vb);
            //vb.BringToFront();
            //vb.SendToBack();
        }

        private static void updateingrlistedit()
        {
            baseform.editingrbox.Items.Clear();
            foreach (var v in ingredientsRAW.Children)
            {
                if (v.Children == null)
                    v.Children = new List<tree>();

                foreach (var v2 in v.Children)
                {
                    if (baseform.editingrbox.Items.Contains(v2.Name) == false)
                        baseform.editingrbox.Items.Add(v2.Name);
                }
            }
            baseform.editingrbox.Sorted = true;
        }

        private static void saveFileIngredients()
        {
            ANDREICSLIB.Helpers.BTree.SaveFileIntoTree(ingredientpath, ingredientsRAW);
            updateingrlistedit();
        }

        #endregion

        #region people

        public static void editPeopleIngredient(tree person, String ingr, String option)
        {
            if (person.Children != null)
            {
                foreach (var o in person.Children) //for each option remove ingr if exists
                {
                    var i = o.GetChildByName(ingr);
                    if (i != null)
                        o.Children.Remove(i);
                }
            }

            if (person.GetChildByName(option) == null)
                person.AddChild(option);
            person.GetChildByName(option).AddChild(ingr);
            saveFilePeople();
        }

        private static void initPeopleList()
        {
            if (peopleRAW.Children == null)
                return;

            var s = baseform.peoplelist.Text;
            baseform.peoplelist.Items.Clear();
            baseform.peoplecheckbox.Items.Clear();
            var a = 0;
            foreach (var t in peopleRAW.Children)
            {
                baseform.peoplelist.Items.Add(t.Name);
                baseform.peoplecheckbox.Items.Add(t.Name);
                baseform.peoplecheckbox.SetItemChecked(a, true);
                a++;
            }

            if (baseform.peoplelist.Items.Contains(s))
                baseform.peoplelist.Text = s;

            else if (baseform.peoplelist.Items.Count > 0)
                baseform.peoplelist.Text = baseform.peoplelist.Items[0].ToString();
        }

        public static void createNewPerson()
        {
            var gsb = new GetStringBox();
            var option = gsb.ShowDialog("Enter name for new person", "question");
            if (string.IsNullOrEmpty(option))
                return;

            peopleRAW.AddChild(option);
            saveFilePeople();
            initPeopleList();
            if (baseform.peoplelist.Items.Count == 1)
                baseform.peoplelist.Text = baseform.peoplelist.Items[0].ToString();

            UpdatePeopleTastePreferences();
        }

        private static void saveFilePeople()
        {
            ANDREICSLIB.Helpers.BTree.SaveFileIntoTree(peoplepath, peopleRAW);
        }

        #endregion

        #region chart
        private static Dictionary<string, Dictionary<string, int>> getRawChartValues()
        {
            var values = new Dictionary<string, Dictionary<string, int>>(); //meal to points

            foreach (var i in mealsRAW.Children) //each meal type
            {
                if (baseform.mealchecklist.CheckedItems.Contains(i.Name) == false)
                    continue;

                foreach (var i2 in i.Children) //each meal name
                {
                    if (values.ContainsKey(i2.Name) == false)
                        values.Add(i2.Name, new Dictionary<string, int>());

                    foreach (var p in peopleRAW.Children) //each person
                    {
                        if (baseform.peoplecheckbox.CheckedItems.Contains(p.Name) == false)
                            continue;

                        values[i2.Name][p.Name] = getPersonMealValue(i2, p);
                    }
                }
            }
            return values;
        }

        private static Dictionary<string, int> normaliseChart(ref Dictionary<string, Dictionary<string, int>> chartin, int min, int max)
        {
            var fmin = 0;
            var fmax = 0;
            var minset = false;
            var maxset = false;
            var ret = new Dictionary<string, int>();

            foreach (var v in chartin)
            {
                //get total point value for all people
                var totalval = v.Value.Sum(person => person.Value);
                totalval /= peopleRAW.Children.Count;

                if (minset == false || fmin > totalval)
                {
                    minset = true;
                    fmin = totalval;
                }

                if (maxset == false || fmax < totalval)
                {
                    maxset = true;
                    fmax = totalval;
                }
                ret.Add(v.Key, totalval);
            }

            for (var a = 0; a < chartin.Count; a++)
            {
                var key = chartin.ElementAt(a).Key;
                var val = ret.ElementAt(a).Value;
                if (val > 0)
                    val = (int)((val / (float)fmax) * max);
                else if (val < 0)
                    val = (int)((val / (float)fmin) * min);

                ret[key] = val;
            }
            return ret;
        }

        private static String getToolTip(string meal)
        {
            var v = baseform.GetChart().Tag as Dictionary<string, Dictionary<string, int>>;
            var ret = meal + ":\n";
            foreach (var v2 in v) //meal to people->their scores
            {
                if (v2.Key.Equals(meal) == false)
                    continue;
                foreach (var v3 in v2.Value) //dictionary of people to their score for this meal
                {
                    ret += v3.Key + "=" + getOption(v3.Value) + "\n";
                }
            }
            return ret;
        }

        public static void setChart()
        {
            const int fmax = 100;
            const int fmin = -100;
            var values = getRawChartValues();
            var values2 = normaliseChart(ref values, fmin, fmax);

            //series init
            baseform.GetChart().Series.Clear();
            baseform.GetChart().Tag = values;
            var s = new Series();
            s.XValueType = ChartValueType.String;
            s.YValueType = ChartValueType.String;
            foreach (var kvp in values2)
            {
                s.Points.AddXY(kvp.Key, kvp.Value);
                var dpc = s.Points[s.Points.Count - 1];
                dpc.Color = ColorExtras.GetRedGreenBlendedColour(kvp.Value);
                dpc.ToolTip = getToolTip(kvp.Key);
            }

            s.YAxisType = AxisType.Primary;
            s.XAxisType = AxisType.Secondary;
            s.IsVisibleInLegend = false;
            s.AxisLabel.Insert(0, "a");
            baseform.GetChart().Series.Add(s);
            //chartarea init
            baseform.GetChart().ChartAreas.Clear();
            var ca = new ChartArea();
            ca.AxisX2.Interval = 1;
            ca.AxisY.Interval = ((Math.Abs(fmax) + Math.Abs(fmin)) / 2) / 4;
            ca.AxisY.Minimum = fmin;
            ca.AxisY.Maximum = fmax;
            s.Sort(PointSortOrder.Descending);
            baseform.GetChart().ChartAreas.Add(ca);
        }

        private static string getOption(int value)
        {
            var count = 0;
            foreach (var op in optionsRAW.Children)
            {
                if (value <= int.Parse(op.Children[0].Name) || (count == optionsRAW.Children.Count - 1))
                {
                    return op.Name;
                }
                count++;
            }
            return "";
        }
        #endregion

        #region mix
        private static void peopleRemoveIng(string ing)
        {
            var change = false;
            foreach (var v in peopleRAW.Children) //people
            {
                foreach (var v2 in v.Children) //options
                {
                    if (v2.GetChildByName(ing) != null)
                    {
                        v2.RemoveChild(ing);
                        change = true;
                    }
                }
            }

            if (change)
            {
                saveFilePeople();
                initPeopleList();
            }
        }

        private static int getPersonMealValue(tree meal, tree person)
        {
            var score = 0;
            foreach (var i3 in meal.Children) //meal ingredient
            {
                foreach (var op in person.Children) //each ingredient option type
                {
                    var val = int.Parse(optionsRAW.GetChildByName(op.Name).Children[0].Name); //option point value
                    //if the meal ingr is in this persons option, add the opion value to the mean
                    if (op.GetChildByName(i3.Name) != null)
                    {
                        score += val;
                    }
                }
            }
            return score;
        }
        #endregion
    }
}