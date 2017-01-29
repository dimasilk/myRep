using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpClientWrapper.Interfaces
{
    public interface ITokenAuth
    {
        void AddToken(string token);
        void RemoveToken();
    }
}
