using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ResponseModels
{
    public class StatisticResponseModel
    {
        public int SoloPeopleCount { get; set; }
        public int TeamsCount { get; set; }
        public int TeamsPeopleCount { get; set; }
        public int TotalPeopleCount { get; set; }
        public int RentCount { get; set; }
        public int PickUpCount { get; set; }
    }
}
