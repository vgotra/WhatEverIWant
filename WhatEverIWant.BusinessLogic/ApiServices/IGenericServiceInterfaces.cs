using WhatEverIWant.BusinessLogic.Models.Api.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Api.Books;
using WhatEverIWant.BusinessLogic.Models.Api.Movies;
using WhatEverIWant.BusinessLogic.Models.Api.Music;
using WhatEverIWant.BusinessLogic.Models.Api.Series;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.ApiServices;

public interface IMovieService : IGenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>;

public interface ISeriesService : IGenericService<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>;

public interface IMusicService : IGenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>;

public interface IBookService : IGenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>;

public interface IAudioBookService : IGenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>;