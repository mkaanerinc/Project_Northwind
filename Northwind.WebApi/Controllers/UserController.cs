using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Base;
using Northwind.Entity.DTOs;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebApi.Base;
using System;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]       
        public IResponse<UserTokenDto> Login(LoginDto loginDto)
        {
            try
            {
                return _userService.Login(loginDto);
            }
            catch (Exception ex)
            {

                return new Response<UserTokenDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IResponse<UserRegisterDto> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                return _userService.Register(userRegisterDto);
            }
            catch (Exception ex)
            {

                return new Response<UserRegisterDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}
