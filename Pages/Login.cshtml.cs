using LoginSystemApp.Data;
using LoginSystemApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;

    public LoginModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }
    public string ErrorMessage { get; set; }

    public IActionResult OnPost()
    {
        var hashedPassword = BitConverter.ToString(
            System.Security.Cryptography.SHA256.HashData(
                System.Text.Encoding.UTF8.GetBytes(Password)
            )).Replace("-", "");

        var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == hashedPassword);

        if (user != null)
        {
            if (user.Role == "Admin")
            {
                return RedirectToPage("/Admin");
            }
            else
            {
                return RedirectToPage("/Welcome", new { username = user.Username });
            }
        }

        ErrorMessage = "Invalid username or password.";
        return Page();
    }
}

