using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANDREICSLIB.NewControls;

namespace Meal_Chooser.Controller
{
    public class Meal
    {
        public string Name { get; set; }
        public List<MealCategory> Categories { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Meal()
        {
            Categories = new List<MealCategory>();
        }

        public Meal(string name, string category, List<Ingredient> ingredients = null) : this()
        {
            Name = name;

            Categories.Add(new MealCategory(category));
            if (ingredients == null)
                ingredients = new List<Ingredient>();
            Ingredients = ingredients;
        }

        public SelectItemFromListBox.SelectItem ToSelectItem(bool isSelected = false)
        {
            var ret = new SelectItemFromListBox.SelectItem(Name, isSelected);
            return ret;
        }
    }

    public partial class controller
    {
        public static void addMeal()
        {
            var gsb = new GetStringBox();
            var mealname = gsb.ShowDialog("Enter name for new meal", "question");
            if (string.IsNullOrEmpty(mealname))
                return;

            var catreturn = SelectItemFromListBox.ShowDialog("Select category of this meal", "question", Data.MealCategories.Select(s => s.ToSelectItem()).ToList(), false, 1);

            if (catreturn == null || catreturn.Count == 0)
                return;
            var category = catreturn[0];

            if (Data.Meals.Any(s => s.Name == mealname))
            {
                MessageBox.Show("Error, meal with this name already exists in the category");
                return;
            }

            var ingredientKeys = SelectItemFromListBox.ShowDialog("Select ingredients in this meal", "question",
                Data.Ingredients.Select(s => s.ToSelectItem()).ToList(), true, 1);

            if (ingredientKeys == null || ingredientKeys.Count == 0)
            {
                Data.AddMeal(new Meal(mealname, category));
                return;
            }

            var ingredients = Data.GetIngredientsByKeys(ingredientKeys);
            Data.AddMeal(new Meal(mealname, category, ingredients));
            UpdateFormFromData(true);
        }

        public static void editMeal(string mealstr)
        {
            var meal = Data.Meals.First(s => s.Name == mealstr);

            var ingrIN = Data.Ingredients.Select(s => s.ToSelectItem(meal.Ingredients.Any(s2 => s2 == s))).ToList();

            var ingredientKeys = SelectItemFromListBox.ShowDialog(
                "Select ingredients you want to have in the meal. remove all ingredients to delete meal all together", "question",
                ingrIN, true, 0);

            if (ingredientKeys == null)
                return;

            if (ingredientKeys.Count == 0)
            {
                Data.RemoveMeal(meal);
            }
            else
            {
                var ingredients = Data.GetIngredientsByKeys(ingredientKeys);
                meal.Ingredients = ingredients;
            }

            UpdateFormFromData(true);
        }
    }
}
