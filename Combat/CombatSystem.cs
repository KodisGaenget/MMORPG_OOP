using System;
using DataManager;
using Items;
using GameInterfaces;
using System.Threading;
using Combat.UI;

namespace Combat
{
    public class CombatSystem
    {
        IFightable fighter1;
        int fighter1Armor = 0;


        IFightable fighter2;
        int fighter2Armor = 0;


        ItemLoader itemLoader;
        public bool combatOver = false;
        Random r = new Random();
        string combatLog = "";
        bool fighter1Turn = false;
        string EndingMessage = "";

        public CombatSystem(IFightable fighter1, IFightable fighter2, ItemLoader itemLoader)
        {
            this.fighter1 = fighter1;
            this.fighter2 = fighter2;
            this.itemLoader = itemLoader;
            SetFighterStats();
            fighter1Turn = r.Next(2) == 0;
        }

        public string Run()
        {
            while (!combatOver)
            {
                // System.Console.WriteLine(fighter1.CurrentHealth);
                if (fighter1Turn)
                {
                    MainMenu newMenu = new(combatLog);
                    string menuoption = newMenu.Run(fighter1);
                    if (menuoption == "Attack")
                    {
                        Turn newTurn = new(fighter1, fighter2, CalcDmgDealt(fighter1, fighter2), Resist(fighter1, fighter2, fighter2Armor));
                        combatLog += newTurn.Attack() + "\n";
                        fighter2 = newTurn.GetTaker();
                    }
                    else if (menuoption == "Escape")
                    {
                        break;
                    }

                }
                else if (!fighter1Turn)
                {
                    Turn newTurn = new(fighter2, fighter1, CalcDmgDealt(fighter2, fighter1), Resist(fighter2, fighter1, fighter1Armor));
                    combatLog += newTurn.Attack() + "\n";
                    fighter1 = newTurn.GetTaker();

                }
                fighter1Turn = !fighter1Turn;
                EndingMessage = CheckCombatOver();
                Thread.Sleep(500);
            }
            return EndingMessage + "\n" + combatLog;
        }

        private int CalcDmgDealt(IFightable dealer, IFightable taker)
        {
            int weaponDmg = r.Next(dealer.MinDamage, dealer.MaxDamage);
            return dealer.Damage + weaponDmg;
        }

        private float Resist(IFightable dealer, IFightable taker, int takerArmor)
        {
            //TODO Fixa legitresist NÄSTAN KLAR!
            float leveldiff = 2 * (dealer.Level - taker.Level) / 100 + 1;
            return (leveldiff * 1 - (taker.Armor - dealer.Penetration) / 100);
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
                Weapon weapon = itemLoader.GetWeaponDetails(item);
                if (item == weapon.Id)
                {
                    fighter1.MinDamage = weapon.MinDamage;
                    fighter1.MaxDamage = weapon.MaxDamage;
                }
            }

            foreach (var item in fighter2.GetItemIdsFromEquipment())
            {
                Weapon weapon = itemLoader.GetWeaponDetails(item);
                if (item == weapon.Id)
                {
                    fighter2.MinDamage = weapon.MinDamage;
                    fighter2.MaxDamage = weapon.MaxDamage;
                }
            }
        }


        private void GetArmorStats()
        {
            foreach (var item in fighter1.GetItemIdsFromEquipment())
            {
                Armor armor = itemLoader.GetArmorDetails(item);
                if (item == armor.Id)
                {
                    fighter1Armor += armor.Defense;
                }
            }
            foreach (var item in fighter2.GetItemIdsFromEquipment())
            {
                Armor armor = itemLoader.GetArmorDetails(item);
                if (item == armor.Id)
                {
                    fighter2Armor += armor.Defense;
                }
            }
        }

        private string CheckCombatOver()
        {
            if (fighter1.CurrentHealth <= 0)
            {
                combatOver = true;
                return "You won the combat!";
            }
            else if (fighter2.CurrentHealth <= 0)
            {
                combatOver = true;
                return "You died!";
            }
            //Om detta retuneras, fortsätt fighten.
            return "";
        }
    }
}



// public enum AttackType
// {
//     Attack,
//     MainAbility,
//     SecondaryAbility
// }


