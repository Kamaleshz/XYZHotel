using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotel.Repository;

namespace XYZHotel.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository er;

        public HotelsController(IHotelsRepository er)
        {
            this.er = er;
        }



        [HttpGet]

        public IEnumerable<Hotels> GetHotels()
        {
            return er.GetHotels();
        }

        [HttpGet("{id}")]

        public Hotels Getid(int id)
        {
            return er.GetHotelById(id);
        }
        [HttpPost]

        public Hotels Post(Hotels Hotels)
        {
            return er.PostHotels(Hotels);
        }
        [HttpPut("{id}")]

        public void PutHotel(Hotels Hotels)
        {
            er.PutHotel(Hotels);
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            er.DeleteHotels(id);
        }
        [HttpGet("/count")]

        public int GetAvailableRoomCount(string hotelname)
        {
            int availableSeats = er.GetAvailableRoomCount(hotelname);
            return availableSeats;
        }




        [HttpGet("/filter/location")]
        public IEnumerable<Hotels> GetLocation(string location)
        {
            return er.GetLocation(location);
        }
        [HttpGet("/filter/amenities")]
        public IEnumerable<Hotels> GetAmenities(string amenities)
        {
            return er.GetAmenities(amenities);
        }
        [HttpGet("/filter/price")]
        public IEnumerable<Hotels> GetPrice(int price)
        {
            return er.GetPrice(price);
        }
    }
}
