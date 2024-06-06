using System;
using System.Collections.Generic;

class Car
{
    private string Name { get; set; }

    public Car(string name)
    {
        Name = name;
    }

    public void WashCar()
    {
        Console.WriteLine($"{Name} помыт.");
    }
}

class Garage
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void CleanAllCars(CarWash carWash)
    {
        foreach (var car in cars)
        {
            carWash.Wash(car);
        }
    }
}

class CarWash
{
    public void Wash(Car car)
    {
        car.WashCar();
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car("Автомобиль 1");
        Car car2 = new Car("Автомобиль 2");
        Car car3 = new Car("Автомобиль 3");

        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);

        CarWash carWash = new CarWash();

        garage.CleanAllCars(carWash);
    }
}
