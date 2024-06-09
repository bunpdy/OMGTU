using System.Drawing;
using System.Linq.Expressions;
using System.Collections;

class Program
{
    static void Main()
    {
        Menu menu1 = new();
        menu1.Start();

        Console.ReadKey();
    }
}

class Menu
{
    private int[] start_array = {3, 2, 1, 5, 4 };
    private List<int> main_array = [];

    private SortedList mySL = new SortedList();

    private int chooise = 0;

    public void PrintArray(int[]? l1, List<int>? l2, int flag)
    {
        if (flag == 1)
        {
            Console.Write("[");
            foreach (int i in l1)
            {
                Console.Write($"{i},");
            }
            Console.WriteLine("]");
        }
        else 
        {
            Console.Write("[");
            foreach (var i in l2)
            {
                Console.Write($"{i},");
            }
            Console.WriteLine("]");
        }
    }

    public void Start()
    {
        for (int i = 0; i < start_array.Length; i++)
        {
            main_array.Add(start_array[i]);
        }
        while (true)
        {
            chooise = Convert.ToInt32(Console.ReadLine());
            switch (chooise)
            {
                case 0:
                    return;

                case 1:
                    {
                        Console.WriteLine(main_array.Count);
                    }
                    break;

                case 2:
                    {
                        main_array.Sort();
                        chooise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(main_array.BinarySearch(chooise));
                    }
                    break;

                case 3:
                    {
                        int[] second_array = { 6, 7, 8, 9, 10};
                        chooise = Convert.ToInt32(Console.ReadLine());
                        Array.Copy(start_array, second_array, chooise);
                        PrintArray(second_array, null, 1);
                    }
                    break;

                case 4:
                    {
                        chooise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Array.Find(start_array, element => element.Equals(chooise)));
                    }
                    break;

                case 5:
                    {
                        chooise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Array.FindLast(start_array, element => element.Equals(chooise)));
                    }
                    break;

                case 6:
                    {
                        chooise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(main_array.IndexOf(chooise));
                    }
                    break;

                case 7:
                    {
                        Array.Reverse(start_array);
                        PrintArray(start_array, null, 1);
                    }
                    break;

                case 8:
                    Array.Resize(ref start_array, start_array.Length + 5);
                    PrintArray(start_array, null, 1);
                    break;

                case 9:
                    {
                        main_array.Sort();
                        PrintArray(null, main_array, 2);
                    }
                    break;

                case 10:
                    {
                        chooise = Convert.ToInt32(Console.ReadLine());
                        int index = Convert.ToInt32(Console.ReadLine());
                        main_array.Insert(index, chooise);
                        PrintArray(null, main_array, 2);
                    }
                    break;

                case 11:
                    {
                        chooise = Convert.ToInt32(Console.ReadLine());
                        main_array.Add(chooise);
                        PrintArray(null, main_array, 2);
                    }
                    break;

                case 12:
                    {
                        int torch = 1;
                        while (torch == 1)
                        {
                            Console.WriteLine("1 - добавить в словарь элементы\n2 - вывод индекса по ключу\n3 - вывод индекса по значению\n4 - вывод ключа по индексу\n5 - вывод значения по индексу\n0 - выход ");
                            chooise = Convert.ToInt32(Console.ReadLine());
                            switch (chooise) 
                            {
                                case 0:
                                    torch = 0;
                                    break;

                                case 1: 
                                    {
                                        int key1 = Convert.ToInt32(Console.ReadLine());
                                        int value1 = Convert.ToInt32(Console.ReadLine());
                                        mySL.Add(key1, value1);

                                        Console.WriteLine("\t-KEY-\t-VALUE-");
                                        for (int i = 0; i < mySL.Count; i++)
                                        {
                                            Console.WriteLine("\t{0}:\t{1}", mySL.GetKey(i), mySL.GetByIndex(i));
                                        }
                                        Console.WriteLine();

                                    }
                                    break;

                                case 2:
                                    {
                                        chooise = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(mySL.IndexOfKey(chooise));
                                    }
                                    break;
                                case 3:
                                    {
                                        chooise = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(mySL.IndexOfValue(chooise));
                                    }
                                break;

                                case 4:
                                    {
                                        chooise = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(mySL.GetKey(chooise));
                                    }
                                    break;
                                case 5:
                                    {
                                        chooise = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(mySL.GetByIndex(chooise));
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
