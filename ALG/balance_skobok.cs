class Program 
{
    static void Main() 
    {
        Console.WriteLine(SolveOfProblem("[]{([])}[]"));
        Console.WriteLine(SolveOfProblem("{()[()]}[({})]"));
        Console.WriteLine(SolveOfProblem("{}()[({}())]"));
        Console.WriteLine(SolveOfProblem("[(])"));
        Console.WriteLine(SolveOfProblem("{{[]]}}"));
    }

    static bool SolveOfProblem(string ls) 
    {

        List<string> stack = [];
        int length_stack = 0;

        for (int i = 0; i < ls.Length; i++) 
        {
            stack.Add(ls[i].ToString());
            length_stack = stack.Count;

            if (length_stack > 1) 
            {
                bool step1 = ((stack[length_stack - 2] + stack[length_stack - 1]) == "{}");
                bool step2 = ((stack[length_stack - 2] + stack[length_stack - 1]) == "[]");
                bool step3 = ((stack[length_stack - 2] + stack[length_stack - 1]) == "()");

                if (step1 | step2 | step3) 
                {
                    stack.RemoveAt(length_stack - 2);
                    length_stack = stack.Count;
                    stack.RemoveAt(length_stack - 1);
                }
            }
        }
        return stack.Count == 0;
    }
}
