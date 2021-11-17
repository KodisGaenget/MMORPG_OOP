using System;
using Characters;
using DataManager;
using Items;
using GameEnums;

namespace Combat
{
    public class CombatSystem
    {
        Player player;
        Enemy enemy;
        ItemLoader itemLoader;
        public bool combatOver = false;
        Random r = new Random();

        public CombatSystem(Player player, Enemy enemy, ItemLoader itemLoader)
        {
            this.player = player;
            this.enemy = enemy;
            this.itemLoader = itemLoader;
        }

        void TurnHandler()
        {

        }



        public string PlayerAttack(AttackType attackType)
        {
            int dealtDmg = 0;
            string EndingMessage = "";
            if (attackType == AttackType.Attack)
            {
                dealtDmg = CombatResult(CalcPlayerDmg() + player.Attack(), "player");
                EndingMessage = CheckCombatOver();
            }
            else if (attackType == AttackType.MainAbility)
            {
                // dealtDmg = CombatResult(CalcPlayerDmg() + player.MainAbility()); //TODO Gör klart med metoden för MainAbility! 
            }
            else if (attackType == AttackType.SecondaryAbility)
            {
                //return CalcPlayerDmg() + player.SecondaryAbility(); //TODO Gör klart med metoden för SecondaryAbility! 
            }
            if (EndingMessage != "")
            {
                return EndingMessage;
            }
            else
            {
                return $"You dealt {dealtDmg} to {enemy.Name}.";
            }
        }

        public int EnemyAttack()
        {
            return enemy.Attack();
        }
        private int CombatResult(int dmg, string dealer)
        {
            //TODO Räkna ut hur mycket skada som görs på motståndaren.
            throw new NotImplementedException();
        }

        private int CalcPlayerDmg()
        {
            int minDamage = 0;
            int maxDamage = 0;

            foreach (var item in player.Equipment.GetEquipment())
            {
                Weapon weapon = itemLoader.GetWeaponDetails(item.Value);
                if (item.Value == weapon.Id)
                {
                    minDamage = weapon.MinDamage;
                    maxDamage = weapon.MaxDamage;
                }
            }
            return r.Next(minDamage, maxDamage);
        }

        private int CalcPlayerDef()
        {
            int defence = 0;
            foreach (var item in player.Equipment.GetEquipment())
            {
                if (item.Key == itemLoader.GetArmorDetails(item.Value).Slot.ToString())
                {
                    defence += itemLoader.GetArmorDetails(item.Value).Defense;
                }
            }
            return defence;
        }

        private string CheckCombatOver()
        {
            if (enemy.CurrentHealth <= 0)
            {
                combatOver = true;
                return "You won the combat!";
            }
            else if (player.CurrentHealth <= 0)
            {
                combatOver = true;
                return "You died!";
            }
            //Om detta retuneras, fortsätt fighten.
            return "";
        }
    }

    public enum AttackType
    {
        Attack,
        MainAbility,
        SecondaryAbility
    }

}
