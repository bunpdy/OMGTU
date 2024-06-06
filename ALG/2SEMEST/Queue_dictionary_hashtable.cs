using System;
using System.Collections;
using System.Collections.Generic;

struct Month
{
    public string PhoneNumber { get; set; }
    public string Date { get; set; }
    public string CallTime { get; set; }
    public int Minutes { get; set; }
}

class Program
{
    static void Main()
    {
        Queue<Month> reportsQueue = new Queue<Month>();

        reportsQueue.Enqueue(new Month { PhoneNumber = "123456789", Date = "2023.01.02", CallTime = "23:59", Minutes = 15 });
        reportsQueue.Enqueue(new Month { PhoneNumber = "987654321", Date = "2021.05.06", CallTime = "05:05", Minutes = 20 });
        reportsQueue.Enqueue(new Month { PhoneNumber = "123456789", Date = "2026.06.02", CallTime = "12:12", Minutes = 10 });
        reportsQueue.Enqueue(new Month { PhoneNumber = "987654321", Date = "2029.05.05", CallTime = "10:09", Minutes = 25 });

        Hashtable minutesHashtable = new Hashtable();

        while (reportsQueue.Count > 0)
        {
            Month report = reportsQueue.Dequeue();

            string phoneNumber = report.PhoneNumber;
            int minutes = report.Minutes;

            if (minutesHashtable.ContainsKey(phoneNumber))
            {
                int nowmin = Convert.ToInt32(minutesHashtable[phoneNumber]);
                minutesHashtable[phoneNumber] = nowmin + minutes;
            }
            else
            {
                minutesHashtable[phoneNumber] = minutes;
            }
        }

        Console.WriteLine("Месячный отчёт по общей сумме минут каждого номера (Hashtable):");
        foreach (DictionaryEntry value1 in minutesHashtable)
        {
            Console.WriteLine($"Номер телефона: {value1.Key}, Общее количество минут: {value1.Value}");
        }

        Dictionary<string, int> Dictt = new Dictionary<string, int>();

        reportsQueue = new Queue<Month>();

        reportsQueue.Enqueue(new Month { PhoneNumber = "123456789", Date = "2023.01.02", CallTime = "23:59", Minutes = 15 });
        reportsQueue.Enqueue(new Month { PhoneNumber = "987654321", Date = "1998.02.04", CallTime = "07:39", Minutes = 20 });
        reportsQueue.Enqueue(new Month { PhoneNumber = "123456789", Date = "2005.03.05", CallTime = "15:15", Minutes = 10 });
        reportsQueue.Enqueue(new Month { PhoneNumber = "987654321", Date = "2020.11.11", CallTime = "21:12", Minutes = 25 });

        while (reportsQueue.Count > 0)
        {
            Month report = reportsQueue.Dequeue();

            string phoneNumber = report.PhoneNumber;
            int minutes = report.Minutes;

            if (Dictt.ContainsKey(phoneNumber))
            {
                Dictt[phoneNumber] += minutes;
            }
            else
            {
                Dictt[phoneNumber] = minutes;
            }
        }

        Console.WriteLine("Месячный отчёт по общей сумме сумме минут каждого номера (Dictionary):");
        foreach (var value in Dictt)
        {
            Console.WriteLine($"Номер телефона: {value.Key}, Общее количество минут: {value.Value}");
        }
    }
}
