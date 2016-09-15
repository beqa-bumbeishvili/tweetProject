using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tweetProject.Models;

namespace tweetProject.Controllers
{
    public class HomeController : Controller
    {
        twitterModel db = new twitterModel();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string email, string pass)
        {
            var loggedUser = new fullUserDataViewModel();
            loggedUser.ID = db.users.Where(e => e.email == email && e.password == pass).Select(x => x.ID).FirstOrDefault();
            loggedUser.userPhoto = db.Photos.Where(e => e.ID == db.users.Where(x => x.email == email && x.password == pass).Select(z => z.PhotoID).FirstOrDefault()).FirstOrDefault();
            loggedUser.allUsers = db.users.ToList();
            var follows = db.follows.Where(e => e.followerID == loggedUser.ID).Select(x => x.userID).ToList();
            var allPosts = db.posts.ToList();
            loggedUser.timelinePosts = new List<post>();
            foreach (var item in follows)
            {
                foreach (var post in allPosts)
                {
                    if (post.userID == item)
                        loggedUser.timelinePosts.Add(post);
                }
            }
            loggedUser.timelineComments = new List<comment>();
            foreach (var post in loggedUser.timelinePosts)
                loggedUser.timelineComments.AddRange(db.comments.Where(e => e.postID == post.ID));

            TempData["UserID"] = loggedUser.ID;
            return View(loggedUser);

        }

        [HttpPost]
        public int postUpdate(string text, int id)
        {
            post userPost = new post();
            userPost.userID = id;
            userPost.post1 = text;
            userPost.postingDate = DateTime.Now;
            db.posts.Add(userPost);
            db.SaveChanges();


            return userPost.ID;
        }

        [HttpPost]
        public int commentUpdate(string text, int userId, int postId)
        {
            comment userComment = new comment();
            userComment.commentatorID = userId;
            userComment.postID = postId;
            userComment.comment1 = text;
            userComment.commentDate = DateTime.Now;
            db.comments.Add(userComment);
            db.SaveChanges();

            return userComment.ID;
        }

        [HttpPost]
        public ActionResult UserProfile(string ID)
        {
            int id = Convert.ToInt32(ID);
            //custom viewmodeli userprofilshi axali userisa da daloginebuli iuzeris monacemebis gadasatanad
            return View(db.users.Where(e => e.ID == id).FirstOrDefault());
        }

        public ActionResult GetUserImage(long userID)
        {
            var imageData = db.users.FirstOrDefault(user => user.ID == userID).Photo.profilePhoto;

        return File(imageData, "image/jpg");
        }
        
    }
}