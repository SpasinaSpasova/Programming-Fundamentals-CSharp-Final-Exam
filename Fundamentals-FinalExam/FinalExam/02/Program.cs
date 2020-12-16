using System;
using System.Text.RegularExpressions;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"^([$|%])(?<tag>[A-Z][a-z]{2,})\1: \[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    char first = (char)(int.Parse(match.Groups[2].Value));
                    char second = (char)(int.Parse(match.Groups[3].Value));
                    char third = (char)(int.Parse(match.Groups[4].Value));
                    string result = string.Concat(first, second, third);
                    Console.WriteLine($"{match.Groups["tag"].Value}: {result}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
