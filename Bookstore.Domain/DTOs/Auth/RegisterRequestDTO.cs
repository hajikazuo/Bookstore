using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.DTOs.Auth
{
    public class RegisterRequestDTO
    {
        [EmailAddress(ErrorMessage = "Invalid email.")]

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
