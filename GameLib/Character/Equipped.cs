namespace GameLib
{
    public class Equipped
    {
        public Armor Helmet { get; private set; }
        public Armor Chest { get; private set; }
        public Armor Gloves { get; private set; }
        public Armor Legs { get; private set; }
        public Armor Boots { get; private set; }
        public Weapon Weapon { get; private set; }
        private Armor newArmor;
        private Weapon newWeapon;

        public Equipped()
        {

        }

        internal Item SetSlot(Item item)
        {
            GetItemType(item);
            if (newWeapon != null)
            {
                if (Weapon != null)
                {
                    var oldWeapon = Weapon;
                    Weapon = newWeapon;
                    newWeapon = null;
                    return oldWeapon;
                }
                Weapon = newWeapon;
            }
            if (newArmor != null)
            {
                // newArmor.Slot;
            }

            return null;
        }

        private void GetItemType(Item item)
        {
            if (item is Weapon)
            {
                newWeapon = item as Weapon;
            }
            else if (item is Armor)
            {
                newArmor = item as Armor;
            }

        }

    }
}