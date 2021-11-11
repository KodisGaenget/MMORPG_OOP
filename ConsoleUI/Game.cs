using GameLib;
using System;

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
            Console.WriteLine(roomHandler.DescribeRoom(_roomID));
        }
    }
}