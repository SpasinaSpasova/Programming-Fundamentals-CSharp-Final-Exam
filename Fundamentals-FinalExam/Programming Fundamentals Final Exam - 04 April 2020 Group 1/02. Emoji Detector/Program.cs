using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numPattern = @"\d";
            string emojyPattern = @"(\:{2}|\*{2})(?<emojy>[A-Z][a-z]{2,})\1";

            string input = Console.ReadLine();

            List<string> emojita = new List<string>();

            MatchCollection numbers = Regex.Matches(input, numPattern);
            long coolThresholdSum = 1;
            foreach (var item in numbers)
            {
                coolThresholdSum *= int.Parse(item.ToString());
            }

            MatchCollection emojy = Regex.Matches(input, emojyPattern);
            foreach (Match item in emojy)
            {
                string current = item.Groups["emojy"].Value;
                long emojySum = 1;
                for (int i = 0; i < current.Length; i++)
                {
                    emojySum += current[i];
                }
                if (emojySum>=coolThresholdSum)
                {
                    emojita.Add(item.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{emojy.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine,emojita));
        }
    }
}
