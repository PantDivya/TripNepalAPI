using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using tripNepalSystem.DAL;
using tripNepalSystem.DTO;
using tripNepalSystem.Model;

namespace PMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TripNepalDbContext _dbContext;

        public AuthenticationController(TripNepalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST api/authentication/signup
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid username or password");
            }

            if (_dbContext.Users.Any(u => u.UserName == user.UserName))
            {
                return Conflict("Username already exists");
            }

            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;

            _dbContext.Add(newUser);
            _dbContext.SaveChanges();

            return Ok("User created successfully");
        }

        // POST api/authentication/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentialDTO userCredentialDTO)
        {
            if (userCredentialDTO == null || string.IsNullOrEmpty(userCredentialDTO.UserName) || string.IsNullOrEmpty(userCredentialDTO.Password))
            {
                return BadRequest("Invalid username or password");
            }

            var user = _dbContext.Users.SingleOrDefault(u => u.UserName == userCredentialDTO.UserName && u.Password == userCredentialDTO.Password);

            if (user == null)
            {
                return NotFound("User not found or invalid credentials");
            }

            return Ok("Login successful");
        }
       
    }
}

