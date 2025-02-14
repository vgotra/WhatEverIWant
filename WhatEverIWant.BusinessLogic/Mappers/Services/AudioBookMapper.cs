using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Services.AudioBooks;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class AudioBookMapper : IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>
{
    [MapperIgnoreTarget(nameof(AudioBook.Id))]
    [MapperIgnoreTarget(nameof(AudioBook.Collections))]
    public partial AudioBook ToEntity(CreateAudioBookRequest createModel);

    [MapperIgnoreTarget(nameof(AudioBook.Id))]
    [MapperIgnoreTarget(nameof(AudioBook.Collections))]
    public partial void UpdateEntity(UpdateAudioBookRequest updateModel, AudioBook entity);

    [MapperIgnoreSource(nameof(AudioBook.Collections))]
    public partial AudioBookResponse ToResponse(AudioBook entity);
}