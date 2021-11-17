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
            allRooms.Add(new Room(1, "Room 1", "Room description string", "Room Examine string", 2, null, null, null));
            allRooms.Add(new Room(2, "Room 2", "Room description string", "Room Examine string", 5, 4, 1, 3));
            allRooms.Add(new Room(3, "Room 3", "Room description string", "Room Examine string", null, 2, null, null));
            allRooms.Add(new Room(4, "Room 4", "Room description string", "Room Examine string", null, null, null, 2));
            allRooms.Add(new Room(5, "Room 5", "Room description string", "Room Examine string", 6, null, 2, null));
            allRooms.Add(new Room(6, "Room 6", "Room description string", "Room Examine string", 8, null, 5, 7));
            allRooms.Add(new Room(7, "Room 7", "Room description string", "Room Examine string", null, 6, null, null));
            allRooms.Add(new Room(8, "Room 8", "Room description string", "Room Examine string", 11, 9, 6, null));
            allRooms.Add(new Room(9, "Room 9", "Room description string", "Room Examine string", null, 10, null, 8));
            allRooms.Add(new Room(10, "Room 10", "Room description string", "Room Examine string", null, null, null, 9));
            allRooms.Add(new Room(11, "Room 11", "Room description string", "Room Examine string", null, null, 8, null));
        }
    }
}
