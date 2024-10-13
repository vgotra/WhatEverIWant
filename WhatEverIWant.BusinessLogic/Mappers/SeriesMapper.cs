using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Series;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers;

[Mapper]
public partial class SeriesMapper : IGenericMapper<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>
{
    public partial Series ToEntity(CreateSeriesRequest createModel);

    public partial void UpdateEntity(UpdateSeriesRequest updateModel, Series entity);

    public partial SeriesResponse ToResponse(Series entity);
}