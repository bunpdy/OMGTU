using System;
class HelloWorld {
  static void Main() {
    // i - stroka / j - stolbec
    int count1 = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count5 = 0;
    int pr3 = 1;
    int max = 0;
    int min = 1;
    string ls2 = "";
    int full_count1 = 0;
    int min_count_stolbov = 99;
    int m = Convert.ToInt32(Console.ReadLine());
    int[][] myArr = new int[m][];
    for (int i = 0; i < m; i++){
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < min_count_stolbov){
            min_count_stolbov = n;
        }
        myArr[i] = new int[n];
        for (int j = 0; j < n; j++){
            int element = Convert.ToInt32(Console.ReadLine());
            myArr[i][j] = element;
            if (j == 0){
                min = element;
                max = element;
            }
            if (element > max){
                max = element;
            }
            if (element < min){
                min = element;
            }
            if (element == 0){
                min = 0;
            }
            if ((element % 2) != 0){
                count2 = count2 + 1;
            }
        }
        
        if (max == min){
            count4 = count4 + 1;
        }
        
        if (count2 == 0){
            ls2 = ls2 + i.ToString();
        }
        count2 = 0;
        
    }
    Console.WriteLine("***");
    // Console.WriteLine(min_count_stolbov);
    int[] stolb = new int[m]; 
    int vert = 0; 
    while (vert < min_count_stolbov){
        for (int s = 0; s < m; s++){
            stolb[s] = myArr[s][vert];
            if (stolb[s] == 0){
                count3 = count3 + 1;
            }
            // Console.WriteLine(myArr[s][vert]);
            
        }
        if (count3 == 0){
            int proizved3 = stolb[0];
            for (int x3 = 1; x3 < m; x3++){
                proizved3 = proizved3 * stolb[x3];
                
            }
            pr3 = pr3 * proizved3;
            proizved3 = 0;
            count3 = 0;
            
        }
        for (int x1 = 0; x1 < m; x1++){
            for (int x2 = 0; x2 < m; x2++){
                if ((stolb[x1] == stolb[x2]) & (x1 != x2)){
                    count1 = count1 + 1;
                }
            }
        }
        if (count1 == 0){
            full_count1 = full_count1 + 1;
            
        }
        count1 = 0;
        vert = vert + 1;
    
        
    }
    int start = 0;
    int per_count = 0;
    while(start < m){
        for (int r = start + 1; r < m; r++){
            // Console.WriteLine($"{start}, {r}");
            // Console.WriteLine(myArr[start].Length);
            // Console.WriteLine(myArr[r].Length);
            per_count = 0;
            if (myArr[start].Length == myArr[r].Length){
                for (int el1 = 0; el1 < myArr[start].Length; el1++){
                    if (myArr[start][el1] != myArr[r][el1]){
                        per_count = per_count + 1;
                        
                    }
                }
                
            }
            else{
                per_count = 1;
            }
                
            
            if (per_count == 0){
                count5 = count5 + 1;
            }
            
        }
        start = start + 1;
        
    }
    Console.WriteLine("Число столбцов без повтор элементов: ");
    Console.WriteLine(full_count1);
    Console.WriteLine("Номера строк где все элементы четные: ");
    Console.Write(ls2);
    Console.WriteLine("Произвидение столбцов где нет нулевых элементов: ");
    Console.WriteLine(pr3);
    Console.WriteLine("Кол-во строк в которых минимальный = максимальному: ");
    Console.WriteLine(count4);
    Console.WriteLine("Кол-во ПАР строк состоящих из одних и тех же элементов: ");
    Console.WriteLine(count5);
    
    

}
}
