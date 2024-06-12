using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class IMIDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<GroupMembers> members { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Admin> Admin { get; set; }



        public IMIDbContext(DbContextOptions<IMIDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            DateTime seedingDate = new DateTime(1970, 01, 01);

            modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id);
            ApplicationUser[] users = new[]
                {
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        FirstName = "Qiandro",
                        LastName = "Claeys",
                        Email = "Qiandro.claeys@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = new DateTime(2001, 07, 20),
                        EmailConfirmed = true,
                        NormalizedEmail = "QIANDRO.CLAEYS@GMAIL.COM",
                        UserName = "Qiandro.claeys@gmail.com",
                        NormalizedUserName = "QIANDRO.CLAEYS@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002").ToString(),
                        FirstName = "Qienta",
                        LastName = "Claeys",
                        Email = "Qienta.claeys@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = new DateTime(2003, 09, 28),
                        EmailConfirmed = true,
                        NormalizedEmail = "QIENTA.CLAEYS@GMAIL.COM",
                        UserName = "Qienta.claeys@gmail.com",
                        NormalizedUserName = "QIENTA.CLAEYS@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,

                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003").ToString(),
                        FirstName = "Taina",
                        LastName = "Reubens",
                        Email = "Taina.reubens@proximus.be",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "TAINA.REUBENS@PROXIMUS.BE",
                        UserName = "Taina.reubens@proximus.be",
                        NormalizedUserName = "TAINA.REUBENS@PROXIMUS.BE",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004").ToString(),
                        FirstName = "Gianni",
                        LastName = "Claeys",
                        Email = "Gianni.claeys@proximus.be",
                        LastOnline = DateTime.Now,
                        EmailConfirmed = true,
                        NormalizedEmail = "GIANNI.CLAEYS@PROXIMUS.BE",
                        UserName = "Gianni.claeys@proximus.be",
                        NormalizedUserName = "GIANNI.CLAEYS@PROXIMUS.BE",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005").ToString(),
                        FirstName = "Joeri",
                        LastName = "Versyck",
                        Email = "Joeri.Versyck@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "JOERI.VERSYCK@GMAIL.COM",
                        UserName = "Joeri.Versyck@gmail.com",
                        NormalizedUserName = "JOERI.VERSYCK@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006").ToString(),
                        FirstName = "Kevin",
                        LastName = "Rooseboom",
                        Email = "Kevin.Rooseboom@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = new DateTime(1998,08,15),
                        EmailConfirmed = true,
                        NormalizedEmail = "KEVIN.ROOSEBOOM@GMAIL.COM",
                        UserName = "Kevin.Rooseboom@gmail.com",
                        NormalizedUserName = "KEVIN.ROOSEBOOM@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007").ToString(),
                        FirstName = "Lieven",
                        LastName = "Geryl",
                        Email = "Lieven.Geryl@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "LIEVEN.GERYL@GMAIL.COM",
                        UserName = "Lieven.Geryl@gmail.com",
                        NormalizedUserName = "LIEVEN.GERYL@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008").ToString(),
                        FirstName = "Michiel",
                        LastName = "Blancquaert",
                        Email = "Miblan@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "MIBLAN@GMAIL.COM",
                        UserName = "Miblan@gmail.com", 
                        NormalizedUserName = "MIBLAN@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009").ToString(),
                        FirstName = "Ashley",
                        LastName = "Senaeve",
                        Email = "Ashley.Senaeve@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "ASHLEY.SENAEVE@GMAIL.COM",
                        UserName = "Ashley.Senaeve@gmail.com",
                        NormalizedUserName = "ASHLEY.SENAEVE@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010").ToString(),
                        FirstName = "Kimberly",
                        LastName = "Sabbe",
                        Email = "Kim.Sabbe@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "KIM.SABBE@GMAIL.COM",
                        UserName = "Kim.sabbe@GMAIL.COM", 
                        NormalizedUserName = "KIM.SABBE@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000011").ToString(),
                        FirstName = "Damien",
                        LastName = "Maddens",
                        Email = "Damien.Maddens@gmail.com",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "DAMIEN.MADDENS@GMAIL.COM",
                        UserName = "Damien.maddens@GMAIL.COM", 
                        NormalizedUserName = "DAMIEN.MADDENS@GMAIL.COM",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,

                    },      
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000012").ToString(),
                        FirstName = "Imi",
                        LastName = "User",
                        Email = "user@imi.be",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "USER@IMI.BE",
                        UserName = "user@imi.be",
                        NormalizedUserName = "USER@IMI.BE",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000013").ToString(),
                        FirstName = "Imi",
                        LastName = "Refuser",
                        Email = "refuser@imi.be",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "REFUSER@IMI.BE",
                        UserName = "refuser@imi.be",
                        NormalizedUserName = "REFUSER@IMI.BE",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = false,
                    },
                    new ApplicationUser
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000014").ToString(),
                        FirstName = "admin",
                        LastName = "admin",
                        Email = "admin@imi.be",
                        LastOnline = DateTime.Now,
                        BirthDate = seedingDate,
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@IMI.BE",
                        UserName = "admin@imi.be",
                        NormalizedUserName = "ADMIN@IMI.BE",
                        PhoneNumberConfirmed = true,
                        HasApprovedTermsAndConditions = true,
                    },


                };

            foreach (ApplicationUser user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Test123?");
            }

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Group>().HasData(

                new[]
                {
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Familie Claeys",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Friends",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "PROG klas",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep1",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep2",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep3",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep4",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep5",
                        Img = ""
                    },
                    new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep6",
                        Img = ""
                    },
                     new Group
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        CreatorId = "00000000-0000-0000-0000-000000000001",
                        Name = "Testgroep7",
                        Img = ""
                    },
                });

            modelBuilder.Entity<GroupMembers>().HasKey(a => new { a.GroupId, a.UserId });
            modelBuilder.Entity<GroupMembers>().HasOne(a => a.Group).WithMany(g => g.GroupMembers).HasForeignKey(a => a.GroupId);
            modelBuilder.Entity<GroupMembers>().HasOne(a => a.User).WithMany(u => u.GroupMembers).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<GroupMembers>().HasData(
                new[]
                {
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = "00000000-0000-0000-0000-000000000001",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = "00000000-0000-0000-0000-000000000002"
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = "00000000-0000-0000-0000-000000000003",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = "00000000-0000-0000-0000-000000000004",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = "00000000-0000-0000-0000-000000000001",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = "00000000-0000-0000-0000-000000000010",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = "00000000-0000-0000-0000-000000000011",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = "00000000-0000-0000-0000-000000000001",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = "00000000-0000-0000-0000-000000000005",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = "00000000-0000-0000-0000-000000000006",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = "00000000-0000-0000-0000-000000000007",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = "00000000-0000-0000-0000-000000000008",
                    },
                    new GroupMembers
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = "00000000-0000-0000-0000-000000000009",
                    },


                });

            modelBuilder.Entity<Admin>().HasKey(a => new { a.GroupId, a.UserId });
            modelBuilder.Entity<Admin>().HasOne(a => a.Group).WithMany(g => g.Admins).HasForeignKey(a => a.GroupId);
            modelBuilder.Entity<Admin>().HasOne(a => a.User).WithMany(u => u.Admins).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Admin>().HasData(
                new[]
                {
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000004").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000011").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000010").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000009").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000008").ToString(),
                    },
                    new Admin
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000007").ToString(),
                    },
                });


            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().HasOne(a => a.Group).WithMany(g => g.Events).HasForeignKey(a => a.GroupId);
            modelBuilder.Entity<Event>().HasOne(a => a.Creator).WithMany(u => u.Events).HasForeignKey(a => a.CreatorId);
            modelBuilder.Entity<Event>().HasData(
                new[]
                {
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Dagje Plopsaland",
                        Description = "We gaan met de familie naar plopsaland en tante gaat mee",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,08,20,10,30,00),
                        EndDate = new DateTime(2023,08,20,18,30,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000002").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Inenting Qienta",
                        Description = "Inenting voor qienta haar reuma",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,05,03,13,00,00),
                        EndDate = new DateTime(2023,05,03,14,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Cinema",
                        Description = "Film gaan kijken in kinepolis brugge",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,29,14,00,00) ,
                        EndDate = new DateTime(2023,04,29,16,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000005").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "les",
                        Description = "Aanwezig",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,28,8,30,00),
                        EndDate = new DateTime(2023,04,28,12,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000006").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "les",
                        Description = "Aanwezig",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,28,8,30,00),
                        EndDate = new DateTime(2023,04,28,12,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000007").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "les",
                        Description = "Aanwezig",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,28,8,30,00),
                        EndDate = new DateTime(2023,04,28,12,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000008").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "les",
                        Description = "Aanwezig",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,28,8,30,00),
                        EndDate = new DateTime(2023,04,28,12,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "les",
                        Description = "Aanwezig",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,28,8,30,00),
                        EndDate = new DateTime(2023,04,28,12,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000009").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "les",
                        Description = "Aanwezig",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,28,8,30,00),
                        EndDate = new DateTime(2023,04,28,12,00,00),
                    },
                    new Event
                    {
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CreatorId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        EventId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Biljart",
                        Description = "Smoking cue in torhout",
                        CreationDate = DateTime.Today,
                        LastEditedOn = null,
                        DeletedOn = null,
                        StartDate = new DateTime(2023,04,29,17,00,00),
                        EndDate = new DateTime(2023,04,29,20,30,00),
                    },

                }) ;

            modelBuilder.Entity<Message>().HasKey(e => e.MessageId);
            modelBuilder.Entity<Message>().HasOne(a => a.Group).WithMany(g => g.Messages).HasForeignKey(a => a.GroupId);
            modelBuilder.Entity<Message>().HasOne(a => a.Sender).WithMany(u => u.Messages).HasForeignKey(a => a.SenderId);
            modelBuilder.Entity<Message>().HasData(
                new[]
                {
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        Content = "Hallo dit is een test",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000002").ToString(),
                        Content = "Hallo dit is (g)een test",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        Content = "Hallo dit is een test",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000001").ToString(),
                        Content = "Hallo dit is een test",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000003").ToString(),
                        Content = "Hallo",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000004").ToString(),
                        Content = "Hallo",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000005").ToString(),
                        Content = "Hallo",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000006").ToString(),
                        Content = "Hallo",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000007").ToString(),
                        Content = "Hallo",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                    new Message
                    {
                        MessageId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        GroupId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        SenderId = Guid.Parse("00000000-0000-0000-0000-000000000008").ToString(),
                        Content = "Hallo",
                        SentTime = DateTime.Today,
                        LastEditedOn = null
                    },
                });
        }

    }
}
