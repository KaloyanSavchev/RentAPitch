using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Models.ViewModels.Pitch;
using RentAPitch.Repositories.Infrastructure;

namespace RentAPitch.Controllers
{
    public class PitchController : Controller
    {
        private readonly IPitchRepository _pitchRepository;
        private IMapper _mapper;

        //
        private readonly RentAPitchDbContext _context;
        
        public PitchController(RentAPitchDbContext context, IPitchRepository pitchRepository, IMapper mapper)
        {
            _pitchRepository = pitchRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult>Index(int pageNumber = 1, int pageSize = 10, string SearchingText = null )
        {
            IEnumerable<PitchViewModel> viewModelsList;
            var pitches = _pitchRepository.GetPitches().GetAwaiter()
                .GetResult().Skip((pageNumber * pageSize) - pageSize).Take(pageSize);
            viewModelsList = _mapper.Map<IEnumerable<PitchViewModel>>(pitches);

            if (!String.IsNullOrEmpty(SearchingText))
            {
                viewModelsList = viewModelsList.Where(x => x.PitchName.Equals(SearchingText)); 
            }

            var pitchViewModel = new ListPitchViewModel
            {
                PitchList = viewModelsList,
                PageInfo = new Utility.PageInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = pageNumber,
                    TotalItems = _pitchRepository.GetPitches().GetAwaiter().GetResult().Count()
                },
                
            };
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePitchViewModel vm)
        {
            var model = _mapper.Map<Pitch>(vm);
            await _pitchRepository.InsertPitches(model);

            return RedirectToAction(nameof(Index));
        }


        //

        public async Task<IActionResult> DetailsForAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitch = await _context.Pitches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pitch == null)
            {
                return NotFound();
            }

            return View(pitch);
        }

        // POST: Pitch/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Pitch pitch)
        {
            if (ModelState.IsValid)
            {
                _context.Update(pitch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pitch);
        }
    }
}
