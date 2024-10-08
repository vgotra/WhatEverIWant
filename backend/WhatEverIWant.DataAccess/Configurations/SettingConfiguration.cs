namespace WhatEverIWant.DataAccess.Configurations;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ToTable("Settings");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Key)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(s => s.Key)
            .IsUnique();

        builder.Property(s => s.Value)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(1000);
    }
}