using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ResponseModels
{
    public class FieldResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        //public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public bool IsCovered { get; set; }
        public string Address { get; set; }
        public string? GPS { get; set; }
    }
}
