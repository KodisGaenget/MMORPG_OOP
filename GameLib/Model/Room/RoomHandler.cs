using System.Collections.Generic;

namespace GameLib
{
    public class RoomHandler
    {
        List<Room> allRooms = new();

        public RoomHandler()
        {
            CreateRooms();
        }

        public string ExamineRoom(int _roomID)
        {
            GetRoom(_roomID).RoomExamined = true;
            return GetRoom(_roomID).ExamineText;
        }

        public bool IsRoomExaminated(int _roomID)
        {
            return GetRoom(_roomID).RoomExamined;
        }

        public string GetRoomName(int _roomID)
        {
            return GetRoom(_roomID).Name;
        }

        public void AddRooms(List<Room> rooms)
        {
            allRooms.AddRange(rooms);
        }

        public string DescribeRoom(int _roomID)
        {
            return GetRoom(_roomID).Description;
        }

        public Room GetRoom(int _roomID)
        {
            foreach (var room in allRooms)
            {
                if (room.ID == _roomID)
                {
                    return room;
                }
            }
            return null;
        }

        private void CreateRooms()
        {
            // INSERT THE ROOM DESCRIPTIONS
        }

        private void AddItemToRoom()
        {
            allRooms[8].ItemInRoomID = 31;
        }
    }
}
