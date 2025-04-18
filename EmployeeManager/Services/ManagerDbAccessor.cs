using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    // 这个类用于向后兼容原有代码，委托给新的专用数据访问器
    public class ManagerDbAccessor
    {
        private readonly DepartmentDbAccessor _departmentDb;
        private readonly WageDbAccessor _wageDb;
        private readonly EmployeeDbAccessor _employeeDb;
        private readonly ReportDbAccessor _reportDb;

        public ManagerDbAccessor()
        {
            _departmentDb = new DepartmentDbAccessor();
            _wageDb = new WageDbAccessor();
            _employeeDb = new EmployeeDbAccessor();
            _reportDb = new ReportDbAccessor();
        }

        // 部门相关方法
        public void AddDepartment(Department dept) => _departmentDb.AddDepartment(dept);
        public List<Department> GetDepartments() => _departmentDb.GetDepartments();
        public void UpdateDepartment(Department dept) => _departmentDb.UpdateDepartment(dept);
        public void DeleteDepartment(int deptId) => _departmentDb.DeleteDepartment(deptId);

        // 工资等级相关方法
        public void AddWage(Wage wage) => _wageDb.AddWage(wage);
        public List<Wage> GetWages() => _wageDb.GetWages();
        public void UpdateWage(Wage wage) => _wageDb.UpdateWage(wage);
        public void DeleteWage(int gradeId) => _wageDb.DeleteWage(gradeId);

        // 员工相关方法
        public void AddEmployee(Employee employee) => _employeeDb.AddEmployee(employee);
        public List<Employee> GetEmployees() => _employeeDb.GetEmployees();
        public Employee GetEmployee(int emp_id) => _employeeDb.GetEmployee(emp_id);
        public void UpdateEmployee(Employee employee) => _employeeDb.UpdateEmployee(employee);
        public void DeleteEmployee(int emp_id) => _employeeDb.DeleteEmployee(emp_id);
        public void FireEmployee(Employee employee) => _employeeDb.FireEmployee(employee);
        public void CancelFireEmployee(Employee employee) => _employeeDb.CancelFireEmployee(employee);

        // 报表相关方法
        public List<EmployeeWage> GetEmployeeWages() => _reportDb.GetEmployeeWages();
    }
}