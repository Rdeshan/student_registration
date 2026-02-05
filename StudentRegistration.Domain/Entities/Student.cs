using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Domain.Entities
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string NIC { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastNameWithInitials { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string BasicQualifications { get; set; } = string.Empty;


        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }


       
        public int UserId { get; set; }
    
        public User User { get; set; }
       

    }
}