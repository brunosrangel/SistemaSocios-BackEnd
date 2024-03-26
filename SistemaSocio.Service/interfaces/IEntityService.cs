using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocio.Service.interfaces
{
  
    public interface IEntityService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllEntities();
        Task<TEntity> GetEntityById(string id);
        Task AddEntity(TEntity entity);
        Task<bool> UpdateEntity(string id, TEntity entity);
        Task<bool> DeleteEntity(string id);
    }

}
