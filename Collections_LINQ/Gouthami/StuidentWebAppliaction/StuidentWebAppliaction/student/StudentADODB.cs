using Microsoft.Data.SqlClient;
using StudentWebAppliaction.Models;

namespace StudentWebAppliaction.student
{
    public class StudentADODB
    {
        public  List<StudentModel> GetAllStudents()
        {
            var students = new List<StudentModel>();

            // Corrected connection string: added missing semicolon and fixed TrustServerCertificate value
            string connectionString = "Data Source=Gouthami;Initial Catalog=student;Integrated Security=True;TrustServerCertificate=true";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "SELECT StudentId, StudentName, FatherName, Email, MobileNumber, IsActive FROM studentdetails";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var student = new StudentModel();
                //var student = new StudentModel();
                    student.StudentId    = reader["StudentId"] != "" ? Convert.ToInt32( reader["StudentId"] ) : 0;
                    student.StudentName  = reader["StudentName"] != "" ? reader["StudentName"].ToString() : "";
                    student.FatherName   = reader["FatherName"] != "" ? reader["FatherName"].ToString() : "";
                    student.Email        = reader["Email"] != "" ? reader["Email"].ToString() : "";
                    student.MobileNumber = reader["MobileNumber"] != "" ? reader["MobileNumber"].ToString() : "";
                    student.IsActive     = reader["IsActive"] != "" ? Convert.ToBoolean( reader["IsActive"] ) : false;
                     

                students.Add(student);
            }

            return students;
        }
    }

    // Simple DTO for returned student rows
}