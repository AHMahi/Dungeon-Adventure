using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventures
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Let's start this adventure!!");
            Console.WriteLine("Enter your Hero Name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Enter your Hero's description: ");
            string playerDesc = Console.ReadLine();
            Player player = new Player(playerName, playerDesc);

            Item rifle = new Item(new string[] { "rifle" }, "a rifle", "This is a automatic rifle ...");
            Item shovel = new Item(new string[] { "shovel", "sword" }, "a shovel", "A shovel for digging");
        
            player.Inventory.Put(rifle);
            player.Inventory.Put(shovel);

            Bag myBag = new Bag(new string[] { "bag" }, "a backpack", "A small backpack to store items");
            player.Inventory.Put(myBag);

            Item honey = new Item(new string[] { "honey" }, "jar of honey", "A jar of honey to restore health");
            myBag.Inventory.Put(honey);

            Location cave = new Location(new string[] { "new location", "cave" }, "Dark cave", "You have entered a dark cave and can see something glowing");
            player.Location = cave;
            cave.Inventory.Put(rifle);

            Console.WriteLine("Enter 'quit' to Exit game");

            LookCommand look = new LookCommand(new string[] { "look" });
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Command - >");
                string command = Console.ReadLine();
                if (command.ToLower() != "quit")
                {
                    Console.WriteLine(look.Execute(player, command.Split()));
                }

                else
                {
                    Console.WriteLine("Exiting.........");
                    repeat = false;
                }
            }
            


            Console.ReadLine();
        }
    }
}
