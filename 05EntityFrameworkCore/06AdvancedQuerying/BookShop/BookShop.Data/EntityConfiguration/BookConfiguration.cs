namespace BookShop.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookShop.Models;

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> book)
        {
            book
                .HasKey(b => b.BookId);

            book
                .Property(b => b.Title)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            book
                .Property(b => b.Description)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(1000);

            book
                .Property(b => b.ReleaseDate)
                .IsRequired(false);

            book
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
