using Movie_recommendation.Exceptions;
using System;
using System.Threading.Tasks;
using System.Windows;


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

            //get data
            string name = TBUserName.Text;
            string password = PBPassword.Password;


            Task t = Task.Run(async () =>
            {
                // load user 
                try
                {
                    await load.LoadUser(name, password);
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
                    LblInfo.Dispatcher.Invoke(() => LblInfo.Content = "Empty field!" +
                    "");
                }
            }
            );
        }

        /// <summary>
        /// Sign up method, it opens registration window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Views.Register window = new Views.Register();
            window.Show();
        }
    }
}
