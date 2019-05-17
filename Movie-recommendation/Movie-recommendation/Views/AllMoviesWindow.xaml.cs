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
using System.Linq;
using System.Windows.Threading;

namespace Movie_recommendation.Views
{

    /// <summary>
    /// Logika interakcji dla klasy AllMoviesWindow.xaml
    /// </summary>
    public partial class AllMoviesWindow : Window
    {
        private LoadingWindow ld;
        private ApplicationWindow ap;
        private UIImageProvider provider;
        private UnitOfWork unit;
        private ICollection<Movie> movieToRecommed;
        private IRecommendator recommendator;
        public AllMoviesWindow()
        {
            ap = new ApplicationWindow(); 
            ld = new LoadingWindow();
            provider = new UIImageProvider();
            unit = new UnitOfWork();
            movieToRecommed = new List<Movie>();
            InitializeComponent();
            recommendator = new MovieRocommendator(unit);
        }

        private async Task AddImagesAsync()
        {

           

            #region action
            MouseButtonEventHandler action = async (object sender, MouseButtonEventArgs e) =>
           {
               
               var img = sender as Image;
              

               if (img != null)
               {
                   Movie movie = await unit.movieRepository.GetByTitle(img.Name);
                   Border b = img.Parent as Border;

                   if (!movieToRecommed.Any(m => m.ID == movie.ID))
                   {
                       movieToRecommed.Add(movie);
                       b.BorderBrush = Brushes.Gold;
                       img.MouseLeave -= provider.mouseDown;
                       img.MouseEnter -= provider.mouseOver;
                   }
                   else
                   {
                       movieToRecommed.Remove(movieToRecommed.First(s => s.ID == movie.ID));
                       b.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#FF05141B"));
                       img.MouseLeave += provider.mouseDown;
                       img.MouseEnter += provider.mouseOver;
                   }
               }

           };
            #endregion

            ICollection<Movie> movies = await unit.movieRepository.GetAsync();
            var images = provider.AddToPanel(MainPanel, movies);
            provider.AddFunctionality(images, action);

        }

        [STAThread]
        private  async void Window_Initialized(object sender, EventArgs e)
        {
            await AddImagesAsync();
        }


        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            
               ld.Show();
            
               List<Movie> mov = (await recommendator.RecommendAsync(movieToRecommed)).ToList();

               foreach (var rec in mov)
               {
                   unit.recommendedMoviesRepository.Insert(new RecommendedMovies
                   {
                       id = Guid.NewGuid().ToString(),
                       movie_id = rec.ID,
                       user_id = LoggedUser.ID
                   });
                   unit.Save();
               }

               ld.Dispatcher.Invoke(() => ld.Close(), DispatcherPriority.Normal );
               ap.Dispatcher.Invoke(() => ap.Show(), DispatcherPriority.Normal);


           
            this.Close();
        }
    }
}
