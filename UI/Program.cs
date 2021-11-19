using System;
using GameLib;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomHandler roomHandler = new();
            Game game = new(roomHandler);
            // GameScene myGameScene = new(game);
            // myGameScene.Start(game);
            game.SetChoosenPlayer(1, 1);
            TestMenu menu = new(game);
            menu.Run();
        }
    }
}
