using Northwind.Entity.DTOs;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IUserService : IGenericService<User,UserDto>
    {
        IResponse<UserTokenDto> Login(LoginDto login);

        IResponse<UserRegisterDto> Register(UserRegisterDto register);
    }
}
