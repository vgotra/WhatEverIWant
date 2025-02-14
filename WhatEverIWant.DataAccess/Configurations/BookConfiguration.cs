namespace WhatEverIWant.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).IsRequired().HasMaxLength(255);
        builder.Property(b => b.Author).HasMaxLength(255).IsRequired();
        builder.Property(b => b.Isbn).HasMaxLength(13).IsRequired(false);
        builder.Property(b => b.Year).IsRequired(false);
    }
}