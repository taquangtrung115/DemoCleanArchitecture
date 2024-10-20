using HR.LeaveManagement.MVC.Contracts;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService localStorageService;
        protected IClient client;
        public BaseHttpService(IClient _client, ILocalStorageService _localStorageService)
        {
            localStorageService = _localStorageService;
            client = _client;
        }
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation error have occured.", ValidationErrors = ex.Message, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else {
                return new Response<Guid>() { Message = "Somethiong went wrong, please try again.", Success = false };
            }
        }
        protected void AddBearerToken()
        {
            if (localStorageService.Exists("token"))
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
