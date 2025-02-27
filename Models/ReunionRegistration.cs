using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ReunionRegistration
    {
        public int ReunionRegistrationId { get; set; }

        [Required(ErrorMessage = "You can't leave it blank")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You can't leave it blank")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "You can't leave it blank")]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}