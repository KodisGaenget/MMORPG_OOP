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
            return GetRoom(_roomID).ExamineRoom;
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
            Room getRoom = new();
            foreach (var item in allRooms)
            {
                if (item.ID == _roomID)
                {
                    getRoom = item;
                }
            }
            return getRoom;
        }

        private void CreateRooms()
        {
            allRooms.Add(new Room(1, "Room 1", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(2, "Room 2", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(3, "Room 3", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(4, "Room 4", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(5, "Room 5", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(6, "Room 6", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(7, "Room 7", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(8, "Room 8", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(9, "Room 9", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(10, "Room 10", "Room description string", "Room Examine string"));
            allRooms.Add(new Room(11, "Room 11", "Room description string", "Room Examine string"));
            ConnectRooms();
        }

        private void ConnectRooms()
        {
            foreach (Room room in allRooms)
            {
                if (room.ID == 1)
                {
                    room.North = allRooms[1];
                }
                if (room.ID == 2)
                {
                    room.North = allRooms[4];
                    room.East = allRooms[3];
                    room.South = allRooms[0];
                    room.West = allRooms[2];
                }
                if (room.ID == 3)
                {
                    room.East = allRooms[1];
                }
                if (room.ID == 4)
                {
                    room.West = allRooms[1];
                }
                if (room.ID == 5)
                {
                    room.North = allRooms[5];
                    room.South = allRooms[1];
                }
                if (room.ID == 6)
                {
                    room.North = allRooms[7];
                    room.South = allRooms[4];
                    room.West = allRooms[6];
                }
                if (room.ID == 7)
                {
                    room.East = allRooms[5];
                }
                if (room.ID == 8)
                {
                    room.North = allRooms[10];
                    room.East = allRooms[8];
                    room.South = allRooms[5];
                }
                if (room.ID == 9)
                {
                    room.East = allRooms[9];
                    room.West = allRooms[7];
                }
                if (room.ID == 10)
                {
                    room.West = allRooms[8];
                }
                if (room.ID == 11)
                {
                    room.South = allRooms[7];
                }
            }

        }
    }
}
