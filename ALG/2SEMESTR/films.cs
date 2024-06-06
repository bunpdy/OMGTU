using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    struct Movie
    {
        public string Title { get; set; }
        public string StartTime { get; set; }
        public int SoldSeats { get; set; }
        public int TotalSeats { get; set; }
    }

    static void Main()
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie { Title = "Фильм 1", StartTime = "13:00", SoldSeats = 20, TotalSeats = 50 },
            new Movie { Title = "Фильм 2", StartTime = "16:00", SoldSeats = 30, TotalSeats = 100 },
            new Movie { Title = "Фильм 3", StartTime = "18:00", SoldSeats = 10, TotalSeats = 30 }
        };

        var less = movies.Where(m => ((double)m.SoldSeats / m.TotalSeats) * 100 < 50);

        Console.WriteLine("Фильмы с процентом занятости мест менее 50%:");
        foreach (var movie in less)
        {
            Console.WriteLine($"{movie.Title}");
        }

        var after = movies.Where(m => TimeToMinutes(m.StartTime) > 900);

        Console.WriteLine("\nФильмы с сеансами, начинающимися после 15:00:");
        foreach (var movie in after)
        {
            Console.WriteLine($"{movie.Title}");
        }
    }

    static int TimeToMinutes(string time)
    {
        var parts = time.Split(':');
        int hours = int.Parse(parts[0]);
        int minutes = int.Parse(parts[1]);
        return hours * 60 + minutes;
    }
}
