using Git.Services;
using Git.ViewModels.InputModels;
using Git.ViewModels.OutputModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitService commitService, IRepositoryService repositoryService)
        {
            this.commitService = commitService;
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/");
            }

            var userId = this.GetUserId();
            var viewModel = this.commitService.GetAllByUserId(userId);

            return this.View(viewModel);
        }

        public HttpResponse Create(string Id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/");
            }

            var name = this.repositoryService.GetRepositoryName(Id);

            var viewModel = new CreateCommitViewModel 
            {
                RepositoryId = Id,
                RepositoryName = name,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel input)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(input.Description) ||
                input.Description.Length < 5)
            {
                return this.Error("Description is required. Description length should be minimum 5 characters.");
            }

            var userId = this.GetUserId();
            this.commitService.Create(input.Description, userId, input.Id);

            return this.Redirect("/Commits/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/");
            }

            var userId = this.GetUserId();
            this.commitService.Delete(id, userId);

            return this.Redirect("/");
        }
    }
}
