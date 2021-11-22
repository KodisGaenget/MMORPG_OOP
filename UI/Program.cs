using System;
using GameLib;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            RoomHandler roomHandler = new();
            Game game = new(1); // 1 = Spelarens id
            RunGame menu = new(game);
            menu.Run();
        }
    }
}
