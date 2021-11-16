using Git.Data.Enums;
using Git.Services;
using Git.ViewModels.InputModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoyInputModel input)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(input.Name) ||
                input.Name.Length < 3 ||
                input.Name.Length > 10)
            {
                return this.Error("Repository name length should be betweem 3 and 10 characters.");
            }

            var isValidRepositoryType = Enum.TryParse<RepositoryType>(input.RepositoryType, true, out var repositoryType);
            if (!isValidRepositoryType)
            {
                return this.Error("Invalid repository type.");
            }

            var isPublic = false;
            if (repositoryType == RepositoryType.Public)
            {
                isPublic = true;
            }

            var userId = this.GetUserId();
            this.repositoryService.Create(input.Name, isPublic, userId);

            return this.Redirect("/");
        }

        public HttpResponse All()
        {
            var viewModel = this.repositoryService.GetAllPublicRepositories();

            return this.View(viewModel);
        }
    }
}
