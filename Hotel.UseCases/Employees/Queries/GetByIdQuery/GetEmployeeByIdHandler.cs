using Application.DTOS.Employees.Response;
using AutoMapper;
using Hotel.Interface.Interfaces;
using Hotel.UseCases.Commons.Bases;
using Hotel.Utils.Constants;
using MediatR;

namespace Hotel.UseCases.Employees.Queries.GetByIdQuery
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, BaseResponse<GetEmployeeByIdResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<GetEmployeeByIdResponseDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetEmployeeByIdResponseDto>();

            try
            {
                var employee = await _unitOfWork.Employee.GetByIdAsync(StoreProcedures.uspEmployeeById, request);

                if (employee is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetEmployeeByIdResponseDto>(employee);
                response.Message = GlobalMessage.MESSAGE_QUERY;
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
