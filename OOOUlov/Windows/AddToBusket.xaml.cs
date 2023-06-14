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
    /// Логика взаимодействия для AddToBusket.xaml
    /// </summary>
    public partial class AddToBusket : Window
    {
        MainWindow MainWin;
        Products products;
        Order order;
        UlovEntity db;
        DataGrid _dg;
        public AddToBusket(Products selected, MainWindow MW, DataGrid dg)
        {
            InitializeComponent();
            db = UlovEntity.GetContext();
            MainWin = MW;
            
            products = selected;
            NameProd.DataContext = selected;
            PriceProd.DataContext = selected;
            DescProd.DataContext = selected;
            IDProd.DataContext = selected;
            _dg = dg;
            bindcombo();
            order = new Order();
            DataContext = order;
        }

        /// <summary>
        /// Логика взаимодействия для вывода значений комбо-боксов
        /// </summary>
        private void bindcombo()
        {
            StatusProd.ItemsSource = db.Status.ToList();
            PKProd.ItemsSource = db.Sklad.ToList();
        }

        /// <summary>
        /// Логика взаимодействия для добавления записей в базу данных в таблицу Busket 
        /// </summary>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            order.Name = NameProd.Text;
            order.Price = Convert.ToDecimal(PriceProd.Text);
            order.Description = DescProd.Text;
            order.IDProd = Convert.ToInt32(IDProd.Text);
            order.IDStatus = (StatusProd.SelectedItem as Status).IDStatus;
            order.IDSklad = (PKProd.SelectedItem as Sklad).IDSklad;

            db.Order.Add(order);
            db.SaveChanges();
            MessageBox.Show("Заказ добавлен в корзину");
            MainWin.BusketBtn.Visibility = Visibility.Visible;
        }
    }
}
