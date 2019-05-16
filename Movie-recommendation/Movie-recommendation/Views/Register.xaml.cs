using Movie_recommendation.Exceptions;
using Movie_recommendation.UIImages;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Movie_recommendation.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private UIImageProvider provider;
        private LoadingWindow loadingWindow;
        private MainWindow loading;
        public Register()
        {
            provider = new UIImageProvider();
            InitializeComponent();
            loadingWindow = new LoadingWindow();
            loading = new MainWindow();
        }
        /// <summary>
        /// Async method for submit button, it checks if username and password are valid 
        /// if everything is ok, it closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
           
            Movie_recommendation.Register register = new Movie_recommendation.Register();

            // Create user to sign in
            User tmp = new User
            {
                id = Guid.NewGuid().ToString(),
                name = TBoxUserName.Text,
                password = PBoxPassword.Password,
                first_logging = true
            };

            // Check if username and password are correct 
            try
            {
                register.CheckUsernameAndPassword(tmp.name, tmp.password);
            }

            catch (InvalidUsernameException)
            {
                MessageBox.Show("User name must contains upper and lower cases and be " +
                   "at least 4 characters long", "User name Error", MessageBoxButton.OK);
                return;
            }
            catch (InvalidPasswordException)
            {
                MessageBox.Show("Password must contains upper and lower cases and be " +
                   "at least 5 characters long", "Password Error", MessageBoxButton.OK);
                return;
            }

            // register user
            Task t = Task.Run(async () => 
            {
                try
                {
                    loadingWindow.Dispatcher.Invoke(() => loadingWindow.Show(), DispatcherPriority.Normal);
                    Dispatcher.Invoke(() => Hide(), DispatcherPriority.Normal);
                    await register.SignInAsync(tmp); 
                }
                catch (UserExistsException ex)
                {
                    this.Dispatcher.Invoke(() => Show());
                    InfoLabel.Dispatcher.Invoke(() => InfoLabel.Content = ex.Message);
                }
                finally
                {
                    loadingWindow.Dispatcher.Invoke(() => loadingWindow.Hide(), DispatcherPriority.Normal);
                }

                loading.Dispatcher.Invoke(() => loading.Show());

            });
            
        }

        private void LbBack_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();

        }

        private void LbBack_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string hexColor = "#4C91FF";
            var lbl = sender as Label;
            provider.ContentControlColorChanger(lbl, hexColor);
        }

        private void LbBack_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string hexColor = "#FFB3C4FF";
            var lbl = sender as Label;
            provider.ContentControlColorChanger(lbl, hexColor);
        }
    }
}
