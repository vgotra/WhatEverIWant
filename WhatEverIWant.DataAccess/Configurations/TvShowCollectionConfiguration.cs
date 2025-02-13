namespace WhatEverIWant.DataAccess.Configurations;

public class TvShowCollectionConfiguration : IEntityTypeConfiguration<TvShowCollection>
{
    public void Configure(EntityTypeBuilder<TvShowCollection> builder)
    {
        builder.ToTable("TvShowsCollections");

        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Name).IsRequired().HasMaxLength(255);
        builder.Property(sc => sc.Description).HasMaxLength(2000).IsRequired(false);
        builder.Property(sc => sc.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(ne => ne.Items).WithMany(ne => ne.Collections);
    }
}