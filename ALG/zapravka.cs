using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HelloWorld
{
    static void Main()
    {
        int gorod, zapravka, rasstoyanie, resultat = 0;
        gorod = Convert.ToInt32(Console.ReadLine());
        zapravka = Convert.ToInt32(Console.ReadLine());
        rasstoyanie = Convert.ToInt32(Console.ReadLine());
        if ((rasstoyanie / 2) < zapravka)
        {
            Console.WriteLine("Nelzya postavit zapravku");
        }
        else
        {
            if ((gorod % 2) == 0)
            {
                if ((rasstoyanie % 2) == 0)
                {
                    for (int c = 0; c < gorod / 2; c++)
                    {
                        resultat += 2 * (rasstoyanie - zapravka) + c * 2 * rasstoyanie;
                    }
                }
                else
                {
                    for (int c = 0; c < gorod / 2; c++)
                    {
                        resultat += zapravka + c * rasstoyanie;
                    }
                    for (int c = 0; c < gorod / 2; c++)
                    {
                        resultat += (rasstoyanie - zapravka) + c * rasstoyanie;
                    }
                }
            }
            else
            {
                for (int c = 0; c <= ((gorod - 3) / 2 + 1); c++)
                {
                    resultat += zapravka + c * rasstoyanie;
                }
                for (int c = 0; c <= ((gorod - 3) / 2); c++)
                {
                    resultat += (rasstoyanie - zapravka) + c * rasstoyanie;
                }
            }
        }
        Console.WriteLine(resultat);
    }
}
