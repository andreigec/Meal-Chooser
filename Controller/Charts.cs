using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Chooser.Controller
{
    public partial class controller
    {
        //private static Dictionary<string, Dictionary<string, int>> getRawChartValues()
        //{
        //    var values = new Dictionary<string, Dictionary<string, int>>(); //meal to points

        //    foreach (var i in mealsRAW.Children) //each meal type
        //    {
        //        if (baseform.mealchecklist.CheckedItems.Contains(i.Name) == false)
        //            continue;

        //        foreach (var i2 in i.Children) //each meal name
        //        {
        //            if (values.ContainsKey(i2.Name) == false)
        //                values.Add(i2.Name, new Dictionary<string, int>());

        //            foreach (var p in peopleRAW.Children) //each person
        //            {
        //                if (baseform.peoplecheckbox.CheckedItems.Contains(p.Name) == false)
        //                    continue;

        //                values[i2.Name][p.Name] = getPersonMealValue(i2, p);
        //            }
        //        }
        //    }
        //    return values;
        //}

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
                totalval /= Data.People.Count;

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

        //private static String getToolTip(string meal)
        //{
        //    var v = baseform.GetChart().Tag as Dictionary<string, Dictionary<string, int>>;
        //    var ret = meal + ":\n";
        //    foreach (var v2 in v) //meal to people->their scores
        //    {
        //        if (v2.Key.Equals(meal) == false)
        //            continue;
        //        foreach (var v3 in v2.Value) //dictionary of people to their score for this meal
        //        {
        //            ret += v3.Key + "=" + getOption(v3.Value) + "\n";
        //        }
        //    }
        //    return ret;
        //}

        //public static void setChart()
        //{
        //    const int fmax = 100;
        //    const int fmin = -100;
        //    var values = null;// getRawChartValues();
        //    var values2 = normaliseChart(ref values, fmin, fmax);

        //    //series init
        //    baseform.GetChart().Series.Clear();
        //    baseform.GetChart().Tag = values;
        //    var s = new Series();
        //    s.XValueType = ChartValueType.String;
        //    s.YValueType = ChartValueType.String;
        //    foreach (var kvp in values2)
        //    {
        //        s.Points.AddXY(kvp.Key, kvp.Value);
        //        var dpc = s.Points[s.Points.Count - 1];
        //        dpc.Color = ColorExtras.GetRedGreenBlendedColour(kvp.Value);
        //        dpc.ToolTip = getToolTip(kvp.Key);
        //    }

        //    s.YAxisType = AxisType.Primary;
        //    s.XAxisType = AxisType.Secondary;
        //    s.IsVisibleInLegend = false;
        //    s.AxisLabel.Insert(0, "a");
        //    baseform.GetChart().Series.Add(s);
        //    //chartarea init
        //    baseform.GetChart().ChartAreas.Clear();
        //    var ca = new ChartArea();
        //    ca.AxisX2.Interval = 1;
        //    ca.AxisY.Interval = ((Math.Abs(fmax) + Math.Abs(fmin)) / 2) / 4;
        //    ca.AxisY.Minimum = fmin;
        //    ca.AxisY.Maximum = fmax;
        //    s.Sort(PointSortOrder.Descending);
        //    baseform.GetChart().ChartAreas.Add(ca);
        //}

        //private static string getOption(int value)
        //{
        //    var count = 0;
        //    foreach (var op in optionsRAW.Children)
        //    {
        //        if (value <= int.Parse(op.Children[0].Name) || (count == optionsRAW.Children.Count - 1))
        //        {
        //            return op.Name;
        //        }
        //        count++;
        //    }
        //    return "";
        //}
    }
}
