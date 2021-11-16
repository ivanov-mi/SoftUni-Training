using Git.ViewModels.OutputModels;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitService
    {
        void Create(string description, string userId, string repositoryId);

        void Delete(string id, string userId);

        IEnumerable<CommitOutputModel> GetAllByUserId(string userId);
    }
}
