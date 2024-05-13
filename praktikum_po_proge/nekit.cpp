#include <iostream> 

void print_week(int[], int); 
 
int main() 
{ 
     
    int week1[]{0, 1, 0, 2, -1, 3, 3, 4, 5, -1, 3, 6, 2, -1, 6, -1, 7, 7, 3, -1, 8, 8, 8}; 
    int week2[]{5, 2, 2, -1, 6, -1, 5, 3, 9, 9, 9, -1, 9, 10, 10, -1, 7, 6, 2, -1, 7, 2}; 
     
    int week3[]{6, 3, 2, 2, -1, 12, 13, 3, -1, 5, 5, -1, 5, 4, 11, -1, 2, 2}; 
    int week4[]{6, 11, 2, -1, 2, 12, 3, 2, -1, 1, -1, 12, 11, 6, -1, 3, 4}; 
     
    while (true) 
    { 
        int term;  
        int week; 
        int subject;
        int hours = 0;
        
        std::cout << "Выбери семестр (1/2):"; 
        std::cin >> term; 
        std::cout << "Выбери неделю (1 до 18):"; 
        std::cin >> week;
        std::cout << "Выбери предмет за который надо вывести часы за ранее выбранный семестр\n"; 
        std::cout << "0-опо, 1-курчас, 2-ин яз, 3-прог, 4-физ-ра, \n 5-опд, 6-мат, 7-иг, 8-орг, 9-физ, 10-цг, 11-эбвт, 12-аиловс, 13-прд:"; 
        std::cin >> subject;
        
        if(term == 1) 
        {
            int size1 = sizeof(week1)/sizeof(week1[0]);
            int size2 = sizeof(week2)/sizeof(week2[0]);
            
            for (int i=0; i < size1; i++)
            {
                if (subject == week1[i])
                {
                    hours++;
                }
            }
            
            for (int j=0; j < size2; j++)
            {
                if (subject == week2[j])
                {
                    hours++;
                }
            }
            
            int res {hours * 9};
            
            int ost{week % 2}; 
            if (ost == 1) 
            { 
                print_week(week1, size1); 
            } 
            else 
            { 
                print_week(week2, size2); 
            }
            
            std::cout << "Количество часов за выбранный предмет за семестр: " << res; 
        } 
        else 
        {
            int size3 = sizeof(week3)/sizeof(week1[0]);
            int size4 = sizeof(week4)/sizeof(week2[0]);
            
            for (int i=0; i < size3; i++)
            {
                if (subject == week3[i])
                {
                    hours++;
                }
            }
            
            for (int j=0; j < size4; j++)
            {
                if (subject == week4[j])
                {
                    hours++;
                }
            }
            
            int res {hours * 9};
            
            int ost{week % 2}; 
            if (ost == 1) 
            { 
                print_week(week3, size3); 
            } 
            else 
            { 
                print_week(week4, size4); 
            }
            
            std::cout << "Количество часов за выбранный предмет за семестр: " << res;
            
        } 
        std::cout << "\n\n"; 
     
    } 
    
    return 0; 
} 
 
 
void print_week(int mass[], int sizze) 
{ 
    std::cout << "@ПОНЕДЕЛЬНИК :" << "\n"; 
    int count = 0; 
    for(int i {0}; i < sizze; i++) 
    { 
        switch(mass[i]) 
        { 
            case 0:  
                std::cout << "открытое программное обеспечение" << "\n"; 
                break; 
            case 1:  
                std::cout << "кур час" << "\n"; 
                break; 
            case 2:  
                std::cout << "ин яз" << "\n"; 
                break; 
            case 3:  
                std::cout << "программирование" << "\n"; 
                break; 
            case 4:  
                std::cout << "физ-ра" << "\n"; 
                break; 
            case 5:  
                std::cout << "основы проф деятельности" << "\n"; 
                break; 
            case 6:  
                std::cout << "математика" << "\n"; 
                break; 
            case 7:  
                std::cout << "инженерная графика" << "\n"; 
                break; 
            case 8:  
                std::cout << "орг" << "\n"; 
                break; 
            case 9:  
                std::cout << "физика" << "\n"; 
                break; 
            case 10:  
                std::cout << "цифр грамотность" << "\n"; 
                break; 
            case 11:  
                std::cout << "элементарная база вычислительной техники " << "\n"; 
                break; 
            case 12:  
                std::cout << "арифмитические и логические основы вычислительных систем" << "\n"; 
                break; 
            case 13:  
                std::cout << "практика речевой деятельности" << "\n"; 
                break; 
            default: 
                count++; 
                switch(count) 
                { 
                    case 1: 
                        std::cout << "@ВТОРНИК :" << "\n"; 
                        break; 
                    case 2: 
                        std::cout << "@СРЕДА :" << "\n"; 
                        break; 
                    case 3: 
                        std::cout << "@ЧЕТВЕРГ :" << "\n"; 
                        break; 
                    case 4: 
                        std::cout << "@ПЯТНИЦА :" << "\n"; 
                        break; 
                    case 5: 
                        std::cout << "@СУББОТА :" << "\n"; 
                        break; 
                } 
                break; 
        } 
    } 
}
