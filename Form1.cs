using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ANDREICSLIB.Licensing;
using tree = ANDREICSLIB.Helpers.Btree<System.String>;

namespace Meal_Chooser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region licensing
        private const String HelpString = "";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)

Licensed under GNU LGPL (http://www.gnu.org/)

Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";

        #endregion


        public Chart GetChart()
        {
            return comparechart;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller.baseform = this;
            controller.initFiles();
            Licensing.LicensingForm(this, menuStrip1, HelpString, OtherText);
        }
        
        public static void rb_Click(object sender, EventArgs e)
        {
            //copy changes to people structure
            var rb = ((RadioButton)sender);
            var option = rb.Text;
            var ingr = rb.Name;
            var p = rb.Tag as tree;
            controller.editPeopleIngredient(p, ingr, option);
        }

        private void ingpedientlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ingredientlistbox.SelectedIndex == -1)
                return;
            controller.initSubIngr();
        }

        private void comparebutton_Click(object sender, EventArgs e)
        {
            controller.setChart();
        }

        private void peoplelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.initSubIngr();
        }

        private void newbutton_Click(object sender, EventArgs e)
        {
            controller.createNewPerson();
        }

        private void addingrbutton_Click(object sender, EventArgs e)
        {
            controller.addIngredient();
        }

        private void deleteselectedbutton_Click(object sender, EventArgs e)
        {
            if (editingrbox.SelectedItem == null)
                return;

            controller.editIngredient();
        }

        private void Editmeal_Click(object sender, EventArgs e)
        {
            if (editmeallbox.SelectedItem == null)
                return;

            var meal = editmeallbox.SelectedItem.ToString();
            controller.editMeal(meal);
        }

        private void addmealbutton_Click(object sender, EventArgs e)
        {
            controller.addMeal();
        }

        private void comparechart_MouseMove(object sender, MouseEventArgs e)
        {
            var result = comparechart.HitTest(e.X, e.Y);
            // Set default cursor
            this.Cursor = Cursors.Default;
            // If the mouse if over a data point
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                var point = comparechart.Series[0].Points[result.PointIndex];

                // Change the appearance of the data point
                hatchChart(point, true);
            }
            else
            {
                if (comparechart.Series.Count == 0)
                    return;
                foreach (var p in comparechart.Series[0].Points)
                {
                    hatchChart(p, false);
                }
            }
        }
        private void hatchChart(DataPoint point, bool hatch)
        {
            if (hatch)
            {
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent25;
                point.BorderWidth = 2;
                Cursor = Cursors.Hand;
            }
            else
            {
                point.BackSecondaryColor = Color.Transparent;
                point.BackHatchStyle = ChartHatchStyle.None;

            }
        }

        private void Editcategories_Click(object sender, EventArgs e)
        {
            controller.EditIngredientCategory();
        }
    }
}