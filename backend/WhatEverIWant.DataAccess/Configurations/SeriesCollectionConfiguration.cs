namespace WhatEverIWant.DataAccess.Configurations;

public class SeriesCollectionConfiguration : IEntityTypeConfiguration<SeriesCollection>
{
    public void Configure(EntityTypeBuilder<SeriesCollection> builder)
    {
        builder.ToTable("SeriesCollections");

        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(sc => sc.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.Property(sc => sc.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(sc => sc.SeriesCollectionItems)
            .WithOne(sci => sci.SeriesCollection)
            .HasForeignKey(sci => sci.SeriesCollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}