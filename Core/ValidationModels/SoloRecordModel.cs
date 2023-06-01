using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class SoloRecordModel
    {
        [Required]
        public bool NeedARent { get; set; }
        [Required]
        public PickUp PickUp { get; set; }
        public Guid GameId { get; set; }
    }
}
