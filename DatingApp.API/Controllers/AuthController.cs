using System;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dto;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        AuthController(IAuthRepository authRepository)
        {
            _repo = authRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register( UserForRegisterDto userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();
            if (await _repo.UserExists(userForRegister.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegister.Username
            };

            var createdUser= await _repo.Register(userToCreate,userForRegister.Password);

            return StatusCode(201);
            throw new NotImplementedException();
        }
    }
}