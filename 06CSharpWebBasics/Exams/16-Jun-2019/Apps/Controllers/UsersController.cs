using Suls.Models.BindingModels;
using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Suls.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignIn())
            {
                return this.View("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginBindingModel input)
        {
            if (this.IsUserSignIn())
            {
                return this.View("/");
            }

            var userId = this.userService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignIn())
            {
                return this.View("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterBindingModel input)
        {
            if (this.IsUserSignIn())
            {
                return this.View("/");
            }

            if (string.IsNullOrWhiteSpace(input.Username) ||
                input.Username.Length < 5 ||
                input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(input.Username, @"^[a-zA-z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Invalid password. Length of the password should be between 6 and 20 characters.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            if (!this.userService.IsUserNameAvailable(input.Username))
            {
                return this.Error("Username is already taken.");
            }

            if (!this.userService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email is already taken.");
            }

            this.userService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
