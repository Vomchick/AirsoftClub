using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class CreationTeamRequestModel
    {
        public Guid TeamId { get; set; }
        public string Description { get; set; }
    }
}
