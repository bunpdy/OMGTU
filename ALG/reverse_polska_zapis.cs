class Program
{
    static void Main()
    {
        string? input_value = Console.ReadLine();
        SolveOfProblem(input_value!);
        Console.ReadKey();
    }
    
    static void SolveOfProblem(string ls)
    {

        List<string> stack = [];

        int count = 0;
        double per_res = 0;

        for (int i = 0; i < ls.Length; i++)
        {

            stack.Add(ls[i].ToString());

            if (stack.Count == 3)
            {
                count = 0;
                for (int j = 0; j < stack.Count; j++)
                {
                    if (int.TryParse(stack[j], out int num)) 
                    {
                        count++; 
                    }
                }
                if (count == 2)
                {
                    bool step1 = stack[^1] == "+";
                    bool step2 = stack[^1] == "-";
                    bool step3 = stack[^1] == "*";
                    bool step4 = stack[^1] == "/";

                    per_res = 0.0;

                    switch (true)
                    {
                        case (true) when step1:
                            {
                                per_res = Convert.ToDouble(stack[0]) + Convert.ToDouble(stack[1]);
                                StackUpdate(stack, per_res);
                            }
                            break;
                        case (true) when step2:
                            {
                                per_res = Convert.ToDouble(stack[0]) + Convert.ToDouble(stack[1]);
                                StackUpdate(stack, per_res);
                            }
                            break;
                        case (true) when step3:
                            {
                                per_res = Convert.ToDouble(stack[0]) * Convert.ToDouble(stack[1]);
                                StackUpdate(stack, per_res);
                            }
                            break;
                        case (true) when step4:
                            {
                                if (stack[1] == "0")
                                {
                                    Console.WriteLine("На ноль делить нельзя!");
                                    return;
                                }
                                else 
                                {
                                    per_res = Convert.ToDouble(stack[0]) / Convert.ToDouble(stack[1]);
                                    StackUpdate(stack, per_res);
                                }
                            }
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("В стеке неодназначность!");
                }
            }
        }
        if (stack.Count == 1)
        {
            Console.Write("Результат: ");
            Console.WriteLine(stack[0]);
        }
        else 
        {
            Console.WriteLine("Неоднозначная запись");
        }
    }

    static private void StackUpdate(List<string> stack, double per_res) 
    {
        stack.Clear();
        stack.Add(per_res.ToString());
    }
}
