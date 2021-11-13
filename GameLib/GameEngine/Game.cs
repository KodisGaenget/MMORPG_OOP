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
            CharacterLoader characterLoader = new(db);
            characterLoader.Load();
            player = characterLoader.GetCharacter();
            Start(player.Position);
        }

        public void Start(int _roomID)
        {
            Console.WriteLine(player.ToString());
            System.Console.WriteLine(player.Equipment);
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