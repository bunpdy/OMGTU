int roaddistance = Convert.ToInt32(Console.ReadLine());

int n = Convert.ToInt32(Console.ReadLine());

int flag = 0;

int summ = 0;

for (int i = 0; i < n; i++) 
{
    int uproad = Convert.ToInt32(Console.ReadLine());
    int downroad = Convert.ToInt32(Console.ReadLine());

    if (uproad < downroad) 
    {
        summ += uproad;
        if (flag == 1) 
        {
            summ += roaddistance;
            flag = 0; 
        }
    }

    else if (downroad < uproad)
    {
        summ += downroad;
        if (flag == 0) 
        {
            summ += roaddistance;
            flag = 1;
        }
    }

    else
    {
        summ += downroad;
    }

}

Console.WriteLine(summ);
Console.ReadKey(); 
