using System.Collections.Generic;
using Characters;
using DataManager;
using Rooms;
using GameEnums;
using Items;

namespace GameLib
{
    public class Game
    {
        private PlayerLoader playerLoader;
        private Database db = new();
        public RoomHandler roomHandler;
        public CombatHandler combatHandler = new();
        public Player player;
        public Player player2;
        public Spawner spawner;
        public ItemLoader itemLoader;

        public Game(int id)
        {
            this.roomHandler = new();
            playerLoader = new(db);
            itemLoader = new(db);
            spawner = new(db);
            player = SetChoosenPlayer(id);
            player2 = SetChoosenPlayer(2);
        }

        public void UpdateGame()
        {
            player.UpdateLevel();
        }

        public void GameOver()
        {
            player.ChangeHealth(player.OriginalHealth);
            player.ChangePosition(1);
        }

        #region PlayerMethods
        public void SavePlayer()
        {
            PlayerSaver playerSaver = new(db, player);
        }

        public Player SetChoosenPlayer(int id)
        {
            return playerLoader.GetPlayer(id);
        }

        public List<InventoryInfo> GetInventoryInfoList()
        {
            List<InventoryInfo> InventoryList = new();
            foreach (var item in player.Inventory.GetInventory())
            {
                foreach (var item2 in itemLoader.itemList)
                {
                    if (item.Key == item2.Id)
                    {
                        InventoryList.Add(new InventoryInfo(item2.Id, item2.Name, item.Value));
                    }
                }
            }
            return InventoryList;
        }

        public int GetDefense()
        {
            int FightDefence = player.Armor;
            foreach (var item in player.Equipment.GetEquipment())
            {
                if (itemLoader.GetItemType(item.Value) == "Armor")
                {
                    FightDefence += GetPlayerDef(item.Value);
                }
            }
            return FightDefence;
        }

        private int GetPlayerDef(int itemId)
        {
            foreach (var item in itemLoader.itemList)
            {
                if (item.Id == itemId)
                {
                    var armor = item as Armor;
                    return armor.Defense;
                }
            }
            return 0;
        }

        public Dictionary<string, int> GetAtkPower(Player player)
        {

            foreach (var item in player.Equipment.GetEquipment())
            {
                if (item.Key == "Weapon")
                {
                    return new(GetPlayerAtk(item.Value));
                }
            }
            return new();
        }

        private Dictionary<string, int> GetPlayerAtk(int itemId)
        {
            Dictionary<string, int> FightAtk = new();
            foreach (var item in itemLoader.itemList)
            {
                if (item.Id == itemId)
                {
                    var weapon = item as Weapon;
                    FightAtk.Add("Min", weapon.MinDamage);
                    FightAtk.Add("Max", weapon.MaxDamage);
                }
            }
            return FightAtk;
        }

        #endregion

        #region ItemMethods
        private KeyValuePair<int, int> FindItemInInventory(int id)
        {
            foreach (var item in player.Inventory.GetInventory())
            {
                if (id == item.Key)
                {
                    return item;
                }
            }
            return new();
        }

        private bool ConsumeItem(KeyValuePair<int, int> item)
        {
            foreach (var item2 in itemLoader.itemList)
            {
                var consumable = item2 as Consumable;
                if (item.Key == consumable.Id)
                {
                    if (consumable.ConsumableType == ConsumableType.HealthPotion)
                    {
                        player.ChangeHealth(consumable.AmountToRestore);
                        player.Inventory.RemoveItem(item.Key, 1);
                        return true;
                    }
                    else if (consumable.ConsumableType == ConsumableType.PowerPotion)
                    {
                        player.CurrentPower = player.Power;
                    }
                }
            }
            return false;
        }
        #endregion

    }
}