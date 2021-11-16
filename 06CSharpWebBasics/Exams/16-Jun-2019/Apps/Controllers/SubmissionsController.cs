using Suls.Models.ViewModels;
using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemService.GetNameById(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(code) ||
                code.Length < 30 ||
                code.Length > 800)
            {
                return this.Error("Submitted code must be between 30 and 800 characters long.");
            }

            var userId = this.GetUserId();
            this.submissionService.Create(problemId, userId, code);
            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.View("/Users/Login");
            }

            this.submissionService.Delete(id);

            return this.Redirect("/");
        }

    }
}
