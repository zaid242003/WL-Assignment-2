using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace RecruitmentCoreMVC.Models
{
    public class Candidate
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select a qualification.")]
        public string Qualification { get; set; }

        [Range(0, 50, ErrorMessage = "Enter a valid number of years.")]
        [Display(Name = "Experience (in years)")]
        public int Experience { get; set; }

        public List<string> Skills { get; set; } = new List<string>();

        [Display(Name = "Upload CV")]
        public IFormFile CVFile { get; set; }
    }
}
