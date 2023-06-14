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


namespace OOOUlov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Products prod;
        UlovEntity db;
        Users us;
        public MainWindow(Users user)
        {
            InitializeComponent();
            db = UlovEntity.GetContext();
            prod = new Products();
            DataContext = prod;
            var list = db.Products.ToList();
            ProdDg.ItemsSource = db.Products.ToList();
            us = user;
            if (user.Role == "Администратор")
            {
                DelBtn.Visibility = Visibility.Visible;
                AddBtn.Visibility = Visibility.Visible;
                UpBtn.Visibility = Visibility.Visible;
            }
           
        }

        /// <summary>
        /// Логика взаимодействия для поиска в таблице
        /// </summary>
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { 
            var search = SearchBox.Text;
            var list = db.Products.ToList();
            List<Products> result = new List<Products>();
            foreach (var research in list)
                if (research.Name.ToLower().IndexOf(search.ToLower()) != -1)
                    result.Add(research);
            if (result.Count == 0)
            {
                MessageBox.Show("Искомый элемент не найден");
                ProdDg.Items.Clear();
                
                return;
            }
            
            ProdDg.ItemsSource = null;
            ProdDg.Items.Clear();
                ProdDg.ItemsSource = result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Логика взаимодействия для открытие окна добавление заказа
        /// </summary>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selected = ProdDg.SelectedItem as Products;
            Windows.AddToBusket b1 = new Windows.AddToBusket(selected, this, ProdDg);
            b1.Show();
        }

        /// <summary>
        /// Логика взаимодействия для открытия окна корзины
        /// </summary>
        private void BusketBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.Busket busket = new Windows.Busket();
            busket.Show();
        }

        /// <summary>
        /// Логика взаимодействия для удаление записей в таблице Products
        /// </summary>

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var UserSelectedProd = ProdDg.SelectedItem as Products;
                db.Products.Remove(UserSelectedProd);
                db.SaveChanges();
                MessageBox.Show("Товар успешно удален");
                ProdDg.ItemsSource = null;
                ProdDg.Items.Clear();
                ProdDg.ItemsSource = db.Products.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Логика взаимодействия для обновления записей в таблице Products
        /// </summary>
        private void UpBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.UpProd busket = new Windows.UpProd();
            busket.Show();
        }

        /// <summary>
        /// Логика взаимодействия для добавления записей в таблицу Products
        /// </summary>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddProd busket = new Windows.AddProd(ProdDg);
            busket.Show();
        }
    }
}
