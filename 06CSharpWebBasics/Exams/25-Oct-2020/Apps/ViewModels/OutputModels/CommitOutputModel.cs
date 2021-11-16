using System;

namespace Git.ViewModels.OutputModels
{
    public class CommitOutputModel
    {
        public string Id { get; set; }

        public string RepositoryName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
