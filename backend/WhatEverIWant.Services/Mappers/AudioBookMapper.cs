using Riok.Mapperly.Abstractions;
using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.Services.Models.AudioBooks;

namespace WhatEverIWant.Services.Mappers;

[Mapper]
public partial class AudioBookMapper : IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>
{
    public partial AudioBook ToEntity(CreateAudioBookRequest createModel);

    public partial void UpdateEntity(UpdateAudioBookRequest updateModel, AudioBook entity);

    public partial AudioBookResponse ToResponse(AudioBook entity);
}