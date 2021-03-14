using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> parkinginfo;        

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            parkinginfo = new List<Car>(capacity);
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return parkinginfo.Count; } }

        public void Add(Car car) 
        {
            if (this.parkinginfo.Count < this.Capacity)
            {
                parkinginfo.Add(car);                
            }            
        }
        public bool Remove(string manufacturer, string model)
        {

            bool isCarExist = false;

            for (int i = 0; i < parkinginfo.Count; i++)
            {
                if (parkinginfo[i].Manufacturer == manufacturer && parkinginfo[i].Model == model)
                {
                    isCarExist = true;
                    parkinginfo.Remove(parkinginfo[i]);
                    break;
                }
            }
            return isCarExist;        
        }

        public Car GetLatestCar() 
        {
            Car isLetestCar = parkinginfo.OrderByDescending(c => c.Year).FirstOrDefault();
            return isLetestCar;
        }

        public Car GetCar(string manufacturer, string model) 
        {
            Car currCar = parkinginfo.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return currCar;

            //for (int i = 0; i < parkinginfo.Count; i++)
            //{
            //    if (parkinginfo[i].Manufacturer == manufacturer && parkinginfo[i].Model == model)
            //    {
            //        currCar = parkinginfo[i];
            //    }
            //}
            //return currCar;
        }
        
        public string GetStatistics()
        {
            StringBuilder carsInfo = new StringBuilder();
            carsInfo.AppendLine($"The cars are parked in {this.Type}:");
            
            foreach (Car car in parkinginfo)
            {
                carsInfo.AppendLine($"{car.Manufacturer} {car.Model} ({car.Year})");
            }            
            return carsInfo.ToString();
        }
    }
}
