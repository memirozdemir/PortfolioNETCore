﻿namespace CoreFolio.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
