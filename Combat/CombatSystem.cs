using System;
using Characters;
using GameLib;

namespace Combat
{
    public class CombatSystem
    {
        Player player;
        Enemy enemy;
        ItemLoader itemLoader;

        public CombatSystem(Player player, Enemy enemy, ItemLoader itemLoader)
        {
            this.player = player;
            this.enemy = enemy;
            this.itemLoader = itemLoader;

        }

        public int PlayerAttack(AttackType attackType)
        {
            if (attackType == AttackType.Attack)
            {
                Random r = new Random();
                foreach (var item in player.Equipment.GetEquipment())
                {
                    // if (item.Value == itemLoader.weaponList)
                }
                player.Attack();
                // enemy.Armor;

            }
            else if (attackType == AttackType.MainAbility)
            {
                player.Attack();
            }
            else if (attackType == AttackType.SecondaryAbility)
            {
                player.Attack();
            }



            return 0;
        }

        public int EnemyAttack()
        {
            return enemy.Attack();
        }

        private bool CheckCombatOver()
        {
            return true;
        }
    }

    public enum AttackType
    {
        Attack,
        MainAbility,
        SecondaryAbility
    }

}
