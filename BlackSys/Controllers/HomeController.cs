using BlackSys.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BlackSys.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private BlackSysEntities db = new BlackSysEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LoadMenu()
        {
            var menu = db.Database.SqlQuery<SEC_MENU_MODEL>("SELECT * FROM VW_MENU_GET WHERE id = '" + User.Identity.GetUserId() + "' AND Visible = 1").ToList();
            return View(menu);
        }

        [HttpPost]
        public ActionResult ValidateMenu(string url)
        {
            var menu = db.Database.SqlQuery<SEC_MENU_MODEL>("EXEC SP_Menu_AUTHACCES '" + User.Identity.GetUserId() + "','"+url+"'").ToList();
            string jsons = new JavaScriptSerializer().Serialize(menu);
            return Content(jsons);
        }



    }
}