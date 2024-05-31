class Program
{
    private List<string> first_input = [];
    private List<int> stack = [];
    private int element;
    private string el1;
    private string el2;
    private int UncorrectNumber;

    public bool SolveOfProblem(string ls) 
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

    bool StringIsDigits(string sstr)
    {
    foreach(var item in sstr)
    {
        if(!char.IsDigit(item))
        {
            return false;
        }
    }
    return true; 
    }

    public void Conclusion()
    {
        if (UncorrectNumber > 0 || stack.Count != 1)
        {
            UncorrectNotation();
        }
        else
        {
            PrintStack();
        }
    }

    public void UncorrectNotation()
    {
        Console.WriteLine("Нотация Неккоректна!");
        return;
    }

    public bool CheckForCorrectNotation()
    {
        if (stack.Count == 2)
        {
            el1 = stack[0].ToString();
            el2 = stack[1].ToString();
            if (StringIsDigits(el1) & StringIsDigits(el2))
            {
                return true;
            }
            else
            {
                UncorrectNumber++;
                return false;
            }
        }
        else
        {
            UncorrectNumber++;
            return false;
        }
    }

    public void ReloadStack(int NumberForStack)
    {
        stack.Clear();
        stack.Add(NumberForStack);
    }

    public void AddInStack(string par)
    {
        stack.Add(Convert.ToInt32(par));
    }

    public void PrintStack()
    {
        if (stack.Count == 1){
            foreach (var el in stack) 
            {
                Console.WriteLine(el);
            }
        }
        else
        {
            UncorrectNotation();
        }
    }

    public bool CheckDevByZero(int denominator)
    {
        if (denominator == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Run()
    {
        string start = "23+";
        for (int i = 0; i < start.Length; i++) 
        {   
            first_input.Add(start[i].ToString());
        }

        foreach (var s in first_input) 
        {
            if (!char.IsDigit(Convert.ToChar(s)))
            {
                switch (s)
                {
                    case "+":
                        if (CheckForCorrectNotation())
                        {
                            element = stack[0] + stack[1];
                            ReloadStack(element);
                        }
                        break;
                    case "-":
                        if (CheckForCorrectNotation())
                        {
                            element = stack[0] - stack[1];
                            ReloadStack(element);
                        }
                        break;
                    case "/":
                        if ((CheckDevByZero(stack[1]) == false) & CheckForCorrectNotation())
                        {
                            element = stack[0] / stack[1];
                            ReloadStack(element);
                        }
                        else
                        {   
                            if (CheckDevByZero(stack[1]))
                            {
                                throw new Exception("Нельзя делить на 0!");
                            }
                        }
                        break;
                    case "*":
                        if (CheckForCorrectNotation())
                        {
                            element = stack[0] * stack[1];
                            ReloadStack(element);
                        }
                        break;
                    default:
                        if (!("+-*/".Contains(s)))
                        {
                            UncorrectNotation();
                            return;
                        }
                    break;
                }
            }
            else
            {
                AddInStack(s);
            }
        }
        Conclusion();
    }
}

Program program1 = new();
program1.Run();

