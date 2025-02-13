namespace WhatEverIWant.DataAccess.Repositories;

public interface IMovieRepository : IGenericRepository<Movie>;

public interface ISeriesRepository : IGenericRepository<TvShow>;

public interface IMusicRepository : IGenericRepository<Music>;

public interface IBookRepository : IGenericRepository<Book>;

public interface IAudioBookRepository : IGenericRepository<AudioBook>;
