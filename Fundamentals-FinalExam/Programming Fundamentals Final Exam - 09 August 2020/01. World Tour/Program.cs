using System;
using System.Globalization;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Travel")
            {
                string[] arg = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string command = arg[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(arg[1]);
                    if (index >= 0 && index < stops.Length)
                    {
                        string value = arg[2];
                        stops = stops.Insert(index, value);
                    }
                        Console.WriteLine(stops);
                }
                else if (command == "Remove Stop")
                {
                    int start = int.Parse(arg[1]);
                    int end = int.Parse(arg[2]);
                    if (start >= 0 && start < stops.Length
                        && end >= 0 && end < stops.Length)
                    {
                        //?????
                        string substr = stops.Substring(start, end - start + 1);
                        stops = stops.Remove(start, substr.Length);
                    }
                        Console.WriteLine(stops);
                }
                else if (command == "Switch")
                {
                    string oldStr = arg[1];
                    string newStr = arg[2];
                    if (stops.Contains(oldStr))
                    {
                        stops = stops.Replace(oldStr, newStr);
                    }
                        Console.WriteLine(stops);

                }


                line = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
