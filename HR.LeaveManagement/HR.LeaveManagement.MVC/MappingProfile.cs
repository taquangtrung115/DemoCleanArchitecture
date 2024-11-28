using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDTO, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDTO, LeaveTypeVM>().ReverseMap();
        }
    }
}
