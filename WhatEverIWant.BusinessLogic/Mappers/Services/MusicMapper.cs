using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Api.Music;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class MusicMapper : IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>
{
    public partial Music ToEntity(CreateMusicRequest createModel);

    public partial void UpdateEntity(UpdateMusicRequest updateModel, Music entity);

    public partial MusicResponse ToResponse(Music entity);
}