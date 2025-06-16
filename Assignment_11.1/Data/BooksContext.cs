using Microsoft.EntityFrameworkCore;

namespace Assignment_11._1.Data;

public class BooksContext : DbContext
{
    public DbSet<Books> Books { get; set; }

    public BooksContext(DbContextOptions<BooksContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Books>().HasKey(b => b.ISBN);
        modelBuilder.Entity<Books>().HasData(GetBooks());
    }
    private Books[] GetBooks()
    {
        return new Books[]
        {
            new Books { ISBN = 1234567890, Title = "The Hobbit", Author = "J.R.R. Tolkien", Description = "An autobiography", Quantity = 1},
            new Books { ISBN = 9876543210, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Description = "A biography", Quantity = 1 },
            new Books { ISBN = 1234567891, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", Description = "A fantasy novel", Quantity = 1 },
            new Books { ISBN = 1234567892, Title = "The Hunger Games", Author = "Suzanne Collins", Description = "Am action novel", Quantity = 1 }
        };
    }
}