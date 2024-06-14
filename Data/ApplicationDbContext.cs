using UserManageAPI.Models;
using Microsoft.EntityFrameworkCore;
using LoremIpsumLogistica.Models;
using System;

namespace UserManageAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cria um usuário administrador inicial
            var adminUser = new User
            {
                Id = 1,
                Nome = "admin",
                Email = "admin@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("AdminPassword123!"),
                DataNascimento = new DateTime(1990, 1, 1),
                Sexo = Sexo.Masculino
            };
            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne()
                .HasForeignKey(a => a.UserId);
        }
    }
}