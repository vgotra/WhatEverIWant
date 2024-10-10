using Riok.Mapperly.Abstractions;
using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.Services.Models.Series;

namespace WhatEverIWant.Services.Mappers;

[Mapper]
public partial class SeriesMapper : IGenericMapper<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>
{
    public partial Series ToEntity(CreateSeriesRequest createModel);

    public partial void UpdateEntity(UpdateSeriesRequest updateModel, Series entity);

    public partial SeriesResponse ToResponse(Series entity);
}