using Suls.Models.BindingModels;
using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProblemBindingModel input)
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) ||
                input.Name.Length < 5 ||
                input.Name.Length > 20)
            {
                return this.Error("Problem name should be between 5 and 20 characters.");
            }

            if (!this.problemService.IsNameAvailable(input.Name))
            {
                return this.Error("Problem`s name is already taken.");
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Error("The total number of point must be an integer number between 50 and 300.");
            }

            this.problemService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            var viewModel = this.problemService.GetProblemDetailsById(id);

            return this.View(viewModel);
        }
    }
}
