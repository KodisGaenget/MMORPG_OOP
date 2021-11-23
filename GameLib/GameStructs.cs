namespace GameLib
{
    public struct InventoryInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public InventoryInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}