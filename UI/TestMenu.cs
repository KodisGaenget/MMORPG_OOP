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
            ConsoleKeyInfo keyPressed;

            while (true)
            {
                // check if room exists
                // check if room is locked
                //      if room is locked check if key is in inventory
                // move player



                Console.Clear();
                Print();
                keyPressed = Console.ReadKey(true);


                // move north
                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (currentRoom.North != null)
                    {
                        if (game.roomHandler.IsRoomLocked(currentRoom.North.GetValueOrDefault()))
                        {
                            foreach (var item in game.player.Inventory.GetInventory())
                            {
                                if (item.Key == game.roomHandler.RequiredItem(currentRoom.North.GetValueOrDefault()))
                                {
                                    game.player.ChangePosition(currentRoom.North.GetValueOrDefault());
                                    currentRoom = game.roomHandler.GetRoom(game.player.Position);
                                }
                                else
                                {
                                    Console.WriteLine("Room is locked");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(currentRoom.North.GetValueOrDefault());
                            currentRoom = game.roomHandler.GetRoom(game.player.Position);
                        }
                    }
                    else
                    {

                        Console.Clear();
                        Console.WriteLine("You charge face first into the northen wall almost breaking your nose, you see stars");
                        Console.ReadKey(true);
                    }
                }




                // move east
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (currentRoom.East != null)
                    {
                        if (game.roomHandler.IsRoomLocked(currentRoom.East.GetValueOrDefault()))
                        {
                            Console.WriteLine("Room is locked");
                        }
                        else
                        {
                            game.player.ChangePosition(currentRoom.East.GetValueOrDefault());
                            currentRoom = game.roomHandler.GetRoom(game.player.Position);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the eastern wall almost breaking your nose, you see stars");
                        Console.ReadKey(true);
                    }
                }




                // move south
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (currentRoom.South != null)
                    {
                        if (game.roomHandler.IsRoomLocked(currentRoom.South.GetValueOrDefault()))
                        {
                            Console.WriteLine("Room is locked");
                        }
                        else
                        {
                            game.player.ChangePosition(currentRoom.South.GetValueOrDefault());
                            currentRoom = game.roomHandler.GetRoom(game.player.Position);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the southern wall almost breaking your nose, you see stars");
                        Console.ReadKey(true);
                    }
                }



                // move west
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    // check if there is a room to the west
                    if (currentRoom.West != null)
                    {
                        // check if the room is locked
                        if (game.roomHandler.IsRoomLocked(currentRoom.West.GetValueOrDefault()))
                        {
                            // check if the player has the required item in inventory
                            if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(currentRoom.West.GetValueOrDefault())))
                            {
                                game.player.ChangePosition(currentRoom.West.GetValueOrDefault());
                                currentRoom = game.roomHandler.GetRoom(game.player.Position);
                            }
                            else
                            {
                                Console.WriteLine($"The door to the {game.roomHandler.GetRoomName(currentRoom.West.GetValueOrDefault())} is locked. You need to find a key");
                                Console.ReadKey(true);
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(currentRoom.West.GetValueOrDefault());
                            currentRoom = game.roomHandler.GetRoom(game.player.Position);
                        }
                    }
                    // if there is no room to the west, prompt message
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the western wall almost breaking your nose, you see stars");
                        Console.ReadKey(true);
                    }
                }

                // examine room
                if (keyPressed.Key == ConsoleKey.E)
                {
                    if (!game.roomHandler.IsRoomExaminated(game.player.Position))
                    {
                        Console.Clear();
                        Console.WriteLine(game.roomHandler.ExamineRoom(game.player.Position));
                    }
                }


                // take item in room
                if (keyPressed.Key == ConsoleKey.T)
                {
                    if (game.roomHandler.IsRoomExaminated(game.player.Position) && currentRoom.ItemInRoomID != null)
                    {
                        game.player.Inventory.AddItem(currentRoom.ItemInRoomID.GetValueOrDefault(), 1);
                    }
                }

                // show inventory
                if (keyPressed.Key == ConsoleKey.I)
                {
                    Console.Clear();
                    Console.WriteLine("Inventory:");
                    foreach (var item in game.player.Inventory.GetInventory())
                    {
                        Console.WriteLine(game.itemLoader.GetKeyDetails(item.Key).Name);
                    }
                    Console.ReadKey(true);
                }

            }

        }

        public void Print()
        {
            // Print room name
            Console.WriteLine($"{game.roomHandler.GetRoomName(game.player.Position)}\n\n");

            // Print room description
            Console.WriteLine($"{game.roomHandler.DescribeRoom(game.player.Position)}\n");

            if (!game.roomHandler.IsRoomExaminated(game.player.Position))
            {
                Console.WriteLine("[E]xamine room");
            }
            else
            {
                if (game.roomHandler.GetRoom(game.player.Position).ItemInRoomID != null)
                {
                    Console.WriteLine($"[T]ake {game.itemLoader.GetKeyDetails(game.roomHandler.GetRoom(game.player.Position).ItemInRoomID.GetValueOrDefault()).Name}");
                }
                else
                {
                    Console.WriteLine($"You have searched through the {game.roomHandler.GetRoomName(game.player.Position)} but you have found nothing of value. What a waste of time.\n\n");
                }
            }

            Console.WriteLine("\n-- Move --");

            if (game.roomHandler.GetRoom(game.player.Position).North != null)
            {
                Console.WriteLine($"\u2191 {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).North.GetValueOrDefault())}");
            }
            if (game.roomHandler.GetRoom(game.player.Position).East != null)
            {
                Console.WriteLine($"\u2192 {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).East.GetValueOrDefault())}");
            }
            if (game.roomHandler.GetRoom(game.player.Position).South != null)
            {
                Console.WriteLine($"\u2193 {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).South.GetValueOrDefault())}");
            }
            if (game.roomHandler.GetRoom(game.player.Position).West != null)
            {
                Console.WriteLine($"<- {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault())}");
            }

        }




    }
}