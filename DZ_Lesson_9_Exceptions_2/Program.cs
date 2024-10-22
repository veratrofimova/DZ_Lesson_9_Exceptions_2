using DZ_Lesson_9_Exceptions;

Console.WriteLine("Добро пожаловать в программу решения квадратного уравнения с обработкой ошибок");
Console.WriteLine("Квадратное уравнение: a * x^2 + b * x + c = 0, \r\nв котором x — неизвестное, а коэффициенты a, b и c — целые числа");
Console.WriteLine("Для старта нажмите любую клавишу...");
Console.ReadKey(true);

try
{
    int[] paramsForEquation = OptionalsMenu.Start();
    QuadraticEquation.Calculate(paramsForEquation[0], paramsForEquation[1], paramsForEquation[2]);
}
catch (NoRealValuesException ex)
{
    ExeptionFunction.FormatData("Вещественных значений не найдено", Severity.Warning);
}
catch (Exception ex)
{
    throw;
}