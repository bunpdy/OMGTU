class TrapezoidalRule {
    public static double Solve(Func<double, double> f, double a, double b, double dx) {
        
        // Решение
        double summ = 0.0;
        double dv = (b - a) / dx;

        for(int i = 0; i < dv; i++)
        {
            double per = ((f((double)i*dx + a) + f((double)i*dx + dx + a)) / 2) * dx;
            summ += per;

        }
        return summ;
    }
}

Func<double, double> f = (double x) => -x*x + 9;

var answ = TrapezoidalRule.Solve(f, -3, 3, 0.1);
answ
