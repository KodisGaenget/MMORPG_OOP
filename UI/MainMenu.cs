using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;
using GameLib;

namespace UI
{
    class MainMenu : BaseMenu
    {
        // BuildItem builditem = new BuildItem();
        public MainMenu(GameScene myGameScene) : base(myGameScene)
        {
            // Constructor
        }

        public override void Run(Game game)
        {
            string prompt = "Welcome to Wörld of Virgincraft: The Saga of the Poopy Pants in the Basement!";
            List<string> options = new List<string> { "Play the game", "Settings", "Credits", "Exit" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    // Write("Play the game");
                    // Create/choose player
                    // Load room 1
                    game.SetChoosenPlayer(1);
                    game.player.ChangePosition(1); 
                    Clear();
                    WriteLine($"{game.player}");
                    WriteLine($"{game.roomHandler.GetRoomName(game.player.Position)}");
                    break;

                case 1:
                    Write("Settings");   // Settings
                    break;

                case 2:
                    Write("Credits");    // Credits
                    break;

                case 3:
                    Write("Exit");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}