using System;
using System.Collections.Generic;


namespace GameLib
{
    public class Game
    {
        RoomHandler roomHandler;
        public Database db = new();
        Player player;

        public Game(RoomHandler _roomHandler)
        {
            this.roomHandler = _roomHandler;
            PlayerLoader playerLoader = new(db, 1);
            playerLoader.Load();
            player = playerLoader.GetCharacter();
            Start(player.Position);
        }

        public void Start(int _roomID)
        {
            player.ChangeHealth(300);
            // player.Inventory.AddItem(1, 1);
            System.Console.WriteLine("Tryck enter för att spara");
            // Console.ReadLine();

            PlayerSaver playerSaver = new(db, player);

            // Console.WriteLine(player.ToString());
            // System.Console.WriteLine(player.Name + " " + player.Equipment);
            // Console.Clear();
            //Console.WriteLine($"You are in {roomHandler.GetRoomName(_roomID)}");
            // ConsoleUtils.TypeWriter(roomHandler.DescribeRoom(1));
            //Console.Write($"1. Examine room\n2. Move to ");
            // foreach (var roomID in roomHandler.GetConnectedRooms(_roomID))
            // {
            //     Console.WriteLine(roomHandler.GetRoomName(roomID));
            // }
        }
    }
}