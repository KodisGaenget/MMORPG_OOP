namespace GameLib
{
    public struct InventoryInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public InventoryInfo(int id, string name, int amount)
        {
            Id = id;
            Name = name;
            Amount = amount;
        }
    }

}