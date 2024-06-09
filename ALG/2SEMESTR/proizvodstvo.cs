struct Data(string number, string name, string position, double salary, string category, int v, double price)
{
    public string Number = number; // табельный номер,
    public string Name = name; // ФИО сотрудника
    public string Position = position; // должность
    public double Salary = salary; // зарплата
    public string Category = category; // категория товара
    public double V = v; // кол-во произведённых товаров
    public double Price = price; // цена за единицу товара
}

class Program 
{
    static void Main() 
    {
        Data[] workers = [
            new("1", "Толя", "лвл1", 30000, "A", 5000, 3000),
            new("2", "Коля", "лвл2", 35000, "B", 6000, 1250),
            new("3", "Оля", "лвл1", 25000, "B", 2000, 1400),
            new("4", "Моля", "лвл3", 50000, "C", 10000, 2500),
            new("5", "Поля", "лвл2", 37000, "C", 9000, 6000)
        ];

        var AllProduction = from worker in workers
                            select worker.V;

        double SumOfAllProduction = AllProduction.ToList().Sum();

        var AllPeopleWhoLessSOAP = from worker in workers
                                  where worker.Salary < SumOfAllProduction
                                  select 1;

        int NumberSOAP = AllPeopleWhoLessSOAP.Count();
        Console.WriteLine($"Количество рабочих которые получают зп < суммы выработанной продукции: {NumberSOAP}\n");

        var categories = from worker in workers
                         select worker.Category;

        double pbt = 0;
        double ppbt = 0;

        foreach (var category in categories.Distinct().ToList()) 
        {
            var ProductByCategory = from worker in workers
                                    where worker.Category == category
                                    select worker.V;
            var PriceProductByCategory = from worker in workers
                                    where worker.Category == category
                                    select worker.V * worker.Price;

            pbt = ProductByCategory.ToList().Sum();
            ppbt = PriceProductByCategory.ToList().Sum();
            Console.WriteLine($"Результаты по категории товаров номер: {category}");
            Console.WriteLine($"Кол-во произведенной продукции: {pbt}");
            Console.WriteLine($"Стоимость произведенной продукции: {ppbt}");
        }
        Console.WriteLine();
        Console.WriteLine($"Общий суммарный объём произведённой продукции: {SumOfAllProduction}\n");

        var PeopleWhoMoreSOP = from worker in workers
                               where worker.Salary > (worker.Price / 2)
                               select 1;
        Console.WriteLine($"Кол-во сотрудников, получающих > 50% от суммы производимого ими продукта: {PeopleWhoMoreSOP.ToList().Count}\n");

    }
}
