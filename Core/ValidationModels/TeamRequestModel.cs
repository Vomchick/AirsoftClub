using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class TeamRequestModel
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public string? Description { get; set; }
        public TeamRole? TeamRole { get; set; }
    }
}
