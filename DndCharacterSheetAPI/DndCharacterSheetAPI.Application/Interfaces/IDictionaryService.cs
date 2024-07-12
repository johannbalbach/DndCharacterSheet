using System.Linq.Expressions;

namespace DndCharacterSheetAPI.Application.Interfaces
{
    public interface IDictionaryService
    {
        Task<List<TDto>> GetAll<TEntity, TDto>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        Task<TDto> GetById<TEntity, TDto>(Guid id, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        Task<TDto> Create<TEntity, TCreateDto, TDto>(TCreateDto createDto) where TEntity : class;
        Task Update<TEntity, TUpdateDto>(Guid id, TUpdateDto updateDto) where TEntity : class;
        Task Delete<TEntity>(Guid id) where TEntity : class;
    }
}
