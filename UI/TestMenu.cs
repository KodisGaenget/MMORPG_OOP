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
            game.player.ChangePosition(1);
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
                    if (game.roomHandler.CheckDirection(game.player.Position, Direction.North))
                    {
                        if (game.roomHandler.GetRoom(game.roomHandler.GetDirectionId(game.player.Position, Direction.North)).ItemRequiredToEnter != 0)
                        {
                            if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetDirectionId(game.player.Position, Direction.North))))
                            {
                                game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.North));
                            }
                            else
                            {
                                RoomIsLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.North));
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.North));
                        }
                    }
                    else
                    {
                        NoRoom("north");
                    }
                }
                // move east
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (game.roomHandler.CheckDirection(game.player.Position, Direction.East))
                    {
                        if (game.roomHandler.GetRoom(game.roomHandler.GetDirectionId(game.player.Position, Direction.East)).ItemRequiredToEnter != 0)
                        {
                            if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetDirectionId(game.player.Position, Direction.East))))
                            {
                                game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.East));
                            }
                            else
                            {
                                RoomIsLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.East));
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.East));
                        }
                    }
                    else
                    {
                        NoRoom("east");
                    }
                }
                // move south
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (game.roomHandler.CheckDirection(game.player.Position, Direction.South))
                    {
                        if (game.roomHandler.GetRoom(game.roomHandler.GetDirectionId(game.player.Position, Direction.South)).ItemRequiredToEnter != 0)
                        {
                            if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetDirectionId(game.player.Position, Direction.South))))
                            {
                                game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.South));
                            }
                            else
                            {
                                RoomIsLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.South));
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.South));
                        }
                    }
                    else
                    {
                        NoRoom("south");
                    }
                }
                // move west
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (game.roomHandler.CheckDirection(game.player.Position, Direction.West))
                    {
                        if (game.roomHandler.GetRoom(game.roomHandler.GetDirectionId(game.player.Position, Direction.West)).ItemRequiredToEnter != 0)
                        {
                            if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetDirectionId(game.player.Position, Direction.West))))
                            {
                                game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.West));
                            }
                            else
                            {
                                RoomIsLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.West));
                            }
                        }
                        else
                        {
                            game.player.ChangePosition(game.roomHandler.GetDirectionId(game.player.Position, Direction.West));
                        }
                    }
                    else
                    {
                        NoRoom("west");
                    }
                }

                if (keyPressed.Key == ConsoleKey.I)
                {
                    Inventory();
                }

                if (keyPressed.Key == ConsoleKey.H)
                {
                    Help();
                }

            }

        }

        private void Help()
        {
            Console.Clear();
            ConsoleUtils.Yellow("\u25bc");
            Console.Write(" - Current position\n");
            ConsoleUtils.Red("\u2764");
            Console.Write(" - Current health\n");
            ConsoleUtils.Yellow("\u2315");
            Console.Write(" - Search room\n");
            ConsoleUtils.Green("\u2191");
            Console.Write(" - Room to the North. Use up arrow key to navigate there.\n");
            ConsoleUtils.Green("\u2192");
            Console.Write(" - Room to the East. Use right arrow key to navigate there.\n");
            ConsoleUtils.Green("\u2193");
            Console.Write(" - Room to the South. Use down arrow key to navigate there.\n");
            ConsoleUtils.Green("\u2190");
            Console.Write(" - Room to the West. Use left arrow key to navigate there.\n");
            ConsoleUtils.Yellow("\u25a3");
            Console.Write(" - Inventory. Press \"I\" to open.\n");
            Console.ReadKey(true);


        }

        private void NoRoom(string s)
        {
            Console.Clear();
            Console.WriteLine($"You charge face first into the {s}ern wall almost breaking your nose, you see stars.\n");
            ConsoleUtils.Red("You loose 5 hp");
            Console.ReadKey(true);
            game.player.CurrentHealth -= 5;

        }

        private void RoomIsLocked(int _roomID)
        {
            Console.WriteLine($"{game.roomHandler.GetRoomName(_roomID)} is locked. You will need to find a the {game.roomHandler.GetRoomName(_roomID)} key to unlock it.");
        }

        private void Inventory()
        {
            Console.Clear();
            ConsoleUtils.Yellow("\u25a3");
            Console.Write(" Inventory \n");
            foreach (var item in game.player.Inventory.GetInventory())
            {
                Console.WriteLine($"{game.itemLoader.GetKeyDetails(item.Key).Name}");
            }
            Console.ReadKey(true);
        }

        private void Print()
        {
            InfoBar();
            RoomDescription();
        }

        private void InfoBar()
        {
            Console.Write("| ");
            ConsoleUtils.Yellow("\u25bc");
            Console.Write($" {game.roomHandler.GetRoomName(game.player.Position)} | ");
            ConsoleUtils.Red("\u2764 ");
            Console.Write($" {game.player.CurrentHealth} | ");
            if (!game.player.IsRoomExamined(game.player.Position))
            {
                ConsoleUtils.Yellow("\u2315");
                Console.Write(" [S]earch | ");
            }
            if (game.roomHandler.CheckDirection(game.player.Position, Direction.North))
            {
                ConsoleUtils.Green("\u2191 ");
                Console.Write($"{game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.North))} ");
            }
            if (game.roomHandler.CheckDirection(game.player.Position, Direction.East))
            {
                ConsoleUtils.Green("\u2192 ");
                Console.Write($"{game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.East))} ");
            }
            if (game.roomHandler.CheckDirection(game.player.Position, Direction.South))
            {
                ConsoleUtils.Green("\u2193 ");
                Console.Write($"{game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.South))} ");
            }
            if (game.roomHandler.CheckDirection(game.player.Position, Direction.West))
            {
                ConsoleUtils.Green("\u2190 ");
                Console.Write($"{game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.West))} ");
            }
            Console.Write("| ");
            ConsoleUtils.Yellow("\u25a3");
            Console.Write(" [I]nventory | ");
            ConsoleUtils.Yellow("?");
            Console.Write(" [H]elp |\n\n");

        }

        private void RoomDescription()
        {
            ConsoleUtils.BreakLine(game.roomHandler.DescribeRoom(game.player.Position));
        }
    }
}
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
