namespace WhatEverIWant.DataAccess.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(m => m.ReleaseDate)
            .IsRequired(false);

        builder.Property(m => m.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.HasMany(m => m.MoviesDownloads)
            .WithOne(md => md.Movie)
            .HasForeignKey(md => md.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.MovieCollectionItems)
            .WithOne(mci => mci.Movie)
            .HasForeignKey(mci => mci.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}