using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            while (input != "Sail")
            {
                string[] tokens = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string city = tokens[0];
                int population = int.Parse(tokens[1]);//0
                int gold = int.Parse(tokens[2]);//1

                if (cities.ContainsKey(city))
                {
                    cities[city][0] += population;
                    cities[city][1] += gold;
                }
                else
                {
                    cities.Add(city, new List<int>()
                    {
                    population,gold
                    }
                    );
                }

                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string city = tokens[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    cities[city][0] -= people;
                    cities[city][1] -= gold;
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[city][0] <= 0 || cities[city][1] <= 0)
                    {
                        cities.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(tokens[2]);
                    if (gold > 0)
                    {

                        cities[city][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city][1]} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }

                }

                input = Console.ReadLine();
            }
           

            if (cities.Count>0)
            {
                var sorted = cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key);
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
