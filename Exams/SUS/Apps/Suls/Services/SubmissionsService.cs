using Suls.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;

        public Random random { get; }

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }
        public void Create(string userId, string problemId, string code)
        {
            var problemMaxPoints = this.db.Problems.Where(x => x.Id == problemId).Select(x => x.Points).FirstOrDefault();
            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = (ushort)this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow
            };
            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
