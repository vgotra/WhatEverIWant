namespace WhatEverIWant.DataAccess.Configurations;

public class DownloadConfiguration : IEntityTypeConfiguration<Download>
{
    public void Configure(EntityTypeBuilder<Download> builder)
    {
        builder.ToTable("Downloads");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Url)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(d => d.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(d => d.MoviesDownloads)
            .WithOne(md => md.Download)
            .HasForeignKey(md => md.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.SeriesDownloads)
            .WithOne(sd => sd.Download)
            .HasForeignKey(sd => sd.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.MusicDownloads)
            .WithOne(md => md.Download)
            .HasForeignKey(md => md.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.BookDownloads)
            .WithOne(bd => bd.Download)
            .HasForeignKey(bd => bd.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.AudioBookDownloads)
            .WithOne(abd => abd.Download)
            .HasForeignKey(abd => abd.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}