using System;
using System.Collections.Generic;
using System.Net.Security;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string line = Console.ReadLine();

            while (line!= "Complete")
            {
                if (line.Contains("Make Upper"))
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (line.Contains("Make Lower"))
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (line.Contains("GetDomain"))
                {
                    string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int count = int.Parse(tokens[1]);
                    string toPrint = email.Substring(email.Length - count, count);
                    Console.WriteLine(toPrint);

                }
                else if (line.Contains("GetUsername"))
                {
                    if (email.Contains("@"))
                    {

                        string toPrint = email.Substring(0, email.IndexOf('@'));
                        Console.WriteLine(toPrint);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }

                }
                else if (line.Contains("Replace"))
                {
                    string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string symbol = tokens[1];
                    email = email.Replace(symbol, "-");
                    Console.WriteLine(email);
                }
                else if (line.Contains("Encrypt"))
                {
                    List<int> encrypted = new List<int>();
                    for (int i = 0; i < email.Length; i++)
                    {
                        int current = email[i];
                        encrypted.Add(current);

                    }
                    Console.WriteLine(string.Join(" ",encrypted));
                    
                }

                line = Console.ReadLine();
            }
        }
    }
}
