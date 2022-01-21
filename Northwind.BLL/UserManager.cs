using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.DTOs;
using Northwind.Entity.Models;
using Northwind.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entity.IBase;
using Northwind.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Northwind.BLL
{
    public class UserManager : GenericService<User, UserDto>, IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserManager(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            _userRepository = serviceProvider.GetService<IUserRepository>();
            _configuration = configuration;
        }

        public IResponse<UserTokenDto> Login(LoginDto login)
        {
            var userPassword = login.Password;
            login.Password = EncryptionManager.MD5Encrypt(userPassword);

            var user = _userRepository.Login(ObjectMapper.Mapper.Map<User>(login));

            if(user != null)
            {
                var dtoUserLogin = ObjectMapper.Mapper.Map<UserLoginDto>(user);
                var token = new TokenManager(_configuration).CreateAccessToken(dtoUserLogin);


                var userToken = new UserTokenDto()
                {
                    UserLoginDto = dtoUserLogin,
                    AccessToken = token
                };

                return new Response<UserTokenDto>
                {
                    Message = "Token is success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };

            } else
            {
                return new Response<UserTokenDto>
                {
                    Message = "UserCode or Password is invalid",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
            
        }

        public IResponse<UserRegisterDto> Register(UserRegisterDto register)
        {
            string userPassword = register.Password;
            register.Password = EncryptionManager.MD5Encrypt(userPassword);

            var addedRegister = _userRepository.Register(ObjectMapper.Mapper.Map<User>(register));

            try
            {
                return new Response<UserRegisterDto>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = ObjectMapper.Mapper.Map<UserRegisterDto>(addedRegister)
                };
            }
            catch (Exception ex)
            {

                return new Response<UserRegisterDto>
                {
                    Message = $"Error{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}
