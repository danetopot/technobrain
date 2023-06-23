using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Employee.Service
{
    public class EmployeeService
    {
        private static int results = 0;
        private static string path = @"../../../../";

        public EmployeeService() { }

        public SqlConnection OpenDatabaseConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.;Database=TechnoBrain;User ID=sa;Password=SQL123!@#;MultipleActiveResultSets=true;Persist Security Info=True;TrustServerCertificate=True";
            con.Open();
            return con;
        }

        public int  PopulateTable()
        {
            //Delete all records from the table
            FileInfo file = new FileInfo(path + "SqlDelete.sql");
            string script = file.OpenText().ReadToEnd();
            var connection = OpenDatabaseConnection();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = script;
                cmd.ExecuteNonQuery();
            }

            // Insert records to the table
            file = new FileInfo(path + "SqlInsert.sql");
            script = file.OpenText().ReadToEnd();
            using(SqlCommand cmd = connection.CreateCommand())
            { 
                cmd.CommandText = script;
                cmd.ExecuteNonQuery();
            }

            // Count records in the table (Should be 5 if insert is successful)
            file = new FileInfo(path + "SqlSelectCount.sql");
            script = file.OpenText().ReadToEnd();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = script;
                results = (int)cmd.ExecuteScalar();
            }

            return results;

        }

        public int DeleteTable()
        {
            //Delete all records from the table
            FileInfo file = new FileInfo(path + "SqlDelete.sql");
            string script = file.OpenText().ReadToEnd();
            var connection = OpenDatabaseConnection();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = script;
                cmd.ExecuteNonQuery();
            }

            // Count records in the table (Should be 5 if insert is successful)
            file = new FileInfo(path + "SqlSelectCount.sql");
            script = file.OpenText().ReadToEnd();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = script;
                results = (int)cmd.ExecuteScalar();
            }

            return results;
        }

        public int UpdateTable(int employeeId, int newSalary)
        {
            Console.WriteLine($"employeeId : {employeeId}   newSalary : {newSalary}");
            int oldSalary = 0;
            string script = $"[dbo].[UpdateEmployeeSalary]";
            var connection = OpenDatabaseConnection();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = script;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@NewSalary", SqlDbType.Int).Value = newSalary;
                cmd.Parameters.Add("@OldSalary", SqlDbType.Int).Value = null;
                cmd.Parameters["@OldSalary"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                oldSalary = Convert.ToInt32(cmd.Parameters["@OldSalary"].Value);
            }

            Console.WriteLine($"OldSalary : {oldSalary}");

            return oldSalary;
        }
    }
}