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
    /// Логика взаимодействия для AddProd.xaml
    /// </summary>
    public partial class AddProd : Window
    {
        UlovEntity db;
        Products prod;
        DataGrid dg;
        public AddProd(DataGrid _dg)
        {
            InitializeComponent();
            prod = new Products();
            db = UlovEntity.GetContext();
            DataContext = prod;
            dg = _dg;
            bindcombo();
        }

        /// <summary>
        /// Логика взаимодействия для вывода данных в комбо-бокс
        /// </summary>
        private void bindcombo()
        {
            ManufactProd.ItemsSource = db.Manufactures.ToList();
        }

        /// <summary>
        /// Логика взаимодействия для добавление записей в таблицу Products
        /// </summary>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            prod.IDMan = (ManufactProd.SelectedItem as Manufactures).IDMan;
            db.Products.Add(prod);
            db.SaveChanges();
            MessageBox.Show("Данные успешно добавлены");
            dg.ItemsSource = null;
            dg.Items.Clear();
            dg.ItemsSource = db.Products.ToList();
        }
    }
}
