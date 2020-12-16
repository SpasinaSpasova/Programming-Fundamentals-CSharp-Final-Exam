using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, List<string>> liked = new Dictionary<string, List<string>>();
            int countUnlike = 0;
            
            while (line != "Stop")
            {
                string[] tokens = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                string guest = tokens[1];
                string meal = tokens[2];
                if (command == "Like")
                {
                    if (liked.ContainsKey(guest))
                    {
                        if (!liked[guest].Contains(meal))
                        {
                            liked[guest].Add(meal);
                        }
                    }
                    else
                    {
                        liked.Add(guest, new List<string>() { meal });
                    }
                }
                else if (command== "Unlike")
                {
                    if (liked.ContainsKey(guest))
                    {
                        if (liked[guest].Contains(meal))
                        {
                            liked[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            countUnlike++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }


                line = Console.ReadLine();
            }

            var sorted = liked.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var item in sorted)
            {
                //{Guest1}: {meal1}, {meal2}, {meal3}
                Console.WriteLine($"{item.Key}: "+string.Join(", ",item.Value));
            }
            Console.WriteLine($"Unliked meals: {countUnlike}");
        }
    }
}
