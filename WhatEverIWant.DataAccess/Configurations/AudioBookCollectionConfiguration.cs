namespace WhatEverIWant.DataAccess.Configurations;

public class AudioBookCollectionConfiguration : IEntityTypeConfiguration<AudioBookCollection>
{
    public void Configure(EntityTypeBuilder<AudioBookCollection> builder)
    {
        builder.ToTable("AudioBookCollections");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
        builder.Property(e => e.Description).HasMaxLength(2000).IsRequired(false);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(ne => ne.Items).WithMany(ne => ne.Collections);
    }
}