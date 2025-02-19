using AutoMapper;

namespace Clothes.Application.Common.Mappings;

public interface IMapFrom<T>
{
    public void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}