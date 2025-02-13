using WhatEverIWant.DataAccess.Configurations;

namespace WhatEverIWant.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<TvShow> Series { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<AudioBook> AudioBooks { get; set; }

    public DbSet<MovieCollection> MovieCollections { get; set; }
    public DbSet<TvShowCollection> SeriesCollections { get; set; }
    public DbSet<MusicCollection> MusicCollections { get; set; }
    public DbSet<BookCollection> BookCollections { get; set; }
    public DbSet<AudioBookCollection> AudioCollections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SettingConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new TvShowsConfiguration());
        modelBuilder.ApplyConfiguration(new MusicConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new AudioBookConfiguration());

        modelBuilder.ApplyConfiguration(new MovieCollectionConfiguration());
        modelBuilder.ApplyConfiguration(new TvShowCollectionConfiguration());
        modelBuilder.ApplyConfiguration(new MusicCollectionConfiguration());
        modelBuilder.ApplyConfiguration(new BookCollectionConfiguration());
        modelBuilder.ApplyConfiguration(new AudioBookCollectionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}