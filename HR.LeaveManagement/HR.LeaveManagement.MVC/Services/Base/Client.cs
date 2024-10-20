
using System.Net.Http;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public System.Net.Http.HttpClient HttpClient
        {
            get
            {
                return _httpClient;

            }
        }
    }
}
