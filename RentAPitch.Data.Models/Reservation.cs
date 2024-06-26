﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentAPitch.Data.Models.Enums;

namespace RentAPitch.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Reservation))]
        public int PitchId { get; set; }
        public Pitch Pitch { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public double TotalPrice { get; set; }

        public bool IsPaid { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ReservationStatus ReservationStatus { get; set; }
    }
}
