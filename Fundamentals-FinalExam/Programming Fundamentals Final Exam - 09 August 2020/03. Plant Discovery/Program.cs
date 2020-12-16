using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = tokens[0];
                int rarityNum = int.Parse(tokens[1]);

                if (dict.ContainsKey(plant))
                {
                    dict[plant][0] = rarityNum;

                }
                else 
                {

                    dict.Add(plant, new List<double>() { rarityNum });
                }
            }

            string comand = Console.ReadLine();

            while (comand != "Exhibition")
            {
                string[] arg = comand.Split(": ");
                string comName = arg[0];

                if (comName == "Rate")
                {
                    string[] splited = arg[1].Split(" - ");
                    string plant = splited[0];
                    int ratingNum = int.Parse(splited[1]);

                    if (dict.ContainsKey(plant))
                    {
                        dict[plant].Add(ratingNum);
                    }
                    else if(!dict.ContainsKey(plant)||ratingNum<0)
                    {

                        Console.WriteLine("error");
                    }
                }
                else if (comName == "Update")
                {
                    string[] splited = arg[1].Split(" - ");
                    string plant = splited[0];
                    int rarityNum = int.Parse(splited[1]);
                    if (dict.ContainsKey(plant))
                    {
                        dict[plant][0] = rarityNum;
                    }
                    else if (!dict.ContainsKey(plant) || rarityNum < 0)
                    {

                        Console.WriteLine("error");
                    }
                }
                else if (comName == "Reset")
                {
                    string plant = arg[1];

                    if (dict.ContainsKey(plant))
                    {
                        dict[plant].RemoveRange(1, dict[plant].Count - 1);
                    }
                    else 
                    {

                        Console.WriteLine("error");
                    }

                }
               


                comand = Console.ReadLine();
            }
            Console.WriteLine($"Plants for the exhibition:");

            foreach (var item in dict)
            {
                double rarity = item.Value[0];
                item.Value.RemoveAt(0);
                if (item.Value.Sum() > 0)
                {

                    double average = item.Value.Average();
                    item.Value.Clear();
                    item.Value.Add(rarity);
                    item.Value.Add(average);
                }
                else
                {

                item.Value.Clear();
                item.Value.Add(rarity);
                item.Value.Add(0);
                }
            }

            foreach (var item in dict.OrderByDescending(x=>x.Value[0]).ThenByDescending(x=>x.Value[1]))
            {
                if (item.Value[1]==0)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: 0.00");
                }
                else
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {item.Value[1]:f2}");
                }
            }
        }
    }
}

