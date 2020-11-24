using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notes2020.Models;
using Notes2020.ViewModels;

namespace Notes2020.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Note> Notes { get; set; }
        // Users, Roles, UserRoles

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Notes2020.ViewModels.NoteIM> NoteIM { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXX1", Name = "Administrátor", NormalizedName = "ADMINISTRÁTOR" });
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Email = "st@pslib.cz",
                NormalizedEmail = "ST@PSLIB.CZ",
                EmailConfirmed = true,
                LockoutEnabled = false,
                UserName = "st@pslib.cz",
                NormalizedUserName = "ST@PSLIB.CZ",
                PasswordHash = hasher.HashPassword(null, "Admin_1234"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXX1", UserId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" });
        }
    }
}
