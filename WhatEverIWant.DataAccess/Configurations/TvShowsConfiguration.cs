namespace WhatEverIWant.DataAccess.Configurations;

public class TvShowsConfiguration : IEntityTypeConfiguration<TvShow>
{
    public void Configure(EntityTypeBuilder<TvShow> builder)
    {
        builder.ToTable("TvShows");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title).IsRequired().HasMaxLength(255);
        builder.Property(s => s.StartDate).IsRequired(false);
        builder.Property(s => s.EndDate).IsRequired(false);
        builder.Property(s => s.Description).HasMaxLength(2000).IsRequired(false);
    }
}