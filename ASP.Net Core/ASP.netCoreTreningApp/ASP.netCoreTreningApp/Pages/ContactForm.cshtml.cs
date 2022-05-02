using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP.netCoreTreningApp.Pages
{
    public class ContactFormModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        public string Title { get; set; }

        [Required]
        [BindProperty]
        public string Context { get; set; }

        public string InfoMessage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                this.InfoMessage = "Thank you for submitting the contact form";
            }
        }
    }
}
