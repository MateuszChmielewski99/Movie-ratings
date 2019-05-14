using Movie_recommendation.UIImages;
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
using System.Windows.Shapes;

namespace Movie_recommendation.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        private UIImageProvider provider;
        public ApplicationWindow()
        {
            provider = new UIImageProvider();
            InitializeComponent();
        }

        private void LblAllMovies_MouseEnter(object sender, MouseEventArgs e)
        {
            string hexColor = "#4C91FF";
            var lbl = sender as Label;
            provider.ContentControlColorChanger(lbl, hexColor);
        }

        private void LblAllMovies_MouseLeave(object sender, MouseEventArgs e)
        {
            string hexColor = "#FFB3C4FF";
            var lbl = sender as Label;
            provider.ContentControlColorChanger(lbl, hexColor);
        }

       
    }
}
