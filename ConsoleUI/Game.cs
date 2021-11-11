using GameLib;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Game
    {
        RoomHandler roomHandler;
        Database db = new();

        public Game(RoomHandler _roomHandler)
        {
            this.roomHandler = _roomHandler;
            LoadCharacter();
        }

        public void Start(int _roomID)
        {
            Console.Clear();
            Console.WriteLine($"You are in {roomHandler.GetRoomName(_roomID)}");
            ConsoleUtils.TypeWriter(roomHandler.DescribeRoom(1));
            Console.Write($"1. Examine room\n2. Move to ");
            foreach (var roomID in roomHandler.GetConnectedRooms(_roomID))
            {
                Console.WriteLine(roomHandler.GetRoomName(roomID));
            }
        }

        public Player LoadCharacter()
        {
            Player player = null;
            foreach (var character in db.LoadPlayer())
            {
                player = character;
            }
            return player;
        }
    }
}