using System.ComponentModel.DataAnnotations;

namespace YunQiERP.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "�b������.")]
        [Display(Name = "�b���G")]
        public string EmployeeMobile { get; set; }

        [Required(ErrorMessage = "�K�X����.")]
        [DataType(DataType.Password)]
        [Display(Name = "�K�X�G")]
        public string Password { get; set; }
    }
}