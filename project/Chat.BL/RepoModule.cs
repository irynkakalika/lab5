using ConsoleApp1.Domain;
using ConsoleApp1.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BL
{
    public class RepoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<User>>().To<UsersRepository>();
        }
    }
}
