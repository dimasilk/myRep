using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmertexBusTicketsSystem.Tests.Common.ApiClient.Interfaces
{
    public interface ITestClient
    {
        bool Login(string usernameOrEmail, string password);
        bool Register(string userName, string email, string password, string passwordConfirm);
        bool ChangePassword(string oldPassword, string newPassword, string confirmPassword);
    }
}
