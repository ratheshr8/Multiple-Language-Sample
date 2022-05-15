using Multiple_Language.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multiple_Language.Controllers
{
    public class HomeController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = LangManager.GetDefaultLanguage();
                }
            }
            new LangManager().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SampleForm r)
        {
            return View(r);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new LangManager().SetLanguage(lang);
            return RedirectToAction("Index", "Home");
        }
    }
}