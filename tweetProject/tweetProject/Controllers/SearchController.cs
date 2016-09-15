using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tweetProject.Models;
using tweetProject.Custom_Model;

namespace tweetProject.Controllers
{
    public class SearchController : Controller
    {
        twitterModel db = new twitterModel();
        // GET: Search
        //public ActionResult Index()
        //{
        //    return View(db.users.ToList());
        //}

        //[HttpPost]
        public JsonResult Index(string text)
        {
            var users = db.users.ToList().Where(e => e.name.Contains(text) || e.lastname.Contains(text)).ToList();

            List<UserViewModel> userList = new List<UserViewModel>();
            foreach (var user in users)
            {
                userList.Add(new UserViewModel()
                {
                    ID = user.ID,
                    Name = user.name,
                    Lastname = user.lastname,
                    ImageURl = "Home/GetUserImage?userID=" + user.ID  
                });
            }

            return Json(userList, JsonRequestBehavior.AllowGet);
        }
    }
}
