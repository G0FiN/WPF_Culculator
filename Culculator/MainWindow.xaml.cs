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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Culculator
{
//Vodianov Serhii CT-20

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Burger_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            OptionalWindow optionalWindow = new OptionalWindow();
            optionalWindow.Show();
        }

        CulcAll CulcAll = new CulcAll();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)((Button)e.OriginalSource).Content;
            CulcAll.UpdateRender(input);
        }
    }
}
