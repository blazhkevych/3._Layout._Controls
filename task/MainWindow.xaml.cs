using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task
{
    // Элементы управления 22:13

    // Тема «Элементы управления»
    // Разработать WPF-приложение «Калькулятор».
    // 
    // В верхней части приложения необходимо использовать два поля для ввода текста.
    // Первое используется для отображения предыдущих операций, а второе – для ввода текущего числа.
    // Оба поля должны запрещать редактировать свое содержимое посредством клавиатурного ввода.
    // Данные поля будут заполняться автоматически при нажатии на соответствующие кнопки, расположенные ниже.
    // 
    // Кнопки «0» – «9» добавляют соответствующую цифру в конец текущего числа.
    // При этом должны выполняться проверки, не допускающие неправильного ввода.
    // Например, нельзя вводить числа, начинающиеся с ноля, после которого нет десятичной точки.
    // 
    // Кнопка «.» добавляет десятичную точку в текущее число.
    // Кнопки «/», «*», «+», «-» выполняют соответствующую операцию над результатом предыдущей операции и текущим числом.
    // Кнопка «=» вычисляет выражение и выводит результат.
    // Кнопка «CE» очищает текущее число.
    // Кнопка «C» очищает текущее число и предыдущее выражение.
    // Кнопка «<» очищает последний введенный символ в текущем числе.
    // 
    // Topic "Controls"
    // Develop a WPF calculator application.
    // 
    // At the top of the application, you need to use two fields to enter text.
    // The first is used to display previous operations, and the second is used to enter the current number.
    // Both fields must prohibit editing their content via keyboard input.
    // These fields will be filled in automatically when you click on the appropriate buttons below.
    // 
    // Buttons "0" - "9" add the corresponding digit to the end of the current number.
    // In this case, checks must be performed that do not allow incorrect input.
    // For example, you cannot enter numbers that start with a zero followed by a decimal point.
    // 
    // Button "." adds a decimal point to the current number.
    // The "/", "*", "+", "-" buttons perform the corresponding operation on the result of the previous operation and the current number.
    // The "=" button evaluates the expression and displays the result.
    // The CE button clears the current number.
    // The "C" button clears the current number and the previous expression.
    // The "<" button clears the last entered character in the current number.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // The CE button clears the current number.
        private void ButtonCe_Click(object sender, RoutedEventArgs e)
        {
            LabelInputDisplay.Content = "0";
        }

        // The "C" button clears the current number and the previous expression.
        private void ButtonC_OnClick(object sender, RoutedEventArgs e)
        {
            LabelInputDisplay.Content = "0";
            LabelDisplayOfPreviousOperations.Content = "0";
        }

        // The "<" button clears the last entered character in the current number.
        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
