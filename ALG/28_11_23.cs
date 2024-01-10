using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

Person[] persons =
[
    new Person("Анатолий", 1997, "тракторист", "Буравкино"),
    new Person("Петя", 1978, "электрик", "Травкино"),
    new Person("Митя", 1989, "инженер", "Мушкино"),
    new Person("Оля", 1999, "актриса", "Опушкино"),
    new Person("Маша", 2000, "продавец", "Кукушкино"),
    new Person("Аня", 1986, "программист", "Пушкино"),
];

Console.WriteLine("Введите даты рождения в пределах которых мы отберем сотрудников, \n Первая дата: ");
int firstdate = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Вторая дата: ");
int seconddate = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < persons.Length; i++) 
{
    if (persons[i].Birthday >= firstdate && persons[i].Birthday <= seconddate) 
    {   
        persons[i].GetInfo();
    }
}

Console.ReadKey();

class Person
{

    private string name;
    private int birthday;
    private string education;
    private string address;
    public Person(string name, int birthday, string education, string address)
    {
        if (name != "" && birthday > 0 && address != "" && education != "")
        {
            this.name = name;
            this.birthday = birthday;
            this.education = education;
            this.address = address;
        }
        else 
        {
            throw new ArgumentException("Введите корректные данные объекта");
        }
    }

    public string Name 
    {
        get 
        { 
            return name; 
        }
        set 
        {
            if (value != "")
            {
                name = value;
            }
        }
    }

    public int Birthday
    {
        get
        {
            return birthday;
        }
        set
        {
            if (value > 0) 
            {
                value = birthday;
            }
        }
    }

    public string Education
    {
        get
        {
            return education;
        }
        set
        {
            if (value != "") 
            {
                value = education;
            }
        }
    }

    public string Address
    {
        get
        {
            return address;
        }
        set
        {
            if (value != "") 
            {
                value = address;
            }
        }
    }

    public void GetInfo() 
    {
        Console.WriteLine($"Я {this.name}, мой год рождения - {this.birthday}, по образованию я " +
            $" {this.education} живу в {this.address}");
    }

}
