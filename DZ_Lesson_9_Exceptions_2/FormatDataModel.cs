namespace DZ_Lesson_9_Exceptions
{
    public class FormatDataModel : Exception
    {
        public string message = string.Empty;
        public Severity severity;
        public Dictionary<string, string> data;
    }
}
