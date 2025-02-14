namespace WhatEverIWant.DataAccess.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title).IsRequired().HasMaxLength(255);
        builder.Property(m => m.Description).HasMaxLength(2000).IsRequired();
        builder.Property(m => m.Year).IsRequired(false);
    }
}