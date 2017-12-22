using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Human
    {
        public string Name;
        public int Strength = 3;
        public int Intelligence = 3;
        public int Dexterity = 3;
        public int Health = 100;


        public void Attack(object other)
        {
            if (other is Human)
            {
                Human other_human = other as Human;
                other_human.Health -= 5 * Strength;
            }
        }


        public Human(string name)
        {
            Name = name;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }
    }
}
