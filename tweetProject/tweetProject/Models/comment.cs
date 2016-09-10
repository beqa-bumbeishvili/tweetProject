namespace tweetProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comment
    {
        public int ID { get; set; }

        public int? postID { get; set; }

        public int? commentatorID { get; set; }

        [Column("comment")]
        public string comment1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? commentDate { get; set; }

        public virtual user user { get; set; }

        public virtual post post { get; set; }
    }
}
