using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginSystemApp.Data;
using LoginSystemApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoginSystemApp.Pages
{
    public class AdminModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminModel(AppDbContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}
