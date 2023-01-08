using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace task;
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
    // Start entering a new number.
    private bool _newNumber;

    // Was the enter button pressed.
    private bool _result;

    public MainWindow()
    {
        InitializeComponent();

        // Window start position.
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
        LabelDisplayOfPreviousOperations.Content = "";
    }

    // The "<" button clears the last entered character in the current number.
    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        var input = LabelInputDisplay.Content.ToString();
        if (input.Length > 1 && input != "0")
            LabelInputDisplay.Content = input.Remove(input.Length - 1);
        else
            LabelInputDisplay.Content = "0";
    }

    // Buttons "0" - "9" add the corresponding digit to the end of the current number.
    private void ButtonNumber_OnClick(object sender, RoutedEventArgs e)
    {
        // If "=" was pressed, reset all fields to default values.
        if (_result)
        {
            LabelInputDisplay.Content = "0";
            LabelDisplayOfPreviousOperations.Content = "";
            _result = false;
        }

        // If the "PREVIOUS OPERATION" field is EMPTY, the "INPUT" field is 0, the 0 key is pressed.
        if (LabelDisplayOfPreviousOperations.Content.ToString() == "" && LabelInputDisplay.Content.ToString() == "0" &&
            ((Button)sender).Content.ToString() == "0")
            return;
        // If the "PREVIOUS OPERATION" field is EMPTY, the "INPUT" field is 0, the 1-9 key is pressed.
        if (LabelDisplayOfPreviousOperations.Content.ToString() == "" && LabelInputDisplay.Content.ToString() == "0" &&
            ((Button)sender).Content.ToString() != "0")
        {
            LabelInputDisplay.Content = ((Button)sender).Content.ToString();
            return;
        }

        // If the "PREVIOUS OPERATION" field is EMPTY, the "INPUT" field is "0,", the 0-9 key is pressed.
        if (
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "0") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "1") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "2") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "3") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "4") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "5") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "6") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "7") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "8") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() == "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "9"))
        {
            // If the length of the "INPUT" field == 16, then exit.
            if (LabelInputDisplay.Content.ToString().Length > 15)
                return;
            LabelInputDisplay.Content += ((Button)sender).Content.ToString();
            return;
        }

        // If "Previous Operation" field = EMPTY, "ENTER" field = not "0," KEY 0-9 is pressed.
        if (LabelDisplayOfPreviousOperations.Content.ToString() == "")
        {
            // If the length of the "INPUT" field == 16, then exit.
            if (LabelInputDisplay.Content.ToString().Length > 15) return;

            LabelInputDisplay.Content += ((Button)sender).Content.ToString();
            return;
        }

        //////////////////////////////////////////"Previous Operation" = PRESENT////////////////////////////////////////////////////
        // If the "Previous Operation" field = PRESENT, the "INPUT" field = 0, KEY 0 was pressed.
        if (LabelDisplayOfPreviousOperations.Content.ToString() != "" && LabelInputDisplay.Content.ToString() == "0" &&
            ((Button)sender).Content.ToString() == "0")
            return;
        // If "Previous Operation" field = PRESENT, "ENTER" field = 0, KEY 1-9 is pressed.
        if (LabelDisplayOfPreviousOperations.Content.ToString() != "" && LabelInputDisplay.Content.ToString() == "0" &&
            ((Button)sender).Content.ToString() != "0")
        {
            LabelInputDisplay.Content = ((Button)sender).Content.ToString();
            return;
        }

        // If "Previous Operation" field = PRESENT, "ENTER" field = "0," KEY 0-9 is pressed.
        if (
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "0") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "1") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "2") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "3") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "4") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "5") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "6") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "7") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "8") ||
            (LabelDisplayOfPreviousOperations.Content.ToString() != "" &&
             LabelInputDisplay.Content.ToString().Contains("0,") && ((Button)sender).Content.ToString() == "9"))
        {
            // If the length of the "INPUT" field == 16, then exit.
            if (LabelInputDisplay.Content.ToString().Length > 15)
                return;
            LabelInputDisplay.Content += ((Button)sender).Content.ToString();
            return;
        }

        // If the "Previous Operation" field = PRESENT, the "INPUT" field = not "0," KEY 0-9 was pressed.
        if (LabelDisplayOfPreviousOperations.Content.ToString() != "")
        {
            // If the length of the "INPUT" field == 16, then exit.
            if (LabelInputDisplay.Content.ToString().Length > 15) return;

            if (_newNumber)
            {
                LabelInputDisplay.Content = ((Button)sender).Content.ToString();
                _newNumber = false;
                return;
            }

            LabelInputDisplay.Content += ((Button)sender).Content.ToString();
        }
    }

    // Button "." adds a decimal point to the current number.
    private void ButtonDot_OnClick(object sender, RoutedEventArgs e)
    {
        if (!LabelInputDisplay.Content.ToString().Contains(",")) LabelInputDisplay.Content += ",";
    }

    // The "/", "*", "+", "-" buttons perform the corresponding operation on the result of the previous operation and the current number.
    private void ButtonOperation_OnClick(object sender, RoutedEventArgs e)
    {
        // When you press the "/", "*", "+", "-" button, the number in the input field must be written in the previous operations field together with the value on the button.
        if (LabelDisplayOfPreviousOperations.Content.ToString() == "")
        {
            LabelDisplayOfPreviousOperations.Content = LabelInputDisplay.Content + " " + ((Button)sender).Content;
            _newNumber = true;
        }
        else
        {
            // The sign of the operation between the 1st number and the second number.
            var signOfTheOperation = LabelDisplayOfPreviousOperations.Content.ToString()
                .ElementAt(LabelDisplayOfPreviousOperations.Content.ToString().Length - 1);
            // The first number for the operation.
            var prevNumber = LabelDisplayOfPreviousOperations.Content.ToString()
                .Remove(LabelDisplayOfPreviousOperations.Content.ToString().Length - 2);
            // 2 number for operation.
            var inputNumber = LabelInputDisplay.Content.ToString();

            decimal result = 0;
            switch (signOfTheOperation)
            {
                case '+':
                    result = Math.Round(decimal.Parse(prevNumber) + decimal.Parse(inputNumber), 15);
                    break;
                case '-':
                    result = Math.Round(decimal.Parse(prevNumber) - decimal.Parse(inputNumber), 15);
                    break;
                case '*':
                    result = Math.Round(decimal.Parse(prevNumber) * decimal.Parse(inputNumber), 15);
                    break;
                case '/':
                    result = Math.Round(decimal.Parse(prevNumber) / decimal.Parse(inputNumber), 15);
                    break;
                default:
                    return;
            }

            LabelDisplayOfPreviousOperations.Content = result + " " + ((Button)sender).Content;
            LabelInputDisplay.Content = result;

            _newNumber = true;
        }
    }

    // The "=" button evaluates the expression and displays the result.
    private void ButtonEqual_OnClick(object sender, RoutedEventArgs e)
    {
        if (LabelDisplayOfPreviousOperations.Content.ToString()
                .ElementAt(LabelDisplayOfPreviousOperations.Content.ToString().Length - 1) == '=')
            return;
        // The sign of the operation between the 1st number and the second number.
        var signOfTheOperation = LabelDisplayOfPreviousOperations.Content.ToString()
            .ElementAt(LabelDisplayOfPreviousOperations.Content.ToString().Length - 1);
        // The first number for the operation.
        var prevNumber = LabelDisplayOfPreviousOperations.Content.ToString()
            .Remove(LabelDisplayOfPreviousOperations.Content.ToString().Length - 2);
        // 2 number for operation.
        var inputNumber = LabelInputDisplay.Content.ToString();

        decimal result = 0;
        switch (signOfTheOperation)
        {
            case '+':
                result = Math.Round(decimal.Parse(prevNumber) + decimal.Parse(inputNumber), 15);
                break;
            case '-':
                result = Math.Round(decimal.Parse(prevNumber) - decimal.Parse(inputNumber), 15);
                break;
            case '*':
                result = Math.Round(decimal.Parse(prevNumber) * decimal.Parse(inputNumber), 15);
                break;
            case '/':
                result = Math.Round(decimal.Parse(prevNumber) / decimal.Parse(inputNumber), 15);
                break;
        }

        LabelDisplayOfPreviousOperations.Content = result + " " + ((Button)sender).Content;
        LabelInputDisplay.Content = result;

        _newNumber = true;
    }
}