using WhatEverIWant.BusinessLogic.Mappers.Services;
using WhatEverIWant.BusinessLogic.Models.Services.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Services.Books;
using WhatEverIWant.BusinessLogic.Models.Services.Movies;
using WhatEverIWant.BusinessLogic.Models.Services.Music;
using WhatEverIWant.BusinessLogic.Models.Services.TvShows;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Services;

public class MovieService(ApplicationDbContext dbContext, IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie> mapper, ISnowflakeIdGenerator idGenerator)
    : GenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>(dbContext, mapper, idGenerator), IMovieService;

public class TvShowsService(ApplicationDbContext dbContext, IGenericMapper<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow> mapper, ISnowflakeIdGenerator idGenerator)
    : GenericService<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow>(dbContext, mapper, idGenerator), ITvShowsService;

public class MusicService(ApplicationDbContext dbContext, IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music> mapper, ISnowflakeIdGenerator idGenerator)
    : GenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>(dbContext, mapper, idGenerator), IMusicService;

public class BookService(ApplicationDbContext dbContext, IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book> mapper, ISnowflakeIdGenerator idGenerator)
    : GenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>(dbContext, mapper, idGenerator), IBookService;

public class AudioBookService(ApplicationDbContext dbContext, IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook> mapper, ISnowflakeIdGenerator idGenerator)
    : GenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>(dbContext, mapper, idGenerator), IAudioBookService;