namespace WhatEverIWant.DataAccess.Configurations;

public class MusicConfiguration : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.ToTable("Music");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(m => m.Artist)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(m => m.Album)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(m => m.ReleaseDate)
            .IsRequired(false);

        builder.HasMany(m => m.MusicDownloads)
            .WithOne(md => md.Music)
            .HasForeignKey(md => md.MusicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.MusicCollectionItems)
            .WithOne(mci => mci.Music)
            .HasForeignKey(mci => mci.MusicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}