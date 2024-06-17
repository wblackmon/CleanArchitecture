using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.UI.Models;

public class LoginVm
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
