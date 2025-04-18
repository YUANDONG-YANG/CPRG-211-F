using Dapper;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class ReportDbAccessor : BaseDbAccessor
    {
        public List<EmployeeWage> GetEmployeeWages()
        {
            try
            {
                OpenConnection();
                string sql = @"SELECT emp_id, dept_id, dept_name, 
                grade_id, grade_name, firstname, lastname, 
                base_wage, bonus_percent
                FROM Employee NATURAL JOIN Department 
                NATURAL JOIN Wage ORDER BY emp_id ASC";
                return connection.Query<EmployeeWage>(sql).ToList();
            }
            finally
            {
                CloseConnection();
            }
        }

        // 可以在这里添加更多报表相关的查询方法
    }
}