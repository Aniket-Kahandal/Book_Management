using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Book_Management.Models;

public partial class BookmanagementContext : DbContext
{
    public BookmanagementContext()
    {
    }

    public BookmanagementContext(DbContextOptions<BookmanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BOOK__3213E83F50747F04");

            entity.ToTable("BOOK");

            entity.HasIndex(e => e.Isbn, "UQ__BOOK__447D36EAFAB2579A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
