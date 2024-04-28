using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class MemberController : Controller
    {
        //Login 為登入畫面
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
