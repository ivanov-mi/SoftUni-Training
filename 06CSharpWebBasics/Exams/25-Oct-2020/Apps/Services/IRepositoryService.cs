using Git.ViewModels.OutputModels;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void Create(string name, bool isPublic, string userId);

        string GetRepositoryName(string id);

        IEnumerable<RepositoryOutputModel> GetAllPublicRepositories();
    }
}
