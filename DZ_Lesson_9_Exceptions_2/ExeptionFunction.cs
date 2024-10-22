namespace DZ_Lesson_9_Exceptions
{
    public class ExeptionFunction
    {
        public static void FormatData(string message, Severity severity, Dictionary<string, string> dictionary = null)
        {
            switch (severity)
            {
                case Severity.Error:
                    ConsoleWriteText.ShowError(message, dictionary);
                    break;
                case Severity.Warning:
                    ConsoleWriteText.ShowWarning(message, dictionary);
                    break;
                case Severity.Information:
                    ConsoleWriteText.ShowInformation(message, dictionary);
                    break;
            }
        }

        public static bool CheckInteger(string[] value, out int[] ints)
        {
            ints = new int[value.Length];

            Dictionary<string, string> dictionaryErr = new Dictionary<string, string>();
            Dictionary<string, string> dictionaryInf = new Dictionary<string, string>();

            string messageExeptionErr = string.Empty;
            string messageExeptionInf = string.Empty;
            string[] valueLetter = new string[] { "a", "b", "c" };

            for (int i = 0; i < value.Length; i++)
            {
                try
                {
                    ints[i] = int.Parse(value[i]);
                }
                catch (OverflowException)
                {
                    dictionaryInf.Add(valueLetter[i], value[i]);
                    messageExeptionInf += $"Значениe {valueLetter[i]} = {value[i]} вышло за диапазон значений int. Введите в интервале между -2147483648 и 2147483647 \r\n";
                }
                catch (FormatException) when (value[i] == "")
                {
                    dictionaryErr.Add(valueLetter[i], "не задано");
                    messageExeptionErr += $"Значениe {valueLetter[i]} не задано \r\n";
                }
                catch
                {
                    dictionaryErr.Add(valueLetter[i], value[i]);
                    messageExeptionErr += $"Значениe {valueLetter[i]} = {value[i]} не является целым числом \r\n";
                }
            }

            if (dictionaryErr != null && dictionaryErr.Count > 0)
            {
                FormatData(messageExeptionErr, Severity.Warning, dictionaryErr);
                return false;
            }
            else if (dictionaryInf != null && dictionaryInf.Count > 0)
            {
                FormatData(messageExeptionInf, Severity.Information, dictionaryInf);
                return false;
            }
            else
                return true;
        }
    }
}
