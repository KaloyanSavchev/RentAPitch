﻿namespace RentAPitch.Models.ViewModels.ApplicationUserViewModels
{
    public class UserDetailViewModel
    {
        public string UserId { get; set; }
        public string SkillLevel { get; set; }
        public IFormFile PhotoProfId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
