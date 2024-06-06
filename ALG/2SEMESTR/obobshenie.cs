using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;

class Menu<T> (T x, T y)
{
    private T X { get; set; } = x;
    private T Y { get; set; } = y;

    // Мне тяжело писать выбор операции, так как сейчас час ночи,
    // поэтому просто выведу результаты всех операций 
    public void NumbersOperations()
    {
        dynamic a = x;
        dynamic b = y;

        Console.WriteLine($"Сложение: {a} + {b} = {a + b}");
        Console.WriteLine($"Вычитание: {a} - {b} = {a - b}");
        Console.WriteLine($"Умножение: {a} * {b} = {a * b}");
        if (b != 0)
        {
            Console.WriteLine($"Деление: {a} / {b} = {a / b}");
        }
        else
        {

            Console.WriteLine("Деление на ноль невозможно.");
        }
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выбери операцию:");
            Console.WriteLine("1. Работа с целыми числами");
            Console.WriteLine("2. Работа с вещественными числами");
            Console.WriteLine("3. Выход");
            int chooise = int.Parse(Console.ReadLine());

            switch (chooise)
            {
                case 1:
                    Console.Write("Введите первое число: ");
                    int v1 = int.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    int v2 = int.Parse(Console.ReadLine());
                    Menu<int> menu1 = new Menu<int>(v1, v2);
                    menu1.NumbersOperations();
                    break;
                case 2:
                    Console.Write("Введите первое число: ");
                    double v3 = double.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    double v4 = double.Parse(Console.ReadLine());
                    Menu<double> menu2 = new Menu<double>(v3, v4);
                    menu2.NumbersOperations();
                    break;
                case 3:
                    Console.WriteLine("Выполнен выход.");
                    return;

            }
        }
    }
}
