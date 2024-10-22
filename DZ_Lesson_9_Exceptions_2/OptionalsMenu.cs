namespace DZ_Lesson_9_Exceptions
{
    public class OptionalsMenu
    {
        private static int selectedValue = 0;
        private static int startValue = 2;
        private static string[] valueArray = new string[3];
        private static string longString = string.Empty;

        /// <summary>
        /// Опции меню
        /// </summary>
        private static string[] options = new[]
        {
            $" Введите значение a: { valueArray[0] }",
            $" Введите значение b: { valueArray[1] }",
            $" Введите значение c: { valueArray[2] }"
        };

        /// <summary>
        /// Запуск меню
        /// </summary>
        public static int[] Start()
        {
            ConsoleKeyInfo ki;
            
            selectedValue = startValue;

            Clear();
            PrintMenu();
            WriteCursor(selectedValue);

            do
            {
                ClearCursor(selectedValue);
                ki = Console.ReadKey();

                switch (ki.Key)
                {
                    case ConsoleKey.UpArrow:

                        SetValue(selectedValue);
                        SetUp();
                        Clear();
                        PrintMenu();

                        break;
                    case ConsoleKey.DownArrow:

                        SetValue(selectedValue);
                        SetDown();
                        Clear();
                        PrintMenu();

                        break;
                    case ConsoleKey.Enter:
                        SetValue(selectedValue);
                        Clear();
                        PrintMenu();

                        int[] paramsForEquation;

                        bool isCheck = ExeptionFunction.CheckInteger(new string[] {valueArray[0], valueArray[1], valueArray[2] }, out paramsForEquation);

                        if (isCheck)
                            return paramsForEquation;
                        else
                        {
                            Console.WriteLine("\r\nДля продолжения расчета нажмите любую кнопку");
                            Console.ReadKey(true);

                            Clear();
                            ClearValue();
                            PrintMenu();
                            ClearCursor(selectedValue);

                            break;
                        }
                    default:

                        GetValue(ki);

                        break;
                }

                WriteCursor(selectedValue);

            } while (ki.Key != ConsoleKey.Escape);

            return null;
        }

        /// <summary>
        /// Отображение формулы и ее переменных
        /// </summary>
        private static void PrintMenu()
        {
            string aText = string.IsNullOrEmpty(valueArray[0]) ? "a" : valueArray[0];
            string bText = string.IsNullOrEmpty(valueArray[1]) ? "b" : valueArray[1];
            string cText = string.IsNullOrEmpty(valueArray[2]) ? "c" : valueArray[2];

            Console.WriteLine("Для рассчета уравнения нажмите - Enter, для ввода следующего значения - стрелочки вверх или вниз");
            Console.WriteLine($"{ aText } * x^2 + { bText } * x + { cText } = 0");

            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i] + valueArray[i]);
            }
        }

        /// <summary>
        /// Считывание значений переменной с консоли
        /// </summary>
        /// <param name="key"></param>
        private static void GetValue(ConsoleKeyInfo key)
        {
            do
            {
                if (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Enter)
                {
                    longString += key.KeyChar;                           
                }
                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Enter);
        }

        /// <summary>
        /// Запись значения переменной в список
        /// </summary>
        /// <param name="pos"></param>
        private static void SetValue(int pos)
        {
            switch (pos)
            {
                case 2:
                    if (string.IsNullOrEmpty(valueArray[0]))
                        valueArray[0] = longString;
                    break;
                case 3:
                    if (string.IsNullOrEmpty(valueArray[1]))
                        valueArray[1] = longString;
                    break;
                case 4:
                    if (string.IsNullOrEmpty(valueArray[2]))
                        valueArray[2] = longString;
                    break;
            }

            longString = string.Empty;
        }

        /// <summary>
        /// Очищение консоли
        /// </summary>
        private static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Очищение переменных
        /// </summary>
        private static void ClearValue()
        {
            selectedValue = startValue;

            for (int i =  0; i < valueArray.Count(); i++)
            {
                valueArray[i] = "";
            }
        }

        /// <summary>
        /// На одну строку вниз
        /// </summary>
        private static void SetDown()
        {
            if (selectedValue < options.Length - 1 + startValue)
            {
                selectedValue++;
            }
            else
            {
                selectedValue = startValue;
            }
        }

        /// <summary>
        /// На одну строку вверх
        /// </summary>
        private static void SetUp()
        {
            if (selectedValue > startValue)
            {
                selectedValue--;
            }
            else
            {
                selectedValue = options.Length + startValue;
            }
        }

        /// <summary>
        /// Исходное положение стрелки меню
        /// </summary>
        private static void WriteCursor(int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(">");
            Console.SetCursorPosition(21, pos);
        }

        /// <summary>
        /// Очищение положения стрелки меню
        /// </summary>
        private static void ClearCursor(int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(" ");
            Console.SetCursorPosition(21, pos);
        }
    }
}
