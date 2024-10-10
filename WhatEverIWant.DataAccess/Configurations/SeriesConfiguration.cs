namespace WhatEverIWant.DataAccess.Configurations;

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(s => s.StartDate)
            .IsRequired(false);

        builder.Property(s => s.EndDate)
            .IsRequired(false);

        builder.Property(s => s.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.HasMany(s => s.SeriesDownloads)
            .WithOne(sd => sd.Series)
            .HasForeignKey(sd => sd.SeriesId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.SeriesCollectionItems)
            .WithOne(sci => sci.Series)
            .HasForeignKey(sci => sci.SeriesId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}