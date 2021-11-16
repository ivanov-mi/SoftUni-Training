using System;

namespace Suls.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(this.AchievedResult * 100.0M / this.MaxPoints);
    }
}
