using AutoMapper;
using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Domain.Context;
using DndCharacterSheetAPI.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DndCharacterSheetAPI.Services
{
    public class DictionaryService: IDictionaryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DictionaryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TDto>> GetAll<TEntity, TDto>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entities = await query.ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        public async Task<TDto> GetById<TEntity, TDto>(Guid id, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
            if (entity == null)
                throw new NotFoundException("Entity not found");

            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Create<TEntity, TCreateDto, TDto>(TCreateDto createDto) where TEntity : class
        {
            var entity = _mapper.Map<TEntity>(createDto);
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task Update<TEntity, TUpdateDto>(Guid id, TUpdateDto updateDto) where TEntity : class
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                throw new NotFoundException("Entity not found");

            _mapper.Map(updateDto, entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete<TEntity>(Guid id) where TEntity : class
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                throw new NotFoundException("Entity not found");

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
