using Chat.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public interface IUserService
    {
        void ChangeUser(UserDTO user);
        void DeleteUser(int id);
        void CreateUser(UserDTO user);
        IEnumerable<UserDTO> GetAllUsers();
    }
}
