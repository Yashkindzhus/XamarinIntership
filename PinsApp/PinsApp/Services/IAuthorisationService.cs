using System;
namespace PinsApp.Services
{
    public interface IAuthorisationService
    {
        void Register(string _Name, string _Email, string _Password, string _PasswordAgain);
        void Login(string _Email, string _Password);
    }
}
