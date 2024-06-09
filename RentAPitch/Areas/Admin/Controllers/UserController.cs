using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentAPitch.Models.ViewModels.ApplicationUserViewModels;
using RentAPitch.Repositories.Infrastructure;
using RentAPitch.Repositories.Utility;
using System.Security.Claims;

namespace RentAPitch.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
              
        [Authorize(Roles = FD.Admin_Role)]
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var users = await _userService.GetApplicationUserAsync(claim.Value);
            var userViewModel = _mapper.Map<List<UserViewModel>>(users);
            return View(userViewModel);
        }
    }
}
