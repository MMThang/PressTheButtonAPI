using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PressTheButtonAPI.DTOs.UserDTOs;
using PressTheButtonAPI.Interfaces;

namespace PressTheButtonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        public UserController(IUserRepository userInterface) {
            _user = userInterface;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO)
        {
            
            try
            {
                var user = await _user.CreateUserRepository(userDTO.Name, userDTO.Password, userDTO.recheckPassword);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO userDTO)
        {

            try
            {
                var token = await _user.LoginUserRepository(userDTO.Name, userDTO.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("check-token")]
        public async Task<IActionResult> CheckToken([FromHeader(Name = "Authorization")] string token)
        {
            
            var jwt = token.Replace("Bearer ", string.Empty);
            try
            {
                var verified = await _user.CheckTokenRepository(jwt);
                return Ok(verified);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Authorize]
        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetUser([FromRoute]Guid id) {
            
            try
            {
                var user = await _user.GetUserRepository(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("account/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]Guid id)
        {

            try
            {
                var user = await _user.DeleteUserRepository(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("like/{userId}")]
        [Authorize]
        public async Task<IActionResult> LikeScenario([FromRoute] Guid userId, [FromBody] int scenarioId)
        {

            try
            {
                var user = await _user.LikeScenarioRepository(userId, scenarioId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("isLike/{userId}/{scenarioId}")]
        [Authorize]
        public async Task<IActionResult> IsScenarioLike([FromRoute] Guid userId, [FromRoute] int scenarioId)
        {
            try
            {
                var user = await _user.IsScenarioLikeRepository(userId, scenarioId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        
        [HttpDelete("like/{userId}/{scenarioId}")]
        [Authorize]
        public async Task<IActionResult> DeleteFavoriteScenarioUser([FromRoute] Guid userId, [FromRoute] int scenarioId)
        {
            try
            {
                var user = await _user.DeleteFavoriteScenarioUserRepository(userId, scenarioId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("history/{userId}")]
        [Authorize]
        public async Task<IActionResult> HistoryScenarioUser([FromRoute] Guid userId, [FromBody] int scenarioId)
        {
            try
            {
                var user = await _user.HistoryScenarioRepository(userId, scenarioId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
