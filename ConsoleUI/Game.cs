using GameLib;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Game
    {
        RoomHandler roomHandler;

        public Game(RoomHandler _roomHandler)
        {
            this.roomHandler = _roomHandler;
        }

        public void Start(int _roomID)
        {
            Console.Clear();
            Console.WriteLine($"You are in {roomHandler.GetRoomName(_roomID)}");
            ConsoleUtils.TypeWriter(roomHandler.DescribeRoom(1));
            Console.WriteLine($"Move to:");
            foreach (var roomID in roomHandler.GetConnectedRooms(_roomID))
            {
                Console.WriteLine(roomHandler.GetRoomName(roomID));
            }
        }
    }
}