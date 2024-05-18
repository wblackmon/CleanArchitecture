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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public string UserId { get => _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid") ?? string.Empty; }

        public async Task<Employee> GetEmployeeById(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            var employeeModel = new Employee
            {
                Id = employee.Id,
                Email = employee.Email ?? string.Empty,
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
                Email = employee.Email ?? string.Empty,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            }).ToList();
            return employeeList;
        }
    }
}
