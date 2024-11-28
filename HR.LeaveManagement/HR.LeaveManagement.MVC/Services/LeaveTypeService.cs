using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IMapper mapper;
        private readonly IClient httpClient;

        public LeaveTypeService(IMapper mapper, IClient httpcCient, ILocalStorageService localStorageService) : base(httpcCient, localStorageService)
        {
            this.mapper = mapper;
            this.httpClient = httpcCient;
            this.localStorageService = localStorageService;
        }
        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDTO createLeaveTypeDTO = mapper.Map<CreateLeaveTypeDTO>(leaveType);
                var apiResponse = await client.LeaveTypePOSTAsync(createLeaveTypeDTO);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                await client.LeaveRequestDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveType = await client.LeaveTypeGETAsync(id);
            return mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveType = await client.LeaveTypeAllAsync();
            return mapper.Map<List<LeaveTypeVM>>(leaveType);
        }

        public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                LeaveTypeDTO leaveTypeDTO = mapper.Map<LeaveTypeDTO>(leaveType);
                await client.LeaveTypePUTAsync(id, leaveTypeDTO);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
