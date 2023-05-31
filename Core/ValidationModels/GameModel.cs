using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class GameModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }
        //public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public int? RentalPrice { get; set; }
        [Required]
        public int DefaultPrice { get; set; }
        [Required]
        public DateTime StartDt { get; set; }
        [Required]
        public GameType GameType { get; set; }
    }
}
