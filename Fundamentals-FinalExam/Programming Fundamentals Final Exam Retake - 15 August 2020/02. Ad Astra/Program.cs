using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#\|])(?<item>[A-Za-z\s]+)\1(?<day>\d{2})\/(?<month>\d{2})\/(?<year>\d{2})\1(?<calories>\d+)\1";
            string info = Console.ReadLine();

            MatchCollection matches = Regex.Matches(info, pattern);

            int sumCalory = 0;
            int kcl = 2000;
            foreach (Match item in matches)
            {
                sumCalory += int.Parse(item.Groups["calories"].Value);
            }
            int needed = sumCalory/ kcl;

            Console.WriteLine($"You have food to last you for: {needed} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["item"].Value}, Best before: {item.Groups["day"].Value}/{item.Groups["month"].Value}/{item.Groups["year"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}
