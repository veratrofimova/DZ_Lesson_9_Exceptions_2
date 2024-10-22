namespace DZ_Lesson_9_Exceptions
{
    public static class ConsoleWriteText
    {
        public static void ShowError(string message, Dictionary<string, string> dictionary)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;

            PrintData(message, dictionary);
            ReturnColor();
        }

        public static void ShowWarning(string message, Dictionary<string, string> dictionary)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;

            PrintData(message, dictionary);
            ReturnColor();
        }

        public static void ShowInformation(string message, Dictionary<string, string> dictionary)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;

            PrintData(message, dictionary);
            ReturnColor();
        }

        private static void ReturnColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void PrintData(string message, Dictionary<string, string> dictionary)
        {
            Console.WriteLine("\r\n" + new string('-', 50) + "\r\n" + message);

            if (dictionary != null)
            {
                foreach (var dict in dictionary)
                {
                    Console.WriteLine($"{dict.Key }: {dict.Value}");
                }
            }
        }
    }
}
