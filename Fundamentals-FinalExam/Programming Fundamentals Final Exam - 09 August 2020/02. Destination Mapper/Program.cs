using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();
            string pattern = @"([=|\/])(?<destination>[A-Z][A-Za-z]{2,})\1";

            MatchCollection matches = Regex.Matches(places, pattern);
            int sum = 0;
            List<string> theRes = new List<string>();

            foreach (Match item in matches)
            {
                sum += item.Groups["destination"].Value.Count();
                theRes.Add(item.Groups["destination"].Value);
            }

            
                Console.WriteLine($"Destinations: {string.Join(", ",theRes)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
