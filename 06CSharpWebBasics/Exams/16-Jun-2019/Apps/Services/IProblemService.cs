using Suls.Models.ViewModels;
using System.Collections.Generic;

namespace Suls.Services
{
    public interface IProblemService
    {
        void CreateProblem(string name, int points);

        bool IsNameAvailable(string name);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string Id);

        ProblemDetailsViewModel GetProblemDetailsById(string id);
    }
}
