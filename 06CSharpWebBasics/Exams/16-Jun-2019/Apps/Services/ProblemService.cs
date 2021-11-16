using Suls.Data;
using Suls.Data.Models;
using Suls.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Services
{
    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem 
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public bool IsNameAvailable(string name)
        {
            return !this.db.Problems.Any(p => p.Name == name);
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(p => new HomePageProblemViewModel 
            {
                Id = p.Id,
                Name = p.Name,
                Count = p.Submissions.Count()
            })
            .ToList();

            return problems;
        }

        public string GetNameById(string Id)
        {
            return this.db.Problems
                .Where(p => p.Id == Id)
                .Select(p => p.Name)
                .FirstOrDefault();
        }

        public ProblemDetailsViewModel GetProblemDetailsById(string id)
        {
            return this.db.Problems.Where(p => p.Id == id).Select(p => new ProblemDetailsViewModel
            {
               Name = p.Name,
               Submissions = p.Submissions.Select(s => new SubmissionViewModel 
               {
                   Id = s.Id,
                   CreatedOn = s.CreatedOn,
                   AchievedResult = s.AchievedResult,
                   Username = s.User.Username,
                   MaxPoints = s.Problem.Points,
               })
            }).FirstOrDefault();
        }
    }
}
