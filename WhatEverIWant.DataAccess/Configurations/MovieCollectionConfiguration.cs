namespace WhatEverIWant.DataAccess.Configurations;

public class MovieCollectionConfiguration : IEntityTypeConfiguration<MovieCollection>
{
    public void Configure(EntityTypeBuilder<MovieCollection> builder)
    {
        builder.ToTable("MovieCollections");

        builder.HasKey(mc => mc.Id);

        builder.Property(mc => mc.Name).IsRequired().HasMaxLength(255);
        builder.Property(mc => mc.Description).HasMaxLength(2000).IsRequired(false);

        builder.HasMany(ne => ne.Items).WithMany(ne => ne.Collections);
    }
}