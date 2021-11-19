using System;
using GameLib;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomHandler roomHandler = new();
            Game game = new(1); // 1 = Spelarens id
            // GameScene myGameScene = new(game);
            // myGameScene.Start(game);
            TestMenu menu = new(game);
            menu.Run();
        }
    }
}
