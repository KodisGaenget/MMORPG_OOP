using System;
using static System.Console;

namespace ItemAdder
{
    class ItemAdder
    {
        public MainMenu MainMenu;
        
        public ItemAdder()
        {
            this.MainMenu = new MainMenu(this);
        }

        public void Start()
        {
            MainMenu.Run();
        }
    }
}