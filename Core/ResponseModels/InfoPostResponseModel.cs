using AirsoftClub.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ResponseModels
{
    public class InfoPostResponseModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorType AuthorType { get; set; }
        public DateTime CreationDt { get; set; }
    }
}
