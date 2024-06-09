using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentAPitch.Data.Models;
using RentAPitch.Models.ViewModels.Pitch;
using RentAPitch.Repositories.Infrastructure;
using System.Security.Claims;

namespace RentAPitch.Controllers
{
    public class HomeController : Controller
    {
        private IPitchRepository _pitchRepository;
        private IMapper _mapper;
        private IUserService _userService;
        private ICartService _cartService;

        public HomeController(IPitchRepository pitchRepository, IMapper mapper, IUserService userService, ICartService cartService)
        {
            _pitchRepository = pitchRepository;
            _mapper = mapper;
            _userService = userService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var pitches = _pitchRepository.GetPitches().GetAwaiter().GetResult()
                .ToList().Where(x => !x.IsDelete && x.IsAvailable);
            var viewModel = _mapper.Map<List<PitchViewModel>>(pitches);
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var pitch = await _pitchRepository.GetPitchById(id);
            if (pitch == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PitchDetailsViewModel>(pitch);
            return View(viewModel);
        }
        //[HttpPost]
        //[Authorize(Roles = "Customer")]
        //public async Task<IActionResult> Order(SummaryViewModel vm)
        //{
                
        //}
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Details(PitchDetailsViewModel vm)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var applicationUser = _userService.GetApplicationUser(claims.Value);
            var cart = _cartService.GetCartItems(claims.Value, vm.Id);
            if (cart == null)
            {
                if (ModelState.IsValid)
                {
                    Cart cartObj = new Cart();
                    TimeSpan duration = (TimeSpan)(vm.ReturnDate - vm.StartDate);
                    cartObj.TotalAmount = vm.DailyRate * duration.Days;
                    cartObj.ReturnDate = vm.ReturnDate;
                    cartObj.StartDate = vm.StartDate;
                    cartObj.TotalAmount = vm.TotalAmount;
                    cartObj.TotalDuration = duration.Days;
                    cartObj.Pitch.ImageUrl = vm.ImageUrl;
                    cartObj.Pitch.Id = vm.Id;
                    cartObj.User = applicationUser;
                    await _cartService.AddToCart(cartObj);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Message = "Pitch already added to cart";
            }

            return View(vm);
        }
    }
}
