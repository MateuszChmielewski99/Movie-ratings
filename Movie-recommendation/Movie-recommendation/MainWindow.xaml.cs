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
        /// Example of register button on click function 
        /// register user async 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Task t = Task.Run(async () => await new Register().RegisterUserAsync(new User
            {
                id = Guid.NewGuid().ToString(),
                name = "Kala",
                password = "MaKota",
                first_logging = true
            }));
            
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            Loading load = new Loading();
            Task t = Task.Run(async () =>
            {
                string name = TBUserName.Dispatcher.Invoke(() => TBUserName.Text);
                string password = PBPassword.Dispatcher.Invoke(() => PBPassword.Password.ToString());
                string tmp = await load.LoadUser(name, password);
                LblInfo.Dispatcher.Invoke(() => LblInfo.Content = tmp);
            }
            );
        }

    }
}
