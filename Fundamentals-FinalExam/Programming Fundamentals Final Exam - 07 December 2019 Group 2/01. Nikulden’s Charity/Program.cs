using System;
using System.Diagnostics.CodeAnalysis;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();

            while (input!= "Finish")
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = arg[0];

                if (command=="Replace")
                {
                    string currentChar = arg[1];
                    string newChar = arg[2];
                    message = message.Replace(currentChar, newChar);
                    Console.WriteLine(message);
                }
                else if (command=="Cut")
                {
                    int start = int.Parse(arg[1]);
                    int end = int.Parse(arg[2]);
                    if (start < 0 || start >= message.Length || end < 0 || end >= message.Length)
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    else
                    {
                        message = message.Remove(start, end - start + 1);
                        Console.WriteLine(message);
                    }
                }
                else if (command=="Make")
                {
                    string action = arg[1];
                    if (action=="Upper")
                    {
                        message = message.ToUpper();
                    }
                    else
                    {
                        message = message.ToLower();

                    }
                    Console.WriteLine(message);
                }
                else if (command== "Check")
                {
                    string check = arg[1];
                    if (message.Contains(check))
                    {
                        Console.WriteLine($"Message contains {check}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {check}");
                    }
                }
                else if (command=="Sum")
                {
                    int start = int.Parse(arg[1]);
                    int end = int.Parse(arg[2]);
                    int sum = 0;
                    if (start < 0 || start >= message.Length || end < 0 || end >= message.Length)
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    else
                    {
                        for (int i = start; i <= end; i++)
                        {
                            sum += message[i];
                        }
                        Console.WriteLine(sum);
                    }
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
