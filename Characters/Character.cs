using System.Collections.Generic;
using GameInterfaces;


namespace Characters
{
    public abstract class Character : IFightable
    {
        public int Id { get; private init; }
        public string Name { get; init; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Power { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }
        public int Position { get; set; }
        public Equipment Equipment { get; protected set; }
        public int CoinPurse { get; set; }

        public int Attack()
        {
            return Damage;
        }

        public int Block()
        {
            return 0;
        }

        public List<int> GetItemFromEquipment()
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
