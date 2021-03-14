using System;
namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(90, 50);

            vehicle.Drive(20);

            Console.WriteLine(vehicle.Fuel);

            Car car = new Car(72, 50);
            car.Drive(10);
            Console.WriteLine(car.Fuel);

            SportCar sportCar = new SportCar(350, 50);
            sportCar.Drive(4.5);

            Console.WriteLine(sportCar.Fuel);

            FamilyCar familyCar = new FamilyCar(82, 50);

            familyCar.Drive(10);

            Console.WriteLine(familyCar.Fuel);

            


        }
    }
}
