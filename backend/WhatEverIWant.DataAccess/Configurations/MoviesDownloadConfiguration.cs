namespace WhatEverIWant.DataAccess.Configurations;

public class MoviesDownloadConfiguration : IEntityTypeConfiguration<MoviesDownload>
{
    public void Configure(EntityTypeBuilder<MoviesDownload> builder)
    {
        builder.ToTable("MoviesDownloads");

        builder.HasKey(md => new { md.MovieId, md.DownloadId });

        builder.HasOne(md => md.Movie)
            .WithMany(m => m.MoviesDownloads)
            .HasForeignKey(md => md.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(md => md.Download)
            .WithMany(d => d.MoviesDownloads)
            .HasForeignKey(md => md.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}