using Microsoft.EntityFrameworkCore;
using Nursey.API.Entities;

namespace Nursey.API.Repositories;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) 
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasKey(x => x.CPF);

        modelBuilder.Entity<Person>()
            .HasDiscriminator(x => x.Type)
            .HasValue<Child>(PersonType.Child)
            .HasValue<Parent>(PersonType.Parent);

        base.OnModelCreating(modelBuilder);
    }
}