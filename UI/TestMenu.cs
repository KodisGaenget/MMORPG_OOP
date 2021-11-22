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
                if (keyPressed.Key == ConsoleKey.S)
                {
                    game.player.ExamineRoom(game.player.Position);
                }
                if (keyPressed.Key == ConsoleKey.T)
                {
                    if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId != 0)
                    {
                        game.player.Inventory.AddItem(game.roomHandler.TakeItem(game.player.Position), 1);
                    }
                }

            }

        }

        private void Help()
        {
            Console.Clear();
            Console.WriteLine("Help");
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
            Console.WriteLine($"\n{game.roomHandler.GetRoomName(_roomID)} is locked. You will need to find a the {game.roomHandler.GetRoomName(_roomID)} key to unlock it.");
            Console.ReadKey(true);
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
            InfoBar2();
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
        private void InfoBar2()
        {
            ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White);

            if (game.player.CurrentHealth < game.player.OriginalHealth / 2.5) Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White));
            else if (game.player.CurrentHealth < game.player.OriginalHealth / 1.5) Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White));
            else Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White));

            if (!game.player.IsRoomExamined(game.player.Position))
            {
                ConsoleUtils.ChangeColor("Write", $"\u2315 S", ConsoleColor.Yellow);
                ConsoleUtils.ChangeColor("Write", "earch | ", ConsoleColor.White);
            }

            var inventory = ConsoleUtils.ChangeColor("Write", $"\u25a3 I", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "nventory | ", ConsoleColor.White);
            var help = ConsoleUtils.ChangeColor("Write", $"? H", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "elp | \n\n", ConsoleColor.White);

            if (game.roomHandler.CheckDirection(game.player.Position, Direction.North))
            {
                var directionColor = game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.North));
                var lockedBool = game.roomHandler.IsRoomLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.North));

                if (lockedBool) ConsoleUtils.ChangeColor("WriteLine", $"\u2191 {directionColor}", ConsoleColor.Red);
                else ConsoleUtils.ChangeColor("WriteLine", $"\u2191 {directionColor}", ConsoleColor.Green);
            }

            if (game.roomHandler.CheckDirection(game.player.Position, Direction.East))
            {
                var directionColor = game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.East));
                var lockedBool = game.roomHandler.IsRoomLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.East));

                if (lockedBool) ConsoleUtils.ChangeColor("WriteLine", $"\u2192 {directionColor}", ConsoleColor.Red);
                else ConsoleUtils.ChangeColor("WriteLine", $"\u2192 {directionColor}", ConsoleColor.Green);
            }

            if (game.roomHandler.CheckDirection(game.player.Position, Direction.South))
            {
                var directionColor = game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.South));
                var lockedBool = game.roomHandler.IsRoomLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.South));

                if (lockedBool) ConsoleUtils.ChangeColor("WriteLine", $"\u2193 {directionColor}", ConsoleColor.Red);
                else ConsoleUtils.ChangeColor("WriteLine", $"\u2193 {directionColor}", ConsoleColor.Green);
            }

            if (game.roomHandler.CheckDirection(game.player.Position, Direction.West))
            {
                var directionColor = game.roomHandler.GetRoomName(game.roomHandler.GetDirectionId(game.player.Position, Direction.West));
                var lockedBool = game.roomHandler.IsRoomLocked(game.roomHandler.GetDirectionId(game.player.Position, Direction.West));

                if (lockedBool) ConsoleUtils.ChangeColor("WriteLine", $"\u2190 {directionColor}", ConsoleColor.Red);
                else ConsoleUtils.ChangeColor("WriteLine", $"\u2190 {directionColor}", ConsoleColor.Green);
            }
            ConsoleUtils.ChangeColor("WriteLine", $"\n\u25bc {game.roomHandler.GetRoomName(game.player.Position)}\n", ConsoleColor.Yellow);
        }

        private void RoomDescription()
        {
            ConsoleUtils.BreakLine(game.roomHandler.DescribeRoom(game.player.Position));
            if (game.player.IsRoomExamined(game.player.Position))
            {
                Console.WriteLine($"\n\n{game.roomHandler.ExamineRoom(game.player.Position)}");
            }
        }
    }
}