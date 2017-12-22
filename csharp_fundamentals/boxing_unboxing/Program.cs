using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> objs = new List<object>();
            // Add the following values to the list: 7, 28, -1, true, "chair"
            objs.Add(7);
            objs.Add(28);
            objs.Add(-1);
            objs.Add(true);
            objs.Add("chair");
            // Loop through the list and print all values (Hint: Type Inference might help here!)
            // Add all values hat are int type together and output the sum
            int sum = 0;
            foreach (var item in objs)
            {
                Console.WriteLine($"typeof({item}) = {item.GetType()}");
                if (item is int)
                {
                    sum += (int)item;
                }
            }
            Console.WriteLine($"Sum = {sum}");
        }
    }
}
