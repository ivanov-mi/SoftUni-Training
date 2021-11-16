using System.Collections.Generic;

namespace Suls.Models.ViewModels
{
    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }

    }
}
