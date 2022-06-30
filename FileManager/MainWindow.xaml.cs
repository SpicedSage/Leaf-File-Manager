using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }
        //nav bar

        public void closeTab(Grid tab)
        {
            IDictionary<string, Grid> LABEL = new Dictionary<string, Grid>()
            {
                { "Files", gridFileTabLabel },
                { "Edit", gridEditTabLabel },
                { "Selection", gridSelectionTabLabel },
                { "View", gridViewTabLabel },
                { "Actions", gridActionsTabLabel },
                { "Go", gridGoTabLabel },
                { "Bookmarks", gridBookmarksTabLabel },
                { "Tools", gridToolsTabLabel },
                { "Help", gridHelpTabLabel }
            };

            string tag = tab.Tag.ToString();

            //tab values
            tab.Visibility = Visibility.Hidden;
            dropdownMaster.Tag = "None";
            Panel.SetZIndex(tab, 0);
            Panel.SetZIndex(dropdownMaster, 0);

            // set the colors of the label
            deactivateLabel(LABEL[tag]);
        }

        public void openTab(Grid tab)
        {
            IDictionary<string, Grid> LABEL = new Dictionary<string, Grid>()
            {
                { "Files", gridFileTabLabel },
                { "Edit", gridEditTabLabel },
                { "Selection", gridSelectionTabLabel },
                { "View", gridViewTabLabel },
                { "Actions", gridActionsTabLabel },
                { "Go", gridGoTabLabel },
                { "Bookmarks", gridBookmarksTabLabel },
                { "Tools", gridToolsTabLabel },
                { "Help", gridHelpTabLabel }
            };

            string tag = tab.Tag.ToString();
            Grid label = LABEL[tag];

            Point position = label.TranslatePoint(new Point(0, 0), wrapper);

            tab.Margin = new Thickness(position.X, position.Y + 20, 0, 0);
            tab.Visibility = Visibility.Visible;
            Panel.SetZIndex(tab, 200);

            dropdownMaster.Tag = tag;
            Panel.SetZIndex(dropdownMaster, 199);

            selectedLabel(label);

            focused = 1;

        }

        public void selectedLabel(Grid label)
        {
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CEF"));
            ((Border)label.Children[0]).BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9DF"));
        }

        public void activateLabel(Grid label)
        {
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EFF"));
            ((Border)label.Children[0]).BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CEF"));
        }

        public void deactivateLabel(Grid label)
        {
            label.Background = new SolidColorBrush(Colors.Transparent);
            ((Border)label.Children[0]).BorderBrush = new SolidColorBrush(Colors.Transparent);
        }


        //tab dropdown universal
        private int focused = 0;
        private void tabMouseIn(object sender, MouseEventArgs e)
        {
            focused = 1;
        }

        private void tabMouseOut(object sender, MouseEventArgs e)
        {
            focused = 0;
        }

        private void dropClick(object sender, MouseButtonEventArgs e)
        {

            IDictionary<string, Grid> TAB = new Dictionary<string, Grid>()
            {
                { "Files", gridFileTab },
                { "Edit", gridEditTab },
                { "Selection", gridSelectionTab },
                { "View", gridViewTab },
                { "Actions", gridActionsTab },
                { "Go", gridGoTab },
                { "Bookmarks", gridBookmarksTab },
                { "Tools", gridToolsTab },
                { "Help", gridHelpTab }
            };

            string open_tag = dropdownMaster.Tag.ToString();
            

            if ( open_tag != "None" )
            {
                Grid open = TAB[open_tag];

                if ( focused == 0)
                    { closeTab(open); }
            }
        }


        //tab labels universal
        private void labelClick(object sender, MouseButtonEventArgs e)
        {
            IDictionary<string, Grid> TAB = new Dictionary<string, Grid>()
            {
                { "Files", gridFileTab },
                { "Edit", gridEditTab },
                { "Selection", gridSelectionTab },
                { "View", gridViewTab },
                { "Actions", gridActionsTab },
                { "Go", gridGoTab },
                { "Bookmarks", gridBookmarksTab },
                { "Tools", gridToolsTab },
                { "Help", gridHelpTab }
            };

            Grid item = sender as Grid;
            Grid tab = TAB[item.Tag.ToString()];

            string item_tag = item.Tag.ToString();
            string open_tag = dropdownMaster.Tag.ToString();

            if (open_tag != "None" )
                { closeTab(TAB[open_tag]); }

            if (open_tag != item_tag) 
                { openTab(tab); }
            else if ( open_tag == item_tag) 
                { activateLabel(item); }
            

        }

        private void labelMouseIn(object sender, MouseEventArgs e)
        {
            // when enter one the tabs at topop screen for drop downs change color

            IDictionary<string, Grid> TAB = new Dictionary<string, Grid>()
            {
                { "Files", gridFileTab },
                { "Edit", gridEditTab },
                { "Selection", gridSelectionTab },
                { "View", gridViewTab },
                { "Actions", gridActionsTab },
                { "Go", gridGoTab },
                { "Bookmarks", gridBookmarksTab },
                { "Tools", gridToolsTab },
                { "Help", gridHelpTab }
            };

            Grid item = sender as Grid;

            string item_tag = item.Tag.ToString();
            string open_tag = dropdownMaster.Tag.ToString();

            if ( open_tag == "None" )
                { activateLabel(item); }
            else if ( open_tag != "None" )
            {
                closeTab(TAB[open_tag]);
                openTab(TAB[item_tag]);
            }
        }

        private void labelMouseOut(object sender, MouseEventArgs e)
        {
            // when you leave tab reset color
            Grid item = sender as Grid;

            if ( item.Tag.ToString() != dropdownMaster.Tag.ToString())
            { deactivateLabel(item); }

            focused = 0;
        }


        //tab drop item univeral
        private void itemMouseIn(object sender, MouseEventArgs e)
        {
            Grid item = sender as Grid;
            item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9CE"));
            ((Border)item.Children[0]).BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
        }

        private void itemMouseOut(object sender, MouseEventArgs e)
        { 
            Grid item = sender as Grid;
            item.Background = new SolidColorBrush(Colors.Transparent);
            ((Border)item.Children[0]).BorderBrush = new SolidColorBrush(Colors.Transparent);
        }



        //fffffffffffffffffffffff


    }
}
