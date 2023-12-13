using System;
class HelloWorld {
  static void Main() {
    int voshod_h = Convert.ToInt32(Console.ReadLine());
    int voshod_m = Convert.ToInt32(Console.ReadLine());
    int zahod_h = Convert.ToInt32(Console.ReadLine());
    int zahod_m = Convert.ToInt32(Console.ReadLine());
    
    double v = Convert.ToDouble(Console.ReadLine());
    
    int points = Convert.ToInt32(Console.ReadLine());
    
    double all_time = (zahod_h - voshod_h) * 60 + (zahod_m - voshod_m);
    double time = all_time;
    int count = 0;
    double start = 0.0;
    for (int i = 0; i < points + 1; i++){
        double from_s_to_point = Convert.ToDouble(Console.ReadLine());
        
        
        //
        double between_points = (from_s_to_point - start);
        double time_between_points = (between_points / v) * 60;
        
        if (time < time_between_points) {
            
            Console.WriteLine("***");
            Console.WriteLine(i);
            Console.WriteLine("***");
            
            time = all_time;
            count = count + 1;
        }
        
        time = time - time_between_points;
        //
        
        start = from_s_to_point;
        
        
        
        
    }
    Console.WriteLine("DAYS");
    Console.WriteLine(count + 1);

    
  }

    
}
