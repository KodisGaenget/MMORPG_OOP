using System;
using DataManager;
using GameInterfaces;
using System.Threading;


namespace Combat
{
    public class CombatSystem
    {
        internal IFightable fighter1;
        int fighter1Armor = 0;


        internal IFightable fighter2;
        int fighter2Armor = 0;


        ItemLoader itemLoader;
        internal bool combatOver = false;
        Random r = new Random();
        internal string combatLog = "";
        bool fighter1Turn = false;
        internal string endingMessage = "";

        public CombatSystem(IFightable fighter1, IFightable fighter2, ItemLoader itemLoader)
        {
            this.fighter1 = fighter1;
            this.fighter2 = fighter2;
            this.itemLoader = itemLoader;
            SetFighterStats();
            fighter1Turn = r.Next(2) == 0;
        }

        internal bool Run()
        {
            if (fighter1Turn)
            {
                Turn newTurn = new(fighter1, fighter2, CalcDmgDealt(fighter1, fighter2), Resist(fighter1, fighter2, fighter2Armor));
                combatLog += newTurn.Attack() + "\n";
                fighter2 = newTurn.GetTaker();
            }
            else if (!fighter1Turn)
            {
                Turn newTurn = new(fighter2, fighter1, CalcDmgDealt(fighter2, fighter1), Resist(fighter2, fighter1, fighter1Armor));
                combatLog += newTurn.Attack() + "\n";
                fighter1 = newTurn.GetTaker();
            }
            fighter1Turn = !fighter1Turn;
            endingMessage = CheckCombatOver();
            Thread.Sleep(500);
            return fighter1Turn;
        }

        private int CalcDmgDealt(IFightable dealer, IFightable taker)
        {
            int weaponDmg = r.Next(dealer.MinDamage, dealer.MaxDamage);
            return dealer.Attack() + weaponDmg;
        }

        private float Resist(IFightable dealer, IFightable taker, int takerArmor)
        {
            float leveldiff = 2 * (dealer.Level - taker.Level) / 100f;
            return leveldiff + ((taker.Armor - dealer.Penetration) / 100f);
        }

        private void SetFighterStats()
        {
            GetArmorStats();
            GetWeaponStats();
        }

        private void GetWeaponStats()
        {
            foreach (var item in fighter1.GetItemIdsFromEquipment())
            {
                if (itemLoader.GetItemType(item) == "Weapon")
                {
                    fighter1.MinDamage = itemLoader.GetWeaponDetails(item).MinDamage;
                    fighter1.MaxDamage = itemLoader.GetWeaponDetails(item).MaxDamage;
                }
            }

            foreach (var item in fighter2.GetItemIdsFromEquipment())
            {
                if (itemLoader.GetItemType(item) == "Weapon")
                {
                    fighter2.MinDamage = itemLoader.GetWeaponDetails(item).MinDamage;
                    fighter2.MaxDamage = itemLoader.GetWeaponDetails(item).MaxDamage;
                }
            }

        }


        private void GetArmorStats()
        {
            foreach (var item in fighter1.GetItemIdsFromEquipment())
            {
                if (itemLoader.GetItemType(item) == "Armor")
                {
                    fighter1Armor += itemLoader.GetArmorDetails(item).Defense;
                }
            }
            foreach (var item in fighter2.GetItemIdsFromEquipment())
            {
                if (itemLoader.GetItemType(item) == "Armor")
                {
                    fighter2Armor += itemLoader.GetArmorDetails(item).Defense;
                }
            }
        }

        private string CheckCombatOver()
        {
            if (fighter2.CurrentHealth <= 0)
            {
                combatOver = true;
                return "You won the combat!";
            }
            else if (fighter1.CurrentHealth <= 0)
            {
                combatOver = true;
                return "You died!";
            }
            return "";
        }
    }
}