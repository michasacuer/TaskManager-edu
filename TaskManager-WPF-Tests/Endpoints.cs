using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string username = "pass something";
            string password = "pass something";
            var account = await http.Login(username, password);

            Assert.IsNotNull(account);
        }
    }
}
