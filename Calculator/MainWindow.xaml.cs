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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string[]> previousInput = new List<string[]>();
        private string currOperation;
        private bool IsResulting = false;
        private bool IsMenuPressed = false;
        private bool IsSpecialSymbolPressed = false;
        private int numOfPrevious = 1;
        public MainWindow()
        {
            InitializeComponent();
            Main.Width = 404;
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "7";
            }
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "8";
            }
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "9";
            }
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "4";
            }
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "5";
            }
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "6";
            }
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "1";
            }
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "2";
            }
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "3";
            }
        }

        private void _00_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting && input.Text.Length != 0)
            {
                input.Text += "00"; 
            }
        }

        private void _0_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += "0"; 
            }
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            if (previousInput.Count <= 4)
            {
                string[] prevInputsValue = new string[] { input.Text, supp_input.Text };
                previousInput.Add(prevInputsValue);
                numOfPrevious = 1;
            }
            else
            {
                previousInput.RemoveAt(0);
                string[] prevInputsValue = new string[] { input.Text, supp_input.Text };
                previousInput.Add(prevInputsValue);
                numOfPrevious = 1;
            }
            string suppInputValue = "";
            string mainInputValue = "";
            Double res = 0;
            if (supp_input.Text.Length != 0 && input.Text.Length != 0)
            {
                if(currOperation == "pow")
                {
                    suppInputValue = supp_input.Text.Remove(supp_input.Text.Length - 2);
                }
                else if (currOperation == "log")
                {
                    suppInputValue = supp_input.Text.Remove(supp_input.Text.Length - 5);
                } else if(supp_input.Text.Contains("π"))
                {
                    suppInputValue = Math.PI.ToString();
                }
                else if(supp_input.Text.Contains("e"))
                {
                    suppInputValue = Math.Exp(1.0).ToString();
                } 
                else
                {
                    suppInputValue = supp_input.Text.Remove(supp_input.Text.Length - 1);
                }
                mainInputValue = input.Text;
                supp_input.Text = "";
                input.Text = "";
                switch (currOperation)
                {
                    case "+":
                        res = Double.Parse(suppInputValue) + Double.Parse(mainInputValue);
                        break;
                    case "-":
                        res = Double.Parse(suppInputValue) - Double.Parse(mainInputValue);
                        break;
                    case "×":
                        res = Double.Parse(suppInputValue) * Double.Parse(mainInputValue);
                        break;
                    case "/":
                        res = Double.Parse(suppInputValue) / Double.Parse(mainInputValue);
                        break;
                    case "pow":
                        res = Math.Pow(Double.Parse(suppInputValue), int.Parse(mainInputValue));
                        break ;
                    case "sqrt":
                        res = Math.Sqrt(Double.Parse(mainInputValue));
                        break;
                    case "log":
                        res = Math.Log(Double.Parse(mainInputValue));
                        break;
                }
                input.Text = res.ToString();
                IsResulting = true;
                IsSpecialSymbolPressed = false;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0 && input.Text.Length != 0)
            {
                supp_input.Text = input.Text;
                input.Text = "";
                supp_input.Text += "+";
                currOperation = "+";
                IsResulting = false;
            } else if (supp_input.Text.Length > 1 && !IsSpecialSymbolPressed)
            {
                supp_input.Text = supp_input.Text.Remove(supp_input.Text.Length - 1);
                supp_input.Text += "+";
                currOperation = "+";
                IsResulting = false;
            }
        }

        private void substract_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0 && input.Text.Length != 0)
            {
                supp_input.Text = input.Text;
                input.Text = "";
                supp_input.Text += "-";
                currOperation = "-";
                IsResulting = false;
            }
            else if (supp_input.Text.Length > 1 && !IsSpecialSymbolPressed)
            {
                supp_input.Text = supp_input.Text.Remove(supp_input.Text.Length - 1);
                supp_input.Text += "-";
                currOperation = "-";
                IsResulting = false;
            }
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0 && input.Text.Length != 0)
            {
                supp_input.Text = input.Text;
                input.Text = "";
                supp_input.Text += "×";
                currOperation = "×";
                IsResulting = false;
            }
            else if (supp_input.Text.Length > 1 && !IsSpecialSymbolPressed)
            {
                supp_input.Text = supp_input.Text.Remove(supp_input.Text.Length - 1);
                supp_input.Text += "×";
                currOperation = "×";
                IsResulting = false;
            }
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0 && input.Text.Length != 0)
            {
                supp_input.Text = input.Text;
                input.Text = "";
                supp_input.Text += "/";
                currOperation = "/";
                IsResulting = false;
            }
            else if (supp_input.Text.Length > 1 && !IsSpecialSymbolPressed)
            {
                supp_input.Text = supp_input.Text.Remove(supp_input.Text.Length - 1);
                supp_input.Text += "/";
                currOperation = "/";
                IsResulting = false;
            }
        }

        private void clear_one_Click(object sender, RoutedEventArgs e)
        {
            if(input.Text.Length != 0 && !IsResulting)
            {
                input.Text = input.Text.Remove(input.Text.Length - 1);
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "";
            supp_input.Text = "";
            IsResulting = false;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            IsResulting = false;
            double temp = previousInput.Count - numOfPrevious;
            if (temp >= 0 && previousInput.Count != 0)
            {
                supp_input.Text = previousInput[previousInput.Count - numOfPrevious][1];
                input.Text = previousInput[previousInput.Count - numOfPrevious][0];
                numOfPrevious++;
                if (supp_input.Text == "√" || supp_input.Text.Contains("^x") || supp_input.Text == "ln(x)")
                {
                    IsSpecialSymbolPressed = true;
                } else
                {
                    IsSpecialSymbolPressed = false;
                }
            }
        }

        private void _decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!IsResulting)
            {
                input.Text += ","; 
            }
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            if (!IsMenuPressed)
            {
                Main.Width = 505;
                input.Width = 505;
                supp_input.Width = 505;
                Pi.Visibility = Visibility.Visible;
                Exp.Visibility = Visibility.Visible;
                sqrt.Visibility = Visibility.Visible;
                pow.Visibility = Visibility.Visible;
                log_nat.Visibility = Visibility.Visible;
                more.Content = "<";
                IsMenuPressed = true;
            } else
            {
                Main.Width = 404;
                input.Width = 404;
                supp_input.Width = 404;
                Pi.Visibility = Visibility.Hidden;
                Exp.Visibility = Visibility.Hidden;
                sqrt.Visibility = Visibility.Hidden;
                pow.Visibility = Visibility.Hidden;
                log_nat.Visibility = Visibility.Hidden;
                more.Content = "☰";
                IsMenuPressed = false;
            }
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0)
            {
                supp_input.Text += "π "; 
            }
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0)
            {
                supp_input.Text += "e "; 
            }
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0)
            {
                supp_input.Text = "√";
                currOperation = "sqrt";
                IsSpecialSymbolPressed = true; 
            }
        }

        private void pow_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text.Length != 0 && supp_input.Text.Length == 0)
            {
                supp_input.Text = input.Text;
                input.Text = "";
                supp_input.Text += "^x";
                currOperation = "pow";
                IsSpecialSymbolPressed = true; 
            }
        }

        private void log_nat_Click(object sender, RoutedEventArgs e)
        {
            if (supp_input.Text.Length == 0)
            {
                supp_input.Text += "ln(x)";
                currOperation = "log";
                IsSpecialSymbolPressed = true; 
            }
        }
    }
}
