using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {

        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => this.cars.Count;
           

        public string AddCar(Car car) 
        {          
            
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }

            if (this.cars.Count == this.capacity)
            {
                return $"Parking is full!";
            }

            this.cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";     
        
        }

        public string RemoveCar(string registraionNumber) 
        {

            Car car = this.cars.FirstOrDefault(r => r.RegistrationNumber == registraionNumber);


            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);

            return $"Successfully removed {registraionNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(e => e.RegistrationNumber == registrationNumber);

        }

        //public Car GetCar(string registrationNumber ) => 
        //    this.cars.FirstOrDefault(e => e.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers) 
        {

            this.cars = this.cars.Where(c => !registrationNumbers.Contains(c.RegistrationNumber)).ToList();     
       
        }



    }
}
