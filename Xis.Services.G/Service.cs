using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Xis.Repository.G.Interfaces;

namespace Xis.Services.G
{
    public class Service<TEntity, TEntityDTO> : IService<TEntityDTO> where TEntity : class where TEntityDTO : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TEntityDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TEntityDTO>>(entities);
        }

        public async Task<IEnumerable<TEntityDTO>> FindAsync(Expression<Func<TEntityDTO, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entities = await _repository.FindAsync(expression);
            return _mapper.Map<IEnumerable<TEntityDTO>>(entities);
        }

        public async Task<TEntityDTO> GetByIdAsync(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TEntityDTO>(entity);
        }

        public async Task CreateAsync(TEntityDTO entity)
        {
            var mappedEntity = _mapper.Map<TEntity>(entity);
            await _repository.AddAsync(mappedEntity);
        }

        public async Task UpdateAsync(TEntityDTO entity)
        {
            var mappedEntity = _mapper.Map<TEntity>(entity);
            await _repository.UpdateAsync(mappedEntity);
        }

        public async Task DeleteAsync(object id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}
