using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Identiy.Models;

namespace CleanArchitecture.Identiy.Services
{
    public class UserService : IUserService
    {
        public string UserId => throw new NotImplementedException();

        public Task<Employee> GetEmployeeById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
