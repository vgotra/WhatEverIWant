using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Api.TvShows;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class TvShowsMapper : IGenericMapper<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow>
{
    public partial TvShow ToEntity(CreateTvShowRequest createModel);

    public partial void UpdateEntity(UpdateTvShowRequest updateModel, TvShow entity);

    public partial TvShowResponse ToResponse(TvShow entity);
}