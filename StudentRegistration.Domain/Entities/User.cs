using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace StudentRegistration.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        
     
        public Student Student { get; set; }
       
    }
}
