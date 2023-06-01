using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class TeamRecordModel
    {
        [Required]
        public int PeopleCount { get; set; }
        public Guid GameId { get; set; }
    }
}
