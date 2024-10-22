namespace DZ_Lesson_9_Exceptions
{
    public class NoRealValuesException : Exception
    {
        public double value;
        public NoRealValuesException(double value, double minValue) 
            : base()
        { 
            this.value = value;
        }
    }
}