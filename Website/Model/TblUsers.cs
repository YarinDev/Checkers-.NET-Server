using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Model
{
    public class TblUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID must be between 1 to 1000")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name must be with at least 2 letters")]
        [StringLength(20, ErrorMessage = "Name must be with at least 2 letters", MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number must be with at least 10 digits")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone Number must be with at least 10 digits")]
        public string Phone { get; set; }
        public int Num { get; set; }

    }
}
