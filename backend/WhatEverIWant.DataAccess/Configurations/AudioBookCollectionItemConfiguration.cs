namespace WhatEverIWant.DataAccess.Configurations;

public class AudioBookCollectionItemConfiguration : IEntityTypeConfiguration<AudioBookCollectionItem>
{
    public void Configure(EntityTypeBuilder<AudioBookCollectionItem> builder)
    {
        builder.HasKey(e => new { e.AudioBookId, e.AudioBookCollectionId });
        
        builder.HasOne(e => e.AudioBook)
            .WithMany(e => e.AudioBookCollectionItems)
            .HasForeignKey(e => e.AudioBookId);

        builder.HasOne(e => e.AudioBookCollection)
            .WithMany(e => e.AudioBookCollectionItems)
            .HasForeignKey(e => e.AudioBookCollectionId);
    }
}