using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MinhlndShop.API.JWT;
using MinhlndShop.API.Models;
using MinhlndShop.Model.Model;
using MinhlndShop.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhlndShop.API.Infrastructure.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhlndShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService ;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig; 

        public UserController(IOptions<JwtConfig> jwtConfig, IUserService userService, IMapper mapper)
        { 
            _userService = userService;
            _jwtConfig = jwtConfig.Value;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {

            User user = _userService.Login("minhlnd", "minhlnd");
            string token = string.Empty;

            if (user != null)
            {
                token = JwtAction.GetInstance().GenerateJwtToken(user, _jwtConfig);
            }

            var newUser = new UserViewModel
            {
                //UserName = "user1",
                Password = "user1",
            };

            var userVm = _mapper.Map<User>(newUser); 

            //_userService.CreateUser(newUser);
            //_userService.Save();

            return Ok(userVm) ; 
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<string>> Login(string userName ,string password)
        {
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
