namespace WhatEverIWant.DataAccess.Configurations;

public class MusicCollectionConfiguration : IEntityTypeConfiguration<MusicCollection>
{
    public void Configure(EntityTypeBuilder<MusicCollection> builder)
    {
        builder.ToTable("MusicCollections");

        builder.HasKey(mc => mc.Id);

        builder.Property(mc => mc.Name).IsRequired().HasMaxLength(255);
        builder.Property(mc => mc.Description).HasMaxLength(2000).IsRequired(false);

        builder.HasMany(ne => ne.Items).WithMany(ne => ne.Collections);
    }
}