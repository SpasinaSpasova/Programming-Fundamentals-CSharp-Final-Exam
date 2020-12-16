using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                if (heroes.ContainsKey(name))
                {
                    heroes[name][0] += hp;
                    heroes[name][1] += mp;
                }
                else
                {
                    heroes.Add(name, new List<int>() { hp, mp });
                }

            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                //CastSpell – {hero name} – {MP needed} – {spell name} 

                if (command.Contains("CastSpell"))
                {
                    string[] arg = command.Split(" - ");
                    string name = arg[1];
                    int mpNeeded = int.Parse(arg[2]);
                    string spellName = arg[3];
                    //!!!!!!!
                    if (heroes[name][1] >= mpNeeded )
                    {
                        heroes[name][1] -= mpNeeded;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name][1]} MP!");
                    }
                    else
                    {
                        //heroes[name][1] -= mpNeeded;
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                if (command.Contains("TakeDamage"))
                {
                    //TakeDamage – {hero name} – {damage} – {attacker}
                    string[] arg = command.Split(" - ");
                    string name = arg[1];
                    int damage = int.Parse(arg[2]);
                    string attacker = arg[3];
                    heroes[name][0] -= damage;
                    if (heroes[name][0]> 0)
                    {
                        
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }

                if (command.Contains("Recharge"))
                {
                    //Recharge – {hero name} – {amount}
                    string[] arg = command.Split(" - ");
                    string name = arg[1];
                    int amount = int.Parse(arg[2]);
                    if (amount + heroes[name][1] > 200)
                    {

                        amount = 200 - heroes[name][1];
                        heroes[name][1] += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }
                    else
                    {
                        heroes[name][1] += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");

                    }
                }
                if (command.Contains("Heal"))
                {
                    //Recharge – {hero name} – {amount}
                    string[] arg = command.Split(" - ");
                    string name = arg[1];
                    int amount = int.Parse(arg[2]);
                    if (amount + heroes[name][0] > 100)
                    {

                        amount = 100 - heroes[name][0];
                        heroes[name][0] += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                    else
                    {
                        heroes[name][0] += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");


                    }
                }

                command = Console.ReadLine();
            }

            heroes = heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, k => k.Value);

            foreach (var item in heroes)
            {
                if (item.Value[0] > 0)
                {
                    Console.WriteLine($"{item.Key}");
                    Console.WriteLine($"  HP: {item.Value[0]}");
                    Console.WriteLine($"  MP: {item.Value[1]}");
                }
            }
        }
    }
}
