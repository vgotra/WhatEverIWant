using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Services.Music;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class MusicMapper : IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>
{
    [MapperIgnoreTarget(nameof(Music.Id))]
    [MapperIgnoreTarget(nameof(Music.Collections))]
    public partial Music ToEntity(CreateMusicRequest createModel);

    [MapperIgnoreTarget(nameof(Music.Id))]
    [MapperIgnoreTarget(nameof(Music.Collections))]
    public partial void UpdateEntity(UpdateMusicRequest updateModel, Music entity);

    [MapperIgnoreSource(nameof(Music.Collections))]
    public partial MusicResponse ToResponse(Music entity);
}