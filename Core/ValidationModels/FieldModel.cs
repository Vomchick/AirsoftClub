using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class FieldModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }
        //public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        [Required]
        public bool IsCovered { get; set; }
        [Required]
        public string Address { get; set; }
        public string? GPS { get; set; }
    }
}
