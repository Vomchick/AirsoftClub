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
        public Player Player { get; set; }

        public Guid ClubId { get; set; }
        public Club Club { get; set; }
    }
}
