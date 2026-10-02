using Microsoft.EntityFrameworkCore;
using MindMirror.Models;

namespace MindMirror.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Resource> Resources => Set<Resource>();
}