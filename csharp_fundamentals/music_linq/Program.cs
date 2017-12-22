using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            Console.WriteLine("There is only one artist in this collection from Mount Vernon, what is their name and age?");
            Artist vernon_artist = Artists.Where(artist => artist.Hometown == "Mount Vernon").First();
            Console.WriteLine($"-- { vernon_artist.RealName }, age { vernon_artist.Age }\n");

            Console.WriteLine("Who is the youngest artist in our collection of artists?");
            Artist youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"-- {youngest.RealName}, age {youngest.Age}\n");

            Console.WriteLine("Display all artists with 'William' somewhere in their real name");
            var williams = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach (Artist will in williams)
            {
                Console.WriteLine($"-- { will.RealName }");
            }

            Console.WriteLine("\nDisplay the 3 oldest artist from Atlanta");
            var atlanta_artists = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3);
            foreach(Artist artist in atlanta_artists)
            {
                Console.WriteLine($"-- {artist.ArtistName} ({artist.RealName}), age {artist.Age}");
            }
        }
    }
}
