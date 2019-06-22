using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRApp.ServiceHost.API.Business;
using HRApp.ServiceHost.API.Contracts;
using HRApp.ServiceHost.API.Data;
using HRApp.ServiceHost.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.ServiceHost.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET api/Users/GetAll"      
        [HttpGet("GetAll")]
        public async Task<UserResponse> GetAll()
        {
            return await _userBusiness.GetAllAsync();
        }
        [HttpGet("Get/{id}")]
        public async Task<UserResponse> Get(long id)
        {
            return await _userBusiness.GetAsync(id);
        }     
        [AllowAnonymous]
        [ProducesResponseType(201)]
        [HttpPost("Post")]
        public async Task Post([FromBody]User user)
        {
            await _userBusiness.AddAsync(user);
        }
        [HttpPut("Put")]
        public async Task Put([FromBody]User user)
        {
            await _userBusiness.UpdateAsync(user);
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userBusiness.Authenticate(userParam.username, userParam.password);
            if (user == null)
                return BadRequest(new { message = "Kullanıcı adınız veya şifreniz yanlış ." });
            return Ok(user.Result);
        }
    }
}