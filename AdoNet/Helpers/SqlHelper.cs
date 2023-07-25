using AdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet.Helpers
{
    public static class SqlHelper
    {
        private const string conn = "Server=VENUS04\\MAINDB;Database=Management;Trusted_Connection=true;";

        public async static Task<List<Student>> Select(string query)
        {
            List<Student> students =new List<Student>();
            using(SqlConnection sc=new SqlConnection(conn))
            {
                await sc.OpenAsync();
                using(SqlDataAdapter sda=new SqlDataAdapter(query, sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        students.Add(new Student()
                        {
                            Id =Convert.ToInt32 (dr[0]),
                            Name = dr[1].ToString(),
                            Surname = dr[2].ToString()
                        });
                    }
                    return students;
                }
            }
        }

        public async static Task<int> Execute(string query)
        {
            using (SqlConnection sc = new SqlConnection(conn))
            {
                await sc.OpenAsync();
                using (SqlCommand sco = new SqlCommand(query,sc))
                {
                   return await sco.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
