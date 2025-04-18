using Dapper;
using EmployeeManager.Models;
using Npgsql;

namespace EmployeeManager.Services
{
    public class WageDbAccessor : BaseDbAccessor
    {
        public void AddWage(Wage wage)
        {
            // Validate wage object
            if (wage == null)
                throw new ArgumentNullException(nameof(wage), "Wage data must be provided.");
            if (string.IsNullOrWhiteSpace(wage.grade_name))
                throw new Exception("Grade name must be provided.");
            if (wage.base_wage <= 0)
                throw new Exception("Base wage must be provided and greater than zero.");
            if (wage.bonus_percent < 0)
                throw new Exception("Bonus percent must be provided and greater than zero.");

            try
            {
                OpenConnection();
                string sql = @"
                INSERT INTO Wage (grade_name, base_wage, bonus_percent)
                VALUES (@GradeName, @BaseWage, @BonusPercent);";

                connection.Execute(sql, new
                {
                    GradeName = wage.grade_name,
                    BaseWage = wage.base_wage,
                    BonusPercent = wage.bonus_percent
                });
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Wage> GetWages()
        {
            try
            {
                OpenConnection();
                string sql = "SELECT * FROM Wage ORDER BY grade_id ASC";
                return connection.Query<Wage>(sql).ToList();
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateWage(Wage wage)
        {
            // Validate wage object
            if (wage == null)
                throw new ArgumentNullException(nameof(wage), "Wage data must be provided.");
            if (string.IsNullOrWhiteSpace(wage.grade_name))
                throw new Exception("Grade name must be provided.");
            if (wage.base_wage <= 0)
                throw new Exception("Base wage must be provided and greater than zero.");
            if (wage.bonus_percent < -1)
                throw new Exception("Bonus percent must be provided and greater than zero.");

            try
            {
                OpenConnection();
                string sql = @"
                UPDATE Wage 
                SET grade_name = @GradeName, 
                base_wage = @BaseWage, 
                bonus_percent = @BonusPercent
                WHERE grade_id = @GradeId;
                ";
                connection.Execute(sql, new
                {
                    GradeName = wage.grade_name,
                    BaseWage = wage.base_wage,
                    BonusPercent = wage.bonus_percent,
                    GradeId = wage.grade_id
                });
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteWage(int gradeId)
        {
            try
            {
                OpenConnection();
                string sql = "DELETE FROM Wage WHERE grade_id = @GradeId";
                try
                {
                    connection.Execute(sql, new { GradeId = gradeId });
                }
                catch (PostgresException ex)
                {
                    if (ex.SqlState == "23503") // Foreign key constraint violation
                    {
                        throw new Exception("Cannot delete wage. It is referenced by other records.");
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