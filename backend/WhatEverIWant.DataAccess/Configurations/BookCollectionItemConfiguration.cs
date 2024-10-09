namespace WhatEverIWant.DataAccess.Configurations;

public class BookCollectionItemConfiguration : IEntityTypeConfiguration<BookCollectionItem>
{
    public void Configure(EntityTypeBuilder<BookCollectionItem> builder)
    {
        builder.HasKey(bookCollectionItem => new { bookCollectionItem.BookId, bookCollectionItem.BookCollectionId });
        
        builder.HasOne(bci => bci.Book)
            .WithMany(a => a.BookCollectionItems)
            .HasForeignKey(bci => bci.BookId);

        builder.HasOne(bci => bci.BookCollection)
            .WithMany(bc => bc.BookCollectionItems)
            .HasForeignKey(bci => bci.BookCollectionId);
    }
}