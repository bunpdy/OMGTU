using System;
class HelloWorld {
  static void Main() {
    Console.WriteLine("Hello World");
    int n = 0;
    int k = 0;
    int z = 0;
    int start = 1;
    int count = 1;
    int last_ind = 0;
    n = Convert.ToInt32(Console.ReadLine());
    k = Convert.ToInt32(Console.ReadLine());
    z = Convert.ToInt32(Console.ReadLine());
    int[] numbers;
    numbers = new int[n + 1];
    for (int i = 0; i < n + 1; i++){
        numbers[i] = 1;
    }
    int man = 1;
    while (man == 1){
        for (int t = start; t < n + 1; t++){
            start = 0;
            if (numbers[t] == 1){
                last_ind = t;
                if (count % k == 0){
                    numbers[t] = 0;
                    count = 0;
                }
            }
            count = count + 1;
        }
        int cvc = 0;
        for (int j = 0; j < n + 1; j++){
            if (numbers[j] == 1){
                cvc = cvc + 1;
        }
        }
        if (cvc == 1){
            man = 0;
            cvc = 0;
        }
    
  }
  Console.WriteLine((n + 1) - (last_ind - z));
}
}
