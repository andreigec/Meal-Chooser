using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDREICSLIB.Helpers;

namespace Meal_Chooser.Controller
{
    public class Data
    {
        public static LocalJSONCache jc = new LocalJSONCache("cache.cache");

        public Data()
        {
            IngredientCategories = new List<IngredientCategory>();
            MealCategories = new List<MealCategory>();
            Ingredients = new List<Ingredient>();
            People = new List<People>();
            Meals = new List<Meal>();
        }

        public List<IngredientCategory> IngredientCategories { get; }

        public List<MealCategory> MealCategories { get; }

        public List<Ingredient> Ingredients { get; }
        public List<People> People { get; }
        public List<Meal> Meals { get; }

        public async Task Save()
        {
            await jc.Set("Data", this);
        }

        public static async Task<Data> Get()
        {
            var ret = await jc.Get<Data>("Data");
            if (ret == null)
            {
                ret = new Data();
                await ret.Save();
            }
            return ret;
        }

        public void AddMeal(Meal m)
        {
            Meals.Add(m);
        }

        public void RemoveMeal(Meal m)
        {
            Meals.Remove(m);
        }

        public void AddIngredient(Ingredient i)
        {
            Ingredients.Add(i);
        }

        public List<Ingredient> GetIngredientsByKeys(List<string> keys)
        {
            var ingredients = Ingredients.Where(s => keys.Contains(s.Name)).ToList();
            return ingredients;
        }

        public void RemoveIngredientCategory(IngredientCategory ic)
        {
            foreach (var i in Ingredients)
            {
                i.Categories.RemoveAll(s => s.Name == ic.Name);
            }
            IngredientCategories.RemoveAll(s => s.Name == ic.Name);
        }
    }
}
