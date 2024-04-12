using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace PO2_6
{
    internal class Program
    {

        static List<int> add(List<int> one, List<int> two)
        {
            List<int> result = new List<int>();
            if (one.Count != two.Count)
            {
                throw new WektoryRoznejDlugosciException(one.Count, two.Count);
            }
            for (int i = 0; i < one.Count; i++)
            {
                result.Add(one[i] + two[i]);
            }
            return result;
        }
        static List<int> read()
        {
            List<int> result = new List<int>();
            bool stop = false;
            while (!stop)
            {
                string Line = Console.ReadLine();
                string[] Nums = Line.Split(' ');
                stop = true;
                foreach (string Num in Nums)
                {
                    try
                    {
                        int N = Convert.ToInt32(Num);
                        result.Add(N);
                    }
                    catch (FormatException e)
                    {
                        result.Clear();
                        stop = false;
                        Console.WriteLine("Incorrect input");
                        break;
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("Input vectors:");
            while (!quit)
            {
                List<int> first = read();
                List<int> second = read();
                List<int> result;
                try
                {
                    result = add(first, second);
                }
                catch (WektoryRoznejDlugosciException e)
                {
                    Console.WriteLine("Długość pierwszego wektora to " + e.lengths().ToArray()[0] + " a drugiego to " + e.lengths().ToArray()[1]);
                    Console.WriteLine("Input new vectors");
                    continue;
                }
                Console.WriteLine("Result:");
                foreach (int n in result)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
                try
                {
                    StreamWriter f = new StreamWriter("results.txt");
                    foreach (int n in result)
                    {
                        f.Write(n + " ");
                    }
                    f.Close();
                } catch (Exception e)
                {
                    Console.WriteLine("Something had gone south with file writing. Detailed report: " + e.Message);
                }
                quit = true;

            }
        }
    }
}
