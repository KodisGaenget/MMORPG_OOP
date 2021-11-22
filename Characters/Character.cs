using System.Collections.Generic;
using GameInterfaces;


namespace Characters
{
    public abstract class Character : IFightable
    {
        public int Id { get; private init; }
        public string Name { get; private init; }
        public int OriginalHealth { get; protected set; }
        public int CurrentHealth { get; set; }
        public int Power { get; protected set; }
        public int CurrentPower { get; set; }
        public int Armor { get; protected set; }
        public int Penetration { get; protected set; }
        public int BaseDamage { get; protected set; }
        public int Level { get; protected set; }
        public int Position { get; protected set; }
        public Equipment Equipment { get; protected set; }
        public int CoinPurse { get; protected set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public int Attack()
        {
            return BaseDamage;
        }

        public int Block()
        {
            return Armor;
        }

        public List<int> GetItemIdsFromEquipment()
        {
            List<int> idList = new();
            foreach (var item in Equipment.GetEquipment())
            {
                idList.Add(item.Value);
            }
            return idList;
        }

        public void ChangePosition(int newPos)
        {
            Position = newPos;
        }

        public bool ChangeHealth(int value)
        {
            int newHp = CurrentHealth + value;

            if (newHp >= OriginalHealth)
            {
                CurrentHealth = OriginalHealth;
            }
            else if (newHp < OriginalHealth)
            {
                CurrentHealth = newHp;
            }

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                return false;
            }
            return true;
        }


    }

}
