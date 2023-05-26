using ClassLibrary.Models;

namespace XYZHotel.Repository
{
    public interface IHotelsRepository 
    {
        public IEnumerable<Hotels> GetHotels();

        public Hotels GetHotelById(int id);

        public Hotels PostHotels(Hotels Hotels);


        public void PutHotel(Hotels Hotels);

        public void DeleteHotels(int id);
        int GetAvailableRoomCount(string hotelname);



        IEnumerable<Hotels> GetLocation(string location);


        IEnumerable<Hotels> GetAmenities(string amenities);

        IEnumerable<Hotels> GetPrice(int price);

    }
    
}
