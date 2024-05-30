using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {

        string start = Console.ReadLine();

        List<string> zzz = new List<string>();
        List<int> stack = new List<int>();

        for (int i = 0; i < start.Length; i++) 
        {
            zzz.Add(start[i].ToString());
        }
        // work with stack
        foreach (var s in zzz) 
        {
            if (!char.IsDigit(Convert.ToChar(s)))
            {
                if (s == "+")
                {
                    int element = stack[^2] + stack[^1];
                    stack.Clear();
                    stack.Add(element);
                }
                else if (s == "-")
                {
                    int element = stack[^2] - stack[^1];
                    stack.Clear();
                    stack.Add(element);
                }
                else if (s == "*") 
                {
                    int element = stack[^2] * stack[^1];
                    stack.Clear();
                    stack.Add(element);
                }
                else if (s == "/")
                {
                    int element = stack[^2] / stack[^1];
                    stack.Clear();
                    stack.Add(element);
                }
            }
            else
            {
                stack.Add(Convert.ToInt32(s));
            }
        }
        foreach (var el in stack) 
        {
            Console.WriteLine(el);
        }
        Console.ReadKey();  
    } 
}
