using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Model
{
    public class Person
    {

        [Required(ErrorMessage = "Name must be with at least 2 letters")]
        [StringLength(20, ErrorMessage = "Name must be with at least 2 letters", MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string FName { get; set; }

        public byte ID { get; set; }

        [Required(ErrorMessage = "Phone Number must be with at least 10 digits")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone Number must be with at least 10 digits")]
        public string Phone { get; set; }
    }

}
