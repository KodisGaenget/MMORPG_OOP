using System;
using GameLib;

namespace UI
{
    class BaseMenu
    {
        protected GameScene myGameScene;

        public BaseMenu(GameScene gameScene)
        {
           myGameScene = gameScene;
        }


        virtual public void Run(Game game)
        {
            // Overridea virtuella menyerna
        }
    }
}