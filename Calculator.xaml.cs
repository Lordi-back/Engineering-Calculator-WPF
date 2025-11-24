using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Engineering_Calculator_WPF
{
    public partial class Calculator : Page
    {
        private double currentNumber = 0;
        private double previousNumber = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;
        private bool isOperatorClicked = false;

        public Calculator()
        {
            InitializeComponent();
            this.Focusable = true;
            this.Focus();
        }

        // Обработчики для обычного калькулятора
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                AppendNumber(button.Content.ToString());
            }
        }

        private void AppendNumber(string number)
        {
            if (isNewNumber || Display.Text == "0")
            {
                Display.Text = number;
                isNewNumber = false;
            }
            else
            {
                Display.Text += number;
            }
            currentNumber = double.Parse(Display.Text);
            isOperatorClicked = false;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (!isOperatorClicked && !isNewNumber)
                {
                    Calculate();
                }
                previousNumber = currentNumber;
                currentOperator = button.Content.ToString();
                isNewNumber = true;
                isOperatorClicked = true;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                Calculate();
                isNewNumber = true;
            }
        }

        private void Calculate()
        {
            try
            {
                double result = 0;
                double secondNumber = currentNumber;

                switch (currentOperator)
                {
                    case "+":
                        result = previousNumber + secondNumber;
                        break;
                    case "-":
                        result = previousNumber - secondNumber;
                        break;
                    case "×":
                        result = previousNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = previousNumber / secondNumber;
                        else
                            throw new DivideByZeroException();
                        break;
                    default:
                        return; // Если оператор не выбран, выходим
                }

                Display.Text = result.ToString();
                currentNumber = result;
                previousNumber = result;
            }
            catch (DivideByZeroException)
            {
                Display.Text = "Ошибка: деление на 0";
                ClearAll();
            }
            catch (Exception)
            {
                Display.Text = "Ошибка";
                ClearAll();
            }
        }

        private void ClearAll()
        {
            currentNumber = 0;
            previousNumber = 0;
            currentOperator = "";
            isNewNumber = true;
            isOperatorClicked = false;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            ClearAll();
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
            if (Display.Text != "0")
            {
                currentNumber = -currentNumber;
                Display.Text = currentNumber.ToString();
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
                isNewNumber = false;
            }
        }


        // Обработчики для матриц
        private void MatrixCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (MatrixOperationComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string operation = selectedItem.Content.ToString();

                try
                {
                    // Получаем значения матриц
                    double[,] matrixA = new double[2, 2]
                    {
                        { double.Parse(A11.Text), double.Parse(A12.Text) },
                        { double.Parse(A21.Text), double.Parse(A22.Text) }
                    };

                    double[,] matrixB = new double[2, 2]
                    {
                        { double.Parse(B11.Text), double.Parse(B12.Text) },
                        { double.Parse(B21.Text), double.Parse(B22.Text) }
                    };

                    double[,] result = new double[2, 2];

                    switch (operation)
                    {
                        case "Сложение матриц":
                            result = AddMatrices(matrixA, matrixB);
                            break;
                        case "Умножение матриц":
                            result = MultiplyMatrices(matrixA, matrixB);
                            break;
                        case "Определитель":
                            double det = Determinant(matrixA);
                            MatrixResult.Text = $"Определитель матрицы A: {det}";
                            return;
                        case "Транспонирование":
                            result = TransposeMatrix(matrixA);
                            break;
                    }

                    MatrixResult.Text = $"Результат ({operation}):\n" +
                                       $"[{result[0, 0]}, {result[0, 1]}]\n" +
                                       $"[{result[1, 0]}, {result[1, 1]}]";
                }
                catch (Exception ex)
                {
                    MatrixResult.Text = $"Ошибка: {ex.Message}";
                }
            }
        }

        // Методы для работы с матрицами
        private double[,] AddMatrices(double[,] a, double[,] b)
        {
            double[,] result = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        private double[,] MultiplyMatrices(double[,] a, double[,] b)
        {
            double[,] result = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        private double Determinant(double[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        private double[,] TransposeMatrix(double[,] matrix)
        {
            return new double[2, 2]
            {
                { matrix[0, 0], matrix[1, 0] },
                { matrix[0, 1], matrix[1, 1] }
            };
        }

        private void GoToEngineeringCalculator_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineeringCalculator());
        }
        private void Parenthesis_Click(object sender, RoutedEventArgs e)
        {
            // Для будущей реализации сложных выражений со скобками
            if (sender is Button button)
            {
                string parenthesis = button.Content.ToString();

                if (isNewNumber || Display.Text == "0")
                {
                    Display.Text = parenthesis;
                    isNewNumber = false;
                }
                else
                {
                    Display.Text += parenthesis;
                }

                // Пока просто добавляем скобку в display, без вычислений
                // В будущем можно добавить парсинг выражений со скобками
            }
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Display.Text != "0" && !string.IsNullOrEmpty(Display.Text))
                {
                    currentNumber = double.Parse(Display.Text);
                    currentNumber = Math.Pow(currentNumber, 2);
                    Display.Text = currentNumber.ToString();
                    isNewNumber = true;
                }
            }
            catch (Exception ex)
            {
                Display.Text = "Ошибка";
                ClearAll();
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Display.Text != "0" && !string.IsNullOrEmpty(Display.Text))
                {
                    currentNumber = double.Parse(Display.Text);

                    if (currentNumber >= 0)
                    {
                        currentNumber = Math.Sqrt(currentNumber);
                        Display.Text = currentNumber.ToString();
                    }
                    else
                    {
                        Display.Text = "Ошибка: отрицательное число";
                    }
                    isNewNumber = true;
                }
            }
            catch (Exception ex)
            {
                Display.Text = "Ошибка";
                ClearAll();
            }
        }

        // Также добавь поддержку клавиш для новых функций в метод OnKeyDown:
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.Key)
            {
                // Цифры
                case Key.D0: case Key.NumPad0: AppendNumber("0"); break;
                case Key.D1: case Key.NumPad1: AppendNumber("1"); break;
                case Key.D2: case Key.NumPad2: AppendNumber("2"); break;
                case Key.D3: case Key.NumPad3: AppendNumber("3"); break;
                case Key.D4: case Key.NumPad4: AppendNumber("4"); break;
                case Key.D5: case Key.NumPad5: AppendNumber("5"); break;
                case Key.D6: case Key.NumPad6: AppendNumber("6"); break;
                case Key.D7: case Key.NumPad7: AppendNumber("7"); break;
                case Key.D8: case Key.NumPad8: AppendNumber("8"); break;
                case Key.D9: case Key.NumPad9: AppendNumber("9"); break;

                // Операции
                case Key.Add: Operator_Click(new Button() { Content = "+" }, null); break;
                case Key.Subtract: Operator_Click(new Button() { Content = "-" }, null); break;
                case Key.Multiply: Operator_Click(new Button() { Content = "×" }, null); break;
                case Key.Divide: Operator_Click(new Button() { Content = "/" }, null); break;
                case Key.Enter: Equals_Click(null, null); break;
               // case Key.Return: Equals_Click(null, null); break;

                // Управление
                case Key.Escape: Clear_Click(null, null); break;
                case Key.Back: Backspace_Click(null, null); break;
                case Key.Delete: Clear_Click(null, null); break;
                case Key.Decimal: Decimal_Click(null, null); break;
                case Key.OemPeriod: Decimal_Click(null, null); break;
                case Key.OemComma: Decimal_Click(null, null); break;
            }
        }
    }
}