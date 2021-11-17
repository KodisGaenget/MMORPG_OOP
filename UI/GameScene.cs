using System;
using static System.Console;
using GameLib;

namespace UI
{
    class GameScene
    {
        public MainMenu MainMenu;
        public SubMenu SubMenu;
        Game game;
        
        public GameScene(Game game)
        {
            this.MainMenu = new MainMenu(this);
            this.SubMenu = new SubMenu(this);
            this.game = game;
        }

        public void Start(Game game)
        {           
            MainMenu.Run(game);
        }
    }
}