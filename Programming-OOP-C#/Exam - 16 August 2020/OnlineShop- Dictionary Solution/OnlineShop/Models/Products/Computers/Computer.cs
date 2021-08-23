using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private Dictionary<string, IComponent> components;
        private Dictionary<string, IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new Dictionary<string, IComponent>();
            peripherals = new Dictionary<string, IPeripheral>();
        }  

        public IReadOnlyCollection<IComponent> Components => components.Values.ToList();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.Values.ToList();

        public override decimal Price => PartsPrice();

        public override double OverallPerformance => ComponentsOverallPerformance() ;

        private double ComponentsOverallPerformance()
        {

            double value = 0.0;
            int count = 0;
            if (components.Values.Count > 0)
            {
                foreach (var item in components.Values)
                {
                    value += item.OverallPerformance;
                    count++;
                }
                value /= count;
            }           
            
            return value;
        }

        private double PeripheralsOverallPerformance()
        {
            double value = 0.0;
            int count = 0;
            if (peripherals.Values.Count > 0)
            {
                foreach (var item in peripherals.Values)
                {
                    value += item.OverallPerformance;
                    count++;
                }
                value /= count;
            }        

            return value;
        }

        private decimal PartsPrice()
        {
            decimal componentsPrice = components.Values.Select(c => c.Price).Sum();
            decimal peripheralsPrice = peripherals.Values.Select(c => c.Price).Sum();

            return componentsPrice + peripheralsPrice;
        }

        public void AddComponent(IComponent component)
        {
            string componentType = component.GetType().Name;
            if (components.ContainsKey(componentType))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingComponent, component.Model, this.GetType().Name, this.Id));
            }
            components.Add(component.GetType().Name, component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.ContainsKey(peripheral.GetType().Name))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ExistingPeripheral, peripheral.Model, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral.GetType().Name, peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.ContainsKey(componentType))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            IComponent component = components[componentType];
           
            components.Remove(componentType);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.ContainsKey(peripheralType))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            IPeripheral peripheral = peripherals[peripheralType];
            peripherals.Remove(peripheralType);            

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString()); 
            sb.AppendLine($" Components ({components.Count}):");

            foreach (var component in components)
            {
                sb.AppendLine($"  {component.Value}");
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({PeripheralsOverallPerformance():f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
