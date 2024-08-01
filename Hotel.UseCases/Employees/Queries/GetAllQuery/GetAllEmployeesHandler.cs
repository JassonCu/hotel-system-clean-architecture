using Application.DTOS.Employees.Response;
using AutoMapper;
using Hotel.Interface.Interfaces;
using Hotel.UseCases.Commons.Bases;
using MediatR;

namespace Hotel.UseCases.Employees.Queries.GetAllQuery
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeeQuery, BaseResponse<IEnumerable<GetEmployeesReponseDto>>>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesHandler(IEmployeesRepository employeesRepository, IMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetEmployeesReponseDto>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetEmployeesReponseDto>>();

            try
            {
                var employees = await _employeesRepository.ListEmployees();
                if(employees is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetEmployeesReponseDto>>(employees);
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
