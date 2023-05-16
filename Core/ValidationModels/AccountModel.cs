using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class AccountModel
    {
        public string CallSign { get; set; }
        public string GameRole { get; set; }
        public string? Desc { get; set; }
        public string? TeamName { get; set; }
        public string? TeamRole { get; set; }
    }
}
