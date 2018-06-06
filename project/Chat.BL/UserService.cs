using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.BL.DTO;
using ConsoleApp1.Domain;
using ConsoleApp1.Repository;

namespace Chat.BL
{
    public class UserService : IUserService
    {
        IRepository<User> userrepo;

        public UserService(IRepository<User> repository)
        {
            userrepo = repository;
        }

        public void ChangeUser(UserDTO user)
        {
            User usr = new User(user.id, user.name, user.surname, user.positionId, user.email, user.companyId);
            userrepo.Update(usr);
        }

        public void CreateUser(UserDTO user)
        {
            User usr = new User(user.id, user.name, user.surname, user.positionId, user.email, user.companyId);
            userrepo.Insert(usr);
        }

        public void DeleteUser(int id)
        {
            userrepo.Delete(id);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return userrepo.Read().Select(x=> new UserDTO(x.id,x.name,x.surname,x.positionId,x.email,x.companyId));
        }
    }
}
