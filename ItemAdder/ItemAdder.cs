using System;
using static System.Console;

namespace ItemAdder
{
    class ItemAdder
    {
        public MainMenu MainMenu;
        public CreateWeapon CreateWeapon;
        public CreateArmor CreateArmor;
        public CreateConsumable CreateConsumable;
        
        public ItemAdder()
        {
            this.MainMenu = new MainMenu(this);
            this.CreateWeapon = new CreateWeapon(this);
            this.CreateArmor = new CreateArmor(this);
            this.CreateConsumable = new CreateConsumable(this);
        }

        public void Start()
        {
            MainMenu.Run();
        }
    }
}