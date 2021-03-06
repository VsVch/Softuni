using System;
using System.Collections.Generic;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main()
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] phones = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] url = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
               
           foreach (var phone in phones)
           {         
              try
              {
                  string result = phone.Length == 10 ?
                  smartphone.Call(phone) : stationaryPhone.Call(phone);
                  Console.WriteLine(result);
              }
              catch (ArgumentException ex)
              {
         
                  Console.WriteLine(ex.Message);
              }
         
           }
         
           foreach (var item in url)
           {
              
              try
              {
                    string result = smartphone.Brows(item);
                    Console.WriteLine(result);
              }
              catch (ArgumentException ex)
              {

                   Console.WriteLine(ex.Message);
              }                
           } 
                  
        }
    }
}
