using Hotel.UseCases.Commons.Bases;
using MediatR;

namespace Hotel.UseCases.Commands.Employee
{
    public class CreateEmployeeCommand : IRequest<BaseResponse<bool>>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Position { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public int? CreatedBy { get; set; }
    }
}
