using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
        HashSet<int> set2 = new HashSet<int>() { 1, 2, 5, 6, 7, 8 };
        HashSet<int> set3 = new HashSet<int>() { 5, 6, 7, 8, 9 };

        // Пересечение
        HashSet<int> intersection = new HashSet<int>(set1);
        intersection.IntersectWith(set2);
        intersection.IntersectWith(set3);

        Console.WriteLine("Пересечение:");
        foreach (int num in intersection)
        {
            Console.WriteLine(num);
        }

        // Объединение
        HashSet<int> union = new HashSet<int>(set1);
        union.UnionWith(set2);
        union.UnionWith(set3);

        Console.WriteLine("\nОбъединение:");
        foreach (int num in union)
        {
            Console.WriteLine(num);
        }

        // Дополнение
        HashSet<int> complement = new HashSet<int>(set1);
        complement.SymmetricExceptWith(set2);
        complement.SymmetricExceptWith(set3);

        Console.WriteLine("\nДополнение:");
        foreach (int num in complement)
        {
            Console.WriteLine(num);
        }
    }
}
