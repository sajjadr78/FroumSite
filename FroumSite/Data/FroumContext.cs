using FroumSite.Models;
using FroumSite.Models.Enums;
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
        public DbSet<UserLikeTopic> UserLikeTopics { get; set; }
        public DbSet<UserLikePost> UserLikePosts { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentApi

            //i'm don't know what i'm doing! 

            //modelBuilder.Entity<User>()
            //    .HasMany(t => t.SharedTopics)
            //    .WithOne(t => t.Uploader)
            //    .OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<User>()
                .HasMany(t => t.SharedTopics)
                .WithOne(u => u.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(p => p.SharedPosts)
                .WithOne(u => u.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasMany(r => r.Rooms)
                .WithOne(s => s.Subject)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasMany(t => t.Topics)
                .WithOne(r => r.Room)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Topic>()
                .HasMany(p => p.Posts)
                .WithOne(t => t.Topic)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            #region ManyToManyRelations


            #region UserPostRelations

            modelBuilder.Entity<UserLikePost>()
                .HasKey(up => new { up.UserId, up.PostId });

            modelBuilder.Entity<UserLikePost>()
                .HasOne(up => up.Post)
                .WithMany(p => p.UsersLikedThisPost)
                .HasForeignKey(up => up.PostId);

            modelBuilder.Entity<UserLikePost>()
                .HasOne(up => up.User)
                .WithMany(p => p.LikedPosts)
                .HasForeignKey(up => up.UserId);

            #endregion

            #region UserTopicRelations

            modelBuilder.Entity<UserLikeTopic>()
                .HasKey(up => new { up.UserId, up.TopicId });

            modelBuilder.Entity<UserLikeTopic>()
                .HasOne(up => up.Topic)
                .WithMany(t => t.UsersLikedThisTopic)
                .HasForeignKey(up => up.TopicId);

            modelBuilder.Entity<UserLikeTopic>()
                .HasOne(up => up.User)
                .WithMany(u => u.LikedTopics)
                .HasForeignKey(up => up.UserId);

            #endregion

            #endregion



            //modelBuilder.Entity<Topic>(
            //    t =>
            //    {
            //        t.HasOne<User>(p => p.Uploader)
            //            .WithMany(u => u.SharedTopics)
            //            .HasForeignKey(s => s.UserId)
            //            .OnDelete(DeleteBehavior.NoAction);
            //    });

            //modelBuilder.Entity<User>(
            //    u =>
            //    {
            //        u.HasMany(s => s.SharedTopics)
            //            .WithOne(e => e.Uploader)
            //            .OnDelete(DeleteBehavior.NoAction);

            //    });

            #endregion






            #region UserInit



            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "سجاد",
                    Family = "تاجمیرریاحی",
                    Birthday = new System.DateTime(1999, 12, 18),
                    Password = "123",
                    PhoneNumber = "09136941387",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Male
                },
                new User
                {
                    Id = 2,
                    Name = "علی",
                    Family = "محمدی",
                    Birthday = new System.DateTime(1980, 10, 20),
                    Password = "123",
                    PhoneNumber = "09121231234",
                    RegisterDate = new System.DateTime(2022, 05, 09),
                    Sex = Sex.Male
                },
                new User
                {
                    Id = 3,
                    Name = "مریم",
                    Family = "غلامی",
                    Birthday = new System.DateTime(1995, 01, 28),
                    Password = "123",
                    PhoneNumber = "09131231598",
                    RegisterDate = new System.DateTime(2020, 05, 06),
                    Sex = Sex.Female
                },
                new User
                {
                    Id = 4,
                    Name = "ثریا",
                    Family = "مهدوی",
                    Birthday = new System.DateTime(2000, 10, 19),
                    Password = "123",
                    PhoneNumber = "09425874136",
                    RegisterDate = new System.DateTime(2023, 10, 10),
                    Sex = Sex.Female
                },
                new User
                {
                    Id = 5,
                    Name = "شیلا",
                    Family = "خدادادی",
                    Birthday = new System.DateTime(1994, 12, 18),
                    Password = "123",
                    PhoneNumber = "09136547156",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Female
                },
                new User
                {
                    Id = 6,
                    Name = "الناز",
                    Family = "حسن پور",
                    Birthday = new System.DateTime(1991, 12, 18),
                    Password = "123",
                    PhoneNumber = "09136512036",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Female
                },
                new User
                {
                    Id = 7,
                    Name = "شهرام",
                    Family = "حسن زاده",
                    Birthday = new System.DateTime(2000, 12, 18),
                    Password = "123",
                    PhoneNumber = "09123650942",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Male
                },
                new User
                {
                    Id = 8,
                    Name = "محمود",
                    Family = "اعتمادی",
                    Birthday = new System.DateTime(1985, 12, 18),
                    Password = "123",
                    PhoneNumber = "09425558182",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Male
                },
                new User
                {
                    Id = 9,
                    Name = "شهلا",
                    Family = "معتمدی",
                    Birthday = new System.DateTime(1980, 12, 18),
                    Password = "123",
                    PhoneNumber = "09116951478",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Female
                },
                new User
                {
                    Id = 10,
                    Name = "زهرا",
                    Family = "زارع",
                    Birthday = new System.DateTime(2004, 12, 18),
                    Password = "123",
                    PhoneNumber = "09362012361",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Female
                },
                new User
                {
                    Id = 11,
                    Name = "امیر",
                    Family = "حیدری",
                    Birthday = new System.DateTime(2005, 12, 18),
                    Password = "123",
                    PhoneNumber = "09352142314",
                    RegisterDate = System.DateTime.Now,
                    Sex = Sex.Male
                }
                );

            #endregion


            #region PostInit



            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Caption = "خانواده اولین گروهی است که ما تجربه می کنیم",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 1,
                    TopicId = 1
                },
                new Post
                {
                    Id = 2,
                    Caption = "بهتر است فضای خانواده صمیمی باشد",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 10,
                    TopicId = 1
                },
                new Post
                {
                    Id = 3,
                    Caption = "فردوسی زحمات زیادی برای ادبیات ایران کشید",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 9,
                    TopicId = 2
                },
                new Post
                {
                    Id = 4,
                    Caption = "شاهنامه بسیار پر مفهوم است",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 4,
                    TopicId = 2
                },
                new Post
                {
                    Id = 5,
                    Caption = "گوشی جدید شیائومی به سیستم عامل اختصاصی این شرکت مجهر است",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 3,
                    TopicId = 3
                },
                new Post
                {
                    Id = 6,
                    Caption = "امسال ، برای اپل سال نحسی بود!",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 6,
                    TopicId = 4
                },
                new Post
                {
                    Id = 7,
                    Caption = "اختلاس چای دبش به کجا رسید؟",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 2,
                    TopicId = 5
                },
                new Post
                {
                    Id = 8,
                    Caption = "آیا اروپا امسال هم زمستان سختی خواهد داشت؟",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 3,
                    TopicId = 5
                },
                new Post
                {
                    Id = 11,
                    Caption = "5 ماه اول شیردهی چقدر مهم است؟",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 2,
                    TopicId = 6
                },
                new Post
                {
                    Id = 12,
                    Caption = "استرس در دوران بارداری",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 4,
                    TopicId = 6
                },
                new Post
                {
                    Id = 13,
                    Caption = "تغذیه در دوران بارداری",
                    LikeCount = 0,
                    UploadDate = System.DateTime.Now,
                    UserId = 4,
                    TopicId = 6
                });

            #endregion

            #region SubjectInit



            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Title = "خانواده"
                },
                new Subject
                {
                    Id = 2,
                    Title = "تکنولوژی"
                }
                , new Subject
                {
                    Id = 3,
                    Title = "سیاست"
                }
                , new Subject
                {
                    Id = 4,
                    Title = "ورزش"
                }
                , new Subject
                {
                    Id = 5,
                    Title = "بارداری"
                }
                , new Subject
                {
                    Id = 6,
                    Title = "ادبیات"
                }
                );

            #endregion


            #region RoomInit



            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Title = "روابط در خانواده",
                    SubjectId = 1
                },
                new Room
                {
                    Id = 2,
                    Title = "صمیمیت در خانواده",
                    SubjectId = 1
                },


                new Room
                {
                    Id = 3,
                    Title = "اپل",
                    SubjectId = 2
                },
                new Room
                {
                    Id = 4,
                    Title = "شیائومی",
                    SubjectId = 2
                },
                new Room
                {
                    Id = 5,
                    Title = "تلویزیون های هوشمند",
                    SubjectId = 2
                },
                new Room
                {
                    Id = 6,
                    Title = "داخل",
                    SubjectId = 3
                },
                new Room
                {
                    Id = 7,
                    Title = "خارج",
                    SubjectId = 3
                },
                new Room
                {
                    Id = 8,
                    Title = "شیردهی",
                    SubjectId = 5
                },
                new Room
                {
                    Id = 9,
                    Title = "ساعت های هوشمند",
                    SubjectId = 2
                },
                new Room
                {
                    Id = 10,
                    Title = "گجت های پوشیدنی",
                    SubjectId = 2
                },
                new Room
                {
                    Id = 11,
                    Title = "ماشین های خودران",
                    SubjectId = 2
                },
                new Room
                {
                    Id = 12,
                    Title = "فردوسی",
                    SubjectId = 6
                }
                );

            #endregion


            #region TopicInit



            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    Description = "روابط پدر با فرزندان باید صمیمانه باشد",
                    Title = "روابط پدر با فرزندان",
                    UserId = 1,
                    RoomId = 1,
                    UploadDate = System.DateTime.Now,
                    LikeCount = 0
                },
                new Topic
                {
                    Id = 2,
                    Description = "اهمیت فردوسی برای ایران",
                    Title = "فردوسی",
                    UserId = 2,
                    RoomId = 12,
                    UploadDate = System.DateTime.Now,
                    LikeCount = 0
                },
                new Topic
                {
                    Id = 3,
                    Description = "خداحافظی با اندروید",
                    Title = "شیائومی ، تافته ی جدا بافته",
                    UserId = 3,
                    RoomId = 4,
                    UploadDate = System.DateTime.Now,
                    LikeCount = 0
                },
                new Topic
                {
                    Id = 4,
                    Description = "تیم کوک حتی فکرش را هم نمی کرد",
                    Title = "سرنوشت اپل در سال 2023",
                    UserId = 4,
                    RoomId = 3,
                    UploadDate = System.DateTime.Now,
                    LikeCount = 0
                },
                new Topic
                {
                    Id = 5,
                    Description = "چند وقته اخبار دنبال نمی کنم ، هر چیزی میدونید به منم بگید",
                    Title = "از سیاست چه خبر",
                    UserId = 5,
                    RoomId = 6,
                    UploadDate = System.DateTime.Now,
                    LikeCount = 0
                },
                new Topic
                {
                    Id = 6,
                    Description = "این موضوع از اهمیت بالایی برخوردار است",
                    Title = "سلامتی در دوران بارداری و شیردهی",
                    UserId = 6,
                    RoomId = 8,
                    UploadDate = System.DateTime.Now,
                    LikeCount = 0
                });

            #endregion


            base.OnModelCreating(modelBuilder);


        }
    }
}
