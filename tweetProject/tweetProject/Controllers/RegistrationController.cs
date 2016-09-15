using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tweetProject.Models;

namespace tweetProject.Controllers
{
    public class RegistrationController : Controller
    {
        twitterModel db = new twitterModel();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post_Registration(string email, string pass, string name, string lastname)
        {
            //hash and salt password
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[8];
            rng.GetBytes(buff);
            string salt = Convert.ToBase64String(buff);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pass + salt);
            System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashedPass = BitConverter.ToString(hash).Replace("-", string.Empty);


            user registeredUser = new user();
            registeredUser.name = name;
            registeredUser.lastname = lastname;
            registeredUser.email = email;
            registeredUser.password = pass;
            registeredUser.PhotoID = 5;
            db.users.Add(registeredUser);
            db.SaveChanges();
            return View();
        }


    }
}