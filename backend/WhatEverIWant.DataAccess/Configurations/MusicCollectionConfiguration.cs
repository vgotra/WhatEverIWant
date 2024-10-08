namespace WhatEverIWant.DataAccess.Configurations;

public class MusicCollectionConfiguration : IEntityTypeConfiguration<MusicCollection>
{
    public void Configure(EntityTypeBuilder<MusicCollection> builder)
    {
        builder.ToTable("MusicCollections");

        builder.HasKey(mc => mc.Id);

        builder.Property(mc => mc.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(mc => mc.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.Property(mc => mc.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(mc => mc.MusicCollectionItems)
            .WithOne(mci => mci.MusicCollection)
            .HasForeignKey(mci => mci.MusicCollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}