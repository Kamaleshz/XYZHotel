using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XYZHotel.DB;

namespace XYZHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelsContext _context;

        private const string CustomerRole = "Customer";
        private const string StaffRole = "Staff";

        public TokenController(IConfiguration config, HotelsContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Customer")]
        public async Task<IActionResult> Post(Customer _userData)
        {
            if (_userData != null && _userData.CustomerEmail != null && _userData.CustomerPassword != null)
            {
                var user = await GetUser(_userData.CustomerEmail, _userData.CustomerPassword);

                if (user != null)
                {

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("CutomerId", user.CutomerId.ToString()),
                         new Claim("CustomerEmail", user.CustomerEmail),
                        new Claim("CustomerPassword",user.CustomerPassword),
                        new Claim(ClaimTypes.Role, CustomerRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:ValidIssuer"],
                        _configuration["Jwt:ValidAudience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Customer> GetUser(string email, string password)
        {
            return await _context.Customer.FirstOrDefaultAsync(u => u.CustomerEmail == email && u.CustomerPassword == password);
        }

        [HttpPost("Staff")]
        public async Task<IActionResult> PostStaff(Staff staffData)
        {
            if (staffData != null && !string.IsNullOrEmpty(staffData.StaffName) && !string.IsNullOrEmpty(staffData.StaffPassword))
            {
                var staff = await GetStaff(staffData.StaffName, staffData.StaffPassword);

                if (staff != null)
                {
                    var claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("StaffId", staff.StaffId.ToString()),
                new Claim("StaffName", staff.StaffName),
                new Claim("StaffPassword", staff.StaffPassword),
                new Claim(ClaimTypes.Role, StaffRole)
            };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:ValidIssuer"],
                        _configuration["Jwt:ValidAudience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Staff> GetStaff(string staffName, string staffPassword)
        {
            return await _context.Staffs.FirstOrDefaultAsync(s => s.StaffName == staffName && s.StaffPassword == staffPassword);
        }
    }
}

