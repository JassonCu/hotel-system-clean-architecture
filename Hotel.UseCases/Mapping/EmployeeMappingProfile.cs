using Application.DTOS.Employees.Response;
using AutoMapper;
using Hotel.Domian.Entities;

namespace Hotel.UseCases.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile() {

            CreateMap<Employee, GetEmployeesResponseDto>()
                .ReverseMap();

            CreateMap<Employee, GetEmployeeByIdResponseDto>()
                .ReverseMap();
        }
    }
}
