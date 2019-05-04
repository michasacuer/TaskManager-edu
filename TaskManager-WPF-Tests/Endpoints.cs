using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.WPF.Enums;
using TaskManager.WPF.Models.BindingModels;
using TaskManager.WPF.Services;

namespace TaskManager_WPF_Tests
{
    [TestClass]
    public class Enpoints
    {
        HttpDataService http = new HttpDataService();

        [TestMethod]
        public async Task IsLoginWorking()
        {
            var login = new LoginBindingModel { UserName = "write smth", Password = "write smth" };

            var account = await http.Login(login);

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public async Task IsRegisterWorking()
        {
            var account = new RegistrationBindingModel
            {
                UserName = "TestUser",
                FirstName = "TestFirst", //Remember, that you cant register two users with the same credentials!
                LastName = "LastTest",
                Password = "test00",
                Email = "Email@dddde.pl",
                Role = Role.Manager
            };

            string response = await http.Register(account);

            Assert.Equals(response, "OK");
        }
    }
}
