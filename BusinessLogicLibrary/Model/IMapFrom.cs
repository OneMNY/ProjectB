using AutoMapper;

namespace BusinessLogicLibrary.Model
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
