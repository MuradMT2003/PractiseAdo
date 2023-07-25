using AdoNet.Models;
using System.Linq.Expressions;

namespace AdoNet.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAll();
        public Task<Student> Get(int id);
        public Task<int> AddStudent(Student student);
    }
}
