using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> information = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split("|");
                //{piece}|{composer}|{key}
                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];

                if (!information.ContainsKey(piece))
                {
                    information.Add(piece, new List<string>() { composer, key });
                }
            }

            string command = Console.ReadLine();

            while (command!= "Stop")
            {
                string[] tokens = command.Split("|");
               
                string arg = tokens[0];

                if (arg=="Add")
                {
                    //•	Add|{piece}|{composer}|{key} 
                    string piece = tokens[1];
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (information.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        information.Add(piece, new List<string>() { composer, key });

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (arg== "Remove")
                {
                    string piece = tokens[1];

                    if (information.ContainsKey(piece))
                    {
                        information.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (arg== "ChangeKey")
                {
                    string piece = tokens[1];
                    string newKey = tokens[2];
                    if (information.ContainsKey(piece))
                    {
                        information[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }
            foreach (var item in information.OrderBy(x=>x.Key).ThenBy(x=>x.Value[0]))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
