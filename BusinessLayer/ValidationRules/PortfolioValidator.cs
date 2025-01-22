using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
            RuleFor(x => x.ImageURL2).NotEmpty().WithMessage("Görsel2 alanı boş geçilemez");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Resim 1 alanı boş geçilemez");
            RuleFor(x => x.Image2).NotEmpty().WithMessage("Resim 2 alanı boş geçilemez");
            RuleFor(x => x.Image3).NotEmpty().WithMessage("Resim 3 alanı boş geçilemez");
            RuleFor(x => x.Image4).NotEmpty().WithMessage("Resim 4 alanı boş geçilemez");
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform resim alanı boş geçilemez");
            RuleFor(x => x.ProjectURL).NotEmpty().WithMessage("Proje url alanı boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ücret alanı boş geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Tamamlanma oranı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı en az 5 karakterden oluşmalıdır");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje adı en fazla 100 karakterden oluşmalıdır");
        }
    }
}
