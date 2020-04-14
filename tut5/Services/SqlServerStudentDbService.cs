using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using tut5.DTOs.Requests;

namespace tut5.Services
{
    public class SqlServerStudentDbService : IStudentServiceDb
    {
        public void EnrollStudent(EnrollStudentRequest request)
        {
            
            using (var con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True"))
            using (var com = new SqlCommand())
            {

                com.CommandText = "SELECT * FROM Studies WHERE Name=@Name";
                com.Parameters.AddWithValue("Name", request.Studies);
                com.Connection = con;

                con.Open();
                var tran = con.BeginTransaction();

                var dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    tran.Rollback(); 
                    
                }
                int idStudies = (int)dr["IdStudies"];
               
                com.CommandText = "SELECT * FROM Enrollment WHERE Semester=1 AND IdStudies=@IdStud";
                                       
                com.CommandText = "INSERT INTO Student(IndexNumber, FirstName, LastName) VALUES (@FirstName, @LastName, @IndexNumber";              
                com.Parameters.AddWithValue("FistName", request.FirstName);
                
                com.ExecuteNonQuery();

                tran.Commit();
            }

        }

        public void PromoteStudents(int semester, string studies)
        {

        }
    }
}
