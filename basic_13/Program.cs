using System;

namespace basic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            // printAll();
            // printOdd();
            // printSum();
            // iterateArray(new int[] {1, 3, 5, 7, 9, 13});
            // getAverage(new int[] {2, 10, 3, 11});
            // oddArray();
            // greaterThanY(new int[] {1, 3, 5, 7}, 3);
            // squareValues(new int[] {1, 5, 10, -2});
            // eliminateNegatives(new int[] {1, 5, 10, -2});
            // minMaxAverage(new int[] {1, 5, 10, -2});
            // shiftValues(new int[] {1, 5, 10, 7, -2});
            // numberToString(new object[] {-1,-3,2});
        }

        // Write a program (sets of instructions) that would print all the numbers from 1 to 255.
        static void printAll()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }

        // Write a program (sets of instructions) that would print all the odd numbers from 1 to 255.
        static void printOdd()
        {
            for (int i = 1; i < 256; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Write a program that would print the numbers from 0 to 255 but this time, it would also print the sum of the numbers that have been printed so far. 
        static void printSum()
        {
            int sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += i;
                Console.WriteLine($"New number: {i} | Sum: {sum}");
            }
        }

        // Given an array X, say [1,3,5,7,9,13], write a program that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.
        static void iterateArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }

        // Write a program (sets of instructions) that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.
        static void findMax(int[] arr)
        {
            int highest = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > highest)
                {
                    highest = arr[i];
                }
            }
            Console.WriteLine($"Highest: {highest}");
        }

        // Write a program that takes an array, and prints the AVERAGE of the values in the array. For example for an array [2, 10, 3], your program should print an average of 5. Again, make sure you come up with a simple base case and write instructions to solve that base case first, then test your instructions for other complicated cases. You can use a count function with this assignment.
        static void getAverage(int[] arr)
        {
            int total = 0;
            foreach (int num in arr)
            {
                total += num;
            }
            Console.WriteLine($"Average: {(float)total / arr.Length}");
        }

        // Write a program that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
        static void oddArray()
        {
            int[] arr = new int[(int)Math.Ceiling(255f / 2)];
            for (int i = 1; i < 256; i++) {
                if (i % 2 != 0)
                {
                    arr[(int)(i - 1)/2] = i;
                }
            }
            Console.WriteLine(String.Join(", ", arr));
        }

        // Write a program that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will print 2 (since there are two values in the array that are greater than 3).
        static void greaterThanY(int[] arr, int y)
        {
            int total = 0;
            foreach (int num in arr)
            {
                if (num > y)
                {
                    total++;
                }
            }
            Console.WriteLine($"Total count greater than {y}: {total}");
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm (sets of instructions) that multiplies each value in the array by itself. When the program is done, the array x should have values that have been squared, say [1, 25, 100, 4].
        static void squareValues(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * arr[i];
            }
            Console.WriteLine(String.Join(", ", arr));
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm that replaces any negative number with the value of 0. When the program is done, x should have no negative values, say [1, 5, 10, 0].

        static void eliminateNegatives(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
            Console.WriteLine(String.Join(", ", arr));
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        static void minMaxAverage(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int total = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                else if (arr[i] > max)
                {
                    max = arr[i];
                }
                total += arr[i];
            }
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.WriteLine($"Average: {(float)total / arr.Length}");
        }

        // Given any array x, say [1, 5, 10, 7, -2], create an algorithm that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        static void shiftValues(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = 0;
            Console.WriteLine(String.Join(", ", arr));
        }
        
        // Write a program that takes an array of numbers and replaces any negative number with the string 'Dojo'. For example, if array x is initially [-1, -3, 2] your function should return an array with values ['Dojo', 'Dojo', 2].
        static void numberToString(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is int && (int)arr[i] < 0)
                {
                    arr[i] = "Dojo";
                }
            }
            Console.WriteLine(String.Join(", ", arr));
        }
    }
}