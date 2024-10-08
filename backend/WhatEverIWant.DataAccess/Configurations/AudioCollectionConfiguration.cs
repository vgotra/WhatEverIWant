namespace WhatEverIWant.DataAccess.Configurations;

public class AudioCollectionConfiguration : IEntityTypeConfiguration<AudioBookCollection>
{
    public void Configure(EntityTypeBuilder<AudioBookCollection> builder)
    {
        builder.ToTable("AudioCollections");

        builder.HasKey(ac => ac.Id);

        builder.Property(ac => ac.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(ac => ac.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.Property(ac => ac.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(ac => ac.AudioCollectionItems)
            .WithOne(aci => aci.AudioCollection)
            .HasForeignKey(aci => aci.AudioCollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}