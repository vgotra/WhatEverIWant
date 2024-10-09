namespace WhatEverIWant.DataAccess.Configurations;

public class AudioBookCollectionConfiguration : IEntityTypeConfiguration<AudioBookCollection>
{
    public void Configure(EntityTypeBuilder<AudioBookCollection> builder)
    {
        builder.ToTable("AudioCollections");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(e => e.AudioBookCollectionItems)
            .WithOne(e => e.AudioBookCollection)
            .HasForeignKey(e => e.AudioBookCollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}