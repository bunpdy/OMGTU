using System;
using System.Collections.Generic;
using System.Linq;

struct Date
{
    public string CallerNumber { get; set; }
    public string ReceiverNumber { get; set; }
    public string CallDate { get; set; }
    public int DurationMinutes { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<string, List<Date>> callRecords = new Dictionary<string, List<Date>>();

        AddCallRecord(callRecords, "123456789", "1", "2024.06.02", 10);
        AddCallRecord(callRecords, "123456789", "2", "2024.06.02", 5);
        AddCallRecord(callRecords, "987654321", "3", "2024.06.02", 15);
        AddCallRecord(callRecords, "987654321", "4", "2024.06.02", 20);
        AddCallRecord(callRecords, "123456789", "2", "2024.06.02", 7);

        string selectedCaller = "123456789";
        string mostCalledNumber = GetMostCalledNumber(callRecords, selectedCaller);
        Console.WriteLine($"Чаще всего звонил на номер: {mostCalledNumber}");

        Dictionary<string, string> mostTalkedNumbers = GetMostTalkedNumbers(callRecords);
        foreach (var kvp in mostTalkedNumbers)
        {
            Console.WriteLine($"Абонент {kvp.Key} чаще всего разговаривал с номером: {kvp.Value}");
        }
    }

    static void AddCallRecord(Dictionary<string, List<Date>> callRecords, string callerNumber, string receiverNumber, string callDate, int durationMinutes)
    {
        if (!callRecords.ContainsKey(callerNumber))
        {
            callRecords[callerNumber] = new List<Date>();
        }

        callRecords[callerNumber].Add(new Date
        {
            CallerNumber = callerNumber,
            ReceiverNumber = receiverNumber,
            CallDate = callDate,
            DurationMinutes = durationMinutes
        });
    }

    static string GetMostCalledNumber(Dictionary<string, List<Date>> callRecords, string callerNumber)
    {
        if (callRecords.ContainsKey(callerNumber))
        {
            Dictionary<string, int> callCounts = new Dictionary<string, int>();
            foreach (var call in callRecords[callerNumber])
            {
                if (callCounts.ContainsKey(call.ReceiverNumber))
                {
                    callCounts[call.ReceiverNumber]++;
                }

                else
                {
                    callCounts[call.ReceiverNumber] = 1;
                }
            }

            string mostCalledNumber = callCounts.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            return mostCalledNumber;
        }
        else
        {
            return "Не найдено";
        }
    }

    static Dictionary<string, string> GetMostTalkedNumbers(Dictionary<string, List<Date>> callRecords)
    {
        Dictionary<string, string> mostTalkedNumbers = new Dictionary<string, string>();

        foreach (var kvp in callRecords)
        {
            Dictionary<string, int> totalDurationPerNumber = new Dictionary<string, int>();

            foreach (var call in kvp.Value)
            {
                if (totalDurationPerNumber.ContainsKey(call.ReceiverNumber))
                {
                    totalDurationPerNumber[call.ReceiverNumber] += call.DurationMinutes;
                }
                else
                {
                    totalDurationPerNumber[call.ReceiverNumber] = call.DurationMinutes;
                }
            }

            string mostTalkedNumber = totalDurationPerNumber.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            mostTalkedNumbers.Add(kvp.Key, mostTalkedNumber ?? "Не найдено");
        }

        return mostTalkedNumbers;
    }
}
