namespace DZ_Lesson_9_Exceptions
{
    public class QuadraticEquation
    {
        public static void Calculate(int a, int b, int c)
        {
            double D = Math.Pow(b, 2) - 4 * a * c;

            Console.SetCursorPosition(0, 6);


            CalculateQuadratic p = new CalculateQuadratic { Di = D };
            if (p.Di == 0)
            {
                double x = (-b + Math.Sqrt(p.Di)) / (2 * a);

                Console.WriteLine($"Ответ: x = {x}");
            }
            else if (p.Di > 0)
            {
                double x1 = (-b + Math.Sqrt(p.Di)) / (2 * a);
                double x2 = (-b - Math.Sqrt(p.Di)) / (2 * a);

                Console.WriteLine($"Ответ: x1 = {x1}, x2 = {x2}");
            }

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey(true);
        }
    }
}
