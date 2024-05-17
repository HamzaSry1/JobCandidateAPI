using System.ComponentModel.DataAnnotations;

namespace JobCandidateAPI.Models
{
    public class Candidate
    {
        [Key]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PreferredCallTime { get; set; }
        public string LinkedIn_Profile_Url { get; set; }
        public string Github_Profile_Url { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
