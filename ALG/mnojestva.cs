using System;

int n = Convert.ToInt32(Console.ReadLine());

int count = 0;

int[][] arr = new int[n][];

for (int i = 0; i < n; i++)
{
    int per = Convert.ToInt32(Console.ReadLine());
    arr[i] = new int[per];
    for (int j = 0; j < per; j++) 
    {
        count++;
        arr[i][j] = Convert.ToInt32(Console.ReadLine());
    }
}

int[] universum = new int[count];
count = 0;

for (int t = 0; t < arr.Length; t++) 
{
    for (int t2 = 0; t2 < arr[t].Length; t2++) 
    {
        if (!universum.Contains(arr[t][t2])) 
        {
            universum[count] = arr[t][t2];
            count++;
        }
    }
}

Console.WriteLine("***********************");


Console.WriteLine("Объеденение всех множеств: ");
for (int i = 0; i < count; i++) 
{
    Console.Write($"{universum[i]} ");
}

Console.WriteLine("\n***********************");

Console.WriteLine("Пересечение всех множеств: ");

int flag = 0;
int count2 = 0;

for (int i = 0; i < count; i++) 
{
    count2 = 1;
    for (int j = 0; j < arr.Length; j++)
    {
        flag = 0;
        for (int k = 0; k < arr[j].Length; k++) 
        {
            if (universum[i] == arr[j][k])
            {
                flag = 1;
                break;
            }
        }
        if (flag == 0)
        {
            count2 = 0; 
            break;
        }
    }
    if (count2 == 1) 
    {
        Console.Write($"{universum[i]} ");
    }
}

Console.WriteLine("\n***********************\n");

int flag2 = 0;
for (int i = 0; i < arr.Length; i++) 
{
    Console.WriteLine($"Дополнение для множества номер {i}: ");
    for (int j = 0; j < count; j++)
    {
        flag2 = 1;
        for (int k = 0; k < arr[i].Length; k++) 
        {
            if (universum[j] == arr[i][k])
            {
                flag2 = 0;
                break;
            }
        }
        if (flag2 == 1) 
        {
            Console.Write($"{universum[j]} ");
        }
    }
    Console.WriteLine(" ");
}

Console.ReadKey();
