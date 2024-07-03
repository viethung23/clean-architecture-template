﻿using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    /*sử dụng hàm này trong trường hợp muốn fix cứng connectString  và muốn flexible thì phải truyền từ ngoài vào qua contructor (ở đây dùng primary constructor) 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=202.92.4.186,1433;Database=Db;uid=sa;pwd=Viethung3900@;TrustServerCertificate=True;");
    }*/


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(o => o.OwnedRestaurants)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId);
    }
}
