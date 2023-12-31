using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("O(n + n**0.5)");
    for (int i = 106732567; i < 152673836 + 1; i++){
        double sqq = Math.Pow((double)i, (double)1 / 4);
        double num = Math.Round(Math.Pow((double)i, (double)1 / 4));
        if (num == sqq){
            int count = 0;
            for (int j = 2; j < num; j++){
                if (num % j == 0){
                    count = 1;
                    break;
                }
            }
            if (count == 0){
                for (int t = i - 1; t > 1; t--){
                    if (i % t == 0){
                        Console.WriteLine($"{i}, {t}");
                        break;
                    }
                }
                
            }
        }
        
    }
    
  }
}
