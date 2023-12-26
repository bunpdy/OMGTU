using System;
class HelloWorld {
  static void Main() {
    int n = Convert.ToInt32(Console.ReadLine());
            int summ = 0, delta1 = 1000, delta2 = 1000;

            for (int i = 0; i < n; i++)
            {
                int first = Convert.ToInt32(Console.ReadLine());
                int second = Convert.ToInt32(Console.ReadLine());
                int maxl = Math.Max(first, second);
                int x = Math.Abs(first - second);
                if (x % 3 == 1 && (x < delta1))
                {
                    delta1 = x;
                }
                else if ((x + delta2) % 3 == 1 && (x + delta2) < delta1) {
                    delta1 = x + delta2;
                }
                if (x % 3 == 2 && x < delta2)
                {
                    delta2 = x;
                }
                else if ((x + delta1) % 3 == 2 && (x + delta1) < delta2) 
                {
                    delta2 = x+ delta1;
                }

                summ += maxl;
            }

            if (summ % 3 == 0)
            {
                Console.WriteLine(summ);
            }

            else if (delta1 < 1000 && (summ - delta1) % 3 == 0)
            {
                Console.WriteLine(summ - delta1);
            }

            else if (delta2 < 1000 && (summ - delta2) % 3 == 0)
            {
                Console.WriteLine(summ - delta2);
            }

            else
            {
                Console.WriteLine("NO");
            }
            Console.ReadLine();
    }
}
