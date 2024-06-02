using FluentValidation;
using HotelProject.WebUI.Models.Staff;

namespace HotelProject.WebUI.ValidationRules.StaffValidationRules
{
    public class StaffCreateValidator:AbstractValidator<AddStaffViewModel>
    {
        public StaffCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("lütfen en az 3 karaker girin");
        }
    }
}
