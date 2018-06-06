using System;
using System.Collections.Generic;
using System.Configuration;
using Chat.BL;
using Chat.BL.DTO;
using ConsoleApp1.Domain;
using ConsoleApp1.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace UnitTestNew
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IRepository<User>> mockrepository;
        IUserService service;
        public UnitTest1()
        {
            mockrepository = new Mock<IRepository<User>>();
            service = new UserService(mockrepository.Object);
        }

        [TestMethod]
        public void TestInsert()
        {
            mockrepository.Setup(m => m.ReadById(It.IsAny<Int32>())).Returns(() => null);
            service.CreateUser(new UserDTO(1, "test", "test", 1, "test", 1));
            mockrepository.Verify(m => m.Insert(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void TestUpdate()
        {
            mockrepository.Setup(m => m.ReadById(It.IsAny<Int32>())).Returns(new User(1, "test", "test", 1, "test", 1));
            service.ChangeUser(new UserDTO(1, "test", "test", 1, "test", 1));
            mockrepository.Verify(m => m.Update(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void TestSelect()
        {
            mockrepository.Setup(m => m.Read()).Returns(new List<User>{
                new User(1, "test", "test", 1, "test", 1),
                new User(2, "test", "test", 1, "test", 1),
                new User(3, "test", "test", 1, "test", 1)
                });
            var users = service.GetAllUsers();
            Assert.AreEqual(3, users.Count());
        }

        [TestMethod]
        public void TestDelete()
        {
            mockrepository.Setup(m => m.ReadById(It.IsAny<Int32>())).Returns(new User(1, "test", "test", 1, "test", 1));
            service.DeleteUser(1);
            mockrepository.Verify(m => m.Delete(It.IsAny<Int32>()), Times.Once);
        }
    }
}
