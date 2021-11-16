using System;
using static System.Console;

namespace ItemAdder
{
    class ItemAdder
    {
        public MainMenu MainMenu;
        public CreateWeapon CreateWeapon;
        public CreateArmor CreateArmor;
        
        public ItemAdder()
        {
            this.MainMenu = new MainMenu(this);
            this.CreateWeapon = new CreateWeapon(this);
            this.CreateArmor = new CreateArmor(this);
        }

        public void Start()
        {
            MainMenu.Run();
        }
    }
}