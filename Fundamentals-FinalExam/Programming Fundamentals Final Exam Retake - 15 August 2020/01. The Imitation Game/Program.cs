using System;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string line = Console.ReadLine();

            while (line!="Decode")
            {
                string[] tokens = line.Split("|");
                string command = tokens[0];

                if (command=="Move")
                {
                    int countOfLetter = int.Parse(tokens[1]);

                    string sb = message.Substring(0, countOfLetter);
                    message = message.Remove(0, countOfLetter);
                    message += sb;
                   
                }
                else if (command=="Insert")
                {
                    int index= int.Parse(tokens[1]);
                    string value = tokens[2];

                    message = message.Insert(index, value);
                }
                else if (command== "ChangeAll")
                {
                    string substr = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substr, replacement);

                }


                line = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
