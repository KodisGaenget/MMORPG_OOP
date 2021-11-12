using System;
using System.Collections.Generic;
using GameLib;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomHandler roomHandler = new();

            List<Room> allRooms = new()
            {
                new Room(1, "Entrance", "You have entered a dark hallway. The door slams shut and you hear the lock turning behind you...\n\nYou lift your torch and see blablabla...\n\nWhat would you like to do?\n\n", "", new List<int> { 2 }),
                new Room(2, "Room 2", "This is room 2", "", new List<int> { 1, 3 }),
                new Room(3, "Room 3", "This is room 3", "", new List<int> { 2, 4, 5 }),
                new Room(4, "Room 4", "This is room 4", "", new List<int> { 3 }),
                new Room(5, "Room 5", "This is room 5", "", new List<int> { 4, 6 }),
                new Room(6, "Room 6", "This is room 6", "", new List<int> { 5 })
            };

            roomHandler.AddRooms(allRooms);
            Game game = new(roomHandler);
            Player player = new();
            game.Start(player.Position);

            player.ChangeHealth(-100);
            // player.Save(game.db);

            // Weapon Daggers = new("Kökskniv", 1, 1000000, 4, 6, WeaponType.Daggers);
            // Weapon DildoKniv = new("Vässad dildo", 2, 9000000, 12, 18, WeaponType.Daggers);

            // List<Weapon> weaponList = new();

            // weaponList.Add(DildoKniv);
            // weaponList.Add(Daggers);

            // foreach (var item in weaponList)
            // {
            //     Console.WriteLine($"{item.MinDamage}  {item.MaxDamage}");
            // }

        }
    }
}
