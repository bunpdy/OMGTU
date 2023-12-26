using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int answer = 1;int count = 1;int prev = int.Parse(Console.ReadLine()); int now = 0; string flag2 = "да";int count3 = 1;int answer3 = 1;bool flag4 = true;int step =0;
            Console.WriteLine("Сейчас максимальная длина подстроки для задачи 1 = 1");
            Console.WriteLine(flag2);
            Console.WriteLine("максимальная длина различных элементов 1");
            Console.WriteLine("пока не могу сказать равномерно ли убывает");
            bool flag = false;
            for (int i = 1; i < numbers; i++) {

                if (prev % (i + 1) != 0)
                {
                    flag2 = "нет";
                }

                now = int.Parse(Console.ReadLine());
                if (i == 1) { step = prev - now; }
                if (i != 1) { if ((prev - now != step) || (step <= 0)) { flag4 = false; } }
                if (prev == now && !flag)
                {
                    flag = true;
                    count++;
                    count3 = 1;
                }
                
                else if (prev != now && flag)
                {
                    flag = false;
                    count = 1;
                }
                else if (prev == now && flag)
                {
                    count++;
                }
                if (prev != now) { count3++; }
                
                prev = now;
                answer = Math.Max(answer, count);
                answer3 = Math.Max(answer3, count3);
                Console.WriteLine("Сейчас максимальная длина подстроки для задачи 1 = " + answer);
                Console.WriteLine(flag2);
                Console.WriteLine("макcисмальная длина различных элементов " + answer3);
                if (flag4  == false)
                {
                    Console.WriteLine("не равномерно убыв");
                }
                else
                {
                    Console.WriteLine("равномерно убыв");
                }
            }
        }
    }
}
