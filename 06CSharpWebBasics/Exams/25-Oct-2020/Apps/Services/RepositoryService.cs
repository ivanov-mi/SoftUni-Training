using Git.Data;
using Git.Data.Enums;
using Git.Data.Models;
using Git.ViewModels.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, bool isPublic, string userId)
        {
            var repository = new Repository
            {
                Name = name,
                IsPublic = isPublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,               
            };

            this.db.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryOutputModel> GetAllPublicRepositories()
        {
            return this.db.Repositories.Where(r => r.IsPublic == true).Select(r => new RepositoryOutputModel
            {
                Id = r.Id,
                Name = r.Name,
                Owner = r.Owner.Username,
                CreatedOn = r.CreatedOn,
                CommitsCount = r.Commits.Count()
            }).ToList();
        }

        public string GetRepositoryName(string id)
        {
            return this.db.Repositories.FirstOrDefault(r => r.Id == id)?.Name;
        }
    }
}
