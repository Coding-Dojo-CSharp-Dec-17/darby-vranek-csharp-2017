using System;

namespace wizard_ninja_samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Dave");
            Wizard wizard = new Wizard("Razmodius");
            Ninja ninja = new Ninja("Donatello");
            Samurai samurai = new Samurai("Tom Cruise");
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

    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Health = 50;
            Intelligence = 25;
            Console.WriteLine("Wizard " + name + " created");
        }

        public void Heal()
        {
            Health += 10 * Intelligence;
        }

        public void Fireball(object other)
        {
            Random random = new Random();
            if (other is Human)
            {
                Human human = (Human)other;
                human.Health -= random.Next(20, 51);
            }
        }
    }

    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
            Console.WriteLine("Ninja " + name + " created");
        }

        void Steal(object other)
        {
            Attack(other);
            Health += 10;
        }

        void GetAway()
        {
            Health -= 15;
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Health = 200;
            Console.WriteLine("Samurai " + name + " created");
        }

        void DeathBlow(object other)
        {
            if (other is Human)
            {
                Human human = other as Human;
                if (human.Health < 50)
                {
                    human.Health = 0;
                }
            }
        }

        void Meditate()
        {
            Health = 200;
        }
    }
}
