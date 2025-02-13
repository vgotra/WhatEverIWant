namespace WhatEverIWant.DataAccess.Repositories;

public class MovieRepository(ApplicationDbContext context) : GenericRepository<Movie>(context), IMovieRepository;

public class SeriesRepository(ApplicationDbContext context) : GenericRepository<TvShow>(context), ISeriesRepository;

public class MusicRepository(ApplicationDbContext context) : GenericRepository<Music>(context), IMusicRepository;

public class BookRepository(ApplicationDbContext context) : GenericRepository<Book>(context), IBookRepository;

public class AudioBookRepository(ApplicationDbContext context) : GenericRepository<AudioBook>(context), IAudioBookRepository;