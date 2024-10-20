namespace Mds.TddExample.Api.Common
{
    public interface IDtoMapper<TModel, TDto>
    {
        TDto MapFrom(TModel model);
        TModel MapTo(TDto dto);
    }
}
