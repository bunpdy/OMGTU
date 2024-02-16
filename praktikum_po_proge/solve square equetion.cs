class Equation 
{
    double a; 
    double b; 
    double c;

    public Equation(double a, double b, double c)
    {
        this.a = a;
        this.b = b; 
        this.c = c;
    }
    public void GiveRoots()
    {
        double D = Math.Pow(b, 2) - 4 * a * c;
        if (D >= 0)
        {
        double x1 = (-b + Math.Pow(D, 0.5)) / (2 * a);
        double x2 = (-b - Math.Pow(D, 0.5)) / (2 * a);
        Console.WriteLine($"x1: {x1} \nx2: {x2}");
        }
        else
        {
            Console.WriteLine("Roots of an equation are Complex numbers ");
        }
    }
}

Equation equation1 = new Equation(4, 5, -6);
equation1.GiveRoots();
