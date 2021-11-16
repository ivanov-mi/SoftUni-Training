using Git.Data;
using Git.Data.Models;
using Git.ViewModels.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext db;

        public CommitService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string description, string userId, string repositoryId)
        {
            var commit = new Commit 
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId,
            };

            this.db.Add(commit);
            this.db.SaveChanges();
        }

        public void Delete(string id, string userId)
        {
            var commit = this.db.Commits.FirstOrDefault(c => c.Id == id && c.CreatorId == userId);
            if (commit == null)
            {
                return;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitOutputModel> GetAllByUserId(string userId)
        {
            return this.db.Commits
                .Where(c => c.CreatorId == userId).
                Select(c => new CommitOutputModel 
                {
                    Id = c.Id,
                    RepositoryName = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn,
                })
                .ToList();
        }
    }
}
