namespace tweetProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class twitterModel : DbContext
    {
        public twitterModel()
            : base("name=twitterModel")
        {
        }

        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<follow> follows { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
                .HasMany(e => e.comments)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.commentatorID);

            modelBuilder.Entity<user>()
                .HasMany(e => e.follows)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.followerID);

            modelBuilder.Entity<user>()
                .HasMany(e => e.follows1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.userID);
        }
    }
}
