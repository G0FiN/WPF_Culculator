using System;
using System.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Culculator
{
//Vodianov Serhii CT-20

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HideOptionalButtons();
        }

        private bool openedStatus = false;
        private void Burger_Button_Click(object sender, RoutedEventArgs e)
        {
            if (openedStatus)
                HideOptionalButtons();
            else
                ShowOptionalButtons();
        }

        private void ShowOptionalButtons() 
        {
            id_2.Visibility = Visibility.Visible;
            id_1.Visibility = Visibility.Visible;
            id_3.Visibility = Visibility.Visible;

            id_4.SetValue(Grid.ColumnSpanProperty, 1);
            id_5.SetValue(Grid.ColumnSpanProperty, 1);
            id_6.SetValue(Grid.ColumnSpanProperty, 1);
            id_7.SetValue(Grid.ColumnSpanProperty, 1);
            id_8.SetValue(Grid.ColumnSpanProperty, 1);
            openedStatus = true;
        }
        private void HideOptionalButtons()
        {
            id_1.Visibility = Visibility.Hidden;
            id_2.Visibility = Visibility.Hidden;
            id_3.Visibility = Visibility.Hidden;

            id_4.SetValue(Grid.ColumnSpanProperty, 2);
            id_5.SetValue(Grid.ColumnSpanProperty, 2);
            id_6.SetValue(Grid.ColumnSpanProperty, 2);
            id_7.SetValue(Grid.ColumnSpanProperty, 2);
            id_8.SetValue(Grid.ColumnSpanProperty, 2);
            openedStatus = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)((Button)e.OriginalSource).Content;
            if (input == "+" || input == "-" || input == "*" || input == "/")
            {
                Culculate();
                input = " " + input + "\n";
            }

            if (input == "=")
            {
                Culculate();
                input = "";
            }    
            
            UpdateRender(input);
        }

        private string culculationsData = "";
        private void UpdateRender(string input) {
            culculationsData += input;
            RenderCulculations();
        }

        private void RenderCulculations() {
            textPanel.Text = culculationsData;
        }

        Stack<string> results = new Stack<string>();
        private void Culculate()
        {
            char[] convert = culculationsData.ToCharArray();
            for(int i = 0; i < convert.Length; i++)
                if (convert[i] == ',')
                    convert[i] = '.';
            culculationsData = new string(convert);

            try {
                culculationsData = new DataTable().Compute(culculationsData, null).ToString();
                results.Push(culculationsData);
            }
            catch {
                culculationsData = "";
            }
            
            RenderCulculations();
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)((Button)e.OriginalSource).Content;
            if (input == "🡐")            
                if (culculationsData.Split().Length > 1)
                    culculationsData = culculationsData.Split()[0];
                else
                    culculationsData = "";

            if (input == "✖") {
                results.Clear();
                culculationsData = "";
            }
            RenderCulculations();
        }

        private void id_3_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            try {
                culculationsData = Math.Log10(double.Parse(culculationsData)).ToString();
                results.Push(culculationsData);
            }
            catch { 
                culculationsData = "";
            }
            RenderCulculations();
        }

        private void id_2_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            try {
                culculationsData = Math.Pow(double.Parse(culculationsData), 2).ToString();
                results.Push(culculationsData);
            }
            catch {
                culculationsData = "";
            }
            RenderCulculations();
        }

        private void id_1_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            try {
                culculationsData = Math.Sqrt(double.Parse(culculationsData)).ToString();
                results.Push(culculationsData);
            }
            catch {
                culculationsData = "";
            }
            RenderCulculations();
        }

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {
            try {
                culculationsData = results.Pop();
                culculationsData = results.Pop();
            }
            catch {
                culculationsData = "";
            }
            RenderCulculations();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                int num = int.Parse(e.Key.ToString()[1].ToString());
                culculationsData += num;
            }
            catch {
                Console.WriteLine("Ooops...");
            }
         
            RenderCulculations();
        }
    }
}
