using System;
using GameLib;

namespace UI
{
    public class TestMenu
    {
        Game game;
        public TestMenu(Game game)
        {
            this.game = game;
            Console.CursorVisible = false;
            // gameEquals.player.ChangePosition(2);
            // Get
            // GetCurrentRoom() roomHandler.GetRoom(game.player.Position);
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
                    if (game.roomHandler.CheckNorth(game.player.Position))
                    {
                        if (game.roomHandler.IsRoomLocked(game.roomHandler.GetRoom(game.player.Position).North.GetValueOrDefault()))
                        {
                            foreach (var item in game.player.Inventory.GetInventory())
                            {
                                if (item.Key == game.roomHandler.RequiredItem(game.roomHandler.GetRoom(game.player.Position).North.GetValueOrDefault()))
                                {
                                    game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).North.GetValueOrDefault());
                                }
                                else
                                {
                                    Console.WriteLine("Room is locked");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                        else game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).North.GetValueOrDefault());
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the northen wall almost breaking your nose, you see stars");
                        game.player.CurrentHealth -= 5;
                        Console.ReadKey(true);
                    }
                }

                // move east
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (game.roomHandler.CheckEast(game.player.Position))
                    {
                        if (game.roomHandler.IsRoomLocked(game.roomHandler.GetRoom(game.player.Position).East.GetValueOrDefault())) Console.WriteLine("Room is locked");
                        else game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).East.GetValueOrDefault());
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the eastern wall almost breaking your nose, you see stars");
                        game.player.CurrentHealth -= 5;
                        Console.ReadKey(true);
                    }
                }

                // move south
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (game.roomHandler.CheckSouth(game.player.Position))
                    {
                        if (game.roomHandler.IsRoomLocked(game.roomHandler.GetRoom(game.player.Position).South.GetValueOrDefault())) Console.WriteLine("Room is locked.");
                        else game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).South.GetValueOrDefault());
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the southern wall almost breaking your nose, you see stars");
                        game.player.CurrentHealth -= 5;
                        Console.ReadKey(true);
                    }
                }

                // move west
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    // check if there is a room to the west<
                    if (game.roomHandler.CheckWest(game.player.Position))
                    {
                        // check if the room is locked
                        if (game.roomHandler.IsRoomLocked(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault()))
                        {
                            // check if the player has the required item in inventory
                            if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault())))
                            {
                                game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault());
                            }
                            else
                            {
                                Console.WriteLine($"\nThe door to the {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault())} appears to be locked.\nMaybe there's a key around here somewhere?");
                                Console.ReadKey(true);
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault());
                        }
                    }

                    // if there is no room to the west, prompt message
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You charge face first into the western wall almost breaking your nose, you see stars");
                        game.player.CurrentHealth -= 5;
                        Console.ReadKey(true);
                    }
                }

                // examine room
                if (keyPressed.Key == ConsoleKey.E)
                {
                    if (!game.player.IsRoomExamined(game.player.Position))
                    {
                        Console.WriteLine("\n" + game.roomHandler.ExamineRoom(game.player.Position));
                        Console.ReadKey(true);
                    }
                    else
                    {
                        Console.WriteLine("\nRoom has already been examined.");
                        Console.ReadKey(true);
                    }
                }

                // take item in room
                if (keyPressed.Key == ConsoleKey.T)
                {
                    if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId != null)
                    {
                        game.player.Inventory.AddItem(game.roomHandler.GetRoom(game.player.Position).ItemInRoomId.GetValueOrDefault(), 1);
                        game.roomHandler.GetRoom(game.player.Position).ItemInRoomId = null;
                        Console.WriteLine("\n{item} has been added to your inventory.");
                        Console.ReadKey(true);
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
            Console.WriteLine($"{game.roomHandler.GetRoomName(game.player.Position).ToUpper()}\n\n");

            // Print room description
            Console.WriteLine($"{game.roomHandler.DescribeRoom(game.player.Position)}\n");

            if (!game.player.IsRoomExamined(game.player.Position))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[E]xamine Room");
                Console.ResetColor();
            }
            else
            {
                if (game.roomHandler.GetRoom(game.player.Position).ItemInRoomId != null) Console.WriteLine($"[T]ake {game.itemLoader.GetKeyDetails(game.roomHandler.GetRoom(game.player.Position).ItemInRoomId.GetValueOrDefault()).Name}");

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[E]xamine Room");
                    Console.ResetColor();
                    // Console.WriteLine($"You have searched through the {game.roomHandler.GetRoomName(game.player.Position)} but you have found nothing of value. What a waste of time.");
                }
            }

            Console.WriteLine("\n-- Move --");

            if (game.roomHandler.GetRoom(game.player.Position).North != null) Console.WriteLine($"\u2191 {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).North.GetValueOrDefault())}");
            if (game.roomHandler.GetRoom(game.player.Position).East != null) Console.WriteLine($"\u2192 {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).East.GetValueOrDefault())}");
            if (game.roomHandler.GetRoom(game.player.Position).South != null) Console.WriteLine($"\u2193 {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).South.GetValueOrDefault())}");
            if (game.roomHandler.GetRoom(game.player.Position).West != null) Console.WriteLine($"<- {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).West.GetValueOrDefault())}");


            // Försökte få till någon form av dynamisk keypress som byter ut ..roomHandler.Check{Compass} mot den knapp användaren trycker på, provade även konvertera string -> bool
            // string Compass;
            // if (keyPressed.Key == ConsoleKey.LeftArrow) Compass = "West";
            // if (keyPressed.Key == ConsoleKey.UpArrow) Compass = "North";
            // if (keyPressed.Key == ConsoleKey.RightArrow) Compass = "East";
            // if (keyPressed.Key == ConsoleKey.DownArrow) Compass = "South";
            // // move west
            // if (keyPressed.Key == ConsoleKey.LeftArrow || keyPressed.Key == ConsoleKey.RightArrow || keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.UpArrow )
            // {
            //     // check if there is a room to the west<
            //     if (game.roomHandler.Check{Compass}(game.player.Position))
            //     {                
            //         // check if the room is locked
            //         if (game.roomHandler.IsRoomLocked(game.roomHandler.GetRoom(game.player.Position).{Compass}.GetValueOrDefault()))
            //         {
            //             // check if the player has the required item in inventory
            //             if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetRoom(game.player.Position).{Compass}.GetValueOrDefault())))
            //             {
            //                 game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).{Compass}.GetValueOrDefault());
            //             }
            //             else
            //             {
            //                 Console.WriteLine($"\nThe door to the {game.roomHandler.GetRoomName(game.roomHandler.GetRoom(game.player.Position).{Compass}.GetValueOrDefault())} appears to be locked.\nMaybe there's a key around here somewhere?");
            //                 Console.ReadKey(true);
            //             }
            //         }
            //         else
            //         {
            //             game.player.ChangePosition(game.roomHandler.GetRoom(game.player.Position).{Compass}.GetValueOrDefault());
            //         }
            //     }

            //     // if there is no room in x direction, prompt message
            //     else
            //     {
            //         Console.Clear();
            //         Console.WriteLine($"You charge face first into the {Compass}ern wall almost breaking your nose, you see stars");
            //         game.player.CurrentHealth -= 5;
            //         Console.ReadKey(true);
            //     }
            // }
        }
    }
}