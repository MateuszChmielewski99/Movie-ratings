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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();

            Action f = async () =>
            {
                 await register.RegisterUserAsync(new User
                {
                    id = Guid.NewGuid().ToString(),
                    name = "Ala",
                    password = "Ula",
                    first_logging = true
                });
            };

           var t = new Task(f);
            t.Start();
            
            

            /*
            using (var x = new MoviesRecDbContext())
            {
                x.Users.Add(new User
                {
                    id = Guid.NewGuid().ToString(),
                    name = LogTb.Text,
                    password = PswBox.Password,
                    first_logging = true
                });
                x.SaveChanges();
            }
            */
        }
    }
}
