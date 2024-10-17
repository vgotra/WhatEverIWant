using WhatEverIWant.BusinessLogic.Mappers;
using WhatEverIWant.BusinessLogic.Mappers.Api;
using WhatEverIWant.BusinessLogic.Models.Api.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Api.Books;
using WhatEverIWant.BusinessLogic.Models.Api.Movies;
using WhatEverIWant.BusinessLogic.Models.Api.Music;
using WhatEverIWant.BusinessLogic.Models.Api.Series;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.ApiServices;

public class MovieService(IGenericRepository<Movie> repository, IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie> mapper)
    : GenericService<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>(repository, mapper), IMovieService;

public class SeriesService(IGenericRepository<Series> repository, IGenericMapper<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series> mapper)
    : GenericService<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>(repository, mapper), ISeriesService;
    
public class MusicService(IGenericRepository<Music> repository, IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music> mapper)
    : GenericService<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>(repository, mapper), IMusicService;
    
public class BookService(IGenericRepository<Book> repository, IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book> mapper)
    : GenericService<CreateBookRequest, UpdateBookRequest, BookResponse, Book>(repository, mapper), IBookService;
    
public class AudioBookService(IGenericRepository<AudioBook> repository, IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook> mapper)
    : GenericService<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>(repository, mapper), IAudioBookService;