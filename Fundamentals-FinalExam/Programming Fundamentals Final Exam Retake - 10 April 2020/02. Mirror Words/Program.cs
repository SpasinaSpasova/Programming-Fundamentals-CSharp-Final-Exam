using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> mirror = new List<string>();
            string pattern = @"([@#])(?<first>[a-zA-z]{3,})\1\1(?<second>[a-zA-z]{3,})\1";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match item in matches)
            {
                string first = item.Groups["first"].Value;
                string second = item.Groups["second"].Value;

                string reversed = new string(second.Reverse().ToArray());

                if (first == reversed)
                {
                    mirror.Add($"{first} <=> {second}");
                }

            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (mirror.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", mirror));

            }
        }
    }
}
