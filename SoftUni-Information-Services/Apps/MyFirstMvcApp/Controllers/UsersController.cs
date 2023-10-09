using SUS.HTTP;
using SUS.MvcFramework;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View("Login");
        }
        public HttpResponse Register(HttpRequest request)
        { 
            return this.View();
        }

        internal HttpResponse DoLogin(HttpRequest arg)
        {
            return this.Redirect("/");
        }
    }
}
