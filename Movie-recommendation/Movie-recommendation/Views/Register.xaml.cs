using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            Movie_recommendation.Register register = new Movie_recommendation.Register();
            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,15}$");
            Regex nameRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z]).{4,15}$");

            if (!passwordRegex.IsMatch(PBoxPassword.Password))
            {
                MessageBox.Show("Password must contains upper and lowwer cases and be " +
                    "at least 5 character long", "Password Error" ,MessageBoxButton.OK);
                return;
            }

            if (!nameRegex.IsMatch(TBoxUserName.Text))
            {
                MessageBox.Show("User name must contains upper and lowwer cases and be " +
                    "at least 4 character long", "User name Error", MessageBoxButton.OK);
                return;
            }

            Task t = Task.Run(async () => 
            {
                string response = await register.RegisterUserAsync(new User
                {
                    id = Guid.NewGuid().ToString(),
                    name = TBoxUserName.Dispatcher.Invoke(() => TBoxUserName.Text),
                    password = PBoxPassword.Dispatcher.Invoke(()=> PBoxPassword.Password),
                    first_logging = true
                });
                if (response != "ok")
                    InfoLabel.Dispatcher.Invoke(() => InfoLabel.Content = response);
                else
                    Close();
            });
        }
    }
}
