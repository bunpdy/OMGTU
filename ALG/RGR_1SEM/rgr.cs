using System.Security.Cryptography;

Console.WriteLine("Игра 'Угадай число' \n\nВведите диапазон рандомного числа\nНижняя грань: ");
int niz1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("\nВерхняя грань: ");
int niz2 = Convert.ToInt32(Console.ReadLine());

Random rnd = new Random();
int value1 = rnd.Next(niz1, niz2 + 1);
int game = 1;

while (game == 1) 
{
    Console.WriteLine("Введите число: ");

    int number = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    if (number > value1)
    {
        Console.WriteLine("Введенное число больше загаданного\n");
    }
    else if (number < value1)
    {
        Console.WriteLine("Введенное число меньше загаданного\n");
    }
    else 
    {
        Console.WriteLine($"Вы отгадали, это число {number} !\nНачать новую игру? (Да/Нет)");
        string? answer = Console.ReadLine();
        if (answer == "Да" || answer == "да" || answer == "д" || answer == "Д" || answer == "1")
        {
            Console.Clear();
            Console.WriteLine("Введите диапазон рандомного числа\nНижняя грань: ");
            int niz3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВерхняя грань: ");
            int niz4 = Convert.ToInt32(Console.ReadLine());
            value1 = rnd.Next(niz3, niz4 + 1);
        }
        else 
        {
            game = 0;
        }
    }
}
