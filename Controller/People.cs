using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDREICSLIB.NewControls;
using tree = ANDREICSLIB.Helpers.Btree<System.String>;

namespace Meal_Chooser.Controller
{
    public class People
    {
        public string Name { get; set; }

        public SelectItemFromListBox.SelectItem ToSelectItem(bool isSelected = false)
        {
            var ret = new SelectItemFromListBox.SelectItem(Name, isSelected);
            return ret;
        }
    }
    public partial class controller
    {
        public static void editPeopleIngredient(tree person, string ingr, string option)
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
            //   saveFilePeople();
        }



        //private static void initPeopleList()
        //{
        //    if (peopleRAW.Children == null)
        //        return;

        //    var s = baseform.peoplelist.Text;
        //    baseform.peoplelist.Items.Clear();
        //    baseform.peoplecheckbox.Items.Clear();
        //    var a = 0;
        //    foreach (var t in peopleRAW.Children)
        //    {
        //        baseform.peoplelist.Items.Add(t.Name);
        //        baseform.peoplecheckbox.Items.Add(t.Name);
        //        baseform.peoplecheckbox.SetItemChecked(a, true);
        //        a++;
        //    }

        //    if (baseform.peoplelist.Items.Contains(s))
        //        baseform.peoplelist.Text = s;

        //    else if (baseform.peoplelist.Items.Count > 0)
        //        baseform.peoplelist.Text = baseform.peoplelist.Items[0].ToString();
        //}

        //public static void createNewPerson()
        //{
        //    var gsb = new GetStringBox();
        //    var option = gsb.ShowDialog("Enter name for new person", "question");
        //    if (string.IsNullOrEmpty(option))
        //        return;

        //    peopleRAW.AddChild(option);
        //    saveFilePeople();
        //    initPeopleList();
        //    if (baseform.peoplelist.Items.Count == 1)
        //        baseform.peoplelist.Text = baseform.peoplelist.Items[0].ToString();

        //    UpdatePeopleTastePreferences();
        //}

        //private static void saveFilePeople()
        //{
        //    ANDREICSLIB.Helpers.BTree.SaveFileIntoTree(peoplepath, peopleRAW);
        //}

        //private static void peopleRemoveIng(string ing)
        //{
        //    var change = false;
        //    foreach (var v in peopleRAW.Children) //people
        //    {
        //        foreach (var v2 in v.Children) //options
        //        {
        //            if (v2.GetChildByName(ing) != null)
        //            {
        //                v2.RemoveChild(ing);
        //                change = true;
        //            }
        //        }
        //    }

        //    if (change)
        //    {
        //        saveFilePeople();
        //        initPeopleList();
        //    }
        //}

        //private static int getPersonMealValue(tree meal, tree person)
        //{
        //    var score = 0;
        //    foreach (var i3 in meal.Children) //meal ingredient
        //    {
        //        foreach (var op in person.Children) //each ingredient option type
        //        {
        //            var val = int.Parse(optionsRAW.GetChildByName(op.Name).Children[0].Name); //option point value
        //            //if the meal ingr is in this persons option, add the opion value to the mean
        //            if (op.GetChildByName(i3.Name) != null)
        //            {
        //                score += val;
        //            }
        //        }
        //    }
        //    return score;
        //}
    }


}
