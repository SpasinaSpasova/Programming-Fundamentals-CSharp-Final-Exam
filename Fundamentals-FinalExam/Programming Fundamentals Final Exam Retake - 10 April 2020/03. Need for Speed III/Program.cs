using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> carInfo = new Dictionary<string, List<int>>();
            for (int i = 0; i < numOfCars; i++)
            {
                string[] car = Console.ReadLine().Split("|");
                string name = car[0];
                int mileage= int.Parse(car[1]);
                int fuel= int.Parse(car[2]);

                if (carInfo.ContainsKey(name))
                {
                    carInfo[name][0] += mileage;
                    carInfo[name][1] += fuel;
                }
                else
                {
                    carInfo.Add(name, new List<int>() { mileage, fuel});
                    
                }
            }

            string input = Console.ReadLine();
            while (input!= "Stop")
            {
                string[] arg = input.Split(" : ",StringSplitOptions.RemoveEmptyEntries);
                string command = arg[0];

                if (command=="Drive")
                {
                    string carName = arg[1];
                    int distance = int.Parse(arg[2]);
                    int fuel = int.Parse(arg[3]);

                    if (fuel>carInfo[carName][1])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carInfo[carName][0] += distance;
                        carInfo[carName][1] -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (carInfo[carName][0]>=100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        carInfo.Remove(carName);
                    }
                }
                else if (command== "Refuel")
                {
                    string carName = arg[1];
                    int fuel = int.Parse(arg[2]);
                    int max = 75;
                    if (carInfo[carName][1]+fuel>max)
                    {
                        fuel = 75 - carInfo[carName][1];
                        carInfo[carName][1] = 75;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");

                    }
                    else
                    {
                        carInfo[carName][1] += fuel;

                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                }
                else if (command == "Revert")
                {
                    string carName = arg[1];
                    int km = int.Parse(arg[2]);

                    if (carInfo[carName][0] -km < 10000)
                    {
                        carInfo[carName][0] = 10000;
                    }
                    else
                    {
                        carInfo[carName][0] -= km;
                        Console.WriteLine($"{carName} mileage decreased by {km} kilometers");
                    }
                }
               

                input = Console.ReadLine();
            }
            var sorted = carInfo.OrderByDescending(x => x.Value[0]).ThenBy(x=>x.Key);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}
