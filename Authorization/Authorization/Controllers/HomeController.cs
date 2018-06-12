using Authorization.Services;
using DateBaseProject;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Authorization.Controllers
{
    public class HomeController : Controller
    {
        private static string login;
        private static int milliseconds = 10000;//300000 = 5 minutes; 1 minutes = 60 000

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(User user)
        {
            UserServices userServices = new UserServices();
            if (!userServices.CheckUser(user))
            {
                 ViewBag.UserNotHave = true;
                 return View();
            }
            else
            {
                ViewBag.login = user.login;
                await MethodWithDelayAsync(milliseconds);
               
                return View("UserRoom");
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.UserRegistration = true;
            return View("Index");
        }

        public async Task<ActionResult> UserRoom()
        {
            ViewBag.login = login;
            await MethodWithDelayAsync(milliseconds);

            return View("UserRoom");
        }

        public async Task<JsonResult> CreateNewUser(string param )
        {
            string[] words = param.Split(' ');
            User user = new User
            {
                login = words[0],
                password = words[1]
            };
            UserServices userServices = new UserServices();
            if (userServices.CheckUser(user))
            {
                return Json("user exist", JsonRequestBehavior.AllowGet);
            }
            else
            {
                login = user.login;
                await userServices.Add(user);
                return Json("thank for registration", JsonRequestBehavior.AllowGet);
                
            }
        }

        public async Task<ActionResult> MethodWithDelayAsync(int milliseconds)
        {
            Task wait = Task.Delay(milliseconds);
            await wait;
            return View("Index");
        }

    }
}