using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANDREICSLIB.NewControls;

namespace Meal_Chooser.Controller
{
    public class IngredientCategory
    {
        public IngredientCategory()
        {
        }

        public IngredientCategory(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public SelectItemFromListBox.SelectItem ToSelectItem(bool isSelected = false)
        {
            var ret = new SelectItemFromListBox.SelectItem(Name, isSelected);
            return ret;
        }
    }

    public partial class controller
    {
        public static void EditIngredientCategory()
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

            var cats = Data.IngredientCategories.Select(s2 => s2.ToSelectItem()).ToList();

            if (mmb.Result.Equals(cr))
            {
                var gsb = new GetStringBox();
                var res = gsb.ShowDialog("Enter Category Name to create:", "Edit Category");
                if (string.IsNullOrWhiteSpace(res))
                    return;
                if (Data.IngredientCategories.Any(s => s.Name == res))
                {
                    MessageBox.Show("Error, a category with that name already exists");
                    return;
                }

                Data.IngredientCategories.Add(new IngredientCategory(res));
            }

            else if (mmb.Result.Equals(ren))
            {
                var res = SelectItemFromListBox.ShowDialog("Select category to rename", "Rename Category", cats, false,
                    1);
                if (res == null)
                    return;

                var rename = new GetStringBox();
                var res2 = rename.ShowDialog("Enter new category name", "Rename Category");

                if (string.IsNullOrWhiteSpace(res2))
                    return;

                if (Data.IngredientCategories.Any(s => s.Name == res2))
                {
                    MessageBox.Show("Error, a category with that name already exists");
                    return;
                }

                try
                {
                    var cat = Data.IngredientCategories.First(s => s.Name == res.First());
                    cat.Name = res2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured:" + ex);
                    return;
                }
            }

            else if (mmb.Result.Equals(del))
            {
                var res = SelectItemFromListBox.ShowDialog("Select category to delete", "Delete Category", cats, true, 1);
                if (res == null)
                    return;

                foreach (var cat in res)
                {
                    var cat1 = Data.IngredientCategories.First(s => s.Name == cat);
                    Data.RemoveIngredientCategory(cat1);
                }
            }

            UpdateFormFromData(true);
        }
    }

}
