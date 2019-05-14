using Movie_recommendation.UIImages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Movie_recommendation.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        private UIImageProvider provider;
        private UnitOfWork unit;
        public ApplicationWindow()
        {
            provider = new UIImageProvider();
            unit = new UnitOfWork();
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

        private async void LblAllMovies_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICollection<Movie> movies = await unit.movieRepository.GetAsync();
            if (MainWrap.Children.Count == 0)
                provider.AddToPanel(MainWrap, movies);
            else
            {
                MainWrap.Children.RemoveRange(0, MainWrap.Children.Count);
                provider.AddToPanel(MainWrap, movies);
            }
        }

        private void LblFavouriteMovies_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICollection<Movie> movies = unit.userRepository.GetUserFavouriteMovies(LoggedUser.ID);
            if (MainWrap.Children.Count == 0)
                provider.AddToPanel(MainWrap, movies);
            else
            {
                MainWrap.Children.RemoveRange(0, MainWrap.Children.Count);
                provider.AddToPanel(MainWrap, movies);
            }
        }

        private void LblRecommendedMovies_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICollection<Movie> movies = unit.userRepository.GetUserRecommendedMovies(LoggedUser.ID);
            if (MainWrap.Children.Count == 0)
                provider.AddToPanel(MainWrap, movies);
            else
            {
                MainWrap.Children.RemoveRange(0, MainWrap.Children.Count);
                provider.AddToPanel(MainWrap, movies);
            }
        }
    }
}
