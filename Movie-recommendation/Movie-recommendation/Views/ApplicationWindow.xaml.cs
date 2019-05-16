using Movie_recommendation.Repositories;
using Movie_recommendation.UIImages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;


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

        #region mouse enter and leave methods 
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

        #endregion

        /// <summary>
        /// Appends all movies to main wrap panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LblAllMovies_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ICollection<Movie> movies = await unit.movieRepository.GetAsync();
            string header = "Add to favourite";
            RoutedEventHandler hendler = Add;
            ICollection<Image> img;

            if (MainWrap.Children.Count != 0)
                MainWrap.Children.RemoveRange(0, MainWrap.Children.Count);
            
                img = provider.AddToPanel(MainWrap, movies);
                provider.AddFunctionality(img, null, provider.mouseOver, provider.mouseDown, header, hendler);


        }

        /// <summary>
        /// Appends user's favourite movies to main panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblFavouriteMovies_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICollection<Movie> movies = unit.userRepository.GetUserFavouriteMovies(LoggedUser.ID);
            ICollection<Image> images;
            string header = "Delete";
            RoutedEventHandler hendler = DeleteFromFavouriteAsync;

            if (MainWrap.Children.Count != 0)
                MainWrap.Children.RemoveRange(0, MainWrap.Children.Count);


                images = provider.AddToPanel(MainWrap, movies);
                provider.AddFunctionality(images, null, provider.mouseOver, provider.mouseDown, header, hendler);


        }

        /// <summary>
        /// Appends recomended movies to main wrap panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblRecommendedMovies_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICollection<Movie> movies = unit.userRepository.GetUserRecommendedMovies(LoggedUser.ID);
            if (MainWrap.Children.Count != 0)
                MainWrap.Children.RemoveRange(0, MainWrap.Children.Count);
                
                provider.AddToPanel(MainWrap, movies);
            
        }

        /// <summary>
        /// Adds movie to favourites 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void Add(object sender, RoutedEventArgs args)
        {
            MenuItem mi = sender as MenuItem;
            Image img = null;
            Movie movie = null;


            if (mi != null)
                 img = ((ContextMenu)mi.Parent).PlacementTarget as Image;
            
            if (img != null)
                 movie = await unit.movieRepository.GetByTitle(img.Name);

            if (movie != null)
            {
                unit.favMowieRepository.Insert(new FavouriteMovies
                {
                    id = Guid.NewGuid().ToString(),
                    user_id = LoggedUser.ID,
                    movie_id = movie.ID
                });
                unit.Save();
            }

        }

        /// <summary>
        /// Deletes image from favourites and refreshes main wrap panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ars"></param>
        private async void DeleteFromFavouriteAsync(object sender, RoutedEventArgs ars)
        {
            MenuItem mi = sender as MenuItem;
            Image img = null;
            Movie movie = null;
           

            if (mi != null)
                img = ((ContextMenu)mi.Parent).PlacementTarget as Image;

            if (img != null)
                movie = await unit.movieRepository.GetByTitle(img.Name);

            if (movie != null)
            {

                ICollection<FavouriteMovies> fvm = await unit.favMowieRepository.GetAsync(s => s.movie_id == movie.ID && s.user_id == LoggedUser.ID);
                unit.favMowieRepository.Delete(fvm.First());
                unit.Save();

                LblFavouriteMovies_MouseLeftButtonDown(img, null);
            }
        }
    }
}
