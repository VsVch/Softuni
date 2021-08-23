using OnlineShop.Common.Constants;
using OnlineShop.Core;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop
{
    public class Controller : IController
    {
        private readonly Dictionary<int, IComputer> computerById;
        private readonly Dictionary<int, IComponent> componentById;
        private readonly Dictionary<int, IPeripheral> peripheralById;

        public Controller()
        {
            computerById = new Dictionary<int, IComputer>();
            componentById = new Dictionary<int, IComponent>();
            peripheralById = new Dictionary<int, IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }            

            if (componentById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComputer computer = FindComputerById(computerId);

            computer.AddComponent(component);

            componentById.Add(id, component);

            return $"{string.Format(SuccessMessages.AddedComponent, componentType, id, computerId)}";           
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer") 
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            if (computerById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            computerById.Add(id, computer);

            return $"{string.Format(SuccessMessages.AddedComputer, id)}";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id,manufacturer,model,price,overallPerformance,connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (peripheralById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IComputer computer = FindComputerById(computerId);            

            computer.AddPeripheral(peripheral);
            peripheralById.Add(id, peripheral);

            return $"{string.Format(SuccessMessages.AddedPeripheral,peripheralType, id, computerId)}";
        }       

        public string BuyBest(decimal budget)
        {
            IComputer curComputer = null;

            foreach (var computer in computerById.OrderByDescending(c => c.Value.OverallPerformance))
            {

                if (computer.Value.Price <= budget)
                {
                    curComputer = computer.Value;
                    break;
                }
                
            }

            if (curComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer,budget));
            }
            computerById.Remove(curComputer.Id);
            return curComputer.ToString().TrimEnd();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = FindComputerById(id);

            computerById.Remove(id);

            return computer.ToString().TrimEnd();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = FindComputerById(id);

            return computer.ToString().TrimEnd();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
           IComputer computer = FindComputerById(computerId);

           IComponent component = computer.RemoveComponent(componentType);

           componentById.Remove(component.Id);

            return $"{string.Format(SuccessMessages.RemovedComponent, componentType, component.Id)}";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = FindComputerById(computerId);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            peripheralById.Remove(peripheral.Id);

            return $"{string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id)}";
        }

        private IComputer FindComputerById(int computerId)
        {
            IComputer computer = null;

            foreach (var item in computerById)
            {
                if (item.Key == computerId)
                {
                    computer = item.Value;
                }
            }

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer;
        }
    }
}
