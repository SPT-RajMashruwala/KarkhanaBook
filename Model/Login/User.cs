using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarKhanaBook.Model.Login
{
    public class User
    {
        [Required(ErrorMessage = "UserName Required !")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Enter Only Letter or Digit  Or Combine String of Letter-Digit no special" +
            "Symbole allowed")]
        public string UserName { get; set; }



        /* [Required(ErrorMessage = "Email Address required ! ")]
         [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter Valid Email Address")]*/
        public string EmailAddress { get; set; }



        [RegularExpression(@"[A-Za-z0-9][A-Za-z0-9@#_.]{6,}[A-Za-z0-9@#_.]$", ErrorMessage = "Password must have minimum 8 character," +
          "First letter not start special character ,atleast one lower case,one number and one special symbol")]
        [Required(ErrorMessage = "Password required")]

        public string Password { get; set; }


        [Required(ErrorMessage = "ContactNumber required ! ")]
        [RegularExpression(@"[0-9]{10}$", ErrorMessage = "Contact Number length must be 10 digit")]

        public string ContactNumber { get; set; }

        [RegularExpression(@"[0-9]{10}$", ErrorMessage = "Contact Number length must be 10 digit")]
        public string AlternetContactNumber { get; set; }
        public Model.Common.IntegerNullString Role { get; set; } = new Model.Common.IntegerNullString();
    }
}
