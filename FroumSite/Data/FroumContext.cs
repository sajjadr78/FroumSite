using FroumSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FroumSite.Data
{
    public class FroumContext : DbContext
    {

        public FroumContext(DbContextOptions<FroumContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region PostInit

            Post post = new Post
            {
                Id = 1,
                Caption = "خانواده اولین گروهی است که ما تجربه می کنیم",
                LikeCount = 0,
                UploadDate = System.DateTime.Now,

                //this line makes error🔽
                //Uploader = user
                //,Topic = topic

            };

            modelBuilder.Entity<Post>().HasData(post);

            #endregion

            #region TopicInit

            Topic topic = new Topic
            {
                Id = 1,
                Description = "روابط پدر با فرزندان باید صمیمانه باشد",
                Title = "روابط پدر با فرزندان"
            };

            modelBuilder.Entity<Topic>().HasData(
                topic);

            #endregion


            #region UserInit

            List<Post> postsOfUserID1 = new List<Post> { post };
            List<Topic> topicsOfUserID1 = new List<Topic> { topic };

            User user = new User
            {
                Id = 1,
                Name = "سجاد",
                Family = "تاجمیرریاحی",
                Birthday = new System.DateTime(1999, 12, 18),
                Password = "123",
                PhoneNumber = "09136941387",
                RegisterDate = System.DateTime.Now,
                Sex = Sex.Male
            };

            modelBuilder.Entity<User>().HasData(user);

            #endregion

            #region SubjectInit

            Subject subject = new Subject
            {
                Id = 1,
                Title = "خانواده"
            };

            modelBuilder.Entity<Subject>().HasData(subject);

            #endregion

            #region RoomInit

            Room room = new Room
            {
                Id = 1,
                Title = "روابط در خانواده"
            };


            modelBuilder.Entity<Room>().HasData(
                room);

            #endregion


        }
    }
}
