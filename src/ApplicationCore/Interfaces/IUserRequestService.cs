using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRequestService
    {
        Task<UserDetailDto> GetUser(int userId);
        Task<List<UserListDto>> GetUsers();
    }
}
