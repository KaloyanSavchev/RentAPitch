using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Models.ViewModels.Pitch;
using RentAPitch.Repositories.Infrastructure;

namespace RentAPitch.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string SearchingText = null)
        {
            IEnumerable<PitchViewModel> viewModelsList;
            var pitches = _pitchRepository.GetPitches().GetAwaiter()
                .GetResult().Skip(pageNumber * pageSize - pageSize).Take(pageSize);
            viewModelsList = _mapper.Map<IEnumerable<PitchViewModel>>(pitches);

            if (!string.IsNullOrEmpty(SearchingText))
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
        public async Task<IActionResult> Create(CreatePitchViewModel viewModel)
        {
            var model = _mapper.Map<Pitch>(viewModel);
            await _pitchRepository.InsertPitch(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pokemon = await _pitchRepository.GetPitchById(id);
            var pokemonViewModel = _mapper.Map<PitchViewModel>(pokemon);
            return View(pokemonViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditPitchViewModel viewModel)
        {
            var model = _mapper.Map<Pitch>(viewModel);
            await _pitchRepository.UpdatePitch(model);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pokemon = await _pitchRepository.GetPitchById(id);
            await _pitchRepository.DeletePitch(pokemon.Id);

            return RedirectToAction("Index");
        }

    }
}
