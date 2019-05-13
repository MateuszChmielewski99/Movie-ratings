using Movie_recommendation.Exceptions;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sign in method, uses async method  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            Loading load = new Loading();
            AllMoviesWindow allMovies = null;
            UnitOfWork unit = null;
            LoadingWindow loadingWindow = new LoadingWindow();
            Hide();
            loadingWindow.Show();
            
            //get data
            string name = TBUserName.Text;
            string password = PBPassword.Password;
            bool result = true;

            Task t = Task.Run(async () =>
            {
                // load user 
                try
                {
                   result = await load.LoadUser(name, password);
                }
                catch (InvalidUsernameException ex)
                {
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = ex.Message);
                }
                catch (InvalidPasswordException ex)
                {
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = ex.Message);
                }
                catch (ArgumentNullException)
                {
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = "Empty field!");
                }

                loadingWindow.Dispatcher.Invoke(() => loadingWindow.Hide(), DispatcherPriority.Normal);
                if (result)
                {
                    unit = new UnitOfWork();
                    User tmp = await unit.userRepository.GetByNameAsync(name);
                    if (tmp.first_logging)
                    {
                        tmp.first_logging = false;
                        unit.context.SaveChanges();
                        this.Dispatcher.Invoke(() => Close());
                        allMovies.Dispatcher.Invoke(() => Show(), DispatcherPriority.Normal);
                    }
                }
                else
                {
                    this.Dispatcher.Invoke(() => Show(), DispatcherPriority.Normal);
                }
            }
            );
             
            
        }


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
            ContentControlColorChanger(lbl, hexColor);
        }

        private void LbRegister_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string hexColor = "#FFB3C4FF";
            var lbl = sender as Label;
            ContentControlColorChanger(lbl,hexColor);   
        }

        private void ContentControlColorChanger(ContentControl cc, string hexColor)
        {
            var bc = new BrushConverter();
            cc.Foreground = bc.ConvertFrom(hexColor) as Brush;
        }
    }
}
