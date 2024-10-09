namespace WhatEverIWant.DataAccess.Configurations;

public class SeriesCollectionItemConfiguration : IEntityTypeConfiguration<SeriesCollectionItem>
{
    public void Configure(EntityTypeBuilder<SeriesCollectionItem> builder)
    {
        builder.HasKey(e => new { e.SeriesId, e.SeriesCollectionId });
        
        builder.HasOne(e => e.Series)
            .WithMany(e => e.SeriesCollectionItems)
            .HasForeignKey(e => e.SeriesId);

        builder.HasOne(e => e.SeriesCollection)
            .WithMany(e => e.SeriesCollectionItems)
            .HasForeignKey(e => e.SeriesCollectionId);
    }
}