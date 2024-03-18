class TrapezoidalRule {
    public static double Solve(Func<double, double> f, double a, double b, double dx) {
        
        // Решение
        double start = a;
        double summ = 0.0;

        while (start < b)
        {
            double per = ((f(start) + f(start + dx)) / 2) * dx;
            summ += per;

            start = start + dx;
        }
        return summ;
    }
}

Func<double, double> f = (double x) => -x*x + 9;

var answ = TrapezoidalRule.Solve(f, -3, 3, 0.1);
answ
