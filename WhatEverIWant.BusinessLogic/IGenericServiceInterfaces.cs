using WhatEverIWant.BusinessLogic.Models.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Books;
using WhatEverIWant.BusinessLogic.Models.Movies;
using WhatEverIWant.BusinessLogic.Models.Music;
using WhatEverIWant.BusinessLogic.Models.Series;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic;

public interface IMovieService : IGenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>;

public interface ISeriesService : IGenericService<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>;

public interface IMusicService : IGenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>;

public interface IBookService : IGenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>;

public interface IAudioBookService : IGenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>;