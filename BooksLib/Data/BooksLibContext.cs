using BooksLib.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksLib.Data
{
    public sealed class BooksLibContext : DbContext
    {
        public BooksLibContext(DbContextOptions<BooksLibContext> options) : base(options)
        { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book2Author>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<Book2Author>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BookAuthors)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Book2Author>()
                .HasOne(pt => pt.Author)
                .WithMany(t => t.AuthorBooks)
                .HasForeignKey(pt => pt.AuthorId);

            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().ToTable("Authors");
        }
    }
}
