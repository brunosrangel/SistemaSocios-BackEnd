using Microsoft.AspNetCore.Mvc;
using SistemaSocio.Service.interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;

namespace SistemaSocios.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Default")] // Definindo a tag padrão
    public abstract class BaseController<TEntity, TService> : ControllerBase
        where TEntity : IDocument
        where TService : IEntityService<TEntity>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
            ApplySwaggerTags(); // Aplicar as anotações Swagger ao instanciar o controlador

        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(string id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(string id, TEntity entity)
        {
            var updated = await _service.UpdateAsync(id, entity);
            //if (!updated.Id.ToString())
            //{
            //    return NotFound();
            //}
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            //if (!deleted)
            //{
            //    return NotFound();
            //}
            return NoContent();
        }

        protected void ApplySwaggerTags()
        {
            var entityType = typeof(TEntity);
            var swaggerTagAttribute = entityType.GetCustomAttribute<SwaggerTagAttribute>();
            if (swaggerTagAttribute != null)
            {
                var controllerType = GetType();
                var controllerSwaggerTagAttribute = controllerType.GetCustomAttribute<SwaggerTagAttribute>();
                if (controllerSwaggerTagAttribute == null)
                {
                    // Define a tag do Swagger para o controlador baseado na classe TEntity
                    var controllerSwaggerTag = new SwaggerTagAttribute(swaggerTagAttribute.Description);
                    controllerType.GetCustomAttributes().ToList().Add(controllerSwaggerTag);
                }

                var methods = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m => m.DeclaringType == controllerType && !m.IsSpecialName); // Exclude properties, constructors, etc.

                foreach (var method in methods)
                {
                    var methodSwaggerOperationAttribute = method.GetCustomAttribute<SwaggerOperationAttribute>();
                    if (methodSwaggerOperationAttribute == null)
                    {
                        // Define a descrição da operação do Swagger com base no nome do método
                        var methodSummary = $"{method.Name} {entityType.Name}";
                        var methodSwaggerOperation = new SwaggerOperationAttribute { Summary = methodSummary };
                        method.GetCustomAttributes().ToList().Add(methodSwaggerOperation);
                    }
                }
            }
        }


        // Método auxiliar para obter o ID da entidade
        protected abstract string GetEntityId(TEntity entity);
    }
}
