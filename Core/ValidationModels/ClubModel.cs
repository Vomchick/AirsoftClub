﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.ValidationModels
{
    public class ClubModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}