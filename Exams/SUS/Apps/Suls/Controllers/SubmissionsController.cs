using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ISubmissionsService submissionsService { get; }

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
             
            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemsService.GetNameById(id)
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters.");
            }

            var userId = this.GetUserId();
            this.submissionsService.Create(userId, problemId, code);
            return this.Redirect("/");
        }
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
