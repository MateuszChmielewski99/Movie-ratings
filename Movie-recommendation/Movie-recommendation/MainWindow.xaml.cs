using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            Task t = Task.Run(async () => {
                string name = TBUserName.Dispatcher.Invoke(() => TBUserName.Text);
                string password = PBPassword.Dispatcher.Invoke(() => PBPassword.Password.ToString());
                string tmp = await load.LoadUser(name, password);
                LblInfo.Dispatcher.Invoke(() => LblInfo.Content = tmp);
                }
            ); 
        }

    }
}
