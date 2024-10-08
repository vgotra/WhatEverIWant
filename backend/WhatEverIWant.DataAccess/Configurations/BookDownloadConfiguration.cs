namespace WhatEverIWant.DataAccess.Configurations;

public class BookDownloadConfiguration : IEntityTypeConfiguration<BookDownload>
{
    public void Configure(EntityTypeBuilder<BookDownload> builder)
    {
        builder.ToTable("BookDownloads");

        builder.HasKey(bd => new { bd.BookId, bd.DownloadId });

        builder.HasOne(bd => bd.Book)
            .WithMany(b => b.BookDownloads)
            .HasForeignKey(bd => bd.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bd => bd.Download)
            .WithMany(d => d.BookDownloads)
            .HasForeignKey(bd => bd.DownloadId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}