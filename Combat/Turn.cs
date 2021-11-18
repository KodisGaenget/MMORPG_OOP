using System;
using Characters;
using GameInterfaces;
using DataManager;
using Items;
using GameEnums;

namespace Combat
{
    public class Turn
    {

        // private string Attack()
        // {
        //     int dealtDmg = 0;
        //     string EndingMessage = "";
        //     dealtDmg = CombatResult(CalcPlayerDmg() + player.Attack(), player, enemy, ArmorResist(player, enemy));
        //     EndingMessage = CheckCombatOver();

        //     if (EndingMessage != "")
        //     {
        //         return EndingMessage;
        //     }
        //     else
        //     {
        //         return $"You dealt {dealtDmg} to {fighter2.Name}.";
        //     }

        // }

        private int CombatResult(int dmg, IFightable dealer, IFightable taker, int resist)
        {
            int realDmg = dmg * resist;
            taker.ChangeHealth(realDmg);
            return realDmg;
            //TODO Räkna ut hur mycket skada som görs på motståndaren.
        }



    }
}