using Bookshelf.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
  }

  public DbSet<Book> Books => Set<Book>();

  public DbSet<UserBook> UserBooks => Set<UserBook>();

  public DbSet<BookProposal> BookProposals => Set<BookProposal>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Book>()
      .HasIndex(book => book.ISBN)
      .IsUnique();

    var userBook = modelBuilder.Entity<UserBook>();

    userBook.HasIndex(userBook => new
      {
        userBook.UserId,
        userBook.BookId
      })
      .IsUnique();

    userBook.HasOne(userBook => userBook.User)
      .WithMany()
      .HasForeignKey(userBook => userBook.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    userBook.HasOne(userBook => userBook.Book)
      .WithMany()
      .HasForeignKey(userBook => userBook.BookId)
      .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<BookProposal>()
      .HasOne(bookProposal => bookProposal.User)
      .WithMany()
      .HasForeignKey(bookProposal => bookProposal.UserId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}