using System;

namespace DataManager
{
    public class BuildItem
    {
        Database db = new();
        public void AddArmor(string newName, Nullable<int> newPrice, string newItemType, string newSlot, Nullable<int> newDef, string newMaterial, Nullable<int> newMaxStack)
        {
            db.Add_NewItem(newName, newPrice, newItemType, newSlot, null, null, null, newDef, newMaterial, null, null, 1);
        }
        public void AddWeapon(string newName, Nullable<int> newPrice, string newItemType, string newSlot, Nullable<int> newMinDmg, Nullable<int> newMaxDmg, string newWeaponType, Nullable<int> newMaxStack)
        {
            db.Add_NewItem(newName, newPrice, newItemType, newSlot, newMinDmg, newMaxDmg, newWeaponType, null, null, null, null, 1);
        }
        public void AddConsumable(string newName, Nullable<int> newPrice, string newItemType, Nullable<int> newAmToRest, string newConsType, Nullable<int> newMaxStack)
        {
            db.Add_NewItem(newName, newPrice, newItemType, null, null, null, null, null, null, newAmToRest, newConsType, newMaxStack);
        }
        public void AddKey(string newName, string newItemType, Nullable<int> newMaxStack)
        {
            db.Add_NewItem(newName, null, newItemType, null, null, null, null, null, null, null, null, newMaxStack);
        }
    }
}