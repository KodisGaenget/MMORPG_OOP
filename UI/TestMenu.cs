using System;
using GameLib;

namespace UI
{
    public class TestMenu
    {
        Game game;
        Room currentRoom;

        public TestMenu(Game game)
        {
            this.game = game;
            currentRoom = game.roomHandler.GetRoom(game.player.Position);
        }

        public void Run()
        {
            game.player.ChangePosition(9);
            currentRoom = game.roomHandler.GetRoom(game.player.Position);
            currentRoom.RoomExamined = true;
            Print();
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine($"You enter the {currentRoom.Name}\n");

            Console.WriteLine($"{currentRoom.Description}\n\n");

            if (!currentRoom.RoomExamined)
            {
                Console.WriteLine($"Examine {currentRoom.Name}");
            }
            else
            {
                if (currentRoom.ItemInRoomID != null)
                {
                    Console.WriteLine($"Snag {game.itemLoader.GetKeyDetails(currentRoom.ItemInRoomID.GetValueOrDefault()).Name}");
                }
                else
                {
                    Console.WriteLine($"You have found nothing of value in the {currentRoom.Name}");
                }
            }

            if (currentRoom.North != null)
            {
                Console.WriteLine($"Go to {game.roomHandler.GetRoomName(currentRoom.North.GetValueOrDefault())}");
            }
            if (currentRoom.East != null)
            {
                Console.WriteLine($"Go to {game.roomHandler.GetRoomName(currentRoom.East.GetValueOrDefault())}");
            }
            if (currentRoom.South != null)
            {
                Console.WriteLine($"Go to {game.roomHandler.GetRoomName(currentRoom.South.GetValueOrDefault())}");
            }
            if (currentRoom.West != null)
            {
                Console.WriteLine($"Go to {game.roomHandler.GetRoomName(currentRoom.West.GetValueOrDefault())}");
            }
        }
    }
}