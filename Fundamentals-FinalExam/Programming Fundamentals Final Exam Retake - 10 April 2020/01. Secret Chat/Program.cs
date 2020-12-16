using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealed = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] arg = input.Split(":|:");
                string command = arg[0];
                if (command == "InsertSpace")
                {
                    int index = int.Parse(arg[1]);
                    concealed = concealed.Insert(index, " ");
                    Console.WriteLine(concealed);
                }
                else if (command == "Reverse")
                {
                    string sb = arg[1];
                    if (concealed.Contains(sb))
                    {
                        int indexOfSb = concealed.IndexOf(sb);
                        concealed = concealed.Remove(indexOfSb, sb.Length);
                        string reversed = new string(sb.Reverse().ToArray());
                        concealed += reversed;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;

                    }
                    Console.WriteLine(concealed);

                }
                else if (command == "ChangeAll")
                {
                    string substr = arg[1];
                    string replacement = arg[2];

                    concealed = concealed.Replace(substr, replacement);
                    Console.WriteLine(concealed);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {concealed}");
        }
    }
}
