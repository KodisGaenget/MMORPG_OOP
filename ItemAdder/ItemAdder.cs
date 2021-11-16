using System;
using static System.Console;

namespace ItemAdder
{
    class ItemAdder
    {
        public MainMenu MainMenu;
        public CreateWeapon CreateWeapon;
        
        public ItemAdder()
        {
            this.MainMenu = new MainMenu(this);
            this.CreateWeapon = new CreateWeapon(this);
        }

        public void Start()
        {
            MainMenu.Run();
        }
    }
}