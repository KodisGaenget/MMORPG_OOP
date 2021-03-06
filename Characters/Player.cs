using System;
using System.Collections.Generic;
using GameInterfaces;

namespace Characters
{
    public class Player : Character
    {
        public Inventory Inventory { get; private set; }

        public int CurrentExp { get; private set; }
        public string Class { get; private set; }
        private List<int> Examined;

        public bool inDb = false;

        public Player()
        {
            Inventory = new();
            inDb = true;
        }

        public bool UpdateLevel()
        {
            int oldLevel = Level;
            Level level = new();
            Level = level.GetLevel(CurrentExp);
            if (oldLevel < Level)
            {
                int hpGain = 20 * (Level - oldLevel);

                OriginalHealth += hpGain;
                CurrentHealth += hpGain;
                return true;
            }
            return false;
        }

        public float ExpToNextLevel()
        {
            Level level = new();
            return level.ExpToNextLevel(CurrentExp, Level);
        }

        public void Equip(string slot, int itemId)
        {
            UnEquip(slot);
            Equipment.ChangeEquipItem(slot, itemId);
            Inventory.RemoveItem(itemId);
        }

        public void UnEquip(string slot)
        {
            var oldItem = Equipment.GetEquipment()[slot];
            if (oldItem > 0)
            {
                Inventory.AddItem(oldItem, 1);
            }
            Equipment.ChangeEquipItem(slot, -1); // Sets equipment slot to empty
        }
        public void Load(Inventory inv, Equipment eq, List<int> examined)
        {
            Equipment = eq;
            Inventory = inv;
            Examined = examined;
        }

        public void GainExp(int amount)
        {
            CurrentExp += amount;
            UpdateLevel();
        }

        public void AddExamineRoom(int roomId)
        {
            Examined.Add(roomId);
        }

        public bool IsRoomExamined(int room_Id)
        {
            foreach (var roomId in Examined)
            {
                if (room_Id == roomId)
                {
                    return true;
                }
            }
            return false;
        }


        // public override string ToString()
        // {
        //     return $"Id: {Id}, Name: {Name}, Class: {Class}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        // }

    }
}


