using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^!(?<command>[A-Z][a-z]{2,})!:\[(?<encrypt>[A-Za-z]{8,})\]$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                List<int> theNum = new List<int>();
                if (match.Success)
                {
                    string encrypt = match.Groups["encrypt"].ToString();
                    for (int j = 0; j < encrypt.Length; j++)
                    {
                        char current = encrypt[j];
                        int cur = (int)current;
                        theNum.Add(cur);
                    }
                    Console.WriteLine($"{match.Groups["command"].ToString()}"+": "+ string.Join(" ",theNum));
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
