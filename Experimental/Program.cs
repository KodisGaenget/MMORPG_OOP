using System;
using Characters;

namespace Experimental
{
    class Program
    {
        private Player CurrentPlayer;
        Enemy enemy = new();
        static void Main(string[] args)
        {

        }

        public void DisplayInfo()
        {

            //      public int Id { get; private init; }
            // public string Name { get; private init; }
            // public int OriginalHealth { get; protected set; }
            // public int CurrentHealth { get; protected set; }
            // public int Power { get; protected set; }
            // public int Armor { get; protected set; }
            // public int Damage { get; protected set; }
            // public int Level { get; protected set; }
        }
        public void run()
        {
            CurrentPlayer = new Player();
        }
    }
}
