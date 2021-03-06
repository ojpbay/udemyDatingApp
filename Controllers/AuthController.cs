﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using udemyDatingApp.Data;
using udemyDatingApp.Dtos;
using udemyDatingApp.Models;

namespace udemyDatingApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository repo, IConfiguration configuration)
        {
            this._repo = repo;
            this._configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userToRegister)
        {
            if (!string.IsNullOrWhiteSpace(userToRegister.Username))
            {
                userToRegister.Username = userToRegister.Username.ToLower();
            }

            if (!string.IsNullOrWhiteSpace(userToRegister.Username))
            {
                if (await _repo.UserExists(userToRegister.Username))
                {
                    ModelState.AddModelError("Username", "Username already exists");
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            var userToCreate = new User
            {
                Username = userToRegister.Username
            };

            var createdUser = await _repo.Register(userToCreate, userToRegister.Password);

            //return CreatedAtRoute()
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLogin)
        {
            var userFromRepo = await _repo.Login(userForLogin.Username.ToLower(), userForLogin.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            string tokenString = GenerateToken(userFromRepo);

            return Ok(new { tokenString });
        }

        private string GenerateToken(User userFromRepo)
        {
            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}