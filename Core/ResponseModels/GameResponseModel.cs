using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ResponseModels
{
    public class GameResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        //public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public int? RentalPrice { get; set; }
        public int DefaultPrice { get; set; }
        public DateTime StartDt { get; set; }
        public GameType GameType { get; set; }
        public Guid? FieldId { get; set; }
        public string? FieldName { get; set; }
    }
}
