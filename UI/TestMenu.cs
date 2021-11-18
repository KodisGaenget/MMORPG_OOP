using System;
using GameLib;
using Characters;

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
                    if (currentRoom.West != null)
                    {
                        if (game.roomHandler.IsRoomLocked(currentRoom.West.GetValueOrDefault()))
                        {
                            foreach (var item in game.player.Inventory.GetInventory())
                            {
                                if (item.Key == game.roomHandler.RequiredItem(currentRoom.West.GetValueOrDefault()))
                                {
                                    game.player.ChangePosition(currentRoom.West.GetValueOrDefault());
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
                            game.player.ChangePosition(currentRoom.West.GetValueOrDefault());
                            currentRoom = game.roomHandler.GetRoom(game.player.Position);
                        }
                    }
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
                    if (game.roomHandler.IsRoomExaminated(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomID != null)
                    {
                        game.player.Inventory.AddItem(game.roomHandler.GetRoom(game.player.Position).ItemInRoomID.GetValueOrDefault(), 1);
                    }
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