using System;
using System.Collections.Generic;
using System.Threading;
using GameLib;
using GameEnums;

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
            string prompt = "Wörld of Gustavo’s evil reign";
            List<string> options = new List<string> { "Play the game", "Settings", "Exit" };
            Menu menu = new Menu(prompt, options, "", game, true);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    GameLoop();
                    break;
                case 1:
                    Console.Clear();
                    Console.Write("Settings");
                    break;
                case 2:
                    Console.Clear();
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
                if (game.player.CurrentHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(@"
            you got
   ______          ___   _ ______ _____  
  / __ \ \        / / \ | |  ____|  __ \ 
 | |  | \ \  /\  / /|  \| | |__  | |  | |
 | |  | |\ \/  \/ / | . ` |  __| | |  | |
 | |__| | \  /\  /  | |\  | |____| |__| |
  \____/   \/  \/   |_| \_|______|_____/ 
                                         ");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
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
                    if (!game.player.IsRoomExamined(game.player.Position))
                    {
                        Console.Write($"\n\nYou look around the {game.roomHandler.GetRoomName(game.player.Position)}");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else Console.WriteLine("\nRoom already searched.\n");
                    System.Threading.Thread.Sleep(1000);

                    game.player.AddExamineRoom(game.player.Position);
                }

                if (keyPressed.Key == ConsoleKey.T)
                {
                    if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId.Count != 0)
                    {
                        foreach (var item in game.roomHandler.TakeItems(game.player.Position))
                        {
                            game.player.Inventory.AddItem(item, 1);
                        }
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
                Fight(_roomID);
            }
            else
            {
                game.player.ChangePosition(_roomID);
            }
        }

        private void Fight(int _roomID)
        {
            game.combatHandler.StartNewCombat(game.player, game.spawner.LoadEnemy(game.roomHandler.GetRoom(_roomID).EnemyInRoom), game.itemLoader);
            string choise = "";
            while (!game.combatHandler.combatOver)
            {
                CMainMenu combatMenu = new(game.combatHandler.combatLog, game);
                if (!game.combatHandler.playersTurn)
                {
                    game.combatHandler.ContinueCombat();
                    Thread.Sleep(100);
                }
                else
                {
                    choise = combatMenu.Run(_roomID);
                    if (choise == "Attack")
                    {
                        game.combatHandler.ContinueCombat();
                    }
                    if (choise == "Inventory")
                    {
                        InventoryMenu inventoryMenu = new(game.GetInventoryInfoList(), game);
                        inventoryMenu.Run();
                    }
                    if (choise == "Escape")
                    {
                        game.player.ChangeHealth(-20);
                        Console.WriteLine("You escaped the fight!");
                        break;
                    }
                }
                if (game.combatHandler.combatOver)
                {
                    if (game.combatHandler.playerWinner)
                    {
                        Console.Clear();
                        ConsoleUtils.ChangeColor("WriteLine", $"You killed {game.spawner.LoadEnemy(game.roomHandler.GetRoom(_roomID).EnemyInRoom).Name} and gained {game.spawner.LoadEnemy(game.roomHandler.GetRoom(_roomID).EnemyInRoom).expValue} XP!", ConsoleColor.Green);
                        game.player.GainExp(game.spawner.LoadEnemy(game.roomHandler.GetRoom(_roomID).EnemyInRoom).expValue);
                        game.roomHandler.GetRoom(_roomID).EnemyInRoom = 0;
                        Console.ReadKey();
                        game.player.ChangePosition(_roomID);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(@"
            you got
   ______          ___   _ ______ _____  
  / __ \ \        / / \ | |  ____|  __ \ 
 | |  | \ \  /\  / /|  \| | |__  | |  | |
 | |  | |\ \/  \/ / | . ` |  __| | |  | |
 | |__| | \  /\  /  | |\  | |____| |__| |
  \____/   \/  \/   |_| \_|______|_____/ 
                                         ");
                        Console.ReadKey(true);
                        Environment.Exit(0); ;
                    }
                }

            }
        }

        private void Help()
        {
            Console.Clear();
            ConsoleUtils.ChangeColor("WriteLine", "HELP", ConsoleColor.White);

            ConsoleUtils.ChangeColor("WriteLine", "\nICONS", ConsoleColor.White);
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u25bc ", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", " - Current position.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2764 ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", " - Current health.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2726 ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", " - Current power.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u16e5 ", ConsoleColor.Magenta) + ConsoleUtils.ChangeColor("Write", " - Current armor.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2315 ", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", " - Search room. Press \"S\" to search.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u25a3 ", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", " - Inventory. Press \"I\" to open.\n", ConsoleColor.White));

            ConsoleUtils.ChangeColor("WriteLine", "\nNAVIGATION", ConsoleColor.White);
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2191 ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", " - Room to the North. Use arrow key up to navigate there.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2192 ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", " - Room to the East. Use arrow key right to navigate there.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2193 ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", " - Room to the South. Use arrow key down to navigate there.\n", ConsoleColor.White));
            Console.Write(ConsoleUtils.ChangeColor("Write", $"\u2190 ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", " - Room to the West. Use arrow key left to navigate there.\n", ConsoleColor.White));

            Console.ReadKey(true);
        }

        private void NoRoom(string s)
        {
            Console.Clear();
            Console.WriteLine($"You charge face first into the {s}ern wall almost breaking your nose, you see stars.\n");
            ConsoleUtils.ChangeColor("WriteLine", "You lose 5 hp", ConsoleColor.Red);
            Console.ReadKey(true);
            game.player.CurrentHealth -= 5;

        }

        private void RoomIsLocked(int _roomID)
        {
            Console.WriteLine($"\n{game.roomHandler.GetRoomName(_roomID)} is locked. You will need to find the {game.roomHandler.GetRoomName(_roomID)} key to unlock it.");
            Console.ReadKey(true);
        }

        private void Inventory()
        {
            Console.Clear();
            ConsoleUtils.ChangeColor("Write", "\u25a3", ConsoleColor.Yellow);
            Console.Write(" Inventory \n");
            InventoryMenu inventoryMenu = new(game.GetInventoryInfoList(), game);
            inventoryMenu.Run();
        }

        private void Print()
        {
            PlayerInfoBar playerInfoBar = new();
            playerInfoBar.InfoBar(game);
            if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId.Count != 0)
            {
                LootMenu();
            }
            else
                DisplayNavigation();
            RoomText();
        }

        private void LootMenu()
        {
            string prompt = "Would you like to loot it?";
            List<string> options = new List<string> { "Yes", "No" };
            Menu menu = new Menu(prompt, options, "", game, false);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Looted.");
                    break;
                case 1:
                    Console.Write("You looted nothing.");
                    break;
            }
        }
        public string InfoBar()
        {
            return DisplayHP() + DisplayPower() + DisplayArmor() + DisplaySearch() + DisplayInventory() + DisplayLevel() + DisplayXPToNextLevel() + DisplayMoney() + DisplayHelp();
        }

        private void DisplayCurrentRoom()
        {
            ConsoleUtils.ChangeColor("WriteLine", $"\n\u25bc {game.roomHandler.GetRoomName(game.player.Position)}\n", ConsoleColor.Yellow);
        }

        private void DisplayNavigation()
        {
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
        }

        private string DisplayHelp()
        {
            return ConsoleUtils.ChangeColor("Write", $"? H", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "elp | \n", ConsoleColor.White);
        }

        private string DisplayInventory()
        {
            return ConsoleUtils.ChangeColor("Write", $"\u25a3 I", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "nventory | ", ConsoleColor.White);
        }

        private string DisplaySearch()
        {
            if (!game.player.IsRoomExamined(game.player.Position))
            {
                return ConsoleUtils.ChangeColor("Write", $"\u2315 S", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "earch | ", ConsoleColor.White);
            }
            return "";
        }

        private string DisplayArmor()
        {
            return ConsoleUtils.ChangeColor("Write", "\u16e5  ", ConsoleColor.Magenta) + ConsoleUtils.ChangeColor("Write", $"{game.GetDefense()} | ", ConsoleColor.White);
        }

        private string DisplayPower()
        {
            string text;
            if (game.player.CurrentPower < game.player.Power / 2.5) text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            else if (game.player.CurrentPower < game.player.Power / 1.5) text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            else text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            return text;
        }

        private string DisplayHP()
        {
            string text;
            if (game.player.CurrentHealth < game.player.OriginalHealth / 2.5) text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            else if (game.player.CurrentHealth < game.player.OriginalHealth / 1.5) text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            else text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            return text;
        }

        private string DisplayMoney()
        {
            return ConsoleUtils.ChangeColor("Write", "\u20AB ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", $"{game.player.CoinPurse} | ", ConsoleColor.White);
        }

        private string DisplayLevel()
        {
            return ConsoleUtils.ChangeColor("Write", $"Level: {game.player.Level} | ", ConsoleColor.White);
        }

        private string DisplayXPToNextLevel()
        {
            return ConsoleUtils.ChangeColor("Write", $"XP to next level: {game.player.ExpToNextLevel()} | ", ConsoleColor.White);
        }

        private void RoomText()
        {
            if (!game.player.IsRoomExamined(game.player.Position))
                ConsoleUtils.TypeWriter(game.roomHandler.DescribeRoom(game.player.Position), ConsoleKey.Enter);
            else Console.WriteLine(game.roomHandler.DescribeRoom(game.player.Position));
            if (game.player.IsRoomExamined(game.player.Position))
            {
                Console.WriteLine($"\n\n{game.roomHandler.ExamineRoom(game.player.Position)}");
            }
            if (game.player.IsRoomExamined(game.player.Position) && game.roomHandler.GetRoom(game.player.Position).ItemInRoomId.Count != 0)
            {
                var Take = ConsoleUtils.ChangeColor("Write", $"\nT", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "ake:  \n", ConsoleColor.White);
                foreach (var item in game.roomHandler.GetRoom(game.player.Position).ItemInRoomId)
                {
                    if (game.itemLoader.GetItemDetails(item).ItemType == ItemType.Consumable)
                    {
                        string attributeToRestore = "";
                        ConsoleColor attributeColor = ConsoleColor.White;
                        string restoreAmount = $"- restores {game.itemLoader.GetConsumableDetails(item).AmountToRestore}";
                        if (game.itemLoader.GetConsumableDetails(item).ConsumableType == ConsumableType.HealthPotion)
                        {
                            attributeToRestore = "health";
                            attributeColor = ConsoleColor.Red;
                        }
                        else if (game.itemLoader.GetConsumableDetails(item).ConsumableType == ConsumableType.PowerPotion)
                        {
                            attributeToRestore = "power";
                            attributeColor = ConsoleColor.Blue;
                        }
                        Console.WriteLine(ConsoleUtils.ChangeColor("Write", $"{game.itemLoader.GetItemDetails(item).Name} ", attributeColor) + ConsoleUtils.ChangeColor("Write", $"{restoreAmount} {attributeToRestore} points", ConsoleColor.White));
                    }
                    else Console.WriteLine(ConsoleUtils.ChangeColor("Write", $"{game.itemLoader.GetItemDetails(item).Name}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" ({game.itemLoader.GetItemDetails(item).ItemType})", ConsoleColor.White));
                }
            }
        }
    }
}