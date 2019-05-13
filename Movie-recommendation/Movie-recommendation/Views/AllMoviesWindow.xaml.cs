using Movie_recommendation.UIImages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Movie_recommendation.Views
{

    /// <summary>
    /// Logika interakcji dla klasy AllMoviesWindow.xaml
    /// </summary>
    public partial class AllMoviesWindow : Window
    {
        UIImageProvider provider;
        UnitOfWork unit;
        public AllMoviesWindow()
        {
            provider = new UIImageProvider();
            unit = new UnitOfWork();
            InitializeComponent();
        }

        private  void AddImagesAsync()
        {
            Task t = Task.Run( async () =>
           {
                #region action
                MouseButtonEventHandler action = (object sender, MouseButtonEventArgs e) =>
               {
                   var img = sender as Image;
                   this.Close();

               };
                #endregion

                #region mouseOver 
                MouseEventHandler mouseOver = (object sender, MouseEventArgs e) =>
               {
                   Image tmp = sender as Image;
                   if (tmp != null)
                   {
                       Border b = tmp.Parent as Border;
                       b.BorderBrush = Brushes.Aqua;
                   }
               };
                #endregion

                #region mouseLeave
                MouseEventHandler mouseDown = (object sender, MouseEventArgs e) =>
               {

                   Image tmp = sender as Image;
                   if (tmp != null)
                   {
                       Border b = tmp.Parent as Border;
                       b.BorderBrush = null;
                   }
               };
                #endregion

               ICollection<Movie> movies = await unit.movieRepository.GetAsync();
               var images = provider.AddToPanel(MainPanel, movies);
               provider.AddFunctionality(images, action, mouseOver, mouseDown);
           });
            
        }

        
        private  void Window_Initialized(object sender, EventArgs e)
        {
            AddImagesAsync();
        }

    }
}
