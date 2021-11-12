using System.Collections.Generic;

namespace GameLib
{
    public class RoomHandler
    {
        List<Room> allRooms = new();


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

        public string ExamineRoom(int _roomID)
        {
            return GetRoom(_roomID).ExamineRoomText;
        }

        public bool IsRoomExaminated(int _roomID)
        {
            return GetRoom(_roomID).RoomExamined;
        }

        public string GetRoomName(int _roomID)
        {
            return GetRoom(_roomID).RoomName;
        }

        public void AddRooms(List<Room> rooms)
        {
            allRooms.AddRange(rooms);
        }

        public string DescribeRoom(int _roomID)
        {
            return GetRoom(_roomID).RoomDescription;
        }
        
        public Room GetRoom(int _roomID)
        {
            foreach (var item in allRooms)
            {
                if (item.RoomID == _roomID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
