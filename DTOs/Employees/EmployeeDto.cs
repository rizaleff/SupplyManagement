using API.Models;

namespace API.DTOs.Employees;
public class EmployeeDto
{
    public Guid Guid { get; set; }
    public string FullName { get; set; }

    public string Nik { get; set; }
    public Guid AccountGuid {  get; set; }

    public static explicit operator EmployeeDto(Employee employee)
    {
        return new EmployeeDto
        {
            Guid = employee.Guid,
            FullName = employee.FirstName + " " + employee.LastName,
            Nik = employee.nik,
            AccountGuid = employee.AccountGuid
        };
    }
}
