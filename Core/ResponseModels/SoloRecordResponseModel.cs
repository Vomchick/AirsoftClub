using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ResponseModels
{
    public class SoloRecordResponseModel
    {
        public bool NeedARent { get; set; }
        public PickUp PickUp { get; set; }
    }
}
