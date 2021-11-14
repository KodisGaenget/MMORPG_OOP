using System;
using System.Collections.Generic;


namespace GameLib
{
    public class Game
    {
        RoomHandler roomHandler;
        Database db = new();
        Player player;
        ItemLoader itemLoader;


        public Game(RoomHandler _roomHandler)
        {
            this.roomHandler = _roomHandler;
            PlayerLoader playerLoader = new(db, 1);
            itemLoader = new(db);
            player = playerLoader.GetCharacter();
            Start();
        }

        public void Start()
        {
            player.GetDefense(itemLoader);
            // Console.WriteLine($"You are in {roomHandler.GetRoomName(player.Position)}");
            // player.Inventory.RemoveItem(1);
            // player.ChangeHealth(300); //Lägger till eller tar bort hp på players upp till maxhp och ner till 0
            // player.Inventory.AddItem(1, 1); //Lägger till itemID: 1 i inventory
            // Console.WriteLine(player.ToString()); //Skriver ut player
            // System.Console.WriteLine(player.Name + " " + player.Equipment); //Skriver ut namn och nuvanade eq.
            // Console.Clear();

            //ConsoleUtils.TypeWriter(roomHandler.DescribeRoom(player.Position));
            // System.Console.WriteLine(roomHandler.DescribeRoom(player.Position));
            // foreach (var room in roomHandler.GetConnectedRooms(player.Position))
            // {
            //     Console.WriteLine(roomHandler.GetRoomName(room));
            // }

            Console.WriteLine("Tryck Enter för att Spara och Avsluta");
            Console.ReadLine();
            PlayerSaver playerSaver = new(db, player); //När detta objektskapas, sparas players/inventory och eq.


            //Console.Write($"1. Examine room\n2. Move to ");
        }
    }
}