﻿// <auto-generated />
using System;
using FroumSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FroumSite.Migrations
{
    [DbContext(typeof(FroumContext))]
    [Migration("20231212210411_AddedLikeFeatureTo_Topic_And_Post_Tbls")]
    partial class AddedLikeFeatureTo_Topic_And_Post_Tbls
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FroumSite.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Caption = "خانواده اولین گروهی است که ما تجربه می کنیم",
                            LikeCount = 0,
                            TopicId = 1,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(6713),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Caption = "بهتر است فضای خانواده صمیمی باشد",
                            LikeCount = 0,
                            TopicId = 1,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7559),
                            UserId = 10
                        },
                        new
                        {
                            Id = 3,
                            Caption = "فردوسی زحمات زیادی برای ادبیات ایران کشید",
                            LikeCount = 0,
                            TopicId = 2,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7583),
                            UserId = 9
                        },
                        new
                        {
                            Id = 4,
                            Caption = "شاهنامه بسیار پر مفهوم است",
                            LikeCount = 0,
                            TopicId = 2,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7585),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Caption = "گوشی جدید شیائومی به سیستم عامل اختصاصی این شرکت مجهر است",
                            LikeCount = 0,
                            TopicId = 3,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7587),
                            UserId = 3
                        },
                        new
                        {
                            Id = 6,
                            Caption = "امسال ، برای اپل سال نحسی بود!",
                            LikeCount = 0,
                            TopicId = 4,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7589),
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            Caption = "اختلاس چای دبش به کجا رسید؟",
                            LikeCount = 0,
                            TopicId = 5,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7591),
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            Caption = "آیا اروپا امسال هم زمستان سختی خواهد داشت؟",
                            LikeCount = 0,
                            TopicId = 5,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7592),
                            UserId = 3
                        },
                        new
                        {
                            Id = 11,
                            Caption = "5 ماه اول شیردهی چقدر مهم است؟",
                            LikeCount = 0,
                            TopicId = 6,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7594),
                            UserId = 2
                        },
                        new
                        {
                            Id = 12,
                            Caption = "استرس در دوران بارداری",
                            LikeCount = 0,
                            TopicId = 6,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7595),
                            UserId = 4
                        },
                        new
                        {
                            Id = 13,
                            Caption = "تغذیه در دوران بارداری",
                            LikeCount = 0,
                            TopicId = 6,
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 859, DateTimeKind.Local).AddTicks(7597),
                            UserId = 4
                        });
                });

            modelBuilder.Entity("FroumSite.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SubjectId = 1,
                            Title = "روابط در خانواده"
                        },
                        new
                        {
                            Id = 2,
                            SubjectId = 1,
                            Title = "صمیمیت در خانواده"
                        },
                        new
                        {
                            Id = 3,
                            SubjectId = 2,
                            Title = "اپل"
                        },
                        new
                        {
                            Id = 4,
                            SubjectId = 2,
                            Title = "شیائومی"
                        },
                        new
                        {
                            Id = 5,
                            SubjectId = 2,
                            Title = "تلویزیون های هوشمند"
                        },
                        new
                        {
                            Id = 6,
                            SubjectId = 3,
                            Title = "داخل"
                        },
                        new
                        {
                            Id = 7,
                            SubjectId = 3,
                            Title = "خارج"
                        },
                        new
                        {
                            Id = 8,
                            SubjectId = 5,
                            Title = "شیردهی"
                        },
                        new
                        {
                            Id = 9,
                            SubjectId = 2,
                            Title = "ساعت های هوشمند"
                        },
                        new
                        {
                            Id = 10,
                            SubjectId = 2,
                            Title = "گجت های پوشیدنی"
                        },
                        new
                        {
                            Id = 11,
                            SubjectId = 2,
                            Title = "ماشین های خودران"
                        },
                        new
                        {
                            Id = 12,
                            SubjectId = 6,
                            Title = "فردوسی"
                        });
                });

            modelBuilder.Entity("FroumSite.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "خانواده"
                        },
                        new
                        {
                            Id = 2,
                            Title = "تکنولوژی"
                        },
                        new
                        {
                            Id = 3,
                            Title = "سیاست"
                        },
                        new
                        {
                            Id = 4,
                            Title = "ورزش"
                        },
                        new
                        {
                            Id = 5,
                            Title = "بارداری"
                        },
                        new
                        {
                            Id = 6,
                            Title = "ادبیات"
                        });
                });

            modelBuilder.Entity("FroumSite.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "روابط پدر با فرزندان باید صمیمانه باشد",
                            LikeCount = 0,
                            RoomId = 1,
                            Title = "روابط پدر با فرزندان",
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(2677),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "اهمیت فردوسی برای ایران",
                            LikeCount = 0,
                            RoomId = 12,
                            Title = "فردوسی",
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3259),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "خداحافظی با اندروید",
                            LikeCount = 0,
                            RoomId = 4,
                            Title = "شیائومی ، تافته ی جدا بافته",
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3278),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "تیم کوک حتی فکرش را هم نمی کرد",
                            LikeCount = 0,
                            RoomId = 3,
                            Title = "سرنوشت اپل در سال 2023",
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3280),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "چند وقته اخبار دنبال نمی کنم ، هر چیزی میدونید به منم بگید",
                            LikeCount = 0,
                            RoomId = 6,
                            Title = "از سیاست چه خبر",
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3282),
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Description = "این موضوع از اهمیت بالایی برخوردار است",
                            LikeCount = 0,
                            RoomId = 8,
                            Title = "سلامتی در دوران بارداری و شیردهی",
                            UploadDate = new DateTime(2023, 12, 13, 0, 34, 10, 860, DateTimeKind.Local).AddTicks(3285),
                            UserId = 6
                        });
                });

            modelBuilder.Entity("FroumSite.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1999, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "تاجمیرریاحی",
                            IsAdmin = false,
                            Name = "سجاد",
                            Password = "123",
                            PhoneNumber = "09136941387",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 857, DateTimeKind.Local).AddTicks(7062),
                            Sex = 0
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1980, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "محمدی",
                            IsAdmin = false,
                            Name = "علی",
                            Password = "123",
                            PhoneNumber = "09121231234",
                            RegisterDate = new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = 0
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1995, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "غلامی",
                            IsAdmin = false,
                            Name = "مریم",
                            Password = "123",
                            PhoneNumber = "09131231598",
                            RegisterDate = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = 1
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(2000, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "مهدوی",
                            IsAdmin = false,
                            Name = "ثریا",
                            Password = "123",
                            PhoneNumber = "09425874136",
                            RegisterDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Sex = 1
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(1994, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "خدادادی",
                            IsAdmin = false,
                            Name = "شیلا",
                            Password = "123",
                            PhoneNumber = "09136547156",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5850),
                            Sex = 1
                        },
                        new
                        {
                            Id = 6,
                            Birthday = new DateTime(1991, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "حسن پور",
                            IsAdmin = false,
                            Name = "الناز",
                            Password = "123",
                            PhoneNumber = "09136512036",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5865),
                            Sex = 1
                        },
                        new
                        {
                            Id = 7,
                            Birthday = new DateTime(2000, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "حسن زاده",
                            IsAdmin = false,
                            Name = "شهرام",
                            Password = "123",
                            PhoneNumber = "09123650942",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5868),
                            Sex = 0
                        },
                        new
                        {
                            Id = 8,
                            Birthday = new DateTime(1985, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "اعتمادی",
                            IsAdmin = false,
                            Name = "محمود",
                            Password = "123",
                            PhoneNumber = "09425558182",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5871),
                            Sex = 0
                        },
                        new
                        {
                            Id = 9,
                            Birthday = new DateTime(1980, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "معتمدی",
                            IsAdmin = false,
                            Name = "شهلا",
                            Password = "123",
                            PhoneNumber = "09116951478",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5874),
                            Sex = 1
                        },
                        new
                        {
                            Id = 10,
                            Birthday = new DateTime(2004, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "زارع",
                            IsAdmin = false,
                            Name = "زهرا",
                            Password = "123",
                            PhoneNumber = "09362012361",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5876),
                            Sex = 1
                        },
                        new
                        {
                            Id = 11,
                            Birthday = new DateTime(2005, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Family = "حیدری",
                            IsAdmin = false,
                            Name = "امیر",
                            Password = "123",
                            PhoneNumber = "09352142314",
                            RegisterDate = new DateTime(2023, 12, 13, 0, 34, 10, 858, DateTimeKind.Local).AddTicks(5880),
                            Sex = 0
                        });
                });

            modelBuilder.Entity("FroumSite.Models.UserLikePost", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("UserLikePosts");
                });

            modelBuilder.Entity("FroumSite.Models.UserLikeTopic", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("UserLikeTopics");
                });

            modelBuilder.Entity("FroumSite.Models.Post", b =>
                {
                    b.HasOne("FroumSite.Models.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FroumSite.Models.User", "User")
                        .WithMany("SharedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FroumSite.Models.Room", b =>
                {
                    b.HasOne("FroumSite.Models.Subject", "Subject")
                        .WithMany("Rooms")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FroumSite.Models.Topic", b =>
                {
                    b.HasOne("FroumSite.Models.Room", "Room")
                        .WithMany("Topics")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FroumSite.Models.User", "User")
                        .WithMany("SharedTopics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FroumSite.Models.UserLikePost", b =>
                {
                    b.HasOne("FroumSite.Models.Post", "Post")
                        .WithMany("UsersLikedThisPost")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FroumSite.Models.User", "User")
                        .WithMany("LikedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FroumSite.Models.UserLikeTopic", b =>
                {
                    b.HasOne("FroumSite.Models.Topic", "Topic")
                        .WithMany("UsersLikedThisTopic")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FroumSite.Models.User", "User")
                        .WithMany("LikedTopics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
