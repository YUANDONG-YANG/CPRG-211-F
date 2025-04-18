namespace EmployeeManager.Models;
public class Employee: Person
{
    public int emp_id { get; set; }
    public int dept_id { get; set; }
    public string dept_name { get; set; }
    public int grade_id { get; set; }
    public string grade_name { get; set; }
    public DateTime? hire_date { get; set; }
    public DateTime? fire_date { get; set; }
}