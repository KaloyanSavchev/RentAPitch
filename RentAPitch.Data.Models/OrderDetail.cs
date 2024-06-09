using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace RentAPitch.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        [Required]
        public int OrderHeaderId { get; set; }
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }
        [ForeignKey(nameof(PitchId))]
        [Required]
        public int PitchId { get; set; }
        [ValidateNever]
        public Pitch Pitch { get; set; }

        public decimal RentalTotal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
