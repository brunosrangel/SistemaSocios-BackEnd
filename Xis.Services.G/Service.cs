using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Xis.Services.G
{
    public class Service<TEntity, TEntityDTO> : IService<TEntityDTO> where TEntity : class where TEntityDTO : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        public Service(DbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TEntityDTO>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TEntityDTO>>(entities);
        }

        public async Task<IEnumerable<TEntityDTO>> FindAsync(Expression<Func<TEntityDTO, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entities = await _dbSet.Where(expression).ToListAsync();
            return _mapper.Map<IEnumerable<TEntityDTO>>(entities);
        }

        public async Task<TEntityDTO> GetByIdAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            return _mapper.Map<TEntityDTO>(entity);
        }

        public async Task CreateAsync(TEntityDTO entityDTO)
        {
            var entity = _mapper.Map<TEntity>(entityDTO);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntityDTO entityDTO)
        {
            var entity = _mapper.Map<TEntity>(entityDTO);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
