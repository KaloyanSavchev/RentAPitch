﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class Pitch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PitchName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Description { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
    }
}
