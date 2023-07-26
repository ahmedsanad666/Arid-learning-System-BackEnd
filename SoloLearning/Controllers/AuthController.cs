﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoloLearning.Data;
using SoloLearning.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoloLearning.Controllers
{
    [Route("Arid/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private  readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _Configuration;
        private readonly ApplicationDbContext _context;
        public AuthController(UserManager<ApiUser> userManager, IConfiguration configuration, ApplicationDbContext context)
        {

            _userManager = userManager;
           _Configuration = configuration;
            _context   = context;
        }





        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] ApiUser apiUser)
        {
            var user = new ApiUser
            {   
              
                Email = apiUser.Email,
                UserName = apiUser.UserName,
                FirstName = apiUser.FirstName,
                LastName = apiUser.LastName,
                Password = apiUser.Password,
                Role = apiUser.Role,
                // Add any other properties needed for ApplicationUser
            };

            var result = await _userManager.CreateAsync(user, apiUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, apiUser.Role);
            }

          if(result.Errors.Any())
            {
                foreach( var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok(result);
        }



        [HttpPost]
        [Route("LogIn")]
        public async Task<ActionResult<AuthResponse>> LogIn([FromBody] ApiUser apiUser)
        {
    
          
                var user = await _userManager.FindByEmailAsync(apiUser.Email);
                var ValidPassword = await _userManager.CheckPasswordAsync(user, apiUser.Password);
                     var userId = user.Id;

            if (ValidPassword)
            {



                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JwtSettings:Key"]));
             
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var roles = await _userManager.GetRolesAsync(apiUser);
                var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
                var userClaims = await _userManager.GetClaimsAsync(apiUser);
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub , apiUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,apiUser.Email),
                    new Claim("uid",userId)
                }.Union(userClaims).Union(roleClaims);

                var token = new JwtSecurityToken(
                    issuer: _Configuration["JwtSettings:Issuer"],
                    audience: _Configuration["JwtSettings:Audience"],
                    claims : claims,
                  expires: DateTime.Now.AddMinutes(Convert.ToInt32(_Configuration["JwtSettings:DurationInMinutes"])
                   ),
                  signingCredentials: credentials

                  );

                var isAdmin = await _userManager.IsInRoleAsync(user, "admin");
                int UseRole =0;
                if (isAdmin)
                {
                    UseRole = 1;
                }
                else
                {
                    UseRole = 0;

                }


                var userToken =  new JwtSecurityTokenHandler().WriteToken(token);
             var  AuthResponse = new  {
                 Token = userToken,
                UserId = userId,
                 Role = UseRole
             };

                return Ok(AuthResponse);

            }  else
            {

                return Unauthorized();
            }

         
            
           
           
        }

        [HttpGet]
        [Route("getallusers")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            var users =  _userManager.Users.Select(u => new AppUser
            {
                Id = u.Id,
                userName = u.UserName,
                firstName = u.FirstName,
                lastName = u.LastName,
                email = u.Email,
                password= u.Password,
                Role = u.Role,
            }).ToList();

            return Ok(users);
        }






        [HttpPost]
        [Route("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] AppUser model)
        {
            // Find the user by their ID
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            // Update the user's properties
            user.FirstName = model.firstName;
            user.LastName = model.lastName;
            user.Email = model.email;
            user.Password = user.Password;
            //user.Role = user.Role;
            // Update other properties as needed

            // Save the changes to the user
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(); // Return success response
            }
            else
            {
                return BadRequest(result.Errors); // Return errors if the update failed
            }
        }




    }
}
