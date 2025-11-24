using System;
using System.Windows;
using System.Windows.Controls;

namespace Engineering_Calculator_WPF
{
    public partial class EngineeringCalculator : Page
    {
        private double currentNumber = 0;
        private double previousNumber = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;
        private bool isRadians = true; // true - радианы, false - градусы

        public EngineeringCalculator()
        {
            InitializeComponent();
        }

        // Базовые операции калькулятора
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (isNewNumber)
                {
                    Display.Text = button.Content.ToString();
                    isNewNumber = false;
                }
                else
                {
                    Display.Text += button.Content.ToString();
                }
                currentNumber = double.Parse(Display.Text);
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (!isNewNumber)
                {
                    Calculate();
                }
                previousNumber = currentNumber;
                currentOperator = button.Content.ToString();
                isNewNumber = true;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            isNewNumber = true;
        }

        private void Calculate()
        {
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = previousNumber + currentNumber;
                    break;
                case "-":
                    result = previousNumber - currentNumber;
                    break;
                case "×":
                    result = previousNumber * currentNumber;
                    break;
                case "/":
                    if (currentNumber != 0)
                        result = previousNumber / currentNumber;
                    else
                        Display.Text = "Ошибка";
                    break;
                case "mod":
                    result = previousNumber % currentNumber;
                    break;
                case "xʸ":
                    result = Math.Pow(previousNumber, currentNumber);
                    break;
            }

            Display.Text = result.ToString();
            currentNumber = result;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            currentNumber = 0;
            previousNumber = 0;
            currentOperator = "";
            isNewNumber = true;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 1 && Display.Text != "0")
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                currentNumber = double.Parse(Display.Text);
            }
            else
            {
                Display.Text = "0";
                currentNumber = 0;
                isNewNumber = true;
            }
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = -currentNumber;
            Display.Text = currentNumber.ToString();
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
                isNewNumber = false;
            }
        }

        // ТРИГОНОМЕТРИЧЕСКИЕ ФУНКЦИИ
        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            double value = currentNumber;
            if (!isRadians) value = value * Math.PI / 180; // Конвертация в радианы
            currentNumber = Math.Sin(value);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            double value = currentNumber;
            if (!isRadians) value = value * Math.PI / 180;
            currentNumber = Math.Cos(value);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            double value = currentNumber;
            if (!isRadians) value = value * Math.PI / 180;
            currentNumber = Math.Tan(value);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Asin_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber >= -1 && currentNumber <= 1)
            {
                double result = Math.Asin(currentNumber);
                if (!isRadians) result = result * 180 / Math.PI; // Конвертация в градусы
                currentNumber = result;
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        private void Acos_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber >= -1 && currentNumber <= 1)
            {
                double result = Math.Acos(currentNumber);
                if (!isRadians) result = result * 180 / Math.PI;
                currentNumber = result;
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        private void Atan_Click(object sender, RoutedEventArgs e)
        {
            double result = Math.Atan(currentNumber);
            if (!isRadians) result = result * 180 / Math.PI;
            currentNumber = result;
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        // МАТЕМАТИЧЕСКИЕ КОНСТАНТЫ
        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.PI;
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.E;
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        // СТЕПЕНИ И КОРНИ
        private void Power2_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Pow(currentNumber, 2);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            // Для операции xʸ нужны два числа
            previousNumber = currentNumber;
            currentOperator = "xʸ";
            isNewNumber = true;
            Display.Text = "0";
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber >= 0)
            {
                currentNumber = Math.Sqrt(currentNumber);
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        // ЛОГАРИФМЫ И ЭКСПОНЕНТЫ
        private void Log10_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 0)
            {
                currentNumber = Math.Log10(currentNumber);
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        private void Ln_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 0)
            {
                currentNumber = Math.Log(currentNumber);
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Exp(currentNumber);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Power10_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Pow(10, currentNumber);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Power2x_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Pow(2, currentNumber);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        // СПЕЦИАЛЬНЫЕ ФУНКЦИИ
        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber >= 0 && currentNumber == Math.Floor(currentNumber))
            {
                long result = 1;
                for (int i = 2; i <= (int)currentNumber; i++)
                {
                    result *= i;
                }
                currentNumber = result;
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        private void Reciprocal_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber != 0)
            {
                currentNumber = 1 / currentNumber;
                Display.Text = currentNumber.ToString();
                isNewNumber = true;
            }
            else
            {
                Display.Text = "Ошибка";
            }
        }

        private void Abs_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Abs(currentNumber);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Floor_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Floor(currentNumber);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Ceiling_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = Math.Ceiling(currentNumber);
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            previousNumber = currentNumber;
            currentOperator = "mod";
            isNewNumber = true;
            Display.Text = "0";
        }

        // КОНВЕРТАЦИЯ И ДОПОЛНИТЕЛЬНОЕ
        private void DegToRad_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = currentNumber * Math.PI / 180;
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void RadToDeg_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = currentNumber * 180 / Math.PI;
            Display.Text = currentNumber.ToString();
            isNewNumber = true;
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            currentNumber = rand.NextDouble() * 100; // Случайное число от 0 до 100
            Display.Text = currentNumber.ToString("F6");
            isNewNumber = true;
        }

        private void Parenthesis_Click(object sender, RoutedEventArgs e)
        {
            // Для будущей реализации сложных выражений
            if (sender is Button button)
            {
                Display.Text += button.Content.ToString();
                isNewNumber = false;
            }
        }

        // НАВИГАЦИЯ
        private void BackToCalculator_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                NavigationService.Navigate(new Calculator());
        }
    }
}