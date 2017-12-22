using System;
using DbConnection;

namespace simple_crud
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
        }

        static void Read(string message="")
        {
            Console.Clear();
            var users = DbConnector.Query("SELECT * FROM users;");
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
            foreach (var user in users)
            {
                Console.WriteLine("# " + user["first_name"] + " " + user["last_name"] + " - favorite number: " + user["favorite_number"]);
            }
            Console.WriteLine("\nType `create` to add a new record to table");
            string input = Console.ReadLine();
            if (input.ToLower() == "create")
            {
                Create();
            }
            else
            {
                Read("Invalid input!\n");
            }
        }

        static void Create()
        {
            Console.Clear();
            Console.WriteLine("First name:");
            string fn = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string ln = Console.ReadLine();
            Console.WriteLine("Favorite Number:");
            int num = 0;
            string num_str = Console.ReadLine();
            int.TryParse(num_str, out num);
            DbConnector.Execute($"INSERT INTO users (first_name, last_name, favorite_number) VALUES ('{fn}', '{ln}', {num});");
            Read($"{fn} {ln} added!\n");
        }
    }
}
