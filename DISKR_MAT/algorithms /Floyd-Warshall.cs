using System;

class HelloWorld
{
    static void Main()
    {
        double Inf = Double.PositiveInfinity;
        double[][] numbers = [
        [0, 5, Inf, 12],
        [Inf, 0, 67, Inf],
        [37, Inf, 0, 5],
        [Inf, 77, Inf, 0]
    ];
        for (int t = 0; t < numbers.Length; t++)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    double anyway = numbers[i][t] + numbers[t][j];
                    double forward_way = numbers[i][j];
                    numbers[i][j] = Math.Min(forward_way, anyway);
                    Console.Write(numbers[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
        }
    }
}
