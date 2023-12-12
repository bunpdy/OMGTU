using System;
class HelloWorld {
  static void Main() {
    string ls = Console.ReadLine();
    string reverse_ls = "";
    int end = ls.Length - 1;
    for (int i = 0; i < ls.Length; i++){
        if (char.IsDigit(ls[end]) == true){
            reverse_ls = reverse_ls + ls[end];
            end = end - 1;
        }
        else {
            reverse_ls = reverse_ls + char.ToLower(ls[end]);
            end = end - 1;
        }
    }
    Console.WriteLine(reverse_ls);
    int start = 2;
    int pred = 0;
    int maxx = 0; 
    while(true){
        string per = "";
        for (int j = pred; j < start; j++){
            per = per + reverse_ls[j];
            
        }

        if (ls.Contains(per) == true & per.Length > maxx){
            maxx = per.Length;
            
        }
        start = start + 1;
        if (start == reverse_ls.Length + 1){
            start = 2;
            pred = pred + 1;
            if (pred == reverse_ls.Length){
                break;
                
            }
        }
        
    }
    Console.WriteLine(maxx);
    
  }
}
