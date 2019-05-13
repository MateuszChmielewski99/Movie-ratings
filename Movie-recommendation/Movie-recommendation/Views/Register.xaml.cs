﻿using Movie_recommendation.Exceptions;
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
        UIImageProvider provider;
        public Register()
        {
            provider = new UIImageProvider();
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
            LoadingWindow ln = new LoadingWindow();

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
                    ln.Dispatcher.Invoke(()=> ln.Show(), DispatcherPriority.Normal);
                    Dispatcher.Invoke(() => Close(), DispatcherPriority.Normal);
                }
                catch (UserExistsException ex)
                {
                    InfoLabel.Dispatcher.Invoke(() => InfoLabel.Content = ex.Message);
                }
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
