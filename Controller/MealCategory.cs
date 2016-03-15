using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDREICSLIB.NewControls;

namespace Meal_Chooser.Controller
{
    public class MealCategory
    {
        public MealCategory(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public MealCategory()
        {

        }


        public SelectItemFromListBox.SelectItem ToSelectItem(bool isSelected = false)
        {
            var ret = new SelectItemFromListBox.SelectItem(Name, isSelected);
            return ret;
        }
    }
}
