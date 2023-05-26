using ClassLibrary.Models;
using static XYZHotel.Repository.HotelsRepository;
using XYZHotel.DB;
using Microsoft.EntityFrameworkCore;

namespace XYZHotel.Repository
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly HotelsContext HotelContext;

        public HotelsRepository(HotelsContext con)
        {
            HotelContext = con;
        }
        public Hotels GetHotelById(int id)
        {
            return HotelContext.hotels.FirstOrDefault(x => x.HotelId == id);
        }
        public IEnumerable<Hotels> GetHotels()
        {
            return HotelContext.hotels.ToList();
        }
        public Hotels PostHotels(Hotels Hotels)
        {
            HotelContext.hotels.Find(Hotels.HotelId);
            HotelContext.hotels.Add(Hotels);
            HotelContext.SaveChanges();
            return Hotels;
        }
        public void PutHotel(Hotels Hotels)
        {
            HotelContext.Entry(Hotels).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            HotelContext.SaveChanges();
        }
        public void DeleteHotels(int id)
        {
            Hotels e = HotelContext.hotels.FirstOrDefault(x => x.HotelId == id);
            HotelContext.hotels.Remove(e);
            HotelContext.SaveChanges();
        }

        public int GetAvailableRoomCount(string hotelname)
        {
            var hotel = HotelContext.hotels.Include(f => f.Bookings).FirstOrDefault(f => f.HotelName == hotelname);

            if (hotel == null)
                return 0;

            int totalRooms = hotel.RoomAvailablity;
            int bookedRooms = hotel.Bookings.Count();
            int availableRooms = totalRooms - bookedRooms;

            return availableRooms >= 0 ? availableRooms : 0;




        }

        public IEnumerable<Hotels> GetLocation(string location)
        {
            return HotelContext.hotels.Where(e => e.HotelLocation == location).ToList();
        }

        public IEnumerable<Hotels> GetAmenities(string amenities)
        {
            return HotelContext.hotels.Where(e => e.HotelAmenities == amenities).ToList();
        }

        public IEnumerable<Hotels> GetPrice(int price)
        {
            return HotelContext.hotels.Where(e => e.HotelPrice == price).ToList();
        }

        
}
}
