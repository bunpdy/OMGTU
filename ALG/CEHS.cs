using System;

Ceh[] cehs =
[
    new Ceh("Цех1", 2000, 100),
    new Ceh("Цех2", 2000, 150),
    new Ceh("Цех3", 2001, 198),
    new Ceh("Цех4", 2001, 170),
    new Ceh("Цех5", 2002, 125),
    new Ceh("Цех1", 2003, 133),
    new Ceh("Цех3", 2004, 166),
];

int count = 0;
int count2 = cehs.Length;

Console.WriteLine("Введите год: ");
int input_year = Convert.ToInt32(Console.ReadLine());


for (int t = 0; t < cehs.Length; t++)
{
    if (cehs[t].Year == input_year)
    {
        cehs[t].GetVolume();
        count++;

    }
}

if (count == 0)
{
    Console.WriteLine("За этот год не было цехов, которые бы производили продукцию");
}

Console.WriteLine("*******************************************");

for (int i = 0; i < count2; i++)
{
    int summ = 0;
    int count3 = 1;
    for (int j = i + 1; j < cehs.Length; j++)
    {

        if (cehs[i].Name == cehs[j].Name)
        {
            count3++;
            summ += cehs[j].Volume + cehs[i].Volume;
            if (summ > 0) 
            {
                count2--;
            }
        }
        
    }
    if (summ == 0) 
    {
        summ = cehs[i].Volume;
    }

    Console.WriteLine($"Суммарный объем по всем годам цеха {cehs[i].Name} равен {summ}");
    Console.WriteLine($"Интенсивность производства цеха {cehs[i].Name} по всем годам равен {summ / count3}");
    Console.WriteLine("     ");
}

Console.ReadKey();

class Ceh
{  

    private string name;
    private int year;
    private int volume;

    public Ceh(string name, int year, int volume) 
    {   
        if (name == "") 
        {
            throw new ArgumentException("Имя цеха не может быть пустым");
        }
        else 
        {   
            this.name = name;
        }
        if (year < 0) 
        {
            throw new ArgumentException("Год не может быть отрицательным");
        }
        else 
        {
            this.year = year;
        }

        if (volume < 0)
        {
            throw new ArgumentException("Объем произовдства не может быть отрицательным");
        }
        else 
        {
            this.volume = volume;
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
            else
            {
                throw new ArgumentException("Имя цеха не может быть пустым");
            }
        }
    
    }
    public int Year
    {
        get
        {
            return year;
        }
        set
        {
            if (value > 0) 
            {
                year = value;
            }
            else 
            {
                throw new ArgumentException("Год не может быть отрицательным");
            }
        }

    }

    public int Volume
    {
        get
        {
            return volume;
        }
        set
        {
            if (value > 0)
            {
                volume = value;
            }
            else 
            {
                throw new ArgumentException("Объем произовдства не может быть отрицательным");
            }

        }
    }
    
    public void GetVolume() 
    {
        Console.WriteLine($"{Name} за {Year} год произвел {Volume} ед. продукции");

    }

}
