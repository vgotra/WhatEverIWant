namespace WhatEverIWant.DataAccess.Configurations;

public class SeriesDownloadConfiguration : IEntityTypeConfiguration<SeriesDownload>
{
    public void Configure(EntityTypeBuilder<SeriesDownload> builder)
    {
        builder.ToTable("SeriesDownloads");

        builder.HasKey(sd => new { sd.SeriesId, sd.DownloadId });

        builder.HasOne(sd => sd.Series)
            .WithMany(s => s.SeriesDownloads)
            .HasForeignKey(sd => sd.SeriesId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sd => sd.Download)
            .WithMany(d => d.SeriesDownloads)
            .HasForeignKey(sd => sd.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}