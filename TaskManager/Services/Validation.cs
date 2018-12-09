using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    static class Validation 
    {
        static public bool IsValid(string login, string password, FakeData context) 
            => context.GetUsers().Any(i => i.Login == login);
    }
}
