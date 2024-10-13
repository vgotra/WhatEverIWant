using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.AudioBooks;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers;

[Mapper]
public partial class AudioBookMapper : IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>
{
    public partial AudioBook ToEntity(CreateAudioBookRequest createModel);

    public partial void UpdateEntity(UpdateAudioBookRequest updateModel, AudioBook entity);

    public partial AudioBookResponse ToResponse(AudioBook entity);
}