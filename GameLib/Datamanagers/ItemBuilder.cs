using System;

namespace GameLib
{
    public class BuildItem
    {
        Database db = new();
        public void AddItem(string newName, Nullable<int> newPrice, string newItemType, string newSlot, Nullable<int> newMinDmg, Nullable<int> newMaxDmg, string newWeaponType, Nullable<int> newDef, string newType, Nullable<int> newAmToRest, string newConsType, Nullable<int> newMaxStack)
        {
            db.Add_NewItem(newName, newPrice, newItemType, newSlot, newMinDmg, newMaxDmg, newWeaponType, newDef, newType, newAmToRest, newConsType, newMaxStack);
        }

        // string newName, int newPrice, string newItemType, string newSlot, int newMinDmg, int newMaxDmg, string newWeaponType, int newDef, string newType, int newAmToRest, string newConsType, int newMaxStack


    }
}