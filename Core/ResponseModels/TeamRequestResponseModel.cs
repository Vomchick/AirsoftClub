using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ResponseModels
{
    public class TeamRequestResponseModel
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string? Description { get; set; }
    }
}
