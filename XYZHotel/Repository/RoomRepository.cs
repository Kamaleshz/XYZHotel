using ClassLibrary.Models;
using XYZHotel.DB;

namespace XYZHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelsContext hotelContext;

        public RoomRepository(HotelsContext con)
        {
            hotelContext = con;
        }
        public Room GetRoomByid(int id)
        {
            return hotelContext.Rooms.FirstOrDefault(x => x.RoomId == id);
        }
        public IEnumerable<Room> GetRoom()
        {
            return hotelContext.Rooms.ToList();
        }
        public Room PostRoom(Room rooms)
        {
            hotelContext.Rooms.Find(rooms.RoomId);
            hotelContext.Rooms.Add(rooms);
            hotelContext.SaveChanges();
            return rooms;
        }
        public void PutRoom(Room rooms)
        {
            hotelContext.Entry(rooms).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            hotelContext.SaveChanges();
        }
        public void DeleteRoom(int id)
        {
            Room e = hotelContext.Rooms.FirstOrDefault(x => x.RoomId == id);
            hotelContext.Rooms.Remove(e);
            hotelContext.SaveChanges();
        }

    }
}
