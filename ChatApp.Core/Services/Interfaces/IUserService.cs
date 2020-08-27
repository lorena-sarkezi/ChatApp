using ChatApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        string TryLoginUser(LoginModel model);
    }
}
