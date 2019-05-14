using Movie_recommendation.MovieRecommendator;
using Movie_recommendation.Repositories;
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
        ICollection<Movie> movieToRecommed;
        IRecommendator recommendator;
        public AllMoviesWindow()
        {
            provider = new UIImageProvider();
            unit = new UnitOfWork();
            movieToRecommed = new List<Movie>();
            InitializeComponent();
            recommendator = new MovieRocommendator(unit);
        }

        private async Task AddImagesAsync()
        {

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

            #region action
            MouseButtonEventHandler action = async (object sender, MouseButtonEventArgs e) =>
           {
               var img = sender as Image;
               if (img != null)
               {
                   Movie movie = await unit.movieRepository.GetByTitle(img.Name);
                   movieToRecommed.Add(movie);
                   Border b = img.Parent as Border;
                   b.BorderBrush = Brushes.Gold;
                   img.MouseLeave -= mouseDown;
                   img.MouseEnter -= mouseOver;
               }

           };
            #endregion

           

            

            ICollection<Movie> movies = await unit.movieRepository.GetAsync();
            var images = provider.AddToPanel(MainPanel, movies);
            provider.AddFunctionality(images, action, mouseOver, mouseDown);


        }

        [STAThread]
        private  async void Window_Initialized(object sender, EventArgs e)
        {
            await AddImagesAsync();
        }

    }
}
