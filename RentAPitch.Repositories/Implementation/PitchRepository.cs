using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Implementation
{
    public class PitchRepository : IPitchRepository
    {
        private readonly RentAPitchDbContext _context;

        public PitchRepository(RentAPitchDbContext context)
        {
            _context = context;
        }

        public async Task DeletePitch(int id)
        {
            var pitch = await _context.Pitches.FindAsync(id);
            if (pitch != null)
            {
                _context.Pitches.Remove(pitch);
                _context.SaveChanges();

            }
        }

        public async Task<IEnumerable<Pitch>> GetPitches()
        {
            var pitch = await _context.Pitches.ToListAsync();
            if (pitch.Count == 0)
            {
                throw new Exception($"Pitch Table is Empty");
            }
            return pitch;
        }

        public async Task<Pitch> GetPitchById(int id)
        {
            var pitch = await _context.Pitches.FindAsync(id);
            if (pitch != null)
            {
                return pitch;
            }
            throw new Exception($"Pitch with ID{id} not found");
        }

        public async Task InsertPitch(Pitch pitch)
        {
            await _context.Pitches.AddAsync(pitch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePitch(Pitch pitch)
        {
            var pitchFromDB = await _context.Pitches.FindAsync(pitch.Id);
            if (pitchFromDB != null)
            {
                pitchFromDB.PitchName = pitch.PitchName;
                if (pitch.ImageUrl != null)
                {
                    pitchFromDB.ImageUrl = pitch.ImageUrl;
                }
                pitchFromDB.Description = pitch.Description;
                pitchFromDB.PricePerDay = pitch.PricePerDay;
                _context.SaveChanges();
            }
        }
    }
}
