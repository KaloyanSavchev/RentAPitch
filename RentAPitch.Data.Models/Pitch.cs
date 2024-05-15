using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Data.Models
{
    public class Pitch
    {
        public int Id { get; set; }

        public string PitchName { get; set; }

        public string GrassType { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public int Capacity { get; set; }

        public decimal GoalLength { get; set; }

        public decimal GoalHeigth { get; set;}

        public string IsOutsite { get; set; }


        public int LandLordId { get; set; }

        public LandLord LandLord { get; set; } = null!;
    }
}
