using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex rg = new Regex(@"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+");

                var isMatch = rg.Match(input);

                if (isMatch.Success)
                {
                    StringBuilder digit = new StringBuilder();
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            digit.Append(input[j]);
                        }
                    }
                    if (digit.Length>0)
                    {
                        Console.WriteLine($"Product group: {digit}");
                    }
                    else
                    {
                    Console.WriteLine("Product group: 00");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
