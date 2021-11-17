using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;
using GameLib;

namespace UI
{
    class SubMenu : BaseMenu
    {
        // BuildItem builditem = new BuildItem();
        public SubMenu(GameScene myGameScene) : base(myGameScene)
        {
            // Constructor
        }

        public override void Run(Game game)
        {
            Clear();
        }
    }
}