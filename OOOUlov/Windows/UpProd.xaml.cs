﻿using System;
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
    /// Логика взаимодействия для UpProd.xaml
    /// </summary>
    public partial class UpProd : Window
    {
        MainWindow mainWindow;
        Products prod;
        UlovEntity db;
        public UpProd(Products editProd, MainWindow mw)
        {
            InitializeComponent();
            prod = editProd;
            db = UlovEntity.GetContext();
            mainWindow = mw;
            DataContext = prod;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
