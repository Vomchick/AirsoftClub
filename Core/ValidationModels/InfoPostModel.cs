using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class InfoPostModel
    {
        [Required]
        public string Text { get; set; }
        public Guid? AuthorId { get; set; }
        [Required]
        public AuthorType AuthorType { get; set; }
    }
}
