namespace Application.DTOS.Employees.Response
{
    public class GetEmployeesReponseDto
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
        public int? EmployeeStateID { get; set; }
    }
}
