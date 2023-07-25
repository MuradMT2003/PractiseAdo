using AdoNet.Helpers;
using AdoNet.Models;
using AdoNet.Services.Interfaces;
using System.Linq.Expressions;

namespace AdoNet.Services.Implements
{
    public class StudentService : IStudentService
    {
        public Task<int> AddStudent(Student student)
        {
            var res = SqlHelper.Execute($"Insert into Students Values('{student.Name}','{student.Surname}')");
            return res;
        }

        public  async Task<Student> Get(int id)
        {
            
                var res= await SqlHelper.Select("Select * From Students where Id=" + id);
                return  res.FirstOrDefault(x=>x.Id == id);   
        }

        public Task<List<Student>> GetAll()
        {
            return SqlHelper.Select("Select * From Students");
        }
    }
}
