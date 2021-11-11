using System.Collections.Generic;

namespace GameLib
{
    public class RoomHandler
    {
        List<Room> allRooms = new();





        // wtf?
        public List<int> GetConnectedRooms(int _roomId)
        {
            List<int> connectedRooms = new();
            foreach (var room in allRooms)
            {
                if (room.RoomID == _roomId)
                {
                    connectedRooms.AddRange(room.ConnectingRooms);
                }
            }
            return connectedRooms;
        }

        public string GetRoomName(int _roomID)
        {
            string roomName = "";
            foreach (var room in allRooms)
            {
                if (room.RoomID == _roomID)
                {
                    roomName = room.RoomName;
                }
            }
            return roomName;
        }




        public void AddRooms(List<Room> rooms)
        {
            allRooms.AddRange(rooms);
        }





        public string DescribeRoom(int _roomID)
        {
            string roomDescription = "";
            foreach (var room in allRooms)
            {
                if (_roomID == room.RoomID)
                {
                    roomDescription = room.RoomDescription;
                }
            }

            return roomDescription;
        }
    }
}
