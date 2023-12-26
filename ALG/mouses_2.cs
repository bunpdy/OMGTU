using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace whiteGrayMice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите общее количество белых мышей: ");
            int belitmishki = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите общее количество серых мышей: ");
            int seriemishki = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите оставшееся количество белых мышей: ");
            int ostavshiesyabeliemishki = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите оставшееся количество серых мышей: ");
            int ostavshiesyaseriemishki = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите шаг: ");
            int shag = Convert.ToInt32(Console.ReadLine());
            int pozitsia = 0;
            int[] kolizestvopoz = new int[0];
            bool resultat = true;
            int[] mishi = new int[belitmishki + seriemishki];
            int count = mishi.Length;
            string[] countMishi = new string[mishi.Length];
            int defGrayMice = Math.Abs(seriemishki - ostavshiesyaseriemishki);
            int defWhiteMice = Math.Abs(belitmishki - ostavshiesyabeliemishki);

            for (int i = 0; i < int.MaxValue; i++)
            {
                if (seriemishki + belitmishki < ostavshiesyaseriemishki + ostavshiesyabeliemishki)
                {
                    resultat = false;
                    break;
                }

                if (mishi[0] == 1 && ostavshiesyaseriemishki == 1)
                {
                    resultat = false;
                    break;
                }

                if (count == ostavshiesyaseriemishki + ostavshiesyabeliemishki)
                {
                    Console.WriteLine();
                    for (int j = 0; j < mishi.Length; j++)
                    {
                        if (mishi[j] == 0) kolizestvopoz[j] = 1;
                    }
                    for (int l = 0; l < kolizestvopoz.Length; l++)
                    {

                        if (ostavshiesyaseriemishki > 0 && kolizestvopoz[l] == 1)
                        {
                            countMishi[l] = "seraya mish";
                            ostavshiesyaseriemishki--;
                            continue;
                        }


                        if (ostavshiesyabeliemishki > 0 && kolizestvopoz[l] == 1)
                        {
                            countMishi[l] = "belaya mish";
                            ostavshiesyabeliemishki--;
                            continue;
                        }


                        if (defGrayMice > 0)
                        {
                            if (mishi[l] == 1) countMishi[l] = "seraya mish";
                            defGrayMice -= 1;
                            continue;
                        }


                        if (defWhiteMice > 0)
                        {
                            if (mishi[l] == 1) countMishi[l] = "belaya mish";
                            defWhiteMice -= 1;
                            continue;
                        }
                    }
                    break;
                }

                kolizestvopoz = new int[mishi.Length];


                if (i == 0)
                {
                    pozitsia = mishi[i] + shag;
                    continue;
                }

                if (pozitsia > mishi.Length)
                {
                    int def = pozitsia - mishi.Length;
                    pozitsia = mishi[0] + def;
                }

                if (pozitsia == mishi.Length)
                {
                    pozitsia = 0;
                }

                while (mishi[pozitsia] == 1)
                {
                    pozitsia++;
                    if (pozitsia == mishi.Length)
                    {
                        pozitsia = 0;
                    }
                }
                mishi[pozitsia] = 1;
                pozitsia = pozitsia + shag;
                count -= 1;
            }
            if (resultat == false)
            {
                Console.WriteLine("Такое невозможно.");
            }
            else Console.WriteLine(String.Join(", ", countMishi));
        }
    }
}
