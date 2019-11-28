using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using code_test.common.Models;
using code_test.common.Services;
using NUnit.Framework;

namespace code_test_unit_tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUsersService _usersService;
        
        [SetUp]
        public void Init()
        {
            _usersService = new UsersService("http://localhost:7070");
        }

        [Test]
        public async Task GetAllUsersReturnsResponseAsListOfUser()
        {
            var response = await _usersService.GetAllUsers();
            
            CollectionAssert.IsNotEmpty(response);
        }

        [Test]
        public async Task GetUserById1ReturnsChaseWarner()
        {
            var response = await _usersService.GetById("1");
            
            Assert.AreEqual(1, response.Id);
            Assert.AreEqual("Chase", response.FirstName);
            Assert.AreEqual("Warner", response.SecondName);
            Assert.AreEqual("nulla.ante@vel.net", response.EmailAddress);
        }
    }
}