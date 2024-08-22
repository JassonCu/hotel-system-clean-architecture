using Application.DTOS.Employees.Response;
using Hotel.UseCases.Commons.Bases;
using MediatR;

namespace Hotel.UseCases.Employees.Queries.GetAllQuery
{
    public class GetAllEmployeeQuery : IRequest<BaseResponse<IEnumerable<GetEmployeesResponseDto>>>
    {
    }
}
