using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class FileUpload
    {
        public IFormFile file { get; set; }
        public string Owner { get; set; }
    }
}
