using System;

namespace Characters
{
    public abstract class Character
    {
        public int Id { get; private init; }
        public string Name { get; private init; }
        public int OriginalHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Power { get; protected set; }
        public int Armor { get; protected set; }
        public int Damage { get; protected set; }
        public int Level { get; protected set; }
        public int Position { get; protected set; }

        //TODO Lägg till i Databasen:
        public int CoinPurse { get; set; }

        public abstract int Attack();

        public abstract int Block();

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
                return true;
            }
            return false;
        }


    }

}
