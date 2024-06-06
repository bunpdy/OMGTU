using System;

interface IMathOperations
{
    double Add(double x, double y);
    double Subtract(double x, double y);
    double Multiply(double x, double y);
    double Divide(double x, double y);
    double SquareRoot(double x);
    double Sin(double x);
    double Cos(double x);
}

class MathOperations : IMathOperations
{
    public double Add(double x, double y) => x + y;
    public double Subtract(double x, double y) => x - y;
    public double Multiply(double x, double y) => x * y;
    public double Divide(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException("Делить на ноль нельзя!");
        return x / y;
    }
    public double SquareRoot(double x)
    {
        if (x < 0)
            throw new ArgumentException("Корень из отрицательного числа!");
        return Math.Sqrt(x);
    }
    public double Sin(double x) => Math.Sin(x);
    public double Cos(double x) => Math.Cos(x);
}

class Program
{
    static void Main()
    {
        IMathOperations mathOperations = new MathOperations();

        while (true)
        {
            Console.WriteLine("Выбери операцию:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Квадратный корень");
            Console.WriteLine("6. Синус");
            Console.WriteLine("7. Косинус");
            Console.WriteLine("8. Выход");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8)
            {
                Console.WriteLine("Неверный выбор! Попробуйте снова");
                continue;
            }

            if (choice == 8)
            {
                Console.WriteLine("Выполнен выход");
                break;
            }

            try
            {
                double result = 0;
                double x, y;
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите первое число: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        y = double.Parse(Console.ReadLine());
                        result = mathOperations.Add(x, y); 
                        break;
                    case 2:
                        Console.Write("Введите первое число: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        y = double.Parse(Console.ReadLine());
                        result = mathOperations.Subtract(x, y); 
                        break;
                    case 3:
                        Console.Write("Введите первое число: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        y = double.Parse(Console.ReadLine());
                        result = mathOperations.Multiply(x, y); 
                        break;
                    case 4:
                        Console.Write("Введите первое число: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        y = double.Parse(Console.ReadLine());
                        result = mathOperations.Divide(x, y); 
                        break;
                    case 5:
                        Console.Write("Введите число: ");
                        x = double.Parse(Console.ReadLine());
                        result = mathOperations.SquareRoot(x); 
                        break;
                    case 6:
                        Console.Write("Введите число: ");
                        x = double.Parse(Console.ReadLine());
                        result = mathOperations.Sin(x); 
                        break;
                    case 7:
                        Console.Write("Введите число: ");
                        x = double.Parse(Console.ReadLine());
                        result = mathOperations.Cos(x); 
                        break;
                }
                Console.WriteLine($"Результат: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число слишком маленбкое/большое");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
            }
        }
    }
}
