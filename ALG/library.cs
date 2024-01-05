using System;

Library[] books =
[
    new Library("Сидоров", "Весна", 1968, [1, 2, 3]),
    new Library("Петров", "Осень", 1955, [6, 7, 12]),
    new Library("Бодров", "Зима", 1977, [5, 9]),
    new Library("Сидоров", "Лето", 1962, [3]),
    new Library("Петров", "Ночь", 1964, [4]),
    new Library("Петров", "День", 1989, [11, 8]),
    new Library("Соколов", "Утро", 1966, [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]),
];

for (int j = 0; j < books.Length; j++) 
{
    books[j].GetData();
}

Console.WriteLine("******************************************");

Console.WriteLine("Введите год: ");

int inptyear = Convert.ToInt32(Console.ReadLine());

for (int x = 0; x < books.Length; x++)
{   
    books[x].YearBiggerInput(inptyear);
}

Console.WriteLine("******************************************");

Console.WriteLine("Введите имя автора: ");

string? inptauthor = Console.ReadLine();

for (int y = 0; y < books.Length; y++)
{
    books[y].InputAuthor(inptauthor);
}

Console.WriteLine("******************************************");

Console.ReadKey();


class Library
{
    private string Author;
    private string Bookname;
    private int Year;
    private int[] Dates;

    public Library(string author, string bookname, int year, int[] dates)
    {   
        this.Author = author;
        this.Bookname = bookname; 
        this.Year = year;
        this.Dates = dates;
    }

    public void GetData() 
    {
        // Выдает даты, когда книга была выдана + Всю инфу о книге (2 задания в одном) 
        for (int i = 0; i < this.Dates.Length; i++) 
        {
            Console.WriteLine($"'{this.Bookname}', года {this.Year}, автора {this.Author}, была выдана в {this.Dates[i]} месяце");
        }
    }

    public void YearBiggerInput(int InputYear) 
    {
        if (this.Year > InputYear) 
        {
            Console.WriteLine($"'{this.Bookname}', книга в которой год издания больше заданного ({InputYear}) года");
        }
    }
    public void InputAuthor(string InputAuthor)
    { 
        if (this.Author == InputAuthor) 
        {
            Console.WriteLine($"'{this.Bookname}', книга заданного автора {InputAuthor}");
        }
    }
}
