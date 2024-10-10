using WhatEverIWant.DataAccess.Configurations;

namespace WhatEverIWant.DataAccess;

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }

        public DbSet<MovieCollection> MovieCollections { get; set; }
        public DbSet<MovieCollectionItem> MovieCollectionItems { get; set; }

        public DbSet<SeriesCollection> SeriesCollections { get; set; }
        public DbSet<SeriesCollectionItem> SeriesCollectionItems { get; set; }

        public DbSet<MusicCollection> MusicCollections { get; set; }
        public DbSet<MusicCollectionItem> MusicCollectionItems { get; set; }

        public DbSet<BookCollection> BookCollections { get; set; }
        public DbSet<BookCollectionItem> BookCollectionItems { get; set; }

        public DbSet<AudioBookCollection> AudioCollections { get; set; }
        public DbSet<AudioBookCollectionItem> AudioCollectionItems { get; set; }

        public DbSet<Download> Downloads { get; set; }
        public DbSet<MoviesDownload> MoviesDownloads { get; set; }
        public DbSet<SeriesDownload> SeriesDownloads { get; set; }
        public DbSet<MusicDownload> MusicDownloads { get; set; }
        public DbSet<BookDownload> BookDownloads { get; set; }
        public DbSet<AudioBookDownload> AudioBookDownloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesConfiguration());
            modelBuilder.ApplyConfiguration(new MusicConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AudioBookConfiguration());

            modelBuilder.ApplyConfiguration(new MovieCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new MovieCollectionItemConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesCollectionItemConfiguration());
            modelBuilder.ApplyConfiguration(new MusicCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new MusicCollectionItemConfiguration());
            modelBuilder.ApplyConfiguration(new BookCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new BookCollectionItemConfiguration());
            modelBuilder.ApplyConfiguration(new AudioBookCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new AudioBookCollectionItemConfiguration());

            modelBuilder.ApplyConfiguration(new DownloadConfiguration());
            modelBuilder.ApplyConfiguration(new MoviesDownloadConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesDownloadConfiguration());
            modelBuilder.ApplyConfiguration(new MusicDownloadConfiguration());
            modelBuilder.ApplyConfiguration(new BookDownloadConfiguration());
            modelBuilder.ApplyConfiguration(new AudioBookDownloadConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }