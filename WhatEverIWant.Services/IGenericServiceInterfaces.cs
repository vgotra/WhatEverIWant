using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.Services.Models.AudioBooks;
using WhatEverIWant.Services.Models.Books;
using WhatEverIWant.Services.Models.Movies;
using WhatEverIWant.Services.Models.Music;
using WhatEverIWant.Services.Models.Series;

namespace WhatEverIWant.Services;

public interface IMovieService : IGenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>;

public interface ISeriesService : IGenericService<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>;

public interface IMusicService : IGenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>;

public interface IBookService : IGenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>;

public interface IAudioBookService : IGenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>;