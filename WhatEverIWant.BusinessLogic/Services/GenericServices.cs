using WhatEverIWant.BusinessLogic.Mappers.Services;
using WhatEverIWant.BusinessLogic.Models.Services.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Services.Books;
using WhatEverIWant.BusinessLogic.Models.Services.Movies;
using WhatEverIWant.BusinessLogic.Models.Services.Music;
using WhatEverIWant.BusinessLogic.Models.Services.TvShows;
using WhatEverIWant.DataAccess;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Services;

public class MovieService(ApplicationDbContext dbContext, IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie> mapper)
    : GenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>(dbContext, mapper), IMovieService;

public class TvShowsService(ApplicationDbContext dbContext, IGenericMapper<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow> mapper)
    : GenericService<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow>(dbContext, mapper), ITvShowsService;
    
public class MusicService(ApplicationDbContext dbContext, IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music> mapper)
    : GenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>(dbContext, mapper), IMusicService;
    
public class BookService(ApplicationDbContext dbContext, IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book> mapper)
    : GenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>(dbContext, mapper), IBookService;
    
public class AudioBookService(ApplicationDbContext dbContext, IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook> mapper)
    : GenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>(dbContext, mapper), IAudioBookService;