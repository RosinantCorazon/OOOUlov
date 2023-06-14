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
using System.Windows.Shapes;

namespace OOOUlov.Windows
{
    /// <summary>
    /// Логика взаимодействия для AutoWindow.xaml
    /// </summary>
    public partial class AutoWindow : Window
    {
        UlovEntity db;
        Users user;
        public AutoWindow()
        {
            InitializeComponent();
            user = new Users();
            db = UlovEntity.GetContext();
            DataContext = user;
        }

        private void LogUserBtn_Click(object sender, RoutedEventArgs e)
        {
            var users = db.Users.ToList();
            foreach (var usFound in users)
                if (usFound.Login == Login.Text && usFound.Password == Password.Text)
                {
                    MainWindow w1 = new MainWindow(usFound);
                    w1.Show();
                    this.Close();
                }


        }

        private void LogGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = new MainWindow(user);
            w1.Show();
            this.Close();
        }
    }
}
