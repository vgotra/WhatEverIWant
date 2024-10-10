namespace WhatEverIWant.DataAccess.Configurations;

public class MusicCollectionItemConfiguration : IEntityTypeConfiguration<MusicCollectionItem>
{
    public void Configure(EntityTypeBuilder<MusicCollectionItem> builder)
    {
        builder.HasKey(e => new { e.MusicId, e.MusicCollectionId });
        
        builder.HasOne(e => e.Music)
            .WithMany(e => e.MusicCollectionItems)
            .HasForeignKey(e => e.MusicId);

        builder.HasOne(e => e.MusicCollection)
            .WithMany(e => e.MusicCollectionItems)
            .HasForeignKey(e => e.MusicCollectionId);
    }
}