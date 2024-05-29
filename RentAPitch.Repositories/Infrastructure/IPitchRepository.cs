using RentAPitch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Infrastructure
{
    public interface IPitchRepository
    {
        Task<IEnumerable<Pitch>> GetPitches();

        Task<Pitch> GetPitchById(int id);

        Task InsertPitches(Pitch pitch);

        Task UpdatePitches(Pitch pitch);

        Task DeletePitches(int id);
    }
}
