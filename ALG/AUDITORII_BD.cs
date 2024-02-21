using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication73
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu1 = new Menu();
            menu1.start();
            Console.ReadKey();
        }
    }

    class Menu
    {
        private List<Audit> audits = new List<Audit>();

        public void AddToBase(int el1, int el2, int el3, int el4, int el5) 
        {
            audits.Add(new Audit(el1, el2, el3, el4, el5));
        }

        public void start() 
        {
            while (true) 
            {
                Console.WriteLine("1 - добавление; \n2 - рефактор по индексу; \n3 - Вывод всех аудиторий; \n4 - Вывод по выборке(1 - места/ 2 - проектор/ 3 - пк/ 4 - этаж); \n0 - выход");
                int chooise = Convert.ToInt32(Console.ReadLine());
                if (chooise == 1)
                {
                    int e1 = Convert.ToInt32(Console.ReadLine());
                    int e2 = Convert.ToInt32(Console.ReadLine());
                    int e3 = Convert.ToInt32(Console.ReadLine());
                    int e4 = Convert.ToInt32(Console.ReadLine());
                    int e5 = Convert.ToInt32(Console.ReadLine());
                    this.AddToBase(e1, e2, e3, e4, e5);

                }
                else if (chooise == 2)
                {
                    int index = Convert.ToInt32(Console.ReadLine());
                    var aud = audits[index];
                    aud.RefactorInfo();

                }
                else if (chooise == 3)
                {
                    int count = 0;
                    foreach (var aud in audits)
                    {
                        count++;
                        Console.WriteLine("\nАудитория номер {0}: ", count);
                        aud.PrintInfo();
                    }
                }
                else if (chooise == 4) 
                {
                    int input_number1 = Convert.ToInt32(Console.ReadLine());
                    int input_number2 = Convert.ToInt32(Console.ReadLine());
                    int input_number3 = Convert.ToInt32(Console.ReadLine());
                    int input_number4 = Convert.ToInt32(Console.ReadLine());
                    foreach (Audit element in audits) 
                    {
                        int posad_mesta = element.ReturnNumberOfPlaces();
                        int projector = element.ReturnProjector();
                        int pc = element.ReturnNumberOfPc();
                        int floor = element.ReturnFloor();
                        if ((posad_mesta >= input_number1) & (projector == input_number2) & (pc >= input_number3) & (floor == input_number4))
                        {
                            element.PrintInfo();
                        }
                    }

                }
                else if (chooise == 0)
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Неправильно введен выбор действия");
                }

            }
        }
    }

    class Audit
    {
        private int floor;
        private int number;
        private int numberofplaces;
        private int projector;
        private int numbersofpc;

        public Audit(int floor, int number, int numberofplaces, int projector, int numberofpc)
        {
            this.floor = floor; // этаж
            this.number = number; // номер аудитории 

            this.numberofplaces = numberofplaces;
            this.projector = projector;
            this.numbersofpc = numberofpc;
        }

        public int ReturnNumberOfPlaces()
        {
            return numberofplaces;
        }

        public int ReturnFloor()
        {
            return floor;
        }

        public int ReturnProjector()
        {
            return projector;
        }

        public int ReturnNumberOfPc()
        {
            return numbersofpc;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Этаж: {0} \nНомер: {1} \nКол-во посадочных мест:{2} \nНаличие проектора:{3} \nКол-во пк: {4}", floor, number, numberofplaces, projector, numbersofpc);
        }

        public void RefactorInfo()
        {
            while (true)
            {
                Console.WriteLine("Выберите номер внесения изменений: \n1 - этаж \n2 - номер \n3 - кол-во посадочных мест \n4 - проектор \n5 - кол-во пк \nдля выхода - 0");
                int chooise = Convert.ToInt32(Console.ReadLine());
            
                if (chooise == 1)
                {
                    this.floor = Convert.ToInt32(Console.ReadLine());
                }
                else if (chooise == 2)
                {
                    this.number = Convert.ToInt32(Console.ReadLine());
                }
                else if (chooise == 3)
                {
                    this.numberofplaces = Convert.ToInt32(Console.ReadLine());
                }
                else if (chooise == 4)
                {
                    this.projector = Convert.ToInt32(Console.ReadLine());
                }
                else if (chooise == 5)
                {
                    this.numbersofpc = Convert.ToInt32(Console.ReadLine());
                }
                else if (chooise == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно введен номер для внесения изменеий!");
                }
            }
        }
    }
}
