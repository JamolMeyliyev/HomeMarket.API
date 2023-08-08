using HomeMarket.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeMarket.API.Context;

public class AppDbContext:DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Discount> Discounts { get; set; }  
    public DbSet<Home> Homes { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
