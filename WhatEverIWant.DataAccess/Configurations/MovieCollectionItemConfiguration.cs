namespace WhatEverIWant.DataAccess.Configurations;

public class MovieCollectionItemConfiguration : IEntityTypeConfiguration<MovieCollectionItem>
{
    public void Configure(EntityTypeBuilder<MovieCollectionItem> builder)
    {
        builder.HasKey(e => new { e.MovieId, e.MovieCollectionId });
        
        builder.HasOne(e => e.Movie)
            .WithMany(e => e.MovieCollectionItems)
            .HasForeignKey(e => e.MovieId);

        builder.HasOne(e => e.MovieCollection)
            .WithMany(e => e.MovieCollectionItems)
            .HasForeignKey(e => e.MovieCollectionId);
    }
}