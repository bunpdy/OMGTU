using System;
using System.Text.RegularExpressions;
class HelloWorld {
  static void Main() {
    string obraz = Console.ReadLine();
    int n = Convert.ToInt32(Console.ReadLine());
    int count = 0; 
    for (int i = 0; i < n; i++){
        string per = Console.ReadLine();
        int amount = new Regex(obraz).Matches(per).Count;
        count = count + amount;
    }
    Console.WriteLine(count);
    
  }
}
