using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HttpContextAccessor _httpContextAccessor;
        public UserService(UserManager<ApplicationUser> userManager, HttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public string UserId { get => _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<Employee> GetEmployeeById(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            var employeeModel = new Employee
            {
                Id = employee.Id,
                Email = employee.Email,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            };
            return employeeModel;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var employeeList = employees.Select(employee => new Employee
            {
                Id = employee.Id,
                Email = employee.Email,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            }).ToList();
            return employeeList;
        }
    }
}
