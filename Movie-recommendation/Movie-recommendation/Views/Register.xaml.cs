using Movie_recommendation.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Movie_recommendation.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Async method for submit button, it checks if username and password are valid 
        /// if everything is ok, it closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoadingWindow ln = null;
            LoadingWindow loadingWindow = null;

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
                    await register.SignInAsync(tmp);
                    Dispatcher.Invoke(() => Close(), DispatcherPriority.Normal);
                    ln = new LoadingWindow();
                    ln.Dispatcher.Invoke(()=> Show(), DispatcherPriority.Normal);
                    loadingWindow = new LoadingWindow();
                    loadingWindow.Dispatcher.Invoke(() => Show(), DispatcherPriority.Normal);
                }
                catch (UserExistsException ex)
                {
                    InfoLabel.Dispatcher.Invoke(() => InfoLabel.Content = ex.Message);
                }
            });
            
        }
    }
}
