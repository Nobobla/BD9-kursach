using System;

using BD9.Models;
using BD9.Models.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BD9.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Model> Models => Set<Model>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<ContactInform> Informs => Set<ContactInform>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Office> Offices => Set<Office>();
        public DbSet<Emploee> Emps => Set<Emploee>();/// <summary>
        /// /
        /// </summary>
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<ServiceModel> ServiceModels => Set<ServiceModel>();
        public DbSet<Complaint> Complaints => Set<Complaint>();


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           /* Database.EnsureCreated(); */  // создаем базу данных при первом обращении
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)// для вывода запросов
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmploeeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
