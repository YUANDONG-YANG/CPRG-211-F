using Dapper;
using EmployeeManager.Models;
using Npgsql;

namespace EmployeeManager.Services
{
    public class DepartmentDbAccessor : BaseDbAccessor
    {
        public void AddDepartment(Department dept)
        {
            try
            {
                OpenConnection();
                string sql = "INSERT INTO department (dept_name) VALUES (@DeptName)";
                connection.Execute(sql, new { DeptName = dept.dept_name });
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Department> GetDepartments()
        {
            try
            {
                OpenConnection();
                string sql = "SELECT * FROM department ORDER BY dept_id ASC";
                return connection.Query<Department>(sql).ToList();
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateDepartment(Department dept)
        {
            try
            {
                OpenConnection();
                string sql = "UPDATE department SET dept_name = @DeptName WHERE dept_id = @DeptId";
                connection.Execute(sql, new { DeptName = dept.dept_name, DeptId = dept.dept_id });
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteDepartment(int deptId)
        {
            try
            {
                OpenConnection();
                string sql = "DELETE FROM department WHERE dept_id = @DeptId";
                try
                {
                    connection.Execute(sql, new { DeptId = deptId });
                }
                catch (PostgresException ex)
                {
                    if (ex.SqlState == "23503") // Foreign key constraint violation
                    {
                        throw new Exception("Cannot delete department. It is referenced by other records.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}