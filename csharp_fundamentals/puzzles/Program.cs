using System;
using System.Linq;

namespace puzzles
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            // randomArray();
            // tossMultipleCoins(57);
            // names();
        }

        static int[] randomArray()
        {
            int[] arr = new int[10];
            int lowest = 25;
            int highest = 5;
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                arr[i] = random.Next(5, 26);
                if (arr[i] > highest)
                {
                    highest = arr[i];
                }
                else if (arr[i] < lowest)
                {
                    lowest = arr[i];
                }
                sum += arr[i];
            }
            Console.WriteLine("[ " + String.Join(", ", arr) + "]");
            Console.WriteLine($"Highest value: {highest}\nLowest value: {lowest}\nSum: {sum}");
            return arr;
        }

        static string coinFlip()
        {
            // Console.WriteLine("Flipping a coin!");
            int flip = random.Next(0, 2);
            string result = flip == 0 ? "Heads" : "Tails";
            // Console.WriteLine(result);
            return result;
        }
        
        static double tossMultipleCoins(int num)
        {
            int heads = 0;
            int tails = 0;
            for (int i = 0; i < num; i++)
            {
                string result = coinFlip();
                if (result == "Heads")
                {
                    heads++;
                }
                else
                {
                    tails++;
                }
            }
            Console.WriteLine($"Heads percentage: {(double)heads * 100 /(heads + tails)}%");
            return (double)heads/(heads+tails);
        }

        static string[] names()
        {
            string[] arr = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            Console.WriteLine("[ " + String.Join(", ", arr) + "]");
            for (int i = 0; i < arr.Length; i++)
            {
                int swap_idx = random.Next(0, arr.Length);
                string switchVal = arr[swap_idx];
                arr[swap_idx] = arr[i];
                arr[i] = switchVal;
            }
            Console.WriteLine("Shuffled:\n[ " + String.Join(", ", arr) + "]");
            string[] longNames = arr.Where(name => name.Length > 5).ToArray();
            Console.WriteLine("Long Names:\n[ " + String.Join(", ", longNames) + "]");
            return longNames;
        }
    }
}
