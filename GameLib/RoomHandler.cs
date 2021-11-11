using System.Collections.Generic;

namespace GameLib
{
    public class RoomHandler
    {
        List<Room> allRooms = new();

        public List<int> GetConnectedRooms(int roomId)
        {
            List<int> connectedRooms = new();
            foreach (var item in allRooms)
            {
                if (item.RoomID == roomId)
                {
                    connectedRooms.AddRange(item.ConnectingRooms);
                }
            }
            return connectedRooms;
        }
        public void AddRooms(List<Room> rooms)
        {
            foreach (var item in rooms)
            {
                allRooms.Add(item);
            }
        }
    }
}
