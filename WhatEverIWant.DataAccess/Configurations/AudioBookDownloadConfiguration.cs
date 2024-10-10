namespace WhatEverIWant.DataAccess.Configurations;

public class AudioBookDownloadConfiguration : IEntityTypeConfiguration<AudioBookDownload>
{
    public void Configure(EntityTypeBuilder<AudioBookDownload> builder)
    {
        builder.ToTable("AudioBookDownloads");

        builder.HasKey(abd => new { abd.AudioBookId, abd.DownloadId });

        builder.HasOne(abd => abd.AudioBook)
            .WithMany(ab => ab.AudioBookDownloads)
            .HasForeignKey(abd => abd.AudioBookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(abd => abd.Download)
            .WithMany(d => d.AudioBookDownloads)
            .HasForeignKey(abd => abd.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}