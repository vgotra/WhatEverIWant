namespace WhatEverIWant.DataAccess.Configurations;

public class BookCollectionConfiguration : IEntityTypeConfiguration<BookCollection>
{
    public void Configure(EntityTypeBuilder<BookCollection> builder)
    {
        builder.ToTable("BookCollections");

        builder.HasKey(bc => bc.Id);

        builder.Property(bc => bc.Name).IsRequired().HasMaxLength(255);
        builder.Property(bc => bc.Description).HasMaxLength(2000).IsRequired(false);
        builder.Property(bc => bc.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(ne => ne.Items).WithMany(ne => ne.Collections);
    }
}