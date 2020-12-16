using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, List<int>> info = new Dictionary<string, List<int>>();

            while (line != "Results")
            {
                string[] tokens = line.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Add")
                {
                    string person = tokens[1];
                    int health = int.Parse(tokens[2]);
                    int energy = int.Parse(tokens[3]);

                    if (info.ContainsKey(person))
                    {
                        info[person][0] += health;
                    }
                    else
                    {
                        info.Add(person, new List<int>() { health, energy });

                    }
                }
                else if (command == "Attack")
                {
                    string attacker = tokens[1];
                    string defender = tokens[2];
                    int demage = int.Parse(tokens[3]);
                    if (info.ContainsKey(attacker) && info.ContainsKey(defender))
                    {
                        info[defender][0] -= demage;
                        info[attacker][1] -= 1;

                        if (info[defender][0] <= 0)
                        {
                            Console.WriteLine($"{defender} was disqualified!");
                            info.Remove(defender);
                        }
                        if (info[attacker][1] == 0)
                        {
                            Console.WriteLine($"{attacker} was disqualified!");
                            info.Remove(attacker);

                        }
                    }
                }
                else if (command == "Delete")
                {
                    string action = tokens[1];
                    if (action == "All")
                    {
                        info.Clear();
                    }
                    if (info.ContainsKey(action))
                    {
                        info.Remove(action);
                    }
                }




                line = Console.ReadLine();
            }
            Console.WriteLine($"People count: {info.Count}");

            foreach (var item in info.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} - {item.Value[1]}");
            }
        }
    }
}
