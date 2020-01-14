using System;
using System.Threading.Tasks;

namespace PinsApp.Services.Authorisation
{
    public interface IAuthorisationService
    {
        Task RegisterAsync(string name, string email, string password, string passwordAgain);
        Task LoginAsync(string email, string password);
    }
}
