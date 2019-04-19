using System.ComponentModel.DataAnnotations;

namespace YunQiERP.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "±b¸¹¥²¶ñ.")]
        [Display(Name = "±b¸¹¡G")]
        public string EmployeeMobile { get; set; }

        [Required(ErrorMessage = "±K½X¥²¶ñ.")]
        [DataType(DataType.Password)]
        [Display(Name = "±K½X¡G")]
        public string Password { get; set; }
    }
}