# Engineering Calculator WPF | Инженерный калькулятор WPF

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-512BD4?style=flat&logo=.net&logoColor=white)
![Status](https://img.shields.io/badge/Status-Complete-brightgreen)

**EN** | **RU**
-----|-----
Advanced engineering calculator built with WPF (Windows Presentation Foundation) for complex mathematical calculations including matrices and geometric computations. | Продвинутый инженерный калькулятор на WPF для сложных математических расчетов, включая работу с матрицами и геометрические вычисления.

## ✨ Features | Функциональность

### 🔢 Basic & Engineering Operations | Базовые и инженерные операции
- **Basic calculations** - addition, subtraction, multiplication, division | **Базовые вычисления** - сложение, вычитание, умножение, деление
- **Advanced functions** - trigonometric, logarithmic, power operations | **Расширенные функции** - тригонометрические, логарифмические, степенные операции
- **Matrix operations** - addition, multiplication, determinant calculation | **Операции с матрицами** - сложение, умножение, вычисление определителя
- **Geometric calculations** - complex shape computations | **Геометрические расчеты** - вычисления для сложных фигур

### 🎯 User Interface | Пользовательский интерфейс
- **Modern WPF UI** with MVVM pattern | **Современный WPF интерфейс** с паттерном MVVM
- **Responsive design** with intuitive controls | **Адаптивный дизайн** с интуитивными элементами управления
- **Real-time calculations** and error handling | **Вычисления в реальном времени** с обработкой ошибок
- **Multiple calculation modes** | **Несколько режимов вычислений**

## 🛠 Tech Stack | Технологии

- **Platform:** .NET Framework 4.8 / .NET 6+
- **UI Framework:** WPF (Windows Presentation Foundation)
- **Architecture:** MVVM (Model-View-ViewModel)
- **Language:** C#
- **Development:** Visual Studio 2022

## 📁 Project Structure | Структура проекта
Engineering-Calculator-WPF/
├── Models/ # Data models and business logic
│ ├── Calculator.cs # Main calculation logic
│ ├── Matrix.cs # Matrix operations
│ └── Geometry.cs # Geometric calculations
├── ViewModels/ # MVVM ViewModels
│ └── MainViewModel.cs # Main view logic
├── Views/ # WPF XAML views
│ └── MainWindow.xaml # Main application window
├── Resources/ # Styles and resources
├── App.xaml # Application definition
└── README.md


## 💻 Installation & Run | Установка и запуск

### Prerequisites | Требования
- **.NET Framework 4.8** or **.NET 6+**
- **Visual Studio 2022** (recommended) or VS Code with C# extensions

### Build & Run | Сборка и запуск

```bash
# Clone repository | Клонируй репозиторий
git clone https://github.com/Lordi-back/Engineering-Calculator-WPF.git

# Open solution | Открой решение
cd Engineering-Calculator-WPF
Engineering-Calculator-WPF.sln

# Build and run in Visual Studio | Собери и запусти в Visual Studio

# Navigate to build directory | Перейди в папку сборки
cd bin/Debug/

# Run executable | Запусти исполняемый файл
Engineering-Calculator-WPF.exe
🚀 Usage | Использование
Basic Calculations | Базовые вычисления
Enter numbers using numeric keypad | Вводи числа с помощью цифровой клавиатуры

Select operation (+, -, *, /) | Выбери операцию (+, -, *, /)

View result in display | Посмотри результат на дисплее

Matrix Operations | Операции с матрицами
Switch to matrix mode | Перейди в режим матриц

Define matrix dimensions | Определи размерности матриц

Enter matrix values | Введи значения матриц

Select matrix operation | Выбери операцию с матрицами

Geometric Calculations | Геометрические расчеты
Select geometric shape | Выбери геометрическую фигуру

Input required parameters | Введи необходимые параметры

Get calculated results | Получи рассчитанные результаты

🔧 Development | Разработка
Architecture | Архитектура
The application follows MVVM pattern for clean separation of concerns:

Models - contain business logic and calculations

ViewModels - handle UI logic and data binding

Views - XAML files defining user interface

Приложение использует паттерн MVVM для четкого разделения ответственности:

Models - содержат бизнес-логику и вычисления

ViewModels - управляют логикой UI и привязкой данных

Views - XAML файлы, определяющие пользовательский интерфейс

Extending Functionality | Расширение функциональности
To add new calculation types:
// Implement new calculation class | Реализуй новый класс вычислений
public class NewCalculation
{
    public double Calculate(double[] parameters)
    {
        // Your logic here | Твоя логика здесь
    }
}

📞 Contact | Контакты
GitHub: Lordi-back

Telegram: @Funny_bastard

Project Link: Engineering Calculator WPF
