namespace tweetProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow
    {
        public int ID { get; set; }

        public int? userID { get; set; }

        public int? followerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? followingTime { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
