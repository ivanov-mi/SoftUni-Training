namespace BookShop.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookShop.Models;

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {
            author
                .HasKey(a => a.AuthorId);

            author
                .Property(a => a.FirstName)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(50);

            author
                .Property(a => a.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);
        }
    }
}
