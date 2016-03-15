using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANDREICSLIB.NewControls;

namespace Meal_Chooser.Controller
{
    public class Ingredient
    {
        public Ingredient()
        {
            Categories = new List<IngredientCategory>();
        }

        public Ingredient(string name, List<IngredientCategory> categories) : this()
        {
            Name = name;
            Categories = categories;
        }

        public string Name { get; set; }
        public List<IngredientCategory> Categories { get; set; }

        public SelectItemFromListBox.SelectItem ToSelectItem(bool isSelected = false)
        {
            var ret = new SelectItemFromListBox.SelectItem(Name, isSelected);
            return ret;
        }
    }

    public partial class controller
    {

        public static void addIngredient()
        {
            var gsb = new GetStringBox();
            var option = gsb.ShowDialog("Enter name for new ingredient", "question");
            if (string.IsNullOrEmpty(option))
                return;

            if (Data.Ingredients.Any(s => s.Name == option))
            {
                MessageBox.Show("Error, an ingredient with that name already exists");
                return;
            }

            var catSI = Data.IngredientCategories.Select(s2 => s2.ToSelectItem()).ToList();

            var catreturn = SelectItemFromListBox.ShowDialog("Select categories that include this ingredient", "question", catSI, true,
                                                       1);

            if (catreturn == null || catreturn.Count == 0)
                return;

            var cats = Data.IngredientCategories.Where(s => catreturn.Contains(s.Name)).ToList();

            Data.AddIngredient(new Ingredient(option, cats));

            UpdateFormFromData(true);
        }

        public static void editIngredient()
        {
            var ingr = baseform.editingrbox.SelectedItem.ToString();

            var cat = Data.Ingredients.FirstOrDefault(s => s.Name == ingr);
            if (cat == null)
                return;

            var ingrs = Data.IngredientCategories.Select(s => s.ToSelectItem(cat.Categories.Any(s2 => s2.Name == s.Name))).ToList();

            var catreturn =
                SelectItemFromListBox.ShowDialog(
                    "Select categories you want to have the ingredient in. remove all categories to delete ingredient all together",
                    "question", ingrs, true, 0);

            if (catreturn == null || catreturn.Any() == false)
            {
                Data.Ingredients.Remove(cat);
            }
            else
            {
                var cats = Data.IngredientCategories.Where(s => catreturn.Contains(s.Name)).ToList();
                cat.Categories = cats;
            }

            UpdateFormFromData(true);
        }
    }
}
