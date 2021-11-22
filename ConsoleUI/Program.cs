using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameLib;
using Characters;
using System.Threading;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new(1); //1 = Spelarens id;

            // List<Room> allRooms = new()
            // {
            //     new Room(1, "Entrance", "You have entered a dark hallway. The door slams shut and you hear the lock turning behind you...\n\nYou lift your torch and see blablabla...\n\nWhat would you like to do?\n\n", "", new List<int> { 2 }),
            //     new Room(2, "Room 2", "This is room 2", "", new List<int> { 1, 3 }),
            //     new Room(3, "Room 3", "This is room 3", "", new List<int> { 2, 4, 5 }),
            //     new Room(4, "Room 4", "This is room 4", "", new List<int> { 3 }),
            //     new Room(5, "Room 5", "This is room 5", "", new List<int> { 4, 6 }),
            //     new Room(6, "Room 6", "This is room 6", "", new List<int> { 5 })
            // };

            // roomHandler.AddRooms(allRooms);

            game.combatHandler.StartNewCombat(game.player, game.spawner.GetEnemy(4), game.itemLoader);
            string choise = "";
            while (!game.combatHandler.combatOver)
            {
                MainMenu combatMenu = new(game.combatHandler.combatLog);
                if (!game.combatHandler.playersTurn)
                {
                    game.combatHandler.ContinueCombat();
                    Thread.Sleep(100);
                }
                else
                {
                    choise = combatMenu.Run(game.combatHandler.playerHealth, game.combatHandler.enemyHealth);
                    if (choise == "Attack")
                    {
                        game.combatHandler.ContinueCombat();
                    }
                    if (choise == "Inventory")
                    {
                        InventoryMenu inventoryMenu = new(game);
                    }
                    if (choise == "Escape")
                    {
                        System.Console.WriteLine("You escaped the fight!");
                        break;
                    }
                }
                if (game.combatHandler.combatOver)
                {
                    System.Console.WriteLine(game.combatHandler.result);
                }

            }


            //game.Start();

            //player.ChangeHealth(-100);
            // player.Save(game.db);

        }
    }
}
