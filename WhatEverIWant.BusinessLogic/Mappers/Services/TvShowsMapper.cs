using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Services.TvShows;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class TvShowsMapper : IGenericMapper<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow>
{
    [MapperIgnoreTarget(nameof(TvShow.Id))]
    [MapperIgnoreTarget(nameof(TvShow.Collections))]
    public partial TvShow ToEntity(CreateTvShowRequest createModel);

    [MapperIgnoreTarget(nameof(TvShow.Id))]
    [MapperIgnoreTarget(nameof(TvShow.Collections))]
    public partial void UpdateEntity(UpdateTvShowRequest updateModel, TvShow entity);

    [MapperIgnoreSource(nameof(TvShow.Collections))]
    public partial TvShowResponse ToResponse(TvShow entity);
}