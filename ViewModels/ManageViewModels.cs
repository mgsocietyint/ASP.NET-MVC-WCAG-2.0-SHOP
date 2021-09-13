using Disabled.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disabled.ViewModels
{
    public class ManageCredentialsViewModel
    {
        public bool HasPassword { get; set; }
        public SetPasswordViewModel SetPasswordViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public Disabled.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
        public bool ShowRemoveButton { get; set; }

        public UserData UserData { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "Pole hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać co najmniej 6 znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź nowe hasło")]
        [Compare("Nowe hasło", ErrorMessage = "Hasła nie zgadzają się")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Pole stare hasło nie może być puste.")]
        [DataType(DataType.Password)]
        [Display(Name = "Stare hasło")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Pole nowe hasło nie może być puste.")]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać co najmniej 6 znaków", MinimumLength = 6)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Pole potwierdź nowe hasło nie może być puste.")]
        [Display(Name = "Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Potwierdź poprawnie nowe hasło")]
        public string ConfirmPassword { get; set; }
    }

    //public class EditProductViewModel
    //{
    //    public Product Product { get; set; }
    //    public IEnumerable<Category> Categories { get; set; }
    //    public bool? ConfirmSuccess { get; set; }
    //}

}