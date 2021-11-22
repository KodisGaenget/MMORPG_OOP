using System;
using System.Collections.Generic;
using GameLib;

namespace UI
{
    public class RunGame
    {
        Game game;


        public RunGame(Game game)
        {
            this.game = game;
            game.player.ChangePosition(1);
        }

        public void Run()
        {
            string prompt = "Welcome to Wörld of Virgincraft: The Saga of the Poopy Pants in the Basement!";
            List<string> options = new List<string> { "Play the game", "Settings", "Credits", "Exit" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    GameLoop();
                    break;

                case 1:
                    Console.Write("Settings");   // Settings
                    break;

                case 2:
                    Console.Write("Credits");    // Credits
                    break;

                case 3:
                    Console.Write("Exit");
                    Environment.Exit(0);
                    break;
            }
        }

        private void GameLoop()
        {
            ConsoleKeyInfo keyPressed;
            while (true)
            {
                Console.Clear();
                Print();
                keyPressed = Console.ReadKey(true);

                #region Movement
                // Move North
                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    Movement(Direction.North);
                }
                // Move East
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    Movement(Direction.East);
                }
                // Move South
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    Movement(Direction.South);
                }
                // Move West
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    Movement(Direction.West);
                }
                #endregion 

                #region UIbar
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
                    game.player.AddExamineRoom(game.player.Position);
                }

                if (keyPressed.Key == ConsoleKey.T)
                {
                    if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId != 0)
                    {
                        game.player.Inventory.AddItem(game.roomHandler.TakeItem(game.player.Position), 1);
                    }
                }
                #endregion 
            }
        }

        private void Movement(Direction direction)
        {
            if (game.roomHandler.CheckDirection(game.player.Position, direction))
            {
                if (game.roomHandler.GetRoom(game.roomHandler.GetDirectionId(game.player.Position, direction)).ItemRequiredToEnter != 0)
                {
                    if (game.player.Inventory.IsItemIDInInventory(game.roomHandler.RequiredItem(game.roomHandler.GetDirectionId(game.player.Position, direction))))
                    {
                        MovePlayer(game.roomHandler.GetDirectionId(game.player.Position, direction));
                    }
                    else
                    {
                        RoomIsLocked(game.roomHandler.GetDirectionId(game.player.Position, direction));
                    }
                }
                else
                {
                    MovePlayer(game.roomHandler.GetDirectionId(game.player.Position, direction));
                }
            }
            else
            {
                NoRoom(direction.ToString());
            }
        }

        private void MovePlayer(int _roomID)
        {
            if (game.roomHandler.GetRoom(_roomID).EnemyInRoom != 0)
            {
                // trigger fight
            }
            game.player.ChangePosition(_roomID);
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
            InfoBar();
            RoomText();
        }

        private void InfoBar()
        {
            ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White);
            // Console.Write(game.player.CurrentPower);
            // Console.Write(game.player.Power);
            // Console.Write(game.player.Armor);
            // Console.Write(game.player.BaseDamage);
            if (game.player.CurrentHealth < game.player.OriginalHealth / 2.5) Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White));
            else if (game.player.CurrentHealth < game.player.OriginalHealth / 1.5) Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White));
            else Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White));

            if (game.player.CurrentPower < game.player.Power / 2.5) Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White));
            else if (game.player.CurrentPower < game.player.Power / 1.5) Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White));
            else Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White));

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

        private void RoomText()
        {
            ConsoleUtils.BreakLine(game.roomHandler.DescribeRoom(game.player.Position));
            if (game.player.IsRoomExamined(game.player.Position))
            {
                Console.WriteLine($"\n\n{game.roomHandler.ExamineRoom(game.player.Position)}");
            }
            if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId != 0)
            {
                Console.WriteLine("You found: \n");
                Console.WriteLine(game.itemLoader.GetKeyDetails(game.roomHandler.GetRoom(game.player.Position).ItemInRoomId).Name);
            }
        }
    }
}