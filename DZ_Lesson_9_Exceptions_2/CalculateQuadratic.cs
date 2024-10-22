namespace DZ_Lesson_9_Exceptions
{
    public class CalculateQuadratic
    {
        public double di;
        public double Di
        {
            get { return di; }
            set
            {
                if (value < 0)
                {
                    throw new NoRealValuesException(value, Di);
                }
                else
                    di = value;
            }
        }
    }
}
