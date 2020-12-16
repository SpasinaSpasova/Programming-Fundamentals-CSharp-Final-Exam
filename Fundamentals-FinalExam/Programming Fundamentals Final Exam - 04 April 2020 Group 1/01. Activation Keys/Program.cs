using System;
using System.Reflection.Metadata.Ecma335;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] cmd = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string name = cmd[0];

                if (name == "Contains")
                {
                    string substr = cmd[1];
                    if (key.Contains(substr))
                    {
                        Console.WriteLine($"{key} contains {substr}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (name == "Flip")
                {
                    string action = cmd[1];
                    int start = int.Parse(cmd[2]);
                    int end = int.Parse(cmd[3]);
                    //!!!!!
                    string substr = key.Substring(start, key.Length - (key.Length - end + start));
                    int indexOfSubstr = key.IndexOf(substr);
                    key = key.Remove(indexOfSubstr, substr.Length);

                    if (action == "Upper")
                    {
                        substr = substr.ToUpper();
                        key = key.Insert(start, substr);

                    }
                    else if (action == "Lower")
                    {
                        substr = substr.ToLower();
                        key = key.Insert(start, substr);
                    }
                    Console.WriteLine(key);
                }
                else if (name == "Slice")
                {
                    int start = int.Parse(cmd[1]);
                    int end = int.Parse(cmd[2]);
                    key = key.Remove(start, end - start);
                    Console.WriteLine(key);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
