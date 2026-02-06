using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Transactions;


namespace StudentRegistration.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
            

      
    }
}
