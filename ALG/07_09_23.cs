using System.Runtime.CompilerServices;

static int MaxNumber(int a, int b)
{
    Console.WriteLine($"значение 1: {a} \nЗначение 2: {b} \nРезультат: ");
    return (a + b + Math.Abs(a - b)) / 2;
}

Console.WriteLine("Введите первое число: ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите второе число: ");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(MaxNumber(num1, num2));

Console.ReadKey();
