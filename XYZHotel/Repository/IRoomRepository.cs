using ClassLibrary.Models;

namespace XYZHotel.Repository
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetRoom();

        public Room GetRoomByid(int id);
        public Room PostRoom(Room rooms);

        public void PutRoom(Room rooms);

        public void DeleteRoom(int id);


    }
}
