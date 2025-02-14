using WhatEverIWant.BusinessLogic.Models.Services.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Services.Books;
using WhatEverIWant.BusinessLogic.Models.Services.Movies;
using WhatEverIWant.BusinessLogic.Models.Services.Music;
using WhatEverIWant.BusinessLogic.Models.Services.TvShows;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Services;

public interface IMovieService : IGenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>;

public interface ITvShowsService : IGenericService<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow>;

public interface IMusicService : IGenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>;

public interface IBookService : IGenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>;

public interface IAudioBookService : IGenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>;