using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class MemberLoginViewModel
    {
        [Required(ErrorMessage = "帳號必填.")]
        [Display(Name = "帳號：")]
        public string MemberMobile { get; set; }

        [Required(ErrorMessage = "密碼必填.")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼：")]
        public string MemberPassword { get; set; }
    }
}