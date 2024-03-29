using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;
using Xis.Generic.DataAccess.Service;

namespace SistemaSocios.WebApi.MySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Default")] // Definindo a tag padrão
    public abstract class BaseController<TEntity, TService> : ControllerBase
         where TEntity : DocModel
         where TService : IGenericService<TEntity>
    {
        protected readonly TService _service;
        protected readonly ILogger<TEntity> _loger;
        private IGenericService<UsuarioModel> usuarioService;

        public BaseController(TService service, ILogger<TEntity> loger)
        {
            _service = service;
            ApplySwaggerTags(); // Aplicar as anotações Swagger ao instanciar o controlador
            _loger = loger;
        }

        protected BaseController(IGenericService<UsuarioModel> usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(string id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            try
            {
                await _service.CreateAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, entity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(string id, TEntity entity)
        {
            try
            {
                await _service.UpdateAsync(entity);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(string id)
        {

            try
            {
                await _service.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
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
