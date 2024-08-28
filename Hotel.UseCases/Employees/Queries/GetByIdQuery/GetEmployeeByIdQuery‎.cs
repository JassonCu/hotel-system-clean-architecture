using Application.DTOS.Employees.Response;
using Hotel.UseCases.Commons.Bases;
using MediatR;

namespace Hotel.UseCases.Employees.Queries.GetByIdQuery
{
    public class GetEmployeeByIdQuery : IRequest<BaseResponse<GetEmployeeByIdResponseDto>>
    {
        public int EmployeeID { get; set; }
    }
}
