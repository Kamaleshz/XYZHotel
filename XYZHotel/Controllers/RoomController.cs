using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotel.Repository;

namespace XYZHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository hr;

        public RoomController(IRoomRepository hr)
        {
            this.hr = hr;
        }
        [Authorize(Roles = "Staff")]
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRoom()
        {
            try
            {
                return Ok(hr.GetRoom());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving hotels.");
            }
        }

        [Authorize(Roles = "Staff,Customer")]
        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomByid(int id)
        {
            try
            {
                var rooms = hr.GetRoomByid(id);
                if (rooms == null)
                {
                    return NotFound();
                }
                return Ok(rooms);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the hotel.");
            }
        }
        
        [Authorize(Roles = "Staff")]
        [HttpPost]
        public ActionResult<Room> Post(Room room)
        {
            try
            {
                return Ok(hr.PostRoom(room));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the hotel.");
            }
        }
        
        [Authorize(Roles = "Staff")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Room room)
        {
            try
            {
                hr.PutRoom(room);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the hotel.");
            }
        }

        [Authorize(Roles = "Staff")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                hr.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the hotel.");
            }
        }

    }
}
