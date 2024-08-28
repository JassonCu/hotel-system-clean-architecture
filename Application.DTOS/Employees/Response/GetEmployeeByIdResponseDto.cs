namespace Application.DTOS.Employees.Response
{
    public class GetEmployeeByIdResponseDto
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
