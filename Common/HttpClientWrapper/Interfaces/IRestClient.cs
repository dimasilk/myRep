using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpClientWrapper.Interfaces
{
    public interface IRestClient
    {
        T MakeApiRequest<T>(string pathAndQuery, HttpMethod method, object parms, string revision = null);
        ApiResponse MakeApiRequest(string pathAndQuery, HttpMethod method, object parms, string revision = null);
    }
}
