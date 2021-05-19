﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoContest.Data.Configurations;
using PhotoContest.Data.Models;
using System;
using System.Collections.Generic;

namespace PhotoContest.Data
{
    public class PhotoContestContext : IdentityDbContext<User,Role,Guid>
    {
        public PhotoContestContext() { }
        public PhotoContestContext(DbContextOptions<PhotoContestContext> options) 
            : base(options) { }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserContest> UserContests { get; set; }
        public DbSet<Jury> Juries { get; set; }
        public DbSet<Point> Points { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ContestConfig());
            modelBuilder.ApplyConfiguration(new JuryConfig());
            modelBuilder.ApplyConfiguration(new PhotoConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserContestConfig());

            this.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
                        options.UseSqlServer("Server=.\\SQLEXPRESS; Database=PhotoContestDB; Integrated Security=True");


        protected virtual void Seed(ModelBuilder modelBuilder)
        {
            //seed categories
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cars",
                    CreatedOn = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Animals",
                    CreatedOn = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nature",
                    CreatedOn = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Architecture",
                    CreatedOn = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Motorbikes",
                    CreatedOn = DateTime.UtcNow,
                }
            };
            //seed statuses
            var statuses = new List<Status>()
            {
                new Status()
                {
                    Id = Guid.NewGuid(),
                    Name = "Phase 1"
                },
                new Status()
                {
                    Id = Guid.NewGuid(),
                    Name = "Phase 2"
                },
                new Status()
                {
                    Id = Guid.NewGuid(),
                    Name = "Finished"
                },
            };
            //seed ranks
            var ranks = new List<Rank>()
            {
                new Rank()
                {
                    Id = Guid.NewGuid(),
                    Name = "Junkie"
                },
                new Rank()
                {
                    Id = Guid.NewGuid(),
                    Name = "Enthusiast"
                },
                new Rank()
                {
                    Id = Guid.NewGuid(),
                    Name = "Master"
                },
                new Rank()
                {
                    Id = Guid.NewGuid(),
                    Name = "Wise and Benevolent Photo Dictator"
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Rank>().HasData(ranks);

            //seed roles 
            var adminRole = new Role() { Id = Guid.NewGuid(), Name = "Organizer", NormalizedName = "ORGANIZER" };
            var userRole = new Role() { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER" };
            var roles = new List<Role>() { adminRole, userRole };

            modelBuilder.Entity<Role>().HasData(roles); 

            //password hasher
            var passHasher = new PasswordHasher<User>();

            //seed organizerUser
            var adminUser = new User();
            adminUser.Id = Guid.NewGuid();
            adminUser.FirstName = "Eric";
            adminUser.LastName = "Berg";
            adminUser.Email = "eric.berg@mail.com";
            adminUser.NormalizedEmail = "ERIC.BERG@MAIL.COM";
            adminUser.UserName = "eric.berg@mail.com";
            adminUser.NormalizedUserName = "ERIC.BERG@MAIL.COM";
            adminUser.CreatedOn = DateTime.UtcNow;
            adminUser.PasswordHash = passHasher.HashPassword(adminUser, "eric.berg123");
            adminUser.RankId = ranks[3].Id;
            adminUser.SecurityStamp = "DC6E275DD1E24957A7781D42BB68293B";
            adminUser.LockoutEnabled = true;
            modelBuilder.Entity<User>().HasData(adminUser);

            //link organizerUser to role
            var adminUserRole = new IdentityUserRole<Guid>();
            adminUserRole.RoleId = adminRole.Id;
            adminUserRole.UserId = adminUser.Id;
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(adminUserRole);

            //seed userRole
            var user = new User();
            user.Id = Guid.NewGuid();
            user.FirstName = "Georgi";
            user.LastName = "Ivanov";
            user.Email = "georgi.ivanov@mail.com";
            user.NormalizedEmail = "GEORGI.IVANOV@MAIL.COM";
            user.UserName = "georgi.ivanov@mail.com";
            user.NormalizedUserName = "GEORGI.IVANOV@MAIL.COM";
            user.CreatedOn = DateTime.UtcNow;
            user.PasswordHash = passHasher.HashPassword(user, "georgi.ivanov123");
            user.RankId = ranks[0].Id;
            user.SecurityStamp = "DC6E275DD1E24957A7781D42BB68292B";
            user.LockoutEnabled = true;
            modelBuilder.Entity<User>().HasData(user);

            //link fanUser to role
            var normalUserRole = new IdentityUserRole<Guid>();
            normalUserRole.RoleId = userRole.Id;
            normalUserRole.UserId = user.Id;
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(normalUserRole);

            
        }
    }
}
