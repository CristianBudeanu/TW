<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> d394d51e90031c7053906bf700a0fbf528066b26

namespace EasyBreath.web.Models
{
     public class LoginForm
     {
          [Required(ErrorMessage = "You must enter your Username.")]
          public string Username { get; set; }

          [Required(ErrorMessage = "You must enter your password.")]
          [DataType(DataType.Password)]
          public string Password { get; set; }
     }
}