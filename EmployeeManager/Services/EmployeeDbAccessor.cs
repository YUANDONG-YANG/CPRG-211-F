using Dapper;
using EmployeeManager.Models;
using Npgsql;

namespace EmployeeManager.Services
{
    public class EmployeeDbAccessor : BaseDbAccessor
    {
        public void AddEmployee(Employee employee)
        {
            try
            {
                OpenConnection();
                string sql = @"
                INSERT INTO Employee (dept_id, firstname, lastname, phone, email, grade_id)
                VALUES (@dept_id, @firstname, @lastname, @phone, @email, @grade_id);
                ";

                connection.Execute(sql, new
                {
                    dept_id = employee.dept_id,
                    firstname = employee.firstname,
                    lastname = employee.lastname,
                    phone = employee.phone,
                    email = employee.email,
                    grade_id = employee.grade_id
                });
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                OpenConnection();
                string sql = @"SELECT emp_id, dept_id, dept_name, grade_id, grade_name, firstname, lastname, 
                phone, email, hire_date, fire_date
                FROM Employee NATURAL JOIN Department 
                NATURAL JOIN Wage ORDER BY emp_id ASC";
                return connection.Query<Employee>(sql).ToList();
            }
            finally
            {
                CloseConnection();
            }
        }

        public Employee GetEmployee(int emp_id)
        {
            try
            {
                OpenConnection();
                string sql = "SELECT * FROM Employee WHERE emp_id = @emp_id";
                return connection.QueryFirstOrDefault<Employee>(sql, new { emp_id = emp_id });
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                OpenConnection();
                string sql = @"
                UPDATE Employee 
                SET dept_id = @dept_id, 
                firstname = @firstname, 
                lastname = @lastname,
                phone = @phone,
                email = @email,
                grade_id = @grade_id
                WHERE emp_id = @emp_id;
                ";
                connection.Execute(sql, new
                {
                    dept_id = employee.dept_id,
                    firstname = employee.firstname,
                    lastname = employee.lastname,
                    phone = employee.phone,
                    email = employee.email,
                    grade_id = employee.grade_id,
                    emp_id = employee.emp_id
                });
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteEmployee(int emp_id)
        {
            try
            {
                OpenConnection();
                string sql = "DELETE FROM Employee WHERE emp_id = @emp_id";
                connection.Execute(sql, new { emp_id = emp_id });
            }
            finally
            {
                CloseConnection();
            }
        }

        public void FireEmployee(Employee employee)
        {
            try
            {
                OpenConnection();
                string sql = @"
                UPDATE Employee 
                SET fire_date = @fire_date
                WHERE emp_id = @emp_id;
                ";
                connection.Execute(sql, new
                {
                    fire_date = DateTime.Now,
                    emp_id = employee.emp_id
                });
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CancelFireEmployee(Employee employee)
        {
            try
            {
                OpenConnection();
                string sql = @"
                UPDATE Employee 
                SET fire_date = NULL
                WHERE emp_id = @emp_id;
                ";
                connection.Execute(sql, new
                {
                    emp_id = employee.emp_id
                });
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}