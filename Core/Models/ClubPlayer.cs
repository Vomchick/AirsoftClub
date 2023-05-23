using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.Models
{
    public class ClubPlayer
    {
        public Guid PlayerId { get; set; }
        public Guid ClubId { get; set; }
        public ClubRole ClubRole { get; set; }

        public Player Player { get; set; }
        public Club Club { get; set; }

    }
}
