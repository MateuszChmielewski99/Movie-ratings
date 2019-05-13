using Movie_recommendation.Exceptions;
using Movie_recommendation.UIImages;
using Movie_recommendation.Views;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Movie_recommendation
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoadingWindow loadingWindow;
        AllMoviesWindow allMovies;
        UIImageProvider provider; 
        public MainWindow()
        {
            InitializeComponent();
            loadingWindow = new LoadingWindow();
            allMovies = new AllMoviesWindow();
            provider = new UIImageProvider();
        }

        /// <summary>
        /// Sign in method, uses async method  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            Loading load = new Loading();
            UnitOfWork unit = null;
            
            Hide();
            loadingWindow.Show();


            //get data
            string name = TBUserName.Text;
            string password = PBPassword.Password;
            bool result = false;
           
            Task t = Task.Run(async () =>
            {
                // load user 
                try
                {
                   result = await load.LoadUser(name, password);
                }
                catch (InvalidUsernameException ex)
                {
                    this.Dispatcher.Invoke(() => Show());
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = ex.Message);
                }
                catch (InvalidPasswordException ex)
                {
                    this.Dispatcher.Invoke(() => Show());
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = ex.Message);
                }
                catch (ArgumentNullException)
                {
                    this.Dispatcher.Invoke(() => Show());
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = "Empty field!");
                }

                if (result)
                {
                    unit = new UnitOfWork();
                    User tmp = await unit.userRepository.GetByNameAsync(name);

                    if (tmp.first_logging)
                    {
                        tmp.first_logging = false;
                        unit.userRepository.Update(tmp);
                        allMovies.Dispatcher.Invoke(() => allMovies.Show(), DispatcherPriority.Normal);
                        this.Dispatcher.Invoke(() => Close());
                    }
                }
                else
                {
                    //this.Dispatcher.Invoke(() => Show(), DispatcherPriority.Normal);
                }
                loadingWindow.Dispatcher.Invoke(() => loadingWindow.Hide(), DispatcherPriority.Normal);
            }
            );

            
        }

        #region Register label color methods
        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Views.Register window = new Views.Register();
            this.Hide();
            window.Show();
        }

        private void LbRegister_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string hexColor = "#4C91FF";
            var lbl = sender as Label;
            provider.ContentControlColorChanger(lbl, hexColor);
        }

        private void LbRegister_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string hexColor = "#FFB3C4FF";
            var lbl = sender as Label;
            provider.ContentControlColorChanger(lbl,hexColor);   
        }

        
        #endregion
    }
}
