using AutoMapper;
using Entity = Hotel.Domian.Entities;
using Hotel.Interface.Interfaces;
using Hotel.UseCases.Commons.Bases;
using MediatR;
using Hotel.Utils.HelperExtensions;
using Hotel.Utils.Constants;

namespace Hotel.UseCases.Commands.Employee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<bool>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var employee = _mapper.Map<Entity.Employee>(request);
                var parameters = employee.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Employee.ExecAsync(StoreProcedures.uspAnalysisRegister, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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
