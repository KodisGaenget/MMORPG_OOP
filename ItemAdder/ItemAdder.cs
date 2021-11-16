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
        public CreateKey CreateKey;
        
        public ItemAdder()
        {
            this.MainMenu = new MainMenu(this);
            this.CreateWeapon = new CreateWeapon(this);
            this.CreateArmor = new CreateArmor(this);
            this.CreateConsumable = new CreateConsumable(this);
            this.CreateKey = new CreateKey(this);
        }

        public void Start()
        {
            MainMenu.Run();
        }
    }
}