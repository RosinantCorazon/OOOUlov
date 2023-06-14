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
    /// Логика взаимодействия для Busket.xaml
    /// </summary>
    public partial class Busket : Window
    {
        UlovEntity db;
        Order order;
        public Busket()
        {
            InitializeComponent();
                db = UlovEntity.GetContext();
            order = new Order();
            BusketDg.ItemsSource = db.Order.ToList();
        }

        /// <summary>
        /// Логика взаимодействия для удаления записей из таблиц Order
        /// </summary>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var UserSelectedProd = BusketDg.SelectedItem as Order;
                db.Order.Remove(UserSelectedProd);
                db.SaveChanges();
                MessageBox.Show("Товар успешно удален из корзины");
                BusketDg.ItemsSource = null;
                BusketDg.Items.Clear();
                BusketDg.ItemsSource = db.Order.ToList(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
