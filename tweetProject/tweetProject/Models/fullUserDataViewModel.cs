using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tweetProject.Models
{
    public class fullUserDataViewModel
    {

        public int ID { get; set; }
        public Photo userPhoto { get; set; }

        public List<user> allUsers { get; set; }

        public List<post> timelinePosts { get; set; }

        public List<comment> timelineComments { get; set; }
    }
}