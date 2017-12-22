using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        // Create an array to hold integer values 0 through 9
        int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        // Create an array of length 10 that alternates between true and false values, starting with true
        bool[] truefalse = { true, false, true, false, true, false, true, false, true, false };
        static void Main(string[] args)
        {
            flavors();
        }

        static int[,] multTable()
        // With the values 1-10, use code to generate a multiplication table like the one below.
        // Use a multidimensional array to store all values
        {
            int[,] table = new int[10,10];
            for (int x = 0; x < 10; x++)
            {
                string row = "[ ";
                for (int y = 0; y < 10; y++)
                {
                    table[x,y] = (x + 1) * (y + 1);
                    row += $"{(x + 1) * (y + 1)}, ";
                }
                row += "]";
                Console.WriteLine(row);
            }
            return table;
        }

        static void flavors()
        {
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] names = { "Tim", "Martin", "Nikki", "Sara" };
            // Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> flavors = new List<string>();
            flavors.Add("Salted Caramel Core");
            flavors.Add("Strawberry Cheesecake");
            flavors.Add("Chunky Monkey");
            flavors.Add("Phish Food");
            flavors.Add("Americone Dream");
            flavors.Add("The Tonight Dough");
            flavors.Add("Chocolate Fudge Brownie");
            flavors.Add("Chocolate Chip Cookie Dough");
            flavors.Add("Cherry Garcia");
            flavors.Add("Half Baked");
            // Output the length of this list after building it
            Console.WriteLine("Length: " + flavors.Count);
            // Output the third flavor in the list, then remove this value.
            Console.WriteLine($"flavors[3]: { flavors[3] }");
            flavors.Remove(flavors[3]);
            // Output the new length of the list (Note it should just be one less~)
            Console.WriteLine("New length: " + flavors.Count);
            // Create a Dictionary that will store both string keys as well as string values
            Dictionary<string, string> favoriteFlavors = new Dictionary<string, string>();
            Random random = new Random();
            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            foreach (string name in names)
            {
                favoriteFlavors.Add(name, null);
            }
            // For each name key, select a random flavor from the flavor list above and store it as the value
            foreach (string name in names)
            {
                favoriteFlavors[name] = flavors[random.Next(0, flavors.Count)];
            }
            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach (KeyValuePair<string, string> favorite in favoriteFlavors)
            {
                Console.WriteLine($"{favorite.Key}'s favorite flavor is {favorite.Value}");
            }
        }
    }
}
