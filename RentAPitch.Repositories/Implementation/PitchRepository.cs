using RentAPitch.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentAPitch.Repositories.Infrastructure;
using RentAPitch.Data.Models;
using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;

namespace RentAPitch.Repositories.Implementation
{
    public class PitchRepository : IPitchRepository
    {

        private readonly RentAPitchDbContext _context;

        public PitchRepository(RentAPitchDbContext context)
        {
            _context = context;
        }

        public Task DeletePitches(int id)
        {
            var pitch = _context.Pitches.Find(id);
            if (pitch != null)
            {
                _context.Pitches.Remove(pitch);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public async Task<Pitch> GetPitchById(int id)
        {
            var pitch = await _context.Pitches.FindAsync(id);
            if (pitch != null)
            {
                return pitch;
            }
            throw new Exception($"Pitch with ID{id} not found!");
        }

        public async Task<IEnumerable<Pitch>> GetPitches()
        {
            var pitches = await _context.Pitches.ToListAsync();
            if (pitches.Count == 0)
            {
                throw new Exception($"Pitches Table is Empty!");
            }
            return pitches;
        }

        public async Task InsertPitches(Pitch pitch)
        {
            await _context.Pitches.AddAsync(pitch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePitches(Pitch pitch)
        {
            var pitchFromDb = await _context.Pitches.FindAsync(pitch.Id);
            if (pitchFromDb != null)
            {
                pitchFromDb.PitchName =  pitch.PitchName;
                pitchFromDb.Location = pitch.Location;
                pitchFromDb.Description = pitch.Description;
                if (pitch.ImageUrl != null)
                {
                    pitchFromDb.ImageUrl = pitch.ImageUrl;
                }
                pitchFromDb.PricePerDay = pitch.PricePerDay;

            }
        }
    }
}
