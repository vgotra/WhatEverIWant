namespace WhatEverIWant.DataAccess.Configurations;

public class MusicDownloadConfiguration : IEntityTypeConfiguration<MusicDownload>
{
    public void Configure(EntityTypeBuilder<MusicDownload> builder)
    {
        builder.ToTable("MusicDownloads");

        builder.HasKey(md => new { md.MusicId, md.DownloadId });

        builder.HasOne(md => md.Music)
            .WithMany(m => m.MusicDownloads)
            .HasForeignKey(md => md.MusicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(md => md.Download)
            .WithMany(d => d.MusicDownloads)
            .HasForeignKey(md => md.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}