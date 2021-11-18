using System;
using Characters;
using DataManager;
using Items;
using GameEnums;
using GameInterfaces;

namespace Combat
{
    public class CombatSystem
    {
        IFightable fighter1;
        int fighter1minDmg = 0;
        int fighter1maxDmg = 0;
        int fighter1Penetration = 0;
        int fighter1Armor = 0;


        IFightable fighter2;
        int fighter2minDmg = 0;
        int fighter2maxDmg = 0;
        int fighter2Penetration = 0;
        int fighter2Armor = 0;


        ItemLoader itemLoader;
        public bool combatOver = false;
        Random r = new Random();
        bool fighter1Turn = false;

        public CombatSystem(IFightable fighter1, IFightable fighter2, ItemLoader itemLoader)
        {
            this.fighter1 = fighter1;
            this.fighter2 = fighter2;
            this.itemLoader = itemLoader;
            fighter1Turn = r.Next(2) == 0;
        }

        void Run()
        {

        }

        public int ArmorResist(Character dealer, Character taker)
        {
            //TODO Fixa legitresist
            int leveldiff = 2 * (dealer.Level - taker.Level) / 100 + 1;
            return leveldiff + 1 - (100) / (taker.Armor);
        }

        // private void GetMinMaxDmg()
        // {
        //     int minDamage = 0;
        //     int maxDamage = 0;

        //     foreach (var item in fighter1.Equipment.GetEquipment())
        //     {
        //         Weapon weapon = itemLoader.GetWeaponDetails(item.Value);
        //         if (item.Value == weapon.Id)
        //         {
        //             minDamage = weapon.MinDamage;
        //             maxDamage = weapon.MaxDamage;
        //         }
        //     }
        // }

        // private int CalcPlayerDef()
        // {
        //     int defence = 0;
        //     foreach (var item in player.Equipment.GetEquipment())
        //     {
        //         if (item.Key == itemLoader.GetArmorDetails(item.Value).Slot.ToString())
        //         {
        //             defence += itemLoader.GetArmorDetails(item.Value).Defense;
        //         }
        //     }
        //     return defence;
        // }

        //     private string CheckCombatOver()
        //     {
        //         if (enemy.CurrentHealth <= 0)
        //         {
        //             combatOver = true;
        //             return "You won the combat!";
        //         }
        //         else if (player.CurrentHealth <= 0)
        //         {
        //             combatOver = true;
        //             return "You died!";
        //         }
        //         //Om detta retuneras, fortsätt fighten.
        //         return "";
        // }
    }

    public enum AttackType
    {
        Attack,
        MainAbility,
        SecondaryAbility
    }

}
