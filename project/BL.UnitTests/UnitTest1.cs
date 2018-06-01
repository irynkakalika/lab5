using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Repository;
using ConsoleApp1.Domain;
using System.Configuration;

namespace BL.UnitTests
{
    [TestClass()]
    public class UserTest
    {
        [TestMethod()]
        public void TestInsert()
        {
            IRepository<User> repo = new UsersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            int id = 3000;

            User user = new User(id, "Tom", "Hardson", 1, "hardson@gmail.com", 2);
            repo.Insert(user);

            User selectedUser = repo.ReadById(id);

            Assert.AreEqual<User>(user, selectedUser);
        }

        [TestMethod()]
        public void TestUpdate()
        {
            IRepository<User> repo = new UsersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            int id = 3000;

            var user = repo.ReadById(id);
            user.name = "Nikola";
            repo.Update(user);

            var updatedUser = repo.ReadById(id);

            Assert.AreEqual<User>(user, updatedUser);
        }

        [TestMethod()]
        public void TestSelect()
        {
            IRepository<User> repo = new UsersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var users = repo.Read();
            Assert.IsNotNull(users);
        }

        [TestMethod()]
        public void TestDelete()
        {
            IRepository<User> repo = new UsersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            int id = 3000;

            repo.Delete(id);

            User user = repo.ReadById(id);

            Assert.IsNull(user);
        }
    }
}
