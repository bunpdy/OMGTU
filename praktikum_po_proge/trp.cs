class Trapezoida()
{
    public static double Solve(Func<double, double> f, double a, double b, double dx)
    {
        double result = 0.0;
        for (double i = a * 10; i < b * 10; i++)
        {
            result += ((f(i*dx) + f(i*dx+dx)) / 2) * dx;
            
        }
        return result;

    }


}

Func<double, double> f = (double x) => -x*x + 9;
var answ = Trapezoida.Solve(f, -3, 3, 0.1);
answ
