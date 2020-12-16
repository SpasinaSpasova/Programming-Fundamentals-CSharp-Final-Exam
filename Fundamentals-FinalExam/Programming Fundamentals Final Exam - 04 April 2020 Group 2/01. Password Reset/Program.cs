using System;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = Console.ReadLine();

            while (input!="Done")
            {
                if (input.Contains("TakeOdd"))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i%2!=0)
                        {
                            sb.Append(password[i]);
                        }
                    }
                    password = sb.ToString();
                    Console.WriteLine(password);
                }
                else if (input.Contains("Cut"))
                {
                    string[] commands = input.Split();
                    int index = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);
                    
                    password = password.Remove(index,length);
                    Console.WriteLine(password);
                }
                else if (input.Contains("Substitute"))
                {
                    string[] commands = input.Split();
                    string oldText = commands[1];
                    string newText = commands[2];

                    if (password.Contains(oldText))
                    {
                        password = password.Replace(oldText, newText);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
