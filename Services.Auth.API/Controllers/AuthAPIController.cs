using Microsoft.AspNetCore.Mvc;
using WebApp21.MessageBus;
using WebApp21.MessageBus.Common;
using WebApp21.Services.AuthAPI.Models.Dto;
using WebApp21.Services.AuthAPI.Services.IService;

namespace WebApp21.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMessageBus _messageBus;
        protected ResponseDto _response; //inchia protected
        public AuthAPIController(IAuthService authService, IMessageBus messageBus)
        {
            _authService = authService;
            _messageBus = messageBus;
            _response = new();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {

            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            RegisterUserMessaging registerUserMessaging = new RegisterUserMessaging { Email = model.Email };
            await _messageBus.PublishMessage(registerUserMessaging);
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);

            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpGet("GetUserId")]
        public async Task<IActionResult> GetUserId(string email)
        {
            var userId = await _authService.GetUserId(email);
            if (userId == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            _response.Result = userId;
            return Ok(_response);
        }

    }

}
