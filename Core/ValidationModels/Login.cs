using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class Login
    {
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
