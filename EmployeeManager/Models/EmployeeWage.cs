namespace EmployeeManager.Models;

public class EmployeeWage: Person
{
    public int emp_id { get; set; }
    public int dept_id { get; set; }
    public string dept_name { get; set; }
    public int grade_id { get; set; }
    public string grade_name { get; set; }
    public decimal base_wage { get; set; }
    public decimal bonus_percent { get; set; }
}