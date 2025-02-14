namespace WhatEverIWant.DataAccess.Configurations;

public class MusicConfiguration : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.ToTable("Musics");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title).IsRequired().HasMaxLength(255);
        builder.Property(m => m.Artist).HasMaxLength(255).IsRequired(false);
        builder.Property(m => m.Album).HasMaxLength(255).IsRequired(false);
        builder.Property(m => m.Year).IsRequired(false);
    }
}