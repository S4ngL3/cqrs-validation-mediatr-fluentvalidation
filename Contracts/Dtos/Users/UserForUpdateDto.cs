using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos.Users
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(100, ErrorMessage = "FirstName can't be longer than 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(100, ErrorMessage = "LastName can't be longer than 100 characters")]
        public string LastName { get; set; }
    }
}
