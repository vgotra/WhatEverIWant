using Riok.Mapperly.Abstractions;
using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.Services.Models.Music;

namespace WhatEverIWant.Services.Mappers;

[Mapper]
public partial class MusicMapper : IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>
{
    public partial Music ToEntity(CreateMusicRequest createModel);

    public partial void UpdateEntity(UpdateMusicRequest updateModel, Music entity);

    public partial MusicResponse ToResponse(Music entity);
}