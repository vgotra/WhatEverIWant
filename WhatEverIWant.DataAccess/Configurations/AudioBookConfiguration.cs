namespace WhatEverIWant.DataAccess.Configurations;

public class AudioBookConfiguration : IEntityTypeConfiguration<AudioBook>
{
    public void Configure(EntityTypeBuilder<AudioBook> builder)
    {
        builder.ToTable("AudioBooks");

        builder.HasKey(ab => ab.Id);

        builder.Property(ab => ab.Title).IsRequired().HasMaxLength(255);
        builder.Property(ab => ab.Author).HasMaxLength(255).IsRequired();
        builder.Property(ab => ab.Isbn).HasMaxLength(13).IsRequired(false);
        builder.Property(ab => ab.Narrator).HasMaxLength(255).IsRequired(false);
        builder.Property(ab => ab.Year).IsRequired(false);
    }
}