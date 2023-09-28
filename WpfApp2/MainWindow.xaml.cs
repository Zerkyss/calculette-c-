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

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double num1 = 0;
        private double num2 = 0;
        private double result;
        private const double Pi = 3.1416;
        private char operation = '0';

        public MainWindow()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            // Associer les gestionnaires d'événements aux boutons numériques
            for (int i = 0; i <= 9; i++)
            {
                Button button = FindName($"BTN_{i}") as Button;
                button.Click += (sender, e) => Show(i, button);
            }

            // Boutons d'opération
            char[] operators = { '+', '-', '*', '/', '^', '%' };
            foreach (char op in operators)
            {
                Button button = FindName($"BTN_{op}") as Button;
                button.Click += (sender, e) => SaveOperation(op);
            }

            // Boutons spéciaux
            BTN_Pi.Click += (sender, e) => Show(Pi, null);
            BTN_Clear.Click += (sender, e) => Clear();
            BTN_Equal.Click += (sender, e) => PerformCalculation();
            BTN_Sqrt.Click += (sender, e) => CalculateSqrt();
        }

        public void AppendText(string text)
        {
            TB_Display.Text += text;
        }

        public void ClearText()
        {
            TB_Display.Text = "";
        }

        public void Show(double number, Button button)
        {
            if (TB_Display.Text == "0" || TB_Display.Text == "ERROR")
            {
                TB_Display.Text = button != null ? button.Content.ToString() : number.ToString();
            }
            else
            {
                AppendText(button != null ? button.Content.ToString() : number.ToString());
            }
        }

        public void SaveOperation(char x)
        {
            if (TB_Display.Text == "ERROR" || string.IsNullOrEmpty(TB_Display.Text) && operation == '0')
            {
                return;
            }

            if (operation == '0')
            {
                num1 = double.Parse(TB_Display.Text);
                ClearText();
                operation = x;
            }
            else if (operation != '0' && string.IsNullOrEmpty(TB_Display.Text))
            {
                operation = x;
            }
            else
            {
                PerformCalculation();
                operation = x;
            }
        }

        public void PerformCalculation()
        {
            if (TB_Display.Text == "ERROR" || num1 == 0)
            {
                return;
            }

            num2 = double.Parse(TB_Display.Text);
            ClearText();

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Clear();
                        TB_Display.Text = "ERROR";
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                case '^':
                    result = Math.Pow(num1, num2);
                    break;
                case '%':
                    result = num1 % num2;
                    break;
            }

            operation = '0';
            TB_Display.Text = result.ToString();
        }

        public void Clear()
        {
            ClearText();
            num1 = 0;
            num2 = 0;
            operation = '0';
        }

        public void CalculateSqrt()
        {
            if (!string.IsNullOrEmpty(TB_Display.Text))
            {
                TB_Display.Text = Math.Sqrt(double.Parse(TB_Display.Text)).ToString();
                num1 = double.Parse(TB_Display.Text);
            }
        }

        private void BTN_Divise_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Sqrt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Divise_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Percentage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Pi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Plus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Moins_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Multiplié_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Equal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Divisé_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Puissance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}