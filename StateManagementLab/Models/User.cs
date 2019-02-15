using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StateManagementLab.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[A-Z{1}]+[a-zA-z{1,30}]+$", ErrorMessage = "Please enter a valid name.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z{1}]+[a-zA-z{1,30}]+$", ErrorMessage = "Please enter a valid name.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9{5,30}]+@[a-zA-A0-9{5,10}]+\.[a-zA-Z0-9{2,3}]+$", ErrorMessage = "Incorrect E-mail Format!")]
        public string Email { get; set; }

        public int Age { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }


        public User(string firstName, string lastName, string email, int age, string password, string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Password = password;
            ConfirmPassword = confirmPassword;
        }


        public User() { }
    }
}