namespace BookShop.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookShop.Models;

    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> bookCategory)
        {
            bookCategory
                .HasKey(bc => new { bc.BookId, bc.CategoryId});

            bookCategory
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            bookCategory
                .HasOne(bc => bc.Category)
                .WithMany(b => b.CategoryBooks)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
