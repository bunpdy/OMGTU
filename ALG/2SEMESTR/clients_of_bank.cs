using System;

class Program
{
    struct BankClient
    {
        public int AccountNumber { get; set; }
        public string FullName { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }

        public decimal Balance => Income - Expense;
        public decimal TaxAmount => Income * 0.05m;
    }
    static void Main()
    {

        List<BankClient> clients = new List<BankClient>
        {
            new BankClient { AccountNumber = 1, FullName = "Иванов Иван Иванович", Income = 5000, Expense = 4000 },
            new BankClient { AccountNumber = 2, FullName = "Петров Петр Петрович", Income = 6000, Expense = 7000 },
            new BankClient { AccountNumber = 3, FullName = "Сидоров Сидор Сидорович", Income = 8000, Expense = 6000 },
            new BankClient { AccountNumber = 4, FullName = "Николаев Николай Николаевич", Income = 4000, Expense = 4500 }
        };

        int clientsWithNegativeBalanceCount = clients.Count(client => client.Balance < 0);
        Console.WriteLine($"Количество клиентов с отрицательным балансом: {clientsWithNegativeBalanceCount}");

        var richestClient = clients.OrderByDescending(client => client.Balance - client.TaxAmount).FirstOrDefault();
        Console.WriteLine($"Клиент с самым большим балансом с учетом налогов: {richestClient.FullName}");

        decimal averageIncomeForClientsWithNegativeBalance = clients
        .Where(client => client.Balance < 0)
        .Average(client => client.Income);
        Console.WriteLine($"Средний доход по счетам с отрицательным балансом: {averageIncomeForClientsWithNegativeBalance}");

        decimal totalTaxAmount = clients.Sum(client => client.TaxAmount);
        Console.WriteLine($"Суммарная сумма налогов со всех клиентов: {totalTaxAmount}");

    }
}
